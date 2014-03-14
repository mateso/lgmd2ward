<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlEditForm
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Udp_forms_submittedDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecordID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area_Level_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeriodFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeriodTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormSerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormTypeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganisationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerifiedByUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovedByUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Udp_forms_submittedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.btnVerifyData = New System.Windows.Forms.Button()
        Me.BtnApproveData = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.btnSaveComment = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnExportAlForms = New System.Windows.Forms.Button()
        Me.Udp_forms_submittedTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.udp_forms_submittedTableAdapter()
        Me.TableAdapterManager = New LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBoxFilterBox = New System.Windows.Forms.GroupBox()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnFilterForm = New System.Windows.Forms.Button()
        Me.cmbPeriodTo = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodFrom = New System.Windows.Forms.ComboBox()
        Me.cmbAreaLevel = New System.Windows.Forms.ComboBox()
        Me.cmbFormType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Udp_forms_submittedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Udp_forms_submittedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBoxFilterBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Udp_forms_submittedDataGridView
        '
        Me.Udp_forms_submittedDataGridView.AllowUserToAddRows = False
        Me.Udp_forms_submittedDataGridView.AllowUserToDeleteRows = False
        Me.Udp_forms_submittedDataGridView.AllowUserToResizeColumns = False
        Me.Udp_forms_submittedDataGridView.AllowUserToResizeRows = False
        Me.Udp_forms_submittedDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Udp_forms_submittedDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Udp_forms_submittedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Udp_forms_submittedDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.RecordID, Me.Area_Level_Name, Me.Area_Name, Me.PeriodFrom, Me.PeriodTo, Me.FormSerialNumber, Me.FormTypeNumber, Me.Area_ID, Me.OrganisationID, Me.ApprovedByUserID, Me.VerifiedByUserID})
        Me.Udp_forms_submittedDataGridView.DataSource = Me.Udp_forms_submittedBindingSource
        Me.Udp_forms_submittedDataGridView.Location = New System.Drawing.Point(15, 137)
        Me.Udp_forms_submittedDataGridView.MultiSelect = False
        Me.Udp_forms_submittedDataGridView.Name = "Udp_forms_submittedDataGridView"
        Me.Udp_forms_submittedDataGridView.ReadOnly = True
        Me.Udp_forms_submittedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Udp_forms_submittedDataGridView.Size = New System.Drawing.Size(687, 337)
        Me.Udp_forms_submittedDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "FormName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Form Type"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 200
        '
        'RecordID
        '
        Me.RecordID.DataPropertyName = "RecordID"
        Me.RecordID.HeaderText = "RecordID"
        Me.RecordID.Name = "RecordID"
        Me.RecordID.ReadOnly = True
        Me.RecordID.Visible = False
        '
        'Area_Level_Name
        '
        Me.Area_Level_Name.DataPropertyName = "Area_Level_Name"
        Me.Area_Level_Name.HeaderText = "Area Level"
        Me.Area_Level_Name.Name = "Area_Level_Name"
        Me.Area_Level_Name.ReadOnly = True
        '
        'Area_Name
        '
        Me.Area_Name.DataPropertyName = "Area_Name"
        Me.Area_Name.HeaderText = "Area"
        Me.Area_Name.Name = "Area_Name"
        Me.Area_Name.ReadOnly = True
        '
        'PeriodFrom
        '
        Me.PeriodFrom.DataPropertyName = "PeriodFrom"
        Me.PeriodFrom.HeaderText = "Period From"
        Me.PeriodFrom.Name = "PeriodFrom"
        Me.PeriodFrom.ReadOnly = True
        '
        'PeriodTo
        '
        Me.PeriodTo.DataPropertyName = "PeriodTo"
        Me.PeriodTo.HeaderText = "Period To"
        Me.PeriodTo.Name = "PeriodTo"
        Me.PeriodTo.ReadOnly = True
        '
        'FormSerialNumber
        '
        Me.FormSerialNumber.DataPropertyName = "FormSerialNumber"
        Me.FormSerialNumber.HeaderText = "FormSerialNumber"
        Me.FormSerialNumber.MinimumWidth = 2
        Me.FormSerialNumber.Name = "FormSerialNumber"
        Me.FormSerialNumber.ReadOnly = True
        Me.FormSerialNumber.Width = 2
        '
        'FormTypeNumber
        '
        Me.FormTypeNumber.DataPropertyName = "FormTypeNumber"
        Me.FormTypeNumber.HeaderText = "FormTypeNumber"
        Me.FormTypeNumber.MinimumWidth = 2
        Me.FormTypeNumber.Name = "FormTypeNumber"
        Me.FormTypeNumber.ReadOnly = True
        Me.FormTypeNumber.Width = 2
        '
        'Area_ID
        '
        Me.Area_ID.DataPropertyName = "AreaID"
        Me.Area_ID.HeaderText = "Area_ID"
        Me.Area_ID.MinimumWidth = 2
        Me.Area_ID.Name = "Area_ID"
        Me.Area_ID.ReadOnly = True
        Me.Area_ID.Width = 2
        '
        'OrganisationID
        '
        Me.OrganisationID.DataPropertyName = "OrganisationID"
        Me.OrganisationID.HeaderText = "OrganisationID"
        Me.OrganisationID.MinimumWidth = 2
        Me.OrganisationID.Name = "OrganisationID"
        Me.OrganisationID.ReadOnly = True
        Me.OrganisationID.Width = 2
        '
        'VerifiedByUserID
        '
        Me.VerifiedByUserID.DataPropertyName = "VerifiedByUserID"
        Me.VerifiedByUserID.HeaderText = "VerifiedByUserID"
        Me.VerifiedByUserID.Name = "VerifiedByUserID"
        Me.VerifiedByUserID.ReadOnly = True
        Me.VerifiedByUserID.Visible = False
        '
        'ApprovedByUserID
        '
        Me.ApprovedByUserID.DataPropertyName = "ApprovedByUserID"
        Me.ApprovedByUserID.HeaderText = "ApprovedByUserID"
        Me.ApprovedByUserID.Name = "ApprovedByUserID"
        Me.ApprovedByUserID.ReadOnly = True
        Me.ApprovedByUserID.Visible = False
        '
        'Udp_forms_submittedBindingSource
        '
        Me.Udp_forms_submittedBindingSource.DataMember = "udp_forms_submitted"
        Me.Udp_forms_submittedBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(13, 480)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(106, 37)
        Me.cmdEdit.TabIndex = 3
        Me.cmdEdit.Text = "Edit form"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'btnVerifyData
        '
        Me.btnVerifyData.Enabled = False
        Me.btnVerifyData.Location = New System.Drawing.Point(127, 480)
        Me.btnVerifyData.Name = "btnVerifyData"
        Me.btnVerifyData.Size = New System.Drawing.Size(106, 37)
        Me.btnVerifyData.TabIndex = 4
        Me.btnVerifyData.Text = "Verify Data"
        Me.btnVerifyData.UseVisualStyleBackColor = True
        '
        'BtnApproveData
        '
        Me.BtnApproveData.Enabled = False
        Me.BtnApproveData.Location = New System.Drawing.Point(243, 480)
        Me.BtnApproveData.Name = "BtnApproveData"
        Me.BtnApproveData.Size = New System.Drawing.Size(106, 37)
        Me.BtnApproveData.TabIndex = 5
        Me.BtnApproveData.Text = "Approve Data"
        Me.BtnApproveData.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(597, 480)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(106, 37)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "Delete form"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Udp_forms_submittedBindingSource, "Comments", True))
        Me.txtComments.Enabled = False
        Me.txtComments.Location = New System.Drawing.Point(131, 520)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(571, 70)
        Me.txtComments.TabIndex = 7
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(13, 526)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(56, 13)
        Me.lblComments.TabIndex = 8
        Me.lblComments.Text = "Comments"
        '
        'btnSaveComment
        '
        Me.btnSaveComment.Enabled = False
        Me.btnSaveComment.Location = New System.Drawing.Point(13, 553)
        Me.btnSaveComment.Name = "btnSaveComment"
        Me.btnSaveComment.Size = New System.Drawing.Size(106, 37)
        Me.btnSaveComment.TabIndex = 9
        Me.btnSaveComment.Text = "Save Comment"
        Me.btnSaveComment.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Enabled = False
        Me.btnExport.Location = New System.Drawing.Point(478, 480)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(106, 37)
        Me.btnExport.TabIndex = 10
        Me.btnExport.Text = "Create Export Zip File (Selected form)"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnExportAlForms
        '
        Me.btnExportAlForms.Enabled = False
        Me.btnExportAlForms.Location = New System.Drawing.Point(360, 480)
        Me.btnExportAlForms.Name = "btnExportAlForms"
        Me.btnExportAlForms.Size = New System.Drawing.Size(106, 37)
        Me.btnExportAlForms.TabIndex = 11
        Me.btnExportAlForms.Text = "Create Export Zip File (All Forms)"
        Me.btnExportAlForms.UseVisualStyleBackColor = True
        '
        'Udp_forms_submittedTableAdapter
        '
        Me.Udp_forms_submittedTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ActivityListTableAdapter = Nothing
        Me.TableAdapterManager.AiredPrograms03TableAdapter = Nothing
        Me.TableAdapterManager.AnimalDrawn03TableAdapter = Nothing
        Me.TableAdapterManager.AnimalsFeeds04TableAdapter = Nothing
        Me.TableAdapterManager.AnimalsGrazedListTableAdapter = Nothing
        Me.TableAdapterManager.AnimalsGroupTableAdapter = Nothing
        Me.TableAdapterManager.AnimalsListTableAdapter = Nothing
        Me.TableAdapterManager.AnnualRecordTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillEducationLevelTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillExtensionOfficersOthersTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillFoodSituationTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillLivestockInfrastructureFirstPartTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillLivestockInfrastructureFourthPartTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillLivestockInfrastructureSecondPartTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillLivestockInfrastructureTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillLivestockInfrastructureThirdPartTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillOxenizingTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillPlanningCommiteeTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillProductsProcessingAnimalTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillProductsProcessingHideTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillProductsProcessingMeatTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillProductsProcessingMilkTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillWorkingEquipmentsTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictAnnualFillWorkingFacilitiesTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictQuarterFillAcaricidesTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictQuarterFillAnimalFeedsTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictQuarterFillLivestockMarketingTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictQuarterFillReproductionInputTableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictQuarterFillTreatment_Drugs_TableAdapter = Nothing
        Me.TableAdapterManager.appUspDistrictQuarterFillVaccinesTableAdapter = Nothing
        Me.TableAdapterManager.AreaLevelsTableAdapter = Nothing
        Me.TableAdapterManager.AreasDistrictsTableAdapter = Nothing
        Me.TableAdapterManager.AreasMtaaTableAdapter = Nothing
        Me.TableAdapterManager.AreasRegionsTableAdapter = Nothing
        Me.TableAdapterManager.AreasTableAdapter = Nothing
        Me.TableAdapterManager.AreasVillagesTableAdapter = Nothing
        Me.TableAdapterManager.AreasWardsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BasicInformation03TableAdapter = Nothing
        Me.TableAdapterManager.ChemicalControl01TableAdapter = Nothing
        Me.TableAdapterManager.CommentsOfVillageOfficer01TableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.ContractFarming03iTableAdapter = Nothing
        Me.TableAdapterManager.ContractFarming03TableAdapter = Nothing
        Me.TableAdapterManager.CoopGroup02iTableAdapter = Nothing
        Me.TableAdapterManager.CoopGroup02TableAdapter = Nothing
        Me.TableAdapterManager.CoopGroupListTableAdapter = Nothing
        Me.TableAdapterManager.CoopGroupTableAdapter = Nothing
        Me.TableAdapterManager.CoopSaccos02TableAdapter = Nothing
        Me.TableAdapterManager.CropGroupListTableAdapter = Nothing
        Me.TableAdapterManager.CropGroupTableAdapter = Nothing
        Me.TableAdapterManager.CropResidue03TableAdapter = Nothing
        Me.TableAdapterManager.DippingSprayingVaccination01TableAdapter = Nothing
        Me.TableAdapterManager.DistrictInfo05TableAdapter = Nothing
        Me.TableAdapterManager.DrawnListTableAdapter = Nothing
        Me.TableAdapterManager.EducationLevel05TableAdapter = Nothing
        Me.TableAdapterManager.ExtensionOfficers05TableAdapter = Nothing
        Me.TableAdapterManager.ExtensionServiceProviders05TableAdapter = Nothing
        Me.TableAdapterManager.FarmersFieldSchool02iTableAdapter = Nothing
        Me.TableAdapterManager.FarmersFieldSchool02TableAdapter = Nothing
        Me.TableAdapterManager.FarmersFieldSchool03iTableAdapter = Nothing
        Me.TableAdapterManager.FarmersFieldSchool03TableAdapter = Nothing
        Me.TableAdapterManager.Fertilizer03TableAdapter = Nothing
        Me.TableAdapterManager.FertilizerListTableAdapter = Nothing
        Me.TableAdapterManager.FFSGroupTableAdapter = Nothing
        Me.TableAdapterManager.FFSListTableAdapter = Nothing
        Me.TableAdapterManager.FoodCondition02TableAdapter = Nothing
        Me.TableAdapterManager.FoodSituation05TableAdapter = Nothing
        Me.TableAdapterManager.FoodStatusListTableAdapter = Nothing
        Me.TableAdapterManager.GrazingLand03iTableAdapter = Nothing
        Me.TableAdapterManager.GrazingLand03TableAdapter = Nothing
        Me.TableAdapterManager.Group2DTableAdapter = Nothing
        Me.TableAdapterManager.HandOperatedImplements03TableAdapter = Nothing
        Me.TableAdapterManager.Implements03iTableAdapter = Nothing
        Me.TableAdapterManager.ImplementsListTableAdapter = Nothing
        Me.TableAdapterManager.ImprovedPasture03TableAdapter = Nothing
        Me.TableAdapterManager.ImprovedSeeds03TableAdapter = Nothing
        Me.TableAdapterManager.InfraListTableAdapter = Nothing
        Me.TableAdapterManager.Irrigation02TableAdapter = Nothing
        Me.TableAdapterManager.IrrigationScheme03iTableAdapter = Nothing
        Me.TableAdapterManager.IrrigationScheme03TableAdapter = Nothing
        Me.TableAdapterManager.Livestock03iTableAdapter = Nothing
        Me.TableAdapterManager.Livestock03TableAdapter = Nothing
        Me.TableAdapterManager.LivestockInfrastructure03TableAdapter = Nothing
        Me.TableAdapterManager.LivestockInfrastructure05TableAdapter = Nothing
        Me.TableAdapterManager.LivestockListTableAdapter = Nothing
        Me.TableAdapterManager.LivestockMarketing04TableAdapter = Nothing
        Me.TableAdapterManager.LivestockMovement04TableAdapter = Nothing
        Me.TableAdapterManager.LivestockPopulation05TableAdapter = Nothing
        Me.TableAdapterManager.LivestockService01TableAdapter = Nothing

        Me.TableAdapterManager.LivestockSlaughtered01TableAdapter = Nothing
        Me.TableAdapterManager.MachineryDrawn03TableAdapter = Nothing
        Me.TableAdapterManager.MachineryListTableAdapter = Nothing
        Me.TableAdapterManager.MachineryProcessListTableAdapter = Nothing
        Me.TableAdapterManager.Machines03TableAdapter = Nothing
        Me.TableAdapterManager.MeatInspection01TableAdapter = Nothing
        Me.TableAdapterManager.MediaGroupTableAdapter = Nothing
        Me.TableAdapterManager.MediaListTableAdapter = Nothing
        Me.TableAdapterManager.Medication01TableAdapter = Nothing
        Me.TableAdapterManager.MonthlyRecordTableAdapter = Nothing
        Me.TableAdapterManager.OtherFarmersGroupsTableAdapter = Nothing
        Me.TableAdapterManager.Oxenizing05TableAdapter = Nothing
        Me.TableAdapterManager.PeopleWhoVisitTheVillage01TableAdapter = Nothing
        Me.TableAdapterManager.PlanningCommitee05TableAdapter = Nothing
        Me.TableAdapterManager.PlantHealth02TableAdapter = Nothing
        Me.TableAdapterManager.ProcessingMachines03TableAdapter = Nothing
        Me.TableAdapterManager.ProcessingMachinesListTableAdapter = Nothing
        Me.TableAdapterManager.ProdLand02iTableAdapter = Nothing
        Me.TableAdapterManager.ProdLand02TableAdapter = Nothing
        Me.TableAdapterManager.ProdMilk01TableAdapter = Nothing
        Me.TableAdapterManager.ProdMilkListTableAdapter = Nothing
        Me.TableAdapterManager.ProdSkinListTableAdapter = Nothing
        Me.TableAdapterManager.ProductsMovement04TableAdapter = Nothing
        Me.TableAdapterManager.ProductsProcessing05TableAdapter = Nothing
        Me.TableAdapterManager.QuarterlyRecordTableAdapter = Nothing
        Me.TableAdapterManager.RecordInfoTableAdapter = Nothing
        Me.TableAdapterManager.ReproductionInputs04TableAdapter = Nothing
        Me.TableAdapterManager.SchemeGroupTableAdapter = Nothing
        Me.TableAdapterManager.SchemeListTableAdapter = Nothing
        Me.TableAdapterManager.SeasonListTableAdapter = Nothing
        Me.TableAdapterManager.SeedGroupTableAdapter = Nothing
        Me.TableAdapterManager.SeedListTableAdapter = Nothing
        Me.TableAdapterManager.SoilErosion02TableAdapter = Nothing
        Me.TableAdapterManager.SoilErosionListTableAdapter = Nothing
        Me.TableAdapterManager.TargetImplementationAndCropPrices01TableAdapter = Nothing
        Me.TableAdapterManager.TargetiTableAdapter = Nothing
        Me.TableAdapterManager.tbl_configTableAdapter = Nothing
        Me.TableAdapterManager.tbl_data_forms_submittedTableAdapter = Nothing
        Me.TableAdapterManager.tbl_setup_area_levelsTableAdapter = Nothing
        Me.TableAdapterManager.tbl_setup_areasTableAdapter = Nothing
        Me.TableAdapterManager.tbl_setup_form_typesTableAdapter = Nothing
        Me.TableAdapterManager.tbl_setup_sectorsTableAdapter = Nothing
        Me.TableAdapterManager.tblAppVersionControlTableAdapter = Nothing
        Me.TableAdapterManager.tblGroupRightsTableAdapter = Nothing
        Me.TableAdapterManager.tblGroupsTableAdapter = Nothing
        Me.TableAdapterManager.tblInstitutionsTableAdapter = Nothing
        Me.TableAdapterManager.tblListTableAdapter = Nothing
        Me.TableAdapterManager.tblRightsTableAdapter = Nothing
        Me.TableAdapterManager.tblUserGroupTableAdapter = Nothing
        Me.TableAdapterManager.tblUsersTableAdapter = Nothing
        Me.TableAdapterManager.TelecomCompaListTableAdapter = Nothing
        Me.TableAdapterManager.Telecommunication03TableAdapter = Nothing
        Me.TableAdapterManager.ThreeDGroupTableAdapter = Nothing
        Me.TableAdapterManager.ThreeDListTableAdapter = Nothing
        Me.TableAdapterManager.TVAndRadioStation03TableAdapter = Nothing
        Me.TableAdapterManager.TwoDListTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WeatherCondition01TableAdapter = Nothing
        Me.TableAdapterManager.WorkingEquipments05TableAdapter = Nothing
        Me.TableAdapterManager.WorkingFacilities05TableAdapter = Nothing
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RecordID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "RecordID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FormName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Form"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Area_Level_Name"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Level"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Area_Name"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Area"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PeriodFrom"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Period From"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PeriodTo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "To"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "FormTypeNumber"
        Me.DataGridViewTextBoxColumn8.HeaderText = "FormTypeNumber"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 2
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Area_ID"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Area_ID"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 2
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "OrganisationID"
        Me.DataGridViewTextBoxColumn10.HeaderText = "OrganisationID"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 2
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "VerifiedByUserID"
        Me.DataGridViewTextBoxColumn11.HeaderText = "VerifiedByUserID"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ApprovedByPersonID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "ApprovedByPersonID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'groupBoxFilterBox
        '
        Me.groupBoxFilterBox.Controls.Add(Me.cmbArea)
        Me.groupBoxFilterBox.Controls.Add(Me.Label5)
        Me.groupBoxFilterBox.Controls.Add(Me.btnFilterForm)
        Me.groupBoxFilterBox.Controls.Add(Me.cmbPeriodTo)
        Me.groupBoxFilterBox.Controls.Add(Me.cmbPeriodFrom)
        Me.groupBoxFilterBox.Controls.Add(Me.cmbAreaLevel)
        Me.groupBoxFilterBox.Controls.Add(Me.cmbFormType)
        Me.groupBoxFilterBox.Controls.Add(Me.Label4)
        Me.groupBoxFilterBox.Controls.Add(Me.Label3)
        Me.groupBoxFilterBox.Controls.Add(Me.Label2)
        Me.groupBoxFilterBox.Controls.Add(Me.Label1)
        Me.groupBoxFilterBox.Location = New System.Drawing.Point(15, 9)
        Me.groupBoxFilterBox.Name = "groupBoxFilterBox"
        Me.groupBoxFilterBox.Size = New System.Drawing.Size(687, 122)
        Me.groupBoxFilterBox.TabIndex = 12
        Me.groupBoxFilterBox.TabStop = False
        Me.groupBoxFilterBox.Text = "Filter Form"
        '
        'cmbArea
        '
        Me.cmbArea.DataSource = Me.Udp_forms_submittedBindingSource
        Me.cmbArea.DisplayMember = "Area_Name"
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(409, 42)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(121, 21)
        Me.cmbArea.TabIndex = 10
        Me.cmbArea.ValueMember = "AreaID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(240, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "By Period To"
        '
        'btnFilterForm
        '
        Me.btnFilterForm.Location = New System.Drawing.Point(409, 90)
        Me.btnFilterForm.Name = "btnFilterForm"
        Me.btnFilterForm.Size = New System.Drawing.Size(96, 23)
        Me.btnFilterForm.TabIndex = 8
        Me.btnFilterForm.Text = "Filter Form"
        Me.btnFilterForm.UseVisualStyleBackColor = True
        '
        'cmbPeriodTo
        '
        Me.cmbPeriodTo.DataSource = Me.Udp_forms_submittedBindingSource
        Me.cmbPeriodTo.DisplayMember = "PeriodTo"
        Me.cmbPeriodTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPeriodTo.FormattingEnabled = True
        Me.cmbPeriodTo.Location = New System.Drawing.Point(243, 92)
        Me.cmbPeriodTo.Name = "cmbPeriodTo"
        Me.cmbPeriodTo.Size = New System.Drawing.Size(121, 21)
        Me.cmbPeriodTo.TabIndex = 7
        Me.cmbPeriodTo.ValueMember = "PeriodTo"
        '
        'cmbPeriodFrom
        '
        Me.cmbPeriodFrom.DataSource = Me.Udp_forms_submittedBindingSource
        Me.cmbPeriodFrom.DisplayMember = "PeriodFrom"
        Me.cmbPeriodFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodFrom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPeriodFrom.FormattingEnabled = True
        Me.cmbPeriodFrom.Location = New System.Drawing.Point(29, 92)
        Me.cmbPeriodFrom.Name = "cmbPeriodFrom"
        Me.cmbPeriodFrom.Size = New System.Drawing.Size(121, 21)
        Me.cmbPeriodFrom.TabIndex = 6
        Me.cmbPeriodFrom.ValueMember = "PeriodFrom"
        '
        'cmbAreaLevel
        '
        Me.cmbAreaLevel.DataSource = Me.Udp_forms_submittedBindingSource
        Me.cmbAreaLevel.DisplayMember = "Area_Level_Name"
        Me.cmbAreaLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreaLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbAreaLevel.FormattingEnabled = True
        Me.cmbAreaLevel.Location = New System.Drawing.Point(243, 42)
        Me.cmbAreaLevel.Name = "cmbAreaLevel"
        Me.cmbAreaLevel.Size = New System.Drawing.Size(121, 21)
        Me.cmbAreaLevel.TabIndex = 5
        Me.cmbAreaLevel.ValueMember = "Area_Level_Name"
        '
        'cmbFormType
        '
        Me.cmbFormType.DataSource = Me.Udp_forms_submittedBindingSource
        Me.cmbFormType.DisplayMember = "FormName"
        Me.cmbFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFormType.FormattingEnabled = True
        Me.cmbFormType.Location = New System.Drawing.Point(31, 42)
        Me.cmbFormType.Name = "cmbFormType"
        Me.cmbFormType.Size = New System.Drawing.Size(183, 21)
        Me.cmbFormType.TabIndex = 4
        Me.cmbFormType.ValueMember = "FormTypeNumber"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "By Period From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(406, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "By Area"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "By Area Level"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "By Form Type"
        '
        'ctrlEditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.groupBoxFilterBox)
        Me.Controls.Add(Me.btnExportAlForms)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnSaveComment)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.BtnApproveData)
        Me.Controls.Add(Me.btnVerifyData)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.Udp_forms_submittedDataGridView)
        Me.Name = "ctrlEditForm"
        Me.Size = New System.Drawing.Size(721, 657)
        CType(Me.Udp_forms_submittedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Udp_forms_submittedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBoxFilterBox.ResumeLayout(False)
        Me.groupBoxFilterBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AreaLevelNameEnglishDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AreaLevelNameSwahiliDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents Udp_forms_submittedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Udp_forms_submittedTableAdapter As LGMD.LGMDdataDataSetTableAdapters.udp_forms_submittedTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Udp_forms_submittedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents btnVerifyData As System.Windows.Forms.Button
    Friend WithEvents BtnApproveData As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents btnSaveComment As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnExportAlForms As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents groupBoxFilterBox As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecordID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area_Level_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormSerialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormTypeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrganisationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerifiedByUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedByUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnFilterForm As System.Windows.Forms.Button
    Friend WithEvents cmbPeriodTo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodFrom As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAreaLevel As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFormType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
