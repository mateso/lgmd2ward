<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlWard02Page01
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
        Dim OfficerNameLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlWard02Page01))
        Me.lblWard = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.RecordInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtWardName = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmoFoodStatus = New System.Windows.Forms.ComboBox()
        Me.FoodCondition02BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FoodStatusListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtEnoughFood = New System.Windows.Forms.TextBox()
        Me.txtNoFood = New System.Windows.Forms.TextBox()
        Me.txtLessFood = New System.Windows.Forms.TextBox()
        Me.txtExcessFood = New System.Windows.Forms.TextBox()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.FoodStatusListTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.FoodStatusListTableAdapter()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.FoodCondition02TableAdapter = New LGMD.LGMDdataDataSetTableAdapters.FoodCondition02TableAdapter()
        Me.txtQuarter = New System.Windows.Forms.TextBox()
        Me.txtMonthStart = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.txtMonthEnd = New System.Windows.Forms.TextBox()
        Me.RecordInfoTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.RecordInfoTableAdapter()
        Me.TableAdapterManager = New LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager()
        Me.txtOfficerName = New System.Windows.Forms.TextBox()
        OfficerNameLabel = New System.Windows.Forms.Label()
        CType(Me.RecordInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.FoodCondition02BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FoodStatusListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficerNameLabel
        '
        OfficerNameLabel.AutoSize = True
        OfficerNameLabel.Location = New System.Drawing.Point(46, 122)
        OfficerNameLabel.Name = "OfficerNameLabel"
        OfficerNameLabel.Size = New System.Drawing.Size(94, 13)
        OfficerNameLabel.TabIndex = 60
        OfficerNameLabel.Text = "Jina la Afisa Ugani"
        '
        'lblWard
        '
        Me.lblWard.AutoSize = True
        Me.lblWard.Location = New System.Drawing.Point(46, 89)
        Me.lblWard.Name = "lblWard"
        Me.lblWard.Size = New System.Drawing.Size(122, 13)
        Me.lblWard.TabIndex = 0
        Me.lblWard.Text = "Jina la Kijiji/ Mtaa/ Kata:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Robo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(160, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Mwezi:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(355, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Mwaka wa Fedha:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(547, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tarehe ya kuwasilisha:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RecordInfoBindingSource, "SubmissionDate", True))
        Me.DateTimePicker1.Location = New System.Drawing.Point(663, 167)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(161, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'RecordInfoBindingSource
        '
        Me.RecordInfoBindingSource.DataMember = "RecordInfo"
        Me.RecordInfoBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(772, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = " (Iwasilishwe kwenye kata kabla ya mwisho wa robo mwaka kutoka kwenye kijiji, na " & _
    "wilayani mwisho wa wiki ya kwanza ya mwezi unaofuata kutoka kwenye kata)" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & _
    "" & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(809, 184)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(453, 143)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = resources.GetString("Label11.Text")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 452)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "1. Hali ya chakula kijiji/ kata" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 571)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(319, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Eleza hali ya upatikanaji wa chakula kwa kipindi cha robo mwaka."
        '
        'txtWardName
        '
        Me.txtWardName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWardName.Enabled = False
        Me.txtWardName.Location = New System.Drawing.Point(168, 87)
        Me.txtWardName.Name = "txtWardName"
        Me.txtWardName.Size = New System.Drawing.Size(209, 20)
        Me.txtWardName.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.44681!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 723.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(29, 481)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(809, 37)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 26)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Hali ya Chakula"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.Location = New System.Drawing.Point(422, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Maelezo" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'cmoFoodStatus
        '
        Me.cmoFoodStatus.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.FoodCondition02BindingSource, "FoodStatustID", True))
        Me.cmoFoodStatus.DataSource = Me.FoodStatusListBindingSource
        Me.cmoFoodStatus.DisplayMember = "StatusDescription"
        Me.cmoFoodStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoFoodStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoFoodStatus.FormattingEnabled = True
        Me.cmoFoodStatus.Location = New System.Drawing.Point(29, 519)
        Me.cmoFoodStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.cmoFoodStatus.Name = "cmoFoodStatus"
        Me.cmoFoodStatus.Size = New System.Drawing.Size(86, 21)
        Me.cmoFoodStatus.TabIndex = 7
        Me.cmoFoodStatus.ValueMember = "FoodStatusListID"
        '
        'FoodCondition02BindingSource
        '
        Me.FoodCondition02BindingSource.DataMember = "FoodCondition02"
        Me.FoodCondition02BindingSource.DataSource = Me.LGMDdataDataSet
        '
        'FoodStatusListBindingSource
        '
        Me.FoodStatusListBindingSource.DataMember = "FoodStatusList"
        Me.FoodStatusListBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FoodCondition02BindingSource, "Remarks", True))
        Me.txtRemarks.Location = New System.Drawing.Point(116, 519)
        Me.txtRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(722, 20)
        Me.txtRemarks.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 3, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(29, 598)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(875, 35)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(179, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "idadi ya kaya zisizokuwa na chakula" & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(235, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(184, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Idadi ya kaya zenye chakula pungufu" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(449, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(204, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Idadi ya kaya zenye chakula cha kutosha" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(674, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(191, 13)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Idadi ya kaya zenye chakula cha ziada" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'txtEnoughFood
        '
        Me.txtEnoughFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEnoughFood.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FoodCondition02BindingSource, "FamilyEnoughFood", True))
        Me.txtEnoughFood.Location = New System.Drawing.Point(471, 634)
        Me.txtEnoughFood.Margin = New System.Windows.Forms.Padding(0)
        Me.txtEnoughFood.Name = "txtEnoughFood"
        Me.txtEnoughFood.Size = New System.Drawing.Size(221, 20)
        Me.txtEnoughFood.TabIndex = 11
        Me.txtEnoughFood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoFood
        '
        Me.txtNoFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoFood.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FoodCondition02BindingSource, "FamilyNoFood", True))
        Me.txtNoFood.Location = New System.Drawing.Point(29, 634)
        Me.txtNoFood.Margin = New System.Windows.Forms.Padding(0)
        Me.txtNoFood.Name = "txtNoFood"
        Me.txtNoFood.Size = New System.Drawing.Size(214, 20)
        Me.txtNoFood.TabIndex = 9
        Me.txtNoFood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLessFood
        '
        Me.txtLessFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLessFood.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FoodCondition02BindingSource, "FamilyLessFood", True))
        Me.txtLessFood.Location = New System.Drawing.Point(244, 634)
        Me.txtLessFood.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLessFood.Name = "txtLessFood"
        Me.txtLessFood.Size = New System.Drawing.Size(226, 20)
        Me.txtLessFood.TabIndex = 10
        Me.txtLessFood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExcessFood
        '
        Me.txtExcessFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExcessFood.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FoodCondition02BindingSource, "FamilyExcessFood", True))
        Me.txtExcessFood.Location = New System.Drawing.Point(693, 634)
        Me.txtExcessFood.Margin = New System.Windows.Forms.Padding(0)
        Me.txtExcessFood.Name = "txtExcessFood"
        Me.txtExcessFood.Size = New System.Drawing.Size(211, 20)
        Me.txtExcessFood.TabIndex = 12
        Me.txtExcessFood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(258, 40)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(290, 30)
        Me.lblPeriod.TabIndex = 23
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(258, 11)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(290, 29)
        Me.lblArea.TabIndex = 22
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(360, 676)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 13
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(318, 679)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 55
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(459, 672)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 14
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'FoodStatusListTableAdapter
        '
        Me.FoodStatusListTableAdapter.ClearBeforeFill = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(255, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Mpaka:"
        '
        'FoodCondition02TableAdapter
        '
        Me.FoodCondition02TableAdapter.ClearBeforeFill = True
        '
        'txtQuarter
        '
        Me.txtQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuarter.Enabled = False
        Me.txtQuarter.Location = New System.Drawing.Point(89, 167)
        Me.txtQuarter.Name = "txtQuarter"
        Me.txtQuarter.Size = New System.Drawing.Size(65, 20)
        Me.txtQuarter.TabIndex = 2
        '
        'txtMonthStart
        '
        Me.txtMonthStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonthStart.Enabled = False
        Me.txtMonthStart.Location = New System.Drawing.Point(199, 167)
        Me.txtMonthStart.Name = "txtMonthStart"
        Me.txtMonthStart.Size = New System.Drawing.Size(54, 20)
        Me.txtMonthStart.TabIndex = 3
        '
        'txtYear
        '
        Me.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYear.Enabled = False
        Me.txtYear.Location = New System.Drawing.Point(448, 167)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(93, 20)
        Me.txtYear.TabIndex = 5
        '
        'txtMonthEnd
        '
        Me.txtMonthEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonthEnd.Enabled = False
        Me.txtMonthEnd.Location = New System.Drawing.Point(302, 167)
        Me.txtMonthEnd.Name = "txtMonthEnd"
        Me.txtMonthEnd.Size = New System.Drawing.Size(55, 20)
        Me.txtMonthEnd.TabIndex = 4
        '
        'RecordInfoTableAdapter
        '
        Me.RecordInfoTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.FoodCondition02TableAdapter = Me.FoodCondition02TableAdapter
        Me.TableAdapterManager.FoodSituation05TableAdapter = Nothing
        Me.TableAdapterManager.FoodStatusListTableAdapter = Me.FoodStatusListTableAdapter
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
        Me.TableAdapterManager.RecordInfoTableAdapter = Me.RecordInfoTableAdapter
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
        'txtOfficerName
        '
        Me.txtOfficerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOfficerName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecordInfoBindingSource, "OfficerName", True))
        Me.txtOfficerName.Location = New System.Drawing.Point(168, 119)
        Me.txtOfficerName.Name = "txtOfficerName"
        Me.txtOfficerName.Size = New System.Drawing.Size(209, 20)
        Me.txtOfficerName.TabIndex = 1
        '
        'ctrlWard02Page01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtEnoughFood)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtNoFood)
        Me.Controls.Add(Me.cmoFoodStatus)
        Me.Controls.Add(Me.txtLessFood)
        Me.Controls.Add(Me.txtExcessFood)
        Me.Controls.Add(OfficerNameLabel)
        Me.Controls.Add(Me.txtOfficerName)
        Me.Controls.Add(Me.txtMonthEnd)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.txtMonthStart)
        Me.Controls.Add(Me.txtQuarter)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtWardName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblWard)
        Me.Name = "ctrlWard02Page01"
        Me.Size = New System.Drawing.Size(1028, 722)
        CType(Me.RecordInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.FoodCondition02BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FoodStatusListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblWard As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtWardName As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmoFoodStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtEnoughFood As System.Windows.Forms.TextBox
    Friend WithEvents txtNoFood As System.Windows.Forms.TextBox
    Friend WithEvents txtLessFood As System.Windows.Forms.TextBox
    Friend WithEvents txtExcessFood As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents FoodStatusListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents FoodStatusListTableAdapter As LGMD.LGMDdataDataSetTableAdapters.FoodStatusListTableAdapter
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FoodCondition02BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FoodCondition02TableAdapter As LGMD.LGMDdataDataSetTableAdapters.FoodCondition02TableAdapter
    Friend WithEvents txtQuarter As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthStart As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthEnd As System.Windows.Forms.TextBox
    Friend WithEvents RecordInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecordInfoTableAdapter As LGMD.LGMDdataDataSetTableAdapters.RecordInfoTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents txtOfficerName As System.Windows.Forms.TextBox

End Class
