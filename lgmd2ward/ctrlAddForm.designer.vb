<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlAddForm
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
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
        Me.cmbAreaID = New System.Windows.Forms.ComboBox()
        Me.Udp_geo_listBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbPlace = New System.Windows.Forms.ComboBox()
        Me.Udp_area_levels_data_entryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbQuarter = New System.Windows.Forms.ComboBox()
        Me.cmbForm = New System.Windows.Forms.ComboBox()
        Me.Tbl_setup_form_typesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbPeriod = New System.Windows.Forms.ComboBox()
        Me.TableAdapterManager = New LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_setup_form_typesTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.tbl_setup_form_typesTableAdapter()
        Me.Udp_geo_listTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.udp_geo_listTableAdapter()
        Me.lblEngFormNumber = New System.Windows.Forms.Label()
        Me.lblEngPlace = New System.Windows.Forms.Label()
        Me.lblEngAreaID = New System.Windows.Forms.Label()
        Me.lblEngPeriod = New System.Windows.Forms.Label()
        Me.cmdAddForm = New System.Windows.Forms.Button()
        Me.lblSwaFormNumber = New System.Windows.Forms.Label()
        Me.lblSwaPlace = New System.Windows.Forms.Label()
        Me.lblSwaAreaID = New System.Windows.Forms.Label()
        Me.lblSwaPeriod = New System.Windows.Forms.Label()
        Me.Udp_area_levels_data_entryTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.udp_area_levels_data_entryTableAdapter()
        Me.lblSwaPeriodType = New System.Windows.Forms.Label()
        Me.lblEngPeriodType = New System.Windows.Forms.Label()
        Me.cmbFinYear = New System.Windows.Forms.ComboBox()
        CType(Me.Udp_geo_listBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Udp_area_levels_data_entryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_setup_form_typesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbAreaID
        '
        Me.cmbAreaID.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAreaID.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.Udp_geo_listBindingSource, "Area_Name", True))
        Me.cmbAreaID.DataSource = Me.Udp_geo_listBindingSource
        Me.cmbAreaID.DisplayMember = "Area_Name"
        Me.cmbAreaID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreaID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAreaID.FormattingEnabled = True
        Me.cmbAreaID.Location = New System.Drawing.Point(155, 111)
        Me.cmbAreaID.Name = "cmbAreaID"
        Me.cmbAreaID.Size = New System.Drawing.Size(139, 21)
        Me.cmbAreaID.TabIndex = 3
        Me.cmbAreaID.ValueMember = "Area_ID"
        Me.cmbAreaID.Visible = False
        '
        'Udp_geo_listBindingSource
        '
        Me.Udp_geo_listBindingSource.DataMember = "udp_geo_list"
        Me.Udp_geo_listBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(469, 135)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(139, 21)
        Me.cmbMonth.TabIndex = 4
        Me.cmbMonth.Visible = False
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(469, 111)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(93, 21)
        Me.cmbYear.TabIndex = 5
        Me.cmbYear.Visible = False
        '
        'cmbPlace
        '
        Me.cmbPlace.DataSource = Me.Udp_area_levels_data_entryBindingSource
        Me.cmbPlace.DisplayMember = "Area_Level_Name_English"
        Me.cmbPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlace.FormattingEnabled = True
        Me.cmbPlace.Location = New System.Drawing.Point(155, 77)
        Me.cmbPlace.Name = "cmbPlace"
        Me.cmbPlace.Size = New System.Drawing.Size(139, 21)
        Me.cmbPlace.TabIndex = 6
        Me.cmbPlace.ValueMember = "Area_Level"
        Me.cmbPlace.Visible = False
        '
        'Udp_area_levels_data_entryBindingSource
        '
        Me.Udp_area_levels_data_entryBindingSource.DataMember = "udp_area_levels_data_entry"
        Me.Udp_area_levels_data_entryBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'cmbQuarter
        '
        Me.cmbQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuarter.FormattingEnabled = True
        Me.cmbQuarter.Location = New System.Drawing.Point(469, 135)
        Me.cmbQuarter.Name = "cmbQuarter"
        Me.cmbQuarter.Size = New System.Drawing.Size(139, 21)
        Me.cmbQuarter.TabIndex = 8
        Me.cmbQuarter.Visible = False
        '
        'cmbForm
        '
        Me.cmbForm.DataSource = Me.Tbl_setup_form_typesBindingSource
        Me.cmbForm.DisplayMember = "FormNameSwahili"
        Me.cmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForm.FormattingEnabled = True
        Me.cmbForm.Location = New System.Drawing.Point(155, 33)
        Me.cmbForm.Name = "cmbForm"
        Me.cmbForm.Size = New System.Drawing.Size(450, 21)
        Me.cmbForm.TabIndex = 9
        Me.cmbForm.ValueMember = "FormTypeNumber"
        '
        'Tbl_setup_form_typesBindingSource
        '
        Me.Tbl_setup_form_typesBindingSource.DataMember = "tbl_setup_form_types"
        Me.Tbl_setup_form_typesBindingSource.DataSource = Me.LGMDdataDataSet
        Me.Tbl_setup_form_typesBindingSource.Sort = ""
        '
        'cmbPeriod
        '
        Me.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriod.FormattingEnabled = True
        Me.cmbPeriod.Items.AddRange(New Object() {"Annual", "Quarterly", "Monthly"})
        Me.cmbPeriod.Location = New System.Drawing.Point(469, 77)
        Me.cmbPeriod.Name = "cmbPeriod"
        Me.cmbPeriod.Size = New System.Drawing.Size(136, 21)
        Me.cmbPeriod.TabIndex = 7
        Me.cmbPeriod.Visible = False
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
        Me.TableAdapterManager.tbl_setup_form_typesTableAdapter = Me.Tbl_setup_form_typesTableAdapter
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
        'Tbl_setup_form_typesTableAdapter
        '
        Me.Tbl_setup_form_typesTableAdapter.ClearBeforeFill = True
        '
        'Udp_geo_listTableAdapter
        '
        Me.Udp_geo_listTableAdapter.ClearBeforeFill = True
        '
        'lblEngFormNumber
        '
        Me.lblEngFormNumber.AutoSize = True
        Me.lblEngFormNumber.Location = New System.Drawing.Point(113, 33)
        Me.lblEngFormNumber.Name = "lblEngFormNumber"
        Me.lblEngFormNumber.Size = New System.Drawing.Size(33, 13)
        Me.lblEngFormNumber.TabIndex = 10
        Me.lblEngFormNumber.Text = "Form:"
        '
        'lblEngPlace
        '
        Me.lblEngPlace.AutoSize = True
        Me.lblEngPlace.Location = New System.Drawing.Point(48, 80)
        Me.lblEngPlace.Name = "lblEngPlace"
        Me.lblEngPlace.Size = New System.Drawing.Size(98, 13)
        Me.lblEngPlace.TabIndex = 11
        Me.lblEngPlace.Text = "Geographical level:"
        Me.lblEngPlace.Visible = False
        '
        'lblEngAreaID
        '
        Me.lblEngAreaID.AutoSize = True
        Me.lblEngAreaID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEngAreaID.Location = New System.Drawing.Point(48, 114)
        Me.lblEngAreaID.Name = "lblEngAreaID"
        Me.lblEngAreaID.Size = New System.Drawing.Size(97, 13)
        Me.lblEngAreaID.TabIndex = 12
        Me.lblEngAreaID.Text = "Geographical area:"
        Me.lblEngAreaID.Visible = False
        '
        'lblEngPeriod
        '
        Me.lblEngPeriod.AutoSize = True
        Me.lblEngPeriod.Location = New System.Drawing.Point(386, 114)
        Me.lblEngPeriod.Name = "lblEngPeriod"
        Me.lblEngPeriod.Size = New System.Drawing.Size(65, 13)
        Me.lblEngPeriod.TabIndex = 13
        Me.lblEngPeriod.Text = "Time period:"
        Me.lblEngPeriod.Visible = False
        '
        'cmdAddForm
        '
        Me.cmdAddForm.Location = New System.Drawing.Point(313, 208)
        Me.cmdAddForm.Name = "cmdAddForm"
        Me.cmdAddForm.Size = New System.Drawing.Size(115, 31)
        Me.cmdAddForm.TabIndex = 14
        Me.cmdAddForm.Text = "Add form"
        Me.cmdAddForm.UseVisualStyleBackColor = True
        '
        'lblSwaFormNumber
        '
        Me.lblSwaFormNumber.AutoSize = True
        Me.lblSwaFormNumber.Location = New System.Drawing.Point(113, 33)
        Me.lblSwaFormNumber.Name = "lblSwaFormNumber"
        Me.lblSwaFormNumber.Size = New System.Drawing.Size(36, 13)
        Me.lblSwaFormNumber.TabIndex = 15
        Me.lblSwaFormNumber.Text = "Fomu:"
        '
        'lblSwaPlace
        '
        Me.lblSwaPlace.AutoSize = True
        Me.lblSwaPlace.Location = New System.Drawing.Point(0, 80)
        Me.lblSwaPlace.Name = "lblSwaPlace"
        Me.lblSwaPlace.Size = New System.Drawing.Size(51, 13)
        Me.lblSwaPlace.TabIndex = 16
        Me.lblSwaPlace.Text = "Kiwango:"
        Me.lblSwaPlace.Visible = False
        '
        'lblSwaAreaID
        '
        Me.lblSwaAreaID.AutoSize = True
        Me.lblSwaAreaID.Location = New System.Drawing.Point(2, 114)
        Me.lblSwaAreaID.Name = "lblSwaAreaID"
        Me.lblSwaAreaID.Size = New System.Drawing.Size(49, 13)
        Me.lblSwaAreaID.TabIndex = 17
        Me.lblSwaAreaID.Text = "Maeneo:"
        Me.lblSwaAreaID.Visible = False
        '
        'lblSwaPeriod
        '
        Me.lblSwaPeriod.AutoSize = True
        Me.lblSwaPeriod.Location = New System.Drawing.Point(347, 114)
        Me.lblSwaPeriod.Name = "lblSwaPeriod"
        Me.lblSwaPeriod.Size = New System.Drawing.Size(41, 13)
        Me.lblSwaPeriod.TabIndex = 18
        Me.lblSwaPeriod.Text = "Kipindi:"
        Me.lblSwaPeriod.Visible = False
        '
        'Udp_area_levels_data_entryTableAdapter
        '
        Me.Udp_area_levels_data_entryTableAdapter.ClearBeforeFill = True
        '
        'lblSwaPeriodType
        '
        Me.lblSwaPeriodType.AutoSize = True
        Me.lblSwaPeriodType.Location = New System.Drawing.Point(310, 80)
        Me.lblSwaPeriodType.Name = "lblSwaPeriodType"
        Me.lblSwaPeriodType.Size = New System.Drawing.Size(78, 13)
        Me.lblSwaPeriodType.TabIndex = 20
        Me.lblSwaPeriodType.Text = "Aina ya kipindi:"
        Me.lblSwaPeriodType.Visible = False
        '
        'lblEngPeriodType
        '
        Me.lblEngPeriodType.AutoSize = True
        Me.lblEngPeriodType.Location = New System.Drawing.Point(386, 80)
        Me.lblEngPeriodType.Name = "lblEngPeriodType"
        Me.lblEngPeriodType.Size = New System.Drawing.Size(63, 13)
        Me.lblEngPeriodType.TabIndex = 19
        Me.lblEngPeriodType.Text = "Period type:"
        Me.lblEngPeriodType.Visible = False
        '
        'cmbFinYear
        '
        Me.cmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinYear.FormattingEnabled = True
        Me.cmbFinYear.Location = New System.Drawing.Point(469, 111)
        Me.cmbFinYear.Name = "cmbFinYear"
        Me.cmbFinYear.Size = New System.Drawing.Size(93, 21)
        Me.cmbFinYear.TabIndex = 21
        Me.cmbFinYear.Visible = False
        '
        'ctrlAddForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbFinYear)
        Me.Controls.Add(Me.lblSwaPeriodType)
        Me.Controls.Add(Me.lblEngPeriodType)
        Me.Controls.Add(Me.lblSwaPeriod)
        Me.Controls.Add(Me.lblSwaAreaID)
        Me.Controls.Add(Me.lblSwaPlace)
        Me.Controls.Add(Me.lblSwaFormNumber)
        Me.Controls.Add(Me.cmdAddForm)
        Me.Controls.Add(Me.lblEngPeriod)
        Me.Controls.Add(Me.lblEngAreaID)
        Me.Controls.Add(Me.lblEngPlace)
        Me.Controls.Add(Me.lblEngFormNumber)
        Me.Controls.Add(Me.cmbForm)
        Me.Controls.Add(Me.cmbQuarter)
        Me.Controls.Add(Me.cmbPeriod)
        Me.Controls.Add(Me.cmbPlace)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.cmbAreaID)
        Me.Name = "ctrlAddForm"
        Me.Size = New System.Drawing.Size(941, 268)
        CType(Me.Udp_geo_listBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Udp_area_levels_data_entryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_setup_form_typesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbAreaID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPlace As System.Windows.Forms.ComboBox
    Friend WithEvents cmbQuarter As System.Windows.Forms.ComboBox
    Friend WithEvents cmbForm As System.Windows.Forms.ComboBox
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents TableAdapterManager As LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Udp_geo_listBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Udp_geo_listTableAdapter As LGMD.LGMDdataDataSetTableAdapters.udp_geo_listTableAdapter
    Friend WithEvents lblEngFormNumber As System.Windows.Forms.Label
    Friend WithEvents lblEngPlace As System.Windows.Forms.Label
    Friend WithEvents lblEngAreaID As System.Windows.Forms.Label
    Friend WithEvents lblEngPeriod As System.Windows.Forms.Label
    Friend WithEvents cmdAddForm As System.Windows.Forms.Button
    Friend WithEvents lblSwaFormNumber As System.Windows.Forms.Label
    Friend WithEvents lblSwaPlace As System.Windows.Forms.Label
    Friend WithEvents lblSwaAreaID As System.Windows.Forms.Label
    Friend WithEvents lblSwaPeriod As System.Windows.Forms.Label
    Friend WithEvents Udp_area_levels_data_entryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Udp_area_levels_data_entryTableAdapter As LGMD.LGMDdataDataSetTableAdapters.udp_area_levels_data_entryTableAdapter
    Friend WithEvents Tbl_setup_form_typesTableAdapter As LGMD.LGMDdataDataSetTableAdapters.tbl_setup_form_typesTableAdapter
    Friend WithEvents Tbl_setup_form_typesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblSwaPeriodType As System.Windows.Forms.Label
    Friend WithEvents lblEngPeriodType As System.Windows.Forms.Label
    Friend WithEvents cmbFinYear As System.Windows.Forms.ComboBox

End Class
