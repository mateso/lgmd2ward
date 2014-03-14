<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlWard01Page08
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
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAchievement = New System.Windows.Forms.TextBox()
        Me.CommentsOfVillageOfficer01BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.txtChallenge = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PeopleWhoVisitTheVillage01BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CommentsOfVillageOfficer01TableAdapter = New LGMD.LGMDdataDataSetTableAdapters.CommentsOfVillageOfficer01TableAdapter()
        Me.PeopleWhoVisitTheVillage01TableAdapter = New LGMD.LGMDdataDataSetTableAdapters.PeopleWhoVisitTheVillage01TableAdapter()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VisitingDateDataGridViewTextBoxColumn = New LGMD.CalendarColumn()
        Me.NameOfVisitorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainPurposeOfVisitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MonthlyRecordIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.CommentsOfVillageOfficer01BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeopleWhoVisitTheVillage01BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(269, 33)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(325, 30)
        Me.lblPeriod.TabIndex = 62
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(269, 7)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(312, 29)
        Me.lblArea.TabIndex = 61
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(308, 833)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 3
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(266, 836)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 65
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(407, 829)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "8. Maoni ya Afisa Ugani wa kijiji/ kata kuhusu sekta ya kilimo katika eneo lake"
        '
        'txtAchievement
        '
        Me.txtAchievement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAchievement.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommentsOfVillageOfficer01BindingSource, "Achievement", True))
        Me.txtAchievement.Location = New System.Drawing.Point(28, 106)
        Me.txtAchievement.Multiline = True
        Me.txtAchievement.Name = "txtAchievement"
        Me.txtAchievement.Size = New System.Drawing.Size(897, 218)
        Me.txtAchievement.TabIndex = 0
        '
        'CommentsOfVillageOfficer01BindingSource
        '
        Me.CommentsOfVillageOfficer01BindingSource.DataMember = "CommentsOfVillageOfficer01"
        Me.CommentsOfVillageOfficer01BindingSource.DataSource = Me.LGMDdataDataSet
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtChallenge
        '
        Me.txtChallenge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallenge.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommentsOfVillageOfficer01BindingSource, "Challenges", True))
        Me.txtChallenge.Location = New System.Drawing.Point(28, 354)
        Me.txtChallenge.Multiline = True
        Me.txtChallenge.Name = "txtChallenge"
        Me.txtChallenge.Size = New System.Drawing.Size(897, 220)
        Me.txtChallenge.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 581)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(329, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "9. Wageni waliotembelea kijiji/kata kwa shughuli za Kilimo au ufugaji"
        '
        'PeopleWhoVisitTheVillage01BindingSource
        '
        Me.PeopleWhoVisitTheVillage01BindingSource.DataMember = "PeopleWhoVisitTheVillage01"
        Me.PeopleWhoVisitTheVillage01BindingSource.DataSource = Me.LGMDdataDataSet
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Mafanikio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 338)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Changamoto/Matatizo:"
        '
        'CommentsOfVillageOfficer01TableAdapter
        '
        Me.CommentsOfVillageOfficer01TableAdapter.ClearBeforeFill = True
        '
        'PeopleWhoVisitTheVillage01TableAdapter
        '
        Me.PeopleWhoVisitTheVillage01TableAdapter.ClearBeforeFill = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn, Me.VisitingDateDataGridViewTextBoxColumn, Me.NameOfVisitorDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn, Me.MainPurposeOfVisitDataGridViewTextBoxColumn, Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn, Me.MonthlyRecordIDDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PeopleWhoVisitTheVillage01BindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(28, 606)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(897, 201)
        Me.DataGridView1.TabIndex = 2
        '
        'PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn
        '
        Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn.DataPropertyName = "PeopleWhoVisitTheVillageID"
        Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn.HeaderText = "PeopleWhoVisitTheVillageID"
        Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn.Name = "PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn"
        Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn.Visible = False
        '
        'VisitingDateDataGridViewTextBoxColumn
        '
        Me.VisitingDateDataGridViewTextBoxColumn.DataPropertyName = "VisitingDate"
        DataGridViewCellStyle1.Format = "d"
        Me.VisitingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.VisitingDateDataGridViewTextBoxColumn.HeaderText = "Tarehe"
        Me.VisitingDateDataGridViewTextBoxColumn.Name = "VisitingDateDataGridViewTextBoxColumn"
        Me.VisitingDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'NameOfVisitorDataGridViewTextBoxColumn
        '
        Me.NameOfVisitorDataGridViewTextBoxColumn.DataPropertyName = "NameOfVisitor"
        Me.NameOfVisitorDataGridViewTextBoxColumn.HeaderText = "Jina la mgeni" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.NameOfVisitorDataGridViewTextBoxColumn.Name = "NameOfVisitorDataGridViewTextBoxColumn"
        Me.NameOfVisitorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NameOfVisitorDataGridViewTextBoxColumn.Width = 150
        '
        'AddressDataGridViewTextBoxColumn
        '
        Me.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn.HeaderText = "Anuani" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        Me.AddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AddressDataGridViewTextBoxColumn.Width = 150
        '
        'MainPurposeOfVisitDataGridViewTextBoxColumn
        '
        Me.MainPurposeOfVisitDataGridViewTextBoxColumn.DataPropertyName = "MainPurposeOfVisit"
        Me.MainPurposeOfVisitDataGridViewTextBoxColumn.HeaderText = "Shughuli iliyomleta" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9)
        Me.MainPurposeOfVisitDataGridViewTextBoxColumn.Name = "MainPurposeOfVisitDataGridViewTextBoxColumn"
        Me.MainPurposeOfVisitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MainPurposeOfVisitDataGridViewTextBoxColumn.Width = 200
        '
        'InstructionsAdviceProvidedDataGridViewTextBoxColumn
        '
        Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn.DataPropertyName = "InstructionsAdviceProvided"
        Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn.HeaderText = "Maagizo/ ushauri wa mgeni " & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9)
        Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn.Name = "InstructionsAdviceProvidedDataGridViewTextBoxColumn"
        Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.InstructionsAdviceProvidedDataGridViewTextBoxColumn.Width = 254
        '
        'MonthlyRecordIDDataGridViewTextBoxColumn
        '
        Me.MonthlyRecordIDDataGridViewTextBoxColumn.DataPropertyName = "MonthlyRecordID"
        Me.MonthlyRecordIDDataGridViewTextBoxColumn.HeaderText = "MonthlyRecordID"
        Me.MonthlyRecordIDDataGridViewTextBoxColumn.Name = "MonthlyRecordIDDataGridViewTextBoxColumn"
        Me.MonthlyRecordIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MonthlyRecordIDDataGridViewTextBoxColumn.Visible = False
        '
        'ctrlWard01Page08
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtChallenge)
        Me.Controls.Add(Me.txtAchievement)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Name = "ctrlWard01Page08"
        Me.Size = New System.Drawing.Size(995, 880)
        CType(Me.CommentsOfVillageOfficer01BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeopleWhoVisitTheVillage01BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAchievement As System.Windows.Forms.TextBox
    Friend WithEvents txtChallenge As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CommentsOfVillageOfficer01BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents CommentsOfVillageOfficer01TableAdapter As LGMD.LGMDdataDataSetTableAdapters.CommentsOfVillageOfficer01TableAdapter
    Friend WithEvents PeopleWhoVisitTheVillage01BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PeopleWhoVisitTheVillage01TableAdapter As LGMD.LGMDdataDataSetTableAdapters.PeopleWhoVisitTheVillage01TableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PeopleWhoVisitTheVillageIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisitingDateDataGridViewTextBoxColumn As LGMD.CalendarColumn
    Friend WithEvents NameOfVisitorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainPurposeOfVisitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstructionsAdviceProvidedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthlyRecordIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
