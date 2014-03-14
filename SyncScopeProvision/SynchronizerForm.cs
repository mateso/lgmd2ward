using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Diagnostics;
using System.Timers;

namespace SyncScopeProvision
{
    #region Filtering Utilities

    /// <summary>
    /// Different Geographic Area Level
    /// </summary>
    public enum AreaLevel
    {
        /// <summary>
        /// District Level
        /// </summary>
        DISTRICT = 1,

        /// <summary>
        /// Regional Level
        /// </summary>
        REGION = 2,

        /// <summary>
        /// National Level
        /// </summary>
        NATION = 3
    }

    /// <summary>
    /// Synchronization Filtering scope
    /// </summary>
    public struct ScopeFilter
    {
        /// <summary>
        /// AreaID
        /// </summary>
        public string FilterClause;

        /// <summary>
        /// Geograhic area level
        /// </summary>
        public AreaLevel Level;

        /// <summary>
        /// Synchronization scope. The name is based on the name Geographic area level, e.g. Ilala, Kigoma, Songea.
        /// </summary>
        public string Name;
    }
    #endregion

    /// <summary>
    /// Form that handles Synchronization. 
    /// Synchronization is performed when you display the form and 
    /// close when the operation is complete or an error is detected.
    /// </summary>
    /// <remarks>
    /// Synchronization follows these steps:
    /// 1. Determine scope name based on the client configuration.
    /// 2. Create a scope in the server database.
    /// 3. Client requests server for the just created scope description.
    /// 4. Client apply the scope locally.
    /// 4. Synchronization process is performed.
    /// Creation of scopes which already exist in the databases may be skipped.
    /// </remarks>
    public partial class SynchronizerForm : Form
    {
        #region Local Variables
        private string localConnection = null;
        private string remoteConnection = null;
        private ScopeFilter scopeFilter = new ScopeFilter();

        //private string[] tableNames = { "tbl_data_forms_submitted","RecordInfo","MonthlyRecord","QuarterlyRecord","AnnualRecord" };

        private string[] tableNames = {
                                    "RecordInfo","MonthlyRecord","QuarterlyRecord","AnnualRecord",                                 
                              
                                    "ChemicalControl01","CommentsOfVillageOfficer01","DippingSprayingVaccination01","LivestockService01",
                                    "LivestockSlaughtered01","MeatInspection01","Medication01","PeopleWhoVisitTheVillage01",
                                    "ProdMilk01","ProdSkin01","TargetImplementationAndCropPrices01","WeatherCondition01",

                                    "CoopGroup02",//NumberOfTotalMembers has problems
                                    "CoopSaccos02","FarmersFieldSchool02","FoodCondition02","Irrigation02",
                                    "PlantHealth02","ProdLand02","SoilErosion02",
                                    
                                    "AiredPrograms03","AnimalDrawn03","BasicInformation03","ContractFarming03","CropResidue03","FarmersFieldSchool03","Fertilizer03",
                                    "GrazingLand03","HandOperatedImplements03","ImprovedPasture03",
                                    "ImprovedSeeds03",//CropNameOthers has problem
                                    "IrrigationScheme03","Livestock03","LivestockInfrastructure03","MachineryDrawn03",
                                    "Machines03",//
                                    "ProcessingMachines03","Telecommunication03","TVAndRadioStation03","Pestcide03",

                                    "AnimalsFeeds04","LivestockMarketing04","LivestockMovement04","ProductsMovement04",
                                    "ReproductionInputs04","Carcass04",

                                    "DistrictInfo05","EducationLevel05","ExtensionOfficers05","ExtensionOfficersTrained05",
                                    "ExtensionServiceProviders05",//AnnuallyRecordID
                                    "FoodSituation05",//FoodsCropsID
                                    "LivestockInfrastructure05","Oxenizing05","PlanningCommitee05","ProductsProcessing05",
                                    "WorkingEquipments05",//NumberOfOtherAvailable,NumberOfOtherRequired
                                    "WorkingFacilities05","LivestockPopulation05",

                                    "TargetImplementationAndCropPrices06"

                                    //"CropGroupList","LivestockSlaughList","MachineryList","DrawnList","ImplementsList",
                                    //"ProcessingMachinesList","FertilizerList","PestcideList","InfraList","MediaList","TelecomCompaList"
                                     };


