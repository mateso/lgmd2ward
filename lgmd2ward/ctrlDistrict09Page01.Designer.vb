<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDistrict09Page01
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
        Dim NumberOfWardsLabel As System.Windows.Forms.Label
        Dim NumberOfVillagesLabel As System.Windows.Forms.Label
        Dim NumberOfHouseholdLabel As System.Windows.Forms.Label
        Dim NumberOfHouseholdAgricultureLabel As System.Windows.Forms.Label
        Dim DistrictPopulationLabel As System.Windows.Forms.Label
        Dim NumberOfOfficersTrainedLabel As System.Windows.Forms.Label
        Dim NumberOfResourceCentresLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlDistrict09Page01))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.NumberOfWardsTextBox = New System.Windows.Forms.TextBox()
        Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AnnuallyIntegratedDataSet = New LGMD.AnnuallyIntegratedDataSet()
        Me.NumberOfVillagesTextBox = New System.Windows.Forms.TextBox()
        Me.NumberOfHouseholdTextBox = New System.Windows.Forms.TextBox()
        Me.NumberOfHouseholdAgricultureTextBox = New System.Windows.Forms.TextBox()
        Me.DistrictPopulationTextBox = New System.Windows.Forms.TextBox()
        Me.NumberOfOfficersTrainedTextBox = New System.Windows.Forms.TextBox()
        Me.NumberOfResourceCentresTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView = New System.Windows.Forms.DataGridView()
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
        Me.AppUspAnnuallyIntegratedFillFoodSituationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AppUspAnnuallyIntegratedFillDistrictInfoTableAdapter = New LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillDistrictInfoTableAdapter()
        Me.TableAdapterManager = New LGMD.AnnuallyIntegratedDataSetTableAdapters.TableAdapterManager()
        Me.AppUspAnnuallyIntegratedFillFoodSituationTableAdapter = New LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillFoodSituationTableAdapter()
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter = New LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter()
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IrrigationSchemeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.AppUspAnnuallyIntegratedFillIrrigationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AppUspAnnuallyIntegratedFillIrrigationTableAdapter = New LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillIrrigationTableAdapter()
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        NumberOfWardsLabel = New System.Windows.Forms.Label()
        NumberOfVillagesLabel = New System.Windows.Forms.Label()
        NumberOfHouseholdLabel = New System.Windows.Forms.Label()
        NumberOfHouseholdAgricultureLabel = New System.Windows.Forms.Label()
        DistrictPopulationLabel = New System.Windows.Forms.Label()
        NumberOfOfficersTrainedLabel = New System.Windows.Forms.Label()
        NumberOfResourceCentresLabel = New System.Windows.Forms.Label()
        CType(Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnnuallyIntegratedDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspAnnuallyIntegratedFillFoodSituationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumberOfWardsLabel
        '
        NumberOfWardsLabel.AutoSize = True
        NumberOfWardsLabel.Location = New System.Drawing.Point(10, 72)
        NumberOfWardsLabel.Name = "NumberOfWardsLabel"
        NumberOfWardsLabel.Size = New System.Drawing.Size(125, 13)
        NumberOfWardsLabel.TabIndex = 118
        NumberOfWardsLabel.Text = "Number of wards in LGA:"
        '
        'NumberOfVillagesLabel
        '
        NumberOfVillagesLabel.AutoSize = True
        NumberOfVillagesLabel.Location = New System.Drawing.Point(10, 101)
        NumberOfVillagesLabel.Name = "NumberOfVillagesLabel"
        NumberOfVillagesLabel.Size = New System.Drawing.Size(136, 13)
        NumberOfVillagesLabel.TabIndex = 120
        NumberOfVillagesLabel.Text = "Number of villages* in LGA:"
        '
        'NumberOfHouseholdLabel
        '
        NumberOfHouseholdLabel.AutoSize = True
        NumberOfHouseholdLabel.Location = New System.Drawing.Point(10, 128)
        NumberOfHouseholdLabel.Name = "NumberOfHouseholdLabel"
        NumberOfHouseholdLabel.Size = New System.Drawing.Size(115, 13)
        NumberOfHouseholdLabel.TabIndex = 122
        NumberOfHouseholdLabel.Text = "Number Of Household:"
        '
        'NumberOfHouseholdAgricultureLabel
        '
        NumberOfHouseholdAgricultureLabel.AutoSize = True
        NumberOfHouseholdAgricultureLabel.Location = New System.Drawing.Point(10, 157)
        NumberOfHouseholdAgricultureLabel.Name = "NumberOfHouseholdAgricultureLabel"
        NumberOfHouseholdAgricultureLabel.Size = New System.Drawing.Size(168, 13)
        NumberOfHouseholdAgricultureLabel.TabIndex = 124
        NumberOfHouseholdAgricultureLabel.Text = "Number Of Household Agriculture:"
        '
        'DistrictPopulationLabel
        '
        DistrictPopulationLabel.AutoSize = True
        DistrictPopulationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DistrictPopulationLabel.Location = New System.Drawing.Point(7, 325)
        DistrictPopulationLabel.Name = "DistrictPopulationLabel"
        DistrictPopulationLabel.Size = New System.Drawing.Size(115, 13)
        DistrictPopulationLabel.TabIndex = 126
        DistrictPopulationLabel.Text = "District Population:"
        '
        'NumberOfOfficersTrainedLabel
        '
        NumberOfOfficersTrainedLabel.AutoSize = True
        NumberOfOfficersTrainedLabel.Location = New System.Drawing.Point(535, 79)
        NumberOfOfficersTrainedLabel.Name = "NumberOfOfficersTrainedLabel"
        NumberOfOfficersTrainedLabel.Size = New System.Drawing.Size(139, 13)
        NumberOfOfficersTrainedLabel.TabIndex = 128
        NumberOfOfficersTrainedLabel.Text = "Number Of Officers Trained:"
        '
        'NumberOfResourceCentresLabel
        '
        NumberOfResourceCentresLabel.AutoSize = True
        NumberOfResourceCentresLabel.Location = New System.Drawing.Point(535, 105)
        NumberOfResourceCentresLabel.Name = "NumberOfResourceCentresLabel"
        NumberOfResourceCentresLabel.Size = New System.Drawing.Size(149, 13)
        NumberOfResourceCentresLabel.TabIndex = 130
        NumberOfResourceCentresLabel.Text = "Number Of Resource Centres:"
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(306, 37)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(325, 30)
        Me.lblPeriod.TabIndex = 116
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(306, 11)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(312, 29)
        Me.lblArea.TabIndex = 115
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumberOfWardsTextBox
        '
        Me.NumberOfWardsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "NumberOfWards", True))
        Me.NumberOfWardsTextBox.Location = New System.Drawing.Point(184, 72)
        Me.NumberOfWardsTextBox.Name = "NumberOfWardsTextBox"
        Me.NumberOfWardsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfWardsTextBox.TabIndex = 119
        '
        'AppUspAnnuallyIntegratedFillDistrictInfoBindingSource
        '
        Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource.DataMember = "appUspAnnuallyIntegratedFillDistrictInfo"
        Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource.DataSource = Me.AnnuallyIntegratedDataSet
        '
        'AnnuallyIntegratedDataSet
        '
        Me.AnnuallyIntegratedDataSet.DataSetName = "AnnuallyIntegratedDataSet"
        Me.AnnuallyIntegratedDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'NumberOfVillagesTextBox
        '
        Me.NumberOfVillagesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "NumberOfVillages", True))
        Me.NumberOfVillagesTextBox.Location = New System.Drawing.Point(184, 101)
        Me.NumberOfVillagesTextBox.Name = "NumberOfVillagesTextBox"
        Me.NumberOfVillagesTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfVillagesTextBox.TabIndex = 121
        '
        'NumberOfHouseholdTextBox
        '
        Me.NumberOfHouseholdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "NumberOfHousehold", True))
        Me.NumberOfHouseholdTextBox.Location = New System.Drawing.Point(184, 128)
        Me.NumberOfHouseholdTextBox.Name = "NumberOfHouseholdTextBox"
        Me.NumberOfHouseholdTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfHouseholdTextBox.TabIndex = 123
        '
        'NumberOfHouseholdAgricultureTextBox
        '
        Me.NumberOfHouseholdAgricultureTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "NumberOfHouseholdAgriculture", True))
        Me.NumberOfHouseholdAgricultureTextBox.Location = New System.Drawing.Point(184, 157)
        Me.NumberOfHouseholdAgricultureTextBox.Name = "NumberOfHouseholdAgricultureTextBox"
        Me.NumberOfHouseholdAgricultureTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfHouseholdAgricultureTextBox.TabIndex = 125
        '
        'DistrictPopulationTextBox
        '
        Me.DistrictPopulationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "DistrictPopulation", True))
        Me.DistrictPopulationTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DistrictPopulationTextBox.Location = New System.Drawing.Point(131, 322)
        Me.DistrictPopulationTextBox.Name = "DistrictPopulationTextBox"
        Me.DistrictPopulationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DistrictPopulationTextBox.TabIndex = 127
        '
        'NumberOfOfficersTrainedTextBox
        '
        Me.NumberOfOfficersTrainedTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "NumberOfOfficersTrained", True))
        Me.NumberOfOfficersTrainedTextBox.Location = New System.Drawing.Point(709, 76)
        Me.NumberOfOfficersTrainedTextBox.Name = "NumberOfOfficersTrainedTextBox"
        Me.NumberOfOfficersTrainedTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfOfficersTrainedTextBox.TabIndex = 129
        '
        'NumberOfResourceCentresTextBox
        '
        Me.NumberOfResourceCentresTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, "NumberOfResourceCentres", True))
        Me.NumberOfResourceCentresTextBox.Location = New System.Drawing.Point(709, 102)
        Me.NumberOfResourceCentresTextBox.Name = "NumberOfResourceCentresTextBox"
        Me.NumberOfResourceCentresTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfResourceCentresTextBox.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(293, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 13)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "* if it is a town, please write number of mitaa."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(10, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(495, 80)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(328, 1418)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 134
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(286, 1421)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 136
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(427, 1414)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 135
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 300)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "1. Food Situation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(245, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(381, 13)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "(Please calculate the current population based on the latest Population Census)"
        '
        'AppUspAnnuallyIntegratedFillFoodSituationDataGridView
        '
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.AllowUserToAddRows = False
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.AllowUserToDeleteRows = False
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.DataSource = Me.AppUspAnnuallyIntegratedFillFoodSituationBindingSource
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.Location = New System.Drawing.Point(10, 353)
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.Name = "AppUspAnnuallyIntegratedFillFoodSituationDataGridView"
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.ReadOnly = True
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.Size = New System.Drawing.Size(953, 190)
        Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView.TabIndex = 139
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "GroupDescription"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Food Type (i)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "AI"
        Me.DataGridViewTextBoxColumn3.HeaderText = "AI"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ListItemSw"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ListItemSw"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ListItemEn"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Food Crops (ii)"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "TotalProduction"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Total Production (Ton) (iii)"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Factor"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Factor (iv)"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "CerealEquivalent"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Cereal Equivalent (Ton) (v) = (iii) x (iv)"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 120
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "totalcerealequivalent"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Total Cereal Equivalent (Ton) (vi)"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 130
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "requirementofcerealequivalent"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Requirement of Cereal Equivalent (Ton) (vii)"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 130
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "SurplusDeficit"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Surplus/ Deficit (Ton) (viii) = (vi) - (vii)" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 130
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "DistrictPopulation"
        Me.DataGridViewTextBoxColumn12.HeaderText = "DistrictPopulation"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'AppUspAnnuallyIntegratedFillFoodSituationBindingSource
        '
        Me.AppUspAnnuallyIntegratedFillFoodSituationBindingSource.DataMember = "appUspAnnuallyIntegratedFillFoodSituation"
        Me.AppUspAnnuallyIntegratedFillFoodSituationBindingSource.DataSource = Me.AnnuallyIntegratedDataSet
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(10, 551)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(537, 106)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label30, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label20, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(694, 726)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(318, 43)
        Me.TableLayoutPanel4.TabIndex = 143
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(13, 2)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(114, 39)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Number of members in Irrigation Organisations (IO)"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(146, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(166, 39)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Number of farmers using irrigation infrastructures (both members and non members " & _
    "of IO)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label31, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label32, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label34, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label19, 3, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(694, 770)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(318, 31)
        Me.TableLayoutPanel3.TabIndex = 142
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(10, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 13)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Male (vii)"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(73, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 1
        Me.Label32.Text = "Female (viii)"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(160, 9)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(46, 13)
        Me.Label34.TabIndex = 2
        Me.Label34.Text = "Male (ix)"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(245, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Female (x)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 685)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 26)
        Me.Label6.TabIndex = 144
        Me.Label6.Text = "2. Irrigation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2 (a) Irrigation scheme"
        '
        'AppUspAnnuallyIntegratedFillDistrictInfoTableAdapter
        '
        Me.AppUspAnnuallyIntegratedFillDistrictInfoTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.DistrictIrrigationScheme03TableAdapter = Nothing
        Me.TableAdapterManager.SchemeGroupTableAdapter = Nothing
        Me.TableAdapterManager.SchemeListTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = LGMD.AnnuallyIntegratedDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AppUspAnnuallyIntegratedFillFoodSituationTableAdapter
        '
        Me.AppUspAnnuallyIntegratedFillFoodSituationTableAdapter.ClearBeforeFill = True
        '
        'AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource
        '
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource.DataMember = "appUspAnnuallyIntegratedFillIrrigationScheme"
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource.DataSource = Me.AnnuallyIntegratedDataSet
        '
        'AppUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter
        '
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter.ClearBeforeFill = True
        '
        'AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView
        '
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.AllowUserToAddRows = False
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.AllowUserToDeleteRows = False
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.AutoGenerateColumns = False
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.ColumnHeadersVisible = False
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupID, Me.DataGridViewTextBoxColumn14, Me.IrrigationSchemeID, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24})
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.DataSource = Me.AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.Location = New System.Drawing.Point(10, 802)
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.Name = "AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView"
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.ReadOnly = True
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.Size = New System.Drawing.Size(1002, 195)
        Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView.TabIndex = 145
        '
        'GroupID
        '
        Me.GroupID.DataPropertyName = "GroupID"
        Me.GroupID.HeaderText = "GroupID"
        Me.GroupID.Name = "GroupID"
        Me.GroupID.ReadOnly = True
        Me.GroupID.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "GroupName"
        Me.DataGridViewTextBoxColumn14.HeaderText = "GroupName"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'IrrigationSchemeID
        '
        Me.IrrigationSchemeID.DataPropertyName = "IrrigationSchemeID"
        Me.IrrigationSchemeID.HeaderText = "IrrigationSchemeID"
        Me.IrrigationSchemeID.Name = "IrrigationSchemeID"
        Me.IrrigationSchemeID.ReadOnly = True
        Me.IrrigationSchemeID.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "SchemeName"
        Me.DataGridViewTextBoxColumn15.HeaderText = "SchemeName"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "NameOfWaterSource"
        Me.DataGridViewTextBoxColumn16.HeaderText = "NameOfWaterSource"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 80
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "PotentialArea"
        Me.DataGridViewTextBoxColumn17.HeaderText = "PotentialArea"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 77
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "AreaUnderImprovedIrrigation"
        Me.DataGridViewTextBoxColumn18.HeaderText = "AreaUnderImprovedIrrigation"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 79
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Seasonirrigated"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Seasonirrigated"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 93
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "StatusOfScheme"
        Me.DataGridViewTextBoxColumn20.HeaderText = "StatusOfScheme"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 113
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "NumberOfMembersInIrrigationSchemeMale"
        Me.DataGridViewTextBoxColumn21.HeaderText = "NumberOfMembersInIrrigationSchemeMale"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 70
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "NumberOfMembersInIrrigationSchemeFemale"
        Me.DataGridViewTextBoxColumn22.HeaderText = "NumberOfMembersInIrrigationSchemeFemale"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 70
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "NumberOfFarmersUsingInfrastructureMale"
        Me.DataGridViewTextBoxColumn23.HeaderText = "NumberOfFarmersUsingInfrastructureMale"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 88
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "NumberOfFarmersUsingInfrastructureFemale"
        Me.DataGridViewTextBoxColumn24.HeaderText = "NumberOfFarmersUsingInfrastructureFemale"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 89
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "NumberOfFarmersUsingInfrastructureMale"
        Me.DataGridViewTextBoxColumn25.HeaderText = "NumberOfFarmersUsingInfrastructureMale"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "NumberOfFarmersUsingInfrastructureFemale"
        Me.DataGridViewTextBoxColumn26.HeaderText = "NumberOfFarmersUsingInfrastructureFemale"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(482, 24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(83, 26)
        Me.Label28.TabIndex = 4
        Me.Label28.Text = "Season irrigated (v)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(404, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 39)
        Me.Label27.TabIndex = 3
        Me.Label27.Text = "Area under irrigation (ha) (iv)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(327, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 26)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Potential Area (ha) (iii)"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(247, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 52)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Name of water source (e.g., Rufiji river) (ii)"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(159, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 26)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Name of the Scheme (i)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label26, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label27, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label28, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 6, 0)
        Me.TableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 726)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(683, 75)
        Me.TableLayoutPanel2.TabIndex = 141
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(577, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 65)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Status of the scheme  (1=Good, 2=Acceptable, 3=Need repairment, 4=Not known) (vi)" & _
    ""
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 1074)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(218, 13)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "2 (b) Crops harvested under irrigation"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(153, 1100)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(600, 53)
        Me.TableLayoutPanel1.TabIndex = 149
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Planted area (ha) (i)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(256, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Yield (ton/ha) (ii)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(438, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Production (tons) (iii) = (i) x (ii)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel5.ColumnCount = 6
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label13, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label14, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label16, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label15, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label17, 5, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(153, 1154)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(600, 47)
        Me.TableLayoutPanel5.TabIndex = 148
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Rainy season (iv)"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(111, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Dry season (v)"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(204, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Rainy season (vi)"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(402, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Rainy season (viii)"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(309, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Dry season (vii)"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(511, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Dry season (ix)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AppUspAnnuallyIntegratedFillIrrigationBindingSource
        '
        Me.AppUspAnnuallyIntegratedFillIrrigationBindingSource.DataMember = "appUspAnnuallyIntegratedFillIrrigation"
        Me.AppUspAnnuallyIntegratedFillIrrigationBindingSource.DataSource = Me.AnnuallyIntegratedDataSet
        '
        'AppUspAnnuallyIntegratedFillIrrigationTableAdapter
        '
        Me.AppUspAnnuallyIntegratedFillIrrigationTableAdapter.ClearBeforeFill = True
        '
        'AppUspAnnuallyIntegratedFillIrrigationDataGridView
        '
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.AllowUserToAddRows = False
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.AllowUserToDeleteRows = False
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.AutoGenerateColumns = False
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.ColumnHeadersVisible = False
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33})
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.DataSource = Me.AppUspAnnuallyIntegratedFillIrrigationBindingSource
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.Location = New System.Drawing.Point(10, 1202)
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.Name = "AppUspAnnuallyIntegratedFillIrrigationDataGridView"
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.ReadOnly = True
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.Size = New System.Drawing.Size(743, 150)
        Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView.TabIndex = 150
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "CropID"
        Me.DataGridViewTextBoxColumn27.HeaderText = "CropID"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "PlantedAreaRainySeason"
        Me.DataGridViewTextBoxColumn28.HeaderText = "PlantedAreaRainySeason"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "PlantedAreaDrySeason"
        Me.DataGridViewTextBoxColumn29.HeaderText = "PlantedAreaDrySeason"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "ProductionRainySeason"
        Me.DataGridViewTextBoxColumn30.HeaderText = "ProductionRainySeason"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "ProductionDrySeason"
        Me.DataGridViewTextBoxColumn31.HeaderText = "ProductionDrySeason"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "YieldRainySeason"
        Me.DataGridViewTextBoxColumn32.HeaderText = "YieldRainySeason"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "YieldDrySeason"
        Me.DataGridViewTextBoxColumn33.HeaderText = "YieldDrySeason"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(10, 1100)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(142, 101)
        Me.TableLayoutPanel6.TabIndex = 151
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 26)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Type of Crops harvested under irrigation"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Location = New System.Drawing.Point(10, 1009)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(803, 41)
        Me.Label21.TabIndex = 152
        Me.Label21.Text = resources.GetString("Label21.Text")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(10, 1365)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(701, 28)
        Me.Label22.TabIndex = 153
        Me.Label22.Text = resources.GetString("Label22.Text")
        '
        'ctrlDistrict09Page01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TableLayoutPanel6)
        Me.Controls.Add(Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(NumberOfWardsLabel)
        Me.Controls.Add(Me.NumberOfWardsTextBox)
        Me.Controls.Add(NumberOfVillagesLabel)
        Me.Controls.Add(Me.NumberOfVillagesTextBox)
        Me.Controls.Add(NumberOfHouseholdLabel)
        Me.Controls.Add(Me.NumberOfHouseholdTextBox)
        Me.Controls.Add(NumberOfHouseholdAgricultureLabel)
        Me.Controls.Add(Me.NumberOfHouseholdAgricultureTextBox)
        Me.Controls.Add(DistrictPopulationLabel)
        Me.Controls.Add(Me.DistrictPopulationTextBox)
        Me.Controls.Add(NumberOfOfficersTrainedLabel)
        Me.Controls.Add(Me.NumberOfOfficersTrainedTextBox)
        Me.Controls.Add(NumberOfResourceCentresLabel)
        Me.Controls.Add(Me.NumberOfResourceCentresTextBox)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Name = "ctrlDistrict09Page01"
        Me.Size = New System.Drawing.Size(1090, 1476)
        CType(Me.AppUspAnnuallyIntegratedFillDistrictInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnnuallyIntegratedDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspAnnuallyIntegratedFillFoodSituationDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspAnnuallyIntegratedFillFoodSituationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspAnnuallyIntegratedFillIrrigationDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents AnnuallyIntegratedDataSet As LGMD.AnnuallyIntegratedDataSet
    Friend WithEvents AppUspAnnuallyIntegratedFillDistrictInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspAnnuallyIntegratedFillDistrictInfoTableAdapter As LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillDistrictInfoTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.AnnuallyIntegratedDataSetTableAdapters.TableAdapterManager
    Friend WithEvents NumberOfWardsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfVillagesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfHouseholdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfHouseholdAgricultureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DistrictPopulationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfOfficersTrainedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfResourceCentresTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AppUspAnnuallyIntegratedFillFoodSituationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspAnnuallyIntegratedFillFoodSituationTableAdapter As LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillFoodSituationTableAdapter
    Friend WithEvents AppUspAnnuallyIntegratedFillFoodSituationDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AppUspAnnuallyIntegratedFillIrrigationSchemeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter As LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter
    Friend WithEvents AppUspAnnuallyIntegratedFillIrrigationSchemeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents AppUspAnnuallyIntegratedFillIrrigationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspAnnuallyIntegratedFillIrrigationTableAdapter As LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillIrrigationTableAdapter
    Friend WithEvents AppUspAnnuallyIntegratedFillIrrigationDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IrrigationSchemeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label

End Class
