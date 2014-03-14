<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDistrict02Page03
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlDistrict02Page03))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtFinancialYear = New System.Windows.Forms.TextBox()
        Me.txtQuarter = New System.Windows.Forms.TextBox()
        Me.txtNameOfLGA = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.AppUspDistrictQuarterFillReproductionInputBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager = New LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager()
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AppUspDistrictQuarterFillReproductionInputTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.appUspDistrictQuarterFillReproductionInputTableAdapter()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspDistrictQuarterFillReproductionInputBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspDistrictQuarterFillReproductionInputDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(281, 642)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(143, 21)
        Me.cmbGoTo.TabIndex = 62
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gotoLbl.Location = New System.Drawing.Point(239, 645)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 64
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(441, 638)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 63
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtFinancialYear
        '
        Me.txtFinancialYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFinancialYear.Location = New System.Drawing.Point(521, 66)
        Me.txtFinancialYear.Name = "txtFinancialYear"
        Me.txtFinancialYear.Size = New System.Drawing.Size(187, 20)
        Me.txtFinancialYear.TabIndex = 77
        '
        'txtQuarter
        '
        Me.txtQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuarter.Location = New System.Drawing.Point(319, 67)
        Me.txtQuarter.Name = "txtQuarter"
        Me.txtQuarter.Size = New System.Drawing.Size(100, 20)
        Me.txtQuarter.TabIndex = 76
        '
        'txtNameOfLGA
        '
        Me.txtNameOfLGA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNameOfLGA.Location = New System.Drawing.Point(105, 66)
        Me.txtNameOfLGA.Name = "txtNameOfLGA"
        Me.txtNameOfLGA.Size = New System.Drawing.Size(147, 20)
        Me.txtNameOfLGA.TabIndex = 75
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(493, 91)
        Me.Label14.TabIndex = 74
        Me.Label14.Text = resources.GetString("Label14.Text")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(438, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "" & Global.Microsoft.VisualBasic.ChrW(9) & "Financial Year:" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(268, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Quarter:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Name of LGA:"
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspDistrictQuarterFillReproductionInputBindingSource
        '
        Me.AppUspDistrictQuarterFillReproductionInputBindingSource.DataMember = "appUspDistrictQuarterFillReproductionInput"
        Me.AppUspDistrictQuarterFillReproductionInputBindingSource.DataSource = Me.LGMDdataDataSet
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
        'AppUspDistrictQuarterFillReproductionInputDataGridView
        '
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.AllowUserToAddRows = False
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.AllowUserToDeleteRows = False
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.AllowUserToResizeColumns = False
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.AllowUserToResizeRows = False
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.AutoGenerateColumns = False
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.DataSource = Me.AppUspDistrictQuarterFillReproductionInputBindingSource
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.Location = New System.Drawing.Point(28, 233)
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.Name = "AppUspDistrictQuarterFillReproductionInputDataGridView"
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.Size = New System.Drawing.Size(843, 366)
        Me.AppUspDistrictQuarterFillReproductionInputDataGridView.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "7 (b). Inputs for reproduction of improved livestock" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 607)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(356, 13)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Note: (iii) and (iv) Number of doses for semen; numbers for bulls and heifer." & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & _
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'AppUspDistrictQuarterFillReproductionInputTableAdapter
        '
        Me.AppUspDistrictQuarterFillReproductionInputTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ListID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ListID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ListItemSw"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ListItemSw"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ListItemEn"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Type of input (i)"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ListItemType"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ListItemType"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ListItemStatus"
        Me.DataGridViewTextBoxColumn5.HeaderText = "ListItemStatus"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ReproductionInputsID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ReproductionInputsID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "InputID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "InputID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Breed"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Breed (ii)"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "AmountRequired"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn9.HeaderText = "Amount required in the quarter (doses or number) (iii)" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 150
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "AmountAvailable"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn10.HeaderText = "Amount available in the quarter (doses or number) (iv)" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 150
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Remarks"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Remarks" & Global.Microsoft.VisualBasic.ChrW(9) & "(v)"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 300
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "QuarterlyRecordID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "QuarterlyRecordID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'ctrlDistrict02Page03
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AppUspDistrictQuarterFillReproductionInputDataGridView)
        Me.Controls.Add(Me.txtFinancialYear)
        Me.Controls.Add(Me.txtQuarter)
        Me.Controls.Add(Me.txtNameOfLGA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Name = "ctrlDistrict02Page03"
        Me.Size = New System.Drawing.Size(900, 680)
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspDistrictQuarterFillReproductionInputBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspDistrictQuarterFillReproductionInputDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtFinancialYear As System.Windows.Forms.TextBox
    Friend WithEvents txtQuarter As System.Windows.Forms.TextBox
    Friend WithEvents txtNameOfLGA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents AppUspDistrictQuarterFillReproductionInputBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableAdapterManager As LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AppUspDistrictQuarterFillReproductionInputDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AppUspDistrictQuarterFillReproductionInputTableAdapter As LGMD.LGMDdataDataSetTableAdapters.appUspDistrictQuarterFillReproductionInputTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