        //select '"' +name + '",' from sys.all_objects  where type ='u'  and name like '%0%' order by right(name,2),Name


        private SyncOrchestrator syncOrchestrator;
        private SyncOperationStatistics syncStats;

        private Stopwatch stopwatch;
        private System.Timers.Timer timer;
        private bool rebuild = false; //Change value to true during provisioning
        private bool rebuildClient = false; //Change value to true during provisioning
        private bool rebuildServer = false; //Change value to true during provisioning
        #endregion

        /// <summary>
        /// Create a form used for synchronization of two servers
        /// </summary>
        /// <param name="localConnection">Local database connection</param>
        /// <param name="remoteConnection">Remote database connection</param>
        /// <param name="repair">Checks whether to repair the whole database or just usual synchronization</param>
        public SynchronizerForm(string localConnection, string remoteConnection, bool repair)
        {
            InitializeComponent();
            this.Visible = false;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.WorkerReportsProgress = true;
            this.stopwatch = new Stopwatch();
            this.timer = new System.Timers.Timer(1000);
            this.timer.AutoReset = true;
            this.timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            this.localConnection = localConnection;
            this.remoteConnection = remoteConnection;
            //this.rebuildClient = true; //Uncomment during provisioning
            this.rebuildClient = repair; //Comment during provisioning

            this.rebuild = (this.rebuildClient || this.rebuildServer);

            int level = Int32.Parse(GetSetting(localConnection, "Area_Level"));
            if (level == 2) this.scopeFilter.Level = AreaLevel.NATION;
            if (level == 4) this.scopeFilter.Level = AreaLevel.REGION;
            if (level == 5) this.scopeFilter.Level = AreaLevel.DISTRICT;

            string areaID = GetSetting(localConnection, "Area_ID");
            this.scopeFilter.FilterClause = areaID;
            this.scopeFilter.Name = GetScopeName(localConnection, areaID);
        }

        /// <summary>
        /// Checks to determine if the database through connection connection can accommodate SqlSyncProvider
        /// scope information together this the Microsoft Sync Framework SDK 2.1 runtime version
        /// </summary>
        /// <param name="connection">Connection to database</param>
        /// <returns>True if compatible otherwise false</returns>
        private bool IsCompatibleServer(SqlConnection connection)
        {
            bool okToContinue = false;
            if (connection.State != ConnectionState.Open) connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT SERVERPROPERTY('productversion') AS [ProductVersion], " +
                "SERVERPROPERTY ('productlevel') AS [ProductLevel], SERVERPROPERTY ('edition') AS [Edition]";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string productVersion = reader.GetString(0);
            string productLevel = reader.GetString(1);

            int version = Int32.Parse(productVersion.Split('.')[0]);
            if (version > 9) okToContinue = true;
            if (version == 9)
            {
                int servicePack = -1;
                try
                {
                    servicePack = Int32.Parse(productLevel.Substring(2, productLevel.Length - 2));
                    if (servicePack >= 2) okToContinue = true;
                }
                catch { }
            }
            reader.Close();
            return okToContinue;
        }

        /// <summary>
        /// Create synchronization scope description scopeName based on the synchronization table found in the
        /// database through connection connection.
        /// The function assumes that the tables involved in the scope are already present in the
        /// database throght provided connection.
        /// The list of tables involved in the scope is stored in the class internal variable
        /// </summary>
        /// <param name="scopeName">Name of the scope</param>
        /// <param name="connection">Database connection</param>
        /// <returns>DbSyncScopeDescription instance contain scope description</returns>
        private DbSyncScopeDescription CreateSyncScopeDescription(string scopeName, SqlConnection connection)
        {
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scopeName);
            DbSyncTableDescription tableDesc = null;
            foreach (string table in tableNames)
            {
                tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(table, connection);
                scopeDesc.Tables.Add(tableDesc);
            }


            return scopeDesc;
        }

