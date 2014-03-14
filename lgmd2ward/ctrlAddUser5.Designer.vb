<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlAddUser5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlAddUser5))
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.AppUspFillUsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AppUspFillUsersTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.appUspFillUsersTableAdapter()
        Me.TableAdapterManager = New LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager()
        Me.AppUspFillUsersBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AppUspFillUsersBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.AppUspFillUsersDataGridView = New System.Windows.Forms.DataGridView()
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PasswordDataGridViewImageColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TblUserGroupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BDeletedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RowVersionIDDataGridViewImageColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YearDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TblUserGroupTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.tblUserGroupTableAdapter()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspFillUsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspFillUsersBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AppUspFillUsersBindingNavigator.SuspendLayout()
        CType(Me.AppUspFillUsersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblUserGroupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspFillUsersBindingSource
        '
        Me.AppUspFillUsersBindingSource.DataMember = "appUspFillUsers"
        Me.AppUspFillUsersBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'AppUspFillUsersTableAdapter
        '
        Me.AppUspFillUsersTableAdapter.ClearBeforeFill = True
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

        Me.TableAdapterManager.appUspDistrictAnnualFillOxenizingTableAdapter = Nothing
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
        Me.TableAdapterManager.ProdSkin01TableAdapter = Nothing
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
        'AppUspFillUsersBindingNavigator
        '
        Me.AppUspFillUsersBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.AppUspFillUsersBindingNavigator.BindingSource = Me.AppUspFillUsersBindingSource
        Me.AppUspFillUsersBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.AppUspFillUsersBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.AppUspFillUsersBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.AppUspFillUsersBindingNavigatorSaveItem})
        Me.AppUspFillUsersBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.AppUspFillUsersBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.AppUspFillUsersBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.AppUspFillUsersBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.AppUspFillUsersBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.AppUspFillUsersBindingNavigator.Name = "AppUspFillUsersBindingNavigator"
        Me.AppUspFillUsersBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.AppUspFillUsersBindingNavigator.Size = New System.Drawing.Size(648, 25)
        Me.AppUspFillUsersBindingNavigator.TabIndex = 0
        Me.AppUspFillUsersBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AppUspFillUsersBindingNavigatorSaveItem
        '
        Me.AppUspFillUsersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AppUspFillUsersBindingNavigatorSaveItem.Enabled = False
        Me.AppUspFillUsersBindingNavigatorSaveItem.Image = CType(resources.GetObject("AppUspFillUsersBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.AppUspFillUsersBindingNavigatorSaveItem.Name = "AppUspFillUsersBindingNavigatorSaveItem"
        Me.AppUspFillUsersBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.AppUspFillUsersBindingNavigatorSaveItem.Text = "Save Data"
        '
        'AppUspFillUsersDataGridView
        '
        Me.AppUspFillUsersDataGridView.AutoGenerateColumns = False
        Me.AppUspFillUsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspFillUsersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserNameDataGridViewTextBoxColumn, Me.PasswordDataGridViewImageColumn, Me.GroupIDDataGridViewTextBoxColumn, Me.BDeletedDataGridViewCheckBoxColumn, Me.RowVersionIDDataGridViewImageColumn, Me.YearDataGridViewTextBoxColumn, Me.SourceIDDataGridViewTextBoxColumn})
        Me.AppUspFillUsersDataGridView.DataSource = Me.AppUspFillUsersBindingSource
        Me.AppUspFillUsersDataGridView.Location = New System.Drawing.Point(32, 38)
        Me.AppUspFillUsersDataGridView.Name = "AppUspFillUsersDataGridView"
        Me.AppUspFillUsersDataGridView.Size = New System.Drawing.Size(243, 220)
        Me.AppUspFillUsersDataGridView.TabIndex = 1
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        '
        'PasswordDataGridViewImageColumn
        '
        Me.PasswordDataGridViewImageColumn.DataPropertyName = "Password"
        Me.PasswordDataGridViewImageColumn.HeaderText = "Password"
        Me.PasswordDataGridViewImageColumn.Name = "PasswordDataGridViewImageColumn"
        Me.PasswordDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PasswordDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PasswordDataGridViewImageColumn.Visible = False
        '
        'GroupIDDataGridViewTextBoxColumn
        '
        Me.GroupIDDataGridViewTextBoxColumn.DataPropertyName = "GroupID"
        Me.GroupIDDataGridViewTextBoxColumn.DataSource = Me.TblUserGroupBindingSource
        Me.GroupIDDataGridViewTextBoxColumn.DisplayMember = "GroupName"
        Me.GroupIDDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupIDDataGridViewTextBoxColumn.HeaderText = "UserGroup"
        Me.GroupIDDataGridViewTextBoxColumn.Name = "GroupIDDataGridViewTextBoxColumn"
        Me.GroupIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GroupIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.GroupIDDataGridViewTextBoxColumn.ValueMember = "GroupID"
        '
        'TblUserGroupBindingSource
        '
        Me.TblUserGroupBindingSource.DataMember = "tblUserGroup"
        Me.TblUserGroupBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'BDeletedDataGridViewCheckBoxColumn
        '
        Me.BDeletedDataGridViewCheckBoxColumn.DataPropertyName = "bDeleted"
        Me.BDeletedDataGridViewCheckBoxColumn.HeaderText = "bDeleted"
        Me.BDeletedDataGridViewCheckBoxColumn.Name = "BDeletedDataGridViewCheckBoxColumn"
        Me.BDeletedDataGridViewCheckBoxColumn.Visible = False
        '
        'RowVersionIDDataGridViewImageColumn
        '
        Me.RowVersionIDDataGridViewImageColumn.DataPropertyName = "RowVersionID"
        Me.RowVersionIDDataGridViewImageColumn.HeaderText = "RowVersionID"
        Me.RowVersionIDDataGridViewImageColumn.Name = "RowVersionIDDataGridViewImageColumn"
        Me.RowVersionIDDataGridViewImageColumn.ReadOnly = True
        Me.RowVersionIDDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RowVersionIDDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RowVersionIDDataGridViewImageColumn.Visible = False
        '
        'YearDataGridViewTextBoxColumn
        '
        Me.YearDataGridViewTextBoxColumn.DataPropertyName = "Year"
        Me.YearDataGridViewTextBoxColumn.HeaderText = "Year"
        Me.YearDataGridViewTextBoxColumn.Name = "YearDataGridViewTextBoxColumn"
        Me.YearDataGridViewTextBoxColumn.Visible = False
        '
        'SourceIDDataGridViewTextBoxColumn
        '
        Me.SourceIDDataGridViewTextBoxColumn.DataPropertyName = "SourceID"
        Me.SourceIDDataGridViewTextBoxColumn.HeaderText = "SourceID"
        Me.SourceIDDataGridViewTextBoxColumn.Name = "SourceIDDataGridViewTextBoxColumn"
        Me.SourceIDDataGridViewTextBoxColumn.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(108, 271)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Save"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'TblUserGroupTableAdapter
        '
        Me.TblUserGroupTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "GroupID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "GroupID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "UserName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "UserName"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Year"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Year"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SourceID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "SourceID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "SourceID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "SourceID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'ctrlAddUser5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.AppUspFillUsersDataGridView)
        Me.Controls.Add(Me.AppUspFillUsersBindingNavigator)
        Me.Name = "ctrlAddUser5"
        Me.Size = New System.Drawing.Size(648, 338)
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspFillUsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspFillUsersBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AppUspFillUsersBindingNavigator.ResumeLayout(False)
        Me.AppUspFillUsersBindingNavigator.PerformLayout()
        CType(Me.AppUspFillUsersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblUserGroupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents AppUspFillUsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspFillUsersTableAdapter As LGMD.LGMDdataDataSetTableAdapters.appUspFillUsersTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AppUspFillUsersBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AppUspFillUsersBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents AppUspFillUsersDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TblUserGroupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblUserGroupTableAdapter As LGMD.LGMDdataDataSetTableAdapters.tblUserGroupTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PasswordDataGridViewImageColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents BDeletedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RowVersionIDDataGridViewImageColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