        /// <summary>
        /// Create Synchronization Scope scope together with all the information required for the
        /// synchronization process in the database through connection connection.
        /// Filtering parameters, tracking tables, triggers and stored procedures for synchronization
        /// are created in this function.
        /// When the function returns, the database is ready for synchronization based on the scope scopeName.
        /// </summary>
        /// <param name="scope">Synchronization scope name</param>
        /// <param name="connection">Database connection</param>
        private void CreateSyncScope(DbSyncScopeDescription scope, SqlConnection connection)
        {
            SqlSyncScopeProvisioning provision = new SqlSyncScopeProvisioning(connection, scope);
            provision.SetCreateTableDefault(DbSyncCreationOption.CreateOrUseExisting);
            provision.SetCreateProceduresForAdditionalScopeDefault(DbSyncCreationOption.Create);


            //start add a filter column just for the first time

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;

            //frmReadTheText  fReadText;
            //fReadText = new frmReadTheText(provision.Tables["HandOperatedImplements03"].Script());
            //fReadText.ShowDialog();


            foreach (string table in this.tableNames)
            {
                try
                {
                    cmd.CommandText = String.Format("ALter TABLE {0} add FormSerialID Nvarchar(50) null", table);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }


            cmd.Dispose();


            // end
            if (this.scopeFilter.Level != AreaLevel.NATION)
            {
                foreach (string table in tableNames)
                {
                    provision.Tables[table].AddFilterColumn("FormSerialID");
                    string clause = String.Format("[side].[FormSerialID] LIKE '00[0-9]{0}%'", scopeFilter.FilterClause);
                    provision.Tables[table].FilterClause = clause;
                }
            }
            try
            {
                provision.Apply();
            }
            catch
            {

                //string message = String.Format(provision.Tables["HandOperatedImplements03"].Script(), "local database engine");          
                //SyncScopeProvision.frmReadTheText fReadText = new frmReadTheText(message);
                //fReadText.ShowDialog();

            }

        }

        /// <summary>
        /// Removes synchronization information of scope scopeName from the database connected through
        /// connection connection. The function does the reverse effect of CreateSyncScope function.
        /// </summary>
        /// <param name="scopeName">Synchronization scope name</param>
        /// <param name="connection">Database connection</param>
        /// <param name="rebuild">Indicate whether user data should also be removed from the table involved in
        /// the synchronization scope.
        /// </param>
        private void RemoveSyncScope(string scopeName, SqlConnection connection, bool rebuild)
        {
            SqlSyncScopeProvisioning provision = new SqlSyncScopeProvisioning(connection);
            if (provision.ScopeExists(scopeName))
            {
                SqlSyncScopeDeprovisioning deprovision = new SqlSyncScopeDeprovisioning(connection);
                deprovision.DeprovisionScope(scopeName);
            }
            if (rebuild) ClearRecordsAndScopeConfig(connection, rebuild);
        }

        /// <summary>
        /// Create synchronization scope scopeName information in the database connected through connection connection
        /// if the scope does not exists in the database.
        /// Function uses connection to another database sourceConnection to retrieve scope description in case the scope
        /// is not created in the database connected through connection.
        /// </summary>
        /// <param name="scopeName">Synchronization scope</param>
        /// <param name="connection">Connection to database which may not have the synchronization scope</param>
        /// <param name="sourceConnection">Connection to database which is considered the 
        /// backup source of synchronization scope</param>
        private void CreateSyncScopeIfNotExists(string scopeName, SqlConnection connection, SqlConnection sourceConnection)
        {
            SqlSyncScopeProvisioning provision = new SqlSyncScopeProvisioning(connection);
            if (provision.ScopeExists(scopeName)) return;
            else
            {
                if (sourceConnection == null) throw new Exception("Source of synchronization scope is required.");
                else
                {
                    DbSyncScopeDescription scopeDesc = null;
                    SqlSyncScopeProvisioning scopeSourceProvision = new SqlSyncScopeProvisioning(sourceConnection);
                    if (scopeSourceProvision.ScopeExists(scopeName))
                    {
                        scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(scopeName, sourceConnection);
                        RemoveSyncScope(scopeName, connection, false);
                        ClearRecordsAndScopeConfig(connection, false);
                        CreateSyncScope(scopeDesc, connection);
                    }
                    else
                    {
                        scopeDesc = CreateSyncScopeDescription(scopeName, sourceConnection);
                        CreateSyncScope(scopeDesc, sourceConnection);

                        scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(scopeName, sourceConnection);
                        RemoveSyncScope(scopeName, connection, false);
                        ClearRecordsAndScopeConfig(connection, false);
                        CreateSyncScope(scopeDesc, connection);
                    }
                }
            }
        }

        /// <summary>
        /// Checks and prepares the two databases for synchronization.
        /// </summary>
        private void PrepareSync()
        {
            SqlConnection clientConnection = new SqlConnection(localConnection);
            SqlConnection serverConnection = new SqlConnection(remoteConnection);

            string msgFormat = "Synchronization could not complete because database servers versions are not compatible." +
                "\n\nYour {0} is not Microsoft SQL Server 2005 Service Pack 2 or later.";
            if (!IsCompatibleServer(clientConnection))
            {
                string message = String.Format(msgFormat, "local database engine");
                throw new Exception(message);
            }

            if (!IsCompatibleServer(serverConnection))
            {
                string message = String.Format(msgFormat, "remote server engine at " + serverConnection.DataSource);
                throw new Exception(message);
            }

            if (this.rebuildClient) RemoveSyncScope(this.scopeFilter.Name, clientConnection, true);
            if (this.rebuildServer) RemoveSyncScope(this.scopeFilter.Name, serverConnection, false);

            CreateSyncScopeIfNotExists(this.scopeFilter.Name, clientConnection, serverConnection);
            CreateSyncScopeIfNotExists(this.scopeFilter.Name, serverConnection, null);
        }

        /// <summary>
        /// Perform synchronization
        /// </summary>
        private void Synchronize()
        {
            try
            {
                backgroundWorker.ReportProgress(-2);
                PrepareSync();
                backgroundWorker.ReportProgress(-3);
            }
            catch (Exception ex)
            {
                this.timer.Enabled = false;
                this.stopwatch.Reset();
                MessageBox.Show(ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection clientConn = new SqlConnection(localConnection);
            SqlConnection serverConn = new SqlConnection(remoteConnection);

            SqlSyncProvider localProvider = new SqlSyncProvider(scopeFilter.Name, clientConn);
            localProvider.SyncProviderPosition = SyncProviderPosition.Local;
            localProvider.DestinationCallbacks.ItemConflicting += new EventHandler<ItemConflictingEventArgs>(ItemConflicted);
            localProvider.DestinationCallbacks.ProgressChanged += new EventHandler<SyncStagedProgressEventArgs>(ProgressChanged);

            SqlSyncProvider remoteProvider = new SqlSyncProvider(scopeFilter.Name, serverConn);
            remoteProvider.SyncProviderPosition = SyncProviderPosition.Remote;
            remoteProvider.DestinationCallbacks.ItemConflicting += new EventHandler<ItemConflictingEventArgs>(ItemConflicted);
            remoteProvider.DestinationCallbacks.ProgressChanged += new EventHandler<SyncStagedProgressEventArgs>(ProgressChanged);

            syncOrchestrator = new SyncOrchestrator();
            syncOrchestrator.LocalProvider = localProvider;
            syncOrchestrator.RemoteProvider = remoteProvider;

            if (scopeFilter.Level == AreaLevel.NATION) syncOrchestrator.Direction = SyncDirectionOrder.Download;
            if (scopeFilter.Level == AreaLevel.REGION) syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
            if (scopeFilter.Level == AreaLevel.DISTRICT) syncOrchestrator.Direction = SyncDirectionOrder.DownloadAndUpload;
            syncStats = syncOrchestrator.Synchronize();
        }

        #region Event Handlers
        private void ItemConflicted(object sender, ItemConflictingEventArgs e)
        {
            e.SetResolutionAction(ConflictResolutionAction.SourceWins);
        }

        private void ProgressChanged(object sender, SyncStagedProgressEventArgs e)
        {
            backgroundWorker.ReportProgress(-1, e);
        }

        private void SynchronizerForm_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer.Enabled = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Synchronize();
            }
            catch (Exception ex)
            {
                backgroundWorker.ReportProgress(-1, ex);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;
            stopwatch.Reset();

            #region Simple Notification Message
            if (syncStats != null)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.Append("Start Time: " + syncStats.SyncStartTime);
                sBuilder.Append(Environment.NewLine + Environment.NewLine);
                sBuilder.Append("Total Upload Changes Applied: " + syncStats.UploadChangesApplied);
                sBuilder.Append(Environment.NewLine);
                sBuilder.Append("Total Upload Changes Failed: " + syncStats.UploadChangesFailed);
                sBuilder.Append(Environment.NewLine);
                sBuilder.Append("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
                sBuilder.Append(Environment.NewLine + Environment.NewLine);
                sBuilder.Append("Total Download Changes Applied: " + syncStats.DownloadChangesApplied);
                sBuilder.Append(Environment.NewLine);
                sBuilder.Append("Total Download Changes Failed: " + syncStats.DownloadChangesFailed);
                sBuilder.Append(Environment.NewLine);
                sBuilder.Append("Total Changes Download: " + syncStats.DownloadChangesTotal);
                sBuilder.Append(Environment.NewLine + Environment.NewLine);
                sBuilder.Append("Complete Time: " + syncStats.SyncEndTime);

                TimeSpan timeTaken = syncStats.SyncEndTime.Subtract(syncStats.SyncStartTime);
                string timeSpan = String.Format("Time taken : {0} minutes {1} seconds",
                    timeTaken.Minutes, timeTaken.Seconds);
                sBuilder.Append(Environment.NewLine + Environment.NewLine);
                sBuilder.Append(timeSpan);
                MessageBox.Show(sBuilder.ToString(), "Synchronization Statistics",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                syncStats = null;
            }
            #endregion
            this.Close();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs ev)
        {
            #region Special GUI Updates
            if (ev.ProgressPercentage == -2)
            {
                btnCancel.Enabled = false;
                lblTimeElapsed.Text = String.Empty;
                return;
            }
            if (ev.ProgressPercentage == -3)
            {
                btnCancel.Enabled = true;
                lblStatus.Text = "Synchronizing database records...";
                return;
            }
            #endregion

            #region Synchronization Stages
            SyncStagedProgressEventArgs e = null;
            try
            {
                e = (SyncStagedProgressEventArgs)ev.UserState;
            }
            catch { }
            if (e != null)
            {
                switch (e.Stage)
                {
                    case SessionProgressStage.ChangeApplication:
                        if (e.ReportingProvider == SyncProviderPosition.Local) lblStatus.Text = "Local Provider: Applying Changes...";
                        else lblStatus.Text = "Remote Provider: Applying Changes...";
                        break;

                    case SessionProgressStage.ChangeDetection:
                        if (e.ReportingProvider == SyncProviderPosition.Local) lblStatus.Text = "Local Provider: Detecting Changes...";
                        else lblStatus.Text = "Remote Provider: Detecting Changes...";
                        break;

                    case SessionProgressStage.ChangeEnumeration:
                        if (e.ReportingProvider == SyncProviderPosition.Local) lblStatus.Text = "Local Provider: Enumerating Changes...";
                        else lblStatus.Text = "Remote Provider: Enumerating Changes...";
                        break;
                }
                progressBar.Maximum = (int)e.TotalWork;
                progressBar.Value = (int)e.CompletedWork;
                return;
            }
            #endregion

            #region Failed Changes
            DbApplyChangeFailedEventArgs failEvent = null;
            try
            {
                failEvent = (DbApplyChangeFailedEventArgs)ev.UserState;
            }
            catch { }
            if (failEvent != null)
            {
                return;
            }
            #endregion

            #region Exception
            Exception ex = null;
            try
            {
                ex = (Exception)ev.UserState;
            }
            catch { }
            if (ex != null)
            {
                if (ex.GetType() == typeof(SqlException))
                {
                    MessageBox.Show(ex.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ex.GetType() == typeof(SyncAbortedException))
                {
                    MessageBox.Show(ex.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    #region Simple Notification Message
                    if (syncStats != null)
                    {
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append("Start Time: " + syncStats.SyncStartTime);
                        sBuilder.Append("\n");
                        sBuilder.Append("\n");
                        sBuilder.Append("Total Upload Changes Applied: " + syncStats.UploadChangesApplied);
                        sBuilder.Append("\n");
                        sBuilder.Append("Total Upload Changes Failed: " + syncStats.UploadChangesFailed);
                        sBuilder.Append("\n");
                        sBuilder.Append("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
                        sBuilder.Append("\n");
                        sBuilder.Append("\n");
                        sBuilder.Append("Total Download Changes Applied: " + syncStats.DownloadChangesApplied);
                        sBuilder.Append("\n");
                        sBuilder.Append("Total Download Changes Failed: " + syncStats.DownloadChangesFailed);
                        sBuilder.Append("\n");
                        sBuilder.Append("Total Changes Download: " + syncStats.DownloadChangesTotal);
                        sBuilder.Append("\n");
                        sBuilder.Append("\n");
                        sBuilder.Append("Complete Time: " + syncStats.SyncEndTime);
                        MessageBox.Show(sBuilder.ToString(),
                            "Synchronization Statistics",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        syncStats = null;
                    }
                    #endregion
                    return;
                }

                if (ex.GetType() == typeof(DbSyncException))
                {
                    StringBuilder msg = new StringBuilder();
                    msg.Append("Message:" + Environment.NewLine);
                    msg.Append(ex.Message);
                    msg.Append(Environment.NewLine + Environment.NewLine);
                    if (ex.InnerException != null)
                    {
                        msg.Append("Inner Message:" + Environment.NewLine);
                        msg.Append(ex.InnerException.Message);
                        msg.Append(Environment.NewLine + Environment.NewLine);
                    }
                    MessageBox.Show(msg.ToString(), "Please Repeat the Synchronization Process",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // default message
                StringBuilder info = new StringBuilder();
                info.Append("Message:" + Environment.NewLine);
                info.Append(ex.Message);
                info.Append(Environment.NewLine + Environment.NewLine);
                if (ex.InnerException != null)
                {
                    info.Append("Inner Message:" + Environment.NewLine);
                    info.Append(ex.InnerException.Message);
                    info.Append(Environment.NewLine + Environment.NewLine);
                }
                MessageBox.Show(info.ToString(), "Unknown Error occured",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Are you sure you want to cancel the current " +
                "synchronization process?\n\nSynchronization will resume from where it was " +
                "canceled next time you \nstart it again.",
                "Cancel Synchronization Process", MessageBoxButtons.YesNo);
            if (reply == DialogResult.Yes)
            {
                try
                {
                    syncOrchestrator.Cancel();
                }
                catch { }
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    lblTimeElapsed.Text = String.Format("Time elapsed: {0} minutes {1} seconds", timeSpan.Minutes, timeSpan.Seconds);
                }));
            }
            catch { }
        }

        private void SynchronizerForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
        #endregion

        /// <summary>
        /// Delete tables in the database.
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="tables">Array of strings containing table name</param>
        private void DeleteTables(string connection, string[] tables)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (string table in tables)
            {
                try
                {
                    cmd.CommandText = String.Format("DROP TABLE {0}", table);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }

            foreach (string table in this.tableNames)
            {
                try
                {
                    cmd.CommandText = String.Format("DROP TABLE {0}_tracking", table);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// Delete stored procedures associated with synchronization.
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="tables">Array of strings containing table names</param>
        private void DeleteSyncStoredProcedures(string connection, string[] tables)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string[] procedures = {
                                      "delete", "bulkdelete", "deletemetadata", "insert", "bulkinsert", "insertmetadata", 
                                      "selectchanges", "selectrow", "update", "bulkupdate", "updatemetadata"
                                  };
            foreach (string table in tables)
            {
                foreach (string procedure in procedures)
                {
                    string procedureName = String.Format("{0}_{1}", table, procedure);
                    try
                    {
                        cmd.CommandText = String.Format("DROP PROCEDURE {0}", procedureName);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// Delete table trigger for table involved in the synchronization
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="tables">Array of string containing table names</param>
        private void DeleteSyncTriggers(string connection, string[] tables)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string[] triggers = { "delete_trigger", "insert_trigger", "update_trigger" };
            foreach (string table in tables)
            {
                foreach (string trigger in triggers)
                {
                    string triggerName = String.Format("{0}_{1}", table, trigger);
                    try
                    {
                        cmd.CommandText = String.Format("DROP TRIGGER {0}", triggerName);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// Remove scope information of the entire database. 
        /// This will delete any information associated with synchronization in the database.
        /// This function SHOULD NOT be used in the server that contains many scope as it will
        /// delete all scope information.
        /// Best suited for CLIENT synchronization information clean up because clients are expected
        /// to hold synchronization information of only one scope.
        /// The flag clearUserData determines if user data in the tables involved in the synchronization 
        /// should be deleted or not [Care should be taken when using with server].
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="clearUserData">Determine if use data should also be deleted.</param>
        private void ClearRecordsAndScopeConfig(SqlConnection connection, bool clearUserData)
        {
            if (clearUserData)
            {
                SqlCommand cmd = new SqlCommand();
                if (connection.State != ConnectionState.Open) connection.Open();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                try
                {
                    cmd.CommandText = "delete from tbl_data_figures";
                    cmd.ExecuteNonQuery();
                }
                catch { }
                try
                {
                    cmd.CommandText = "delete from tbl_data_answers";
                    cmd.ExecuteNonQuery();
                }
                catch { }
                try
                {
                    cmd.CommandText = "delete from tbl_data_forms_submitted";
                    cmd.ExecuteNonQuery();
                }
                catch { }

                try
                {
                    cmd.CommandText = "exec cleanDB";
                    cmd.ExecuteNonQuery();
                }
                catch { }


            }

            string[] tables = {
                                  "scope_info", "scope_config", "schema_info"
                              };
            DeleteTables(localConnection, tables);
            DeleteSyncTriggers(localConnection, this.tableNames);
            DeleteSyncStoredProcedures(localConnection, this.tableNames);
        }

        /// <summary>
        /// Returns the string containing the value of the setting settingName defined in the tbl_config table
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="settingName">Name of the setting</param>
        /// <returns>String containing the value of the setting</returns>
        private string GetSetting(string connection, string settingName)
        {
            string value = null;
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;
            settingName = settingName.Replace("'", "''");
            cmd.CommandText = String.Format("SELECT config_value FROM tbl_config WHERE config_name = '{0}'", settingName);
            try
            {
                value = cmd.ExecuteScalar().ToString();
            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return value;
        }

        /// <summary>
        /// Returns the scope name based on the Area ID areaID of the database connected through connection string connection.
        /// Connection provided should be that of the client database.
        /// The scope name is {Area_Name}_{Area_ID}.
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="areaID">Database configured Area ID</param>
        /// <returns>String containing scope name</returns>
        private string GetScopeName(string connection, string areaID)
        {
            string value = null;
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;
            areaID = areaID.Replace("'", "''");
            cmd.CommandText = String.Format("SELECT Area_Name + '_' + Area_ID FROM tbl_setup_areas WHERE Area_ID = '{0}'", areaID);
            try
            {
                value = cmd.ExecuteScalar().ToString();
            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return value;
        }


        /// <summary>
        /// Returns the names of the tables of the database connected through connection string connection.
        /// Connection provided should be that of the required database.
        /// The table names are the ones with the naming convention having a Zero in it
        /// </summary>
        /// <param name="connection">Database connection string</param>
        /// <param name="areaID">Table type as whether monthly, quartley or annual</param>
        /// <returns>String containing the table names</returns>
        private string GetInvolvedTables(string connection, string FormTypeID)
        {
            string value = null;

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;

            cmd.CommandText = String.Format("select * from sys.all_objects  where type ='u' and name like '{0}'", FormTypeID);
            try
            {
                //'value = cmd.
                //'   DataTableReader d
            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return value;
        }
    }
}
