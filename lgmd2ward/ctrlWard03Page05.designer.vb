<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlWard03Page05
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.appUspAnnualFillFertilizerDataGridView = New System.Windows.Forms.DataGridView()
        Me.AppUspAnnualFillFertilizerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LGMDdataDataSet = New LGMD.LGMDdataDataSet()
        Me.AppUspLookupUnitsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LookupTableDataDataSet = New LGMD.LookupTableDataDataSet()
        Me.AppUspAnnualFillFertilizerTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.appUspAnnualFillFertilizerTableAdapter()
        Me.AppUspLookupUnitsTableAdapter = New LGMD.LookupTableDataDataSetTableAdapters.appUspLookupUnitsTableAdapter()
        Me.FertilizerListIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FertilizerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FertilizerStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fertilizer03IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FertilizerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnnualNeedsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnnualUsageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExplanationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnnualRecordIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormSerialIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.appUspAnnualFillFertilizerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspAnnualFillFertilizerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspLookupUnitsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookupTableDataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(266, 46)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(340, 30)
        Me.lblPeriod.TabIndex = 62
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(270, 17)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(325, 29)
        Me.lblArea.TabIndex = 61
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(312, 543)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 63
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(270, 546)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 65
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(411, 539)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 64
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 26)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "6. Pembejeo" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6.1 Mbolea za viwandani" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 500)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(431, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Maelezo: Pia kiasi cha mbolea inayotumika katika kuzalisha malisho ya mifugo ijum" & _
    "uishwe." & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'appUspAnnualFillFertilizerDataGridView
        '
        Me.appUspAnnualFillFertilizerDataGridView.AllowUserToResizeColumns = False
        Me.appUspAnnualFillFertilizerDataGridView.AllowUserToResizeRows = False
        Me.appUspAnnualFillFertilizerDataGridView.AutoGenerateColumns = False
        Me.appUspAnnualFillFertilizerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.appUspAnnualFillFertilizerDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FertilizerListIDDataGridViewTextBoxColumn, Me.FertilizerNameDataGridViewTextBoxColumn, Me.FertilizerStatusDataGridViewTextBoxColumn, Me.Fertilizer03IDDataGridViewTextBoxColumn, Me.FertilizerIDDataGridViewTextBoxColumn, Me.AnnualNeedsDataGridViewTextBoxColumn, Me.AnnualUsageDataGridViewTextBoxColumn, Me.ExplanationDataGridViewTextBoxColumn, Me.AnnualRecordIDDataGridViewTextBoxColumn, Me.FormSerialIDDataGridViewTextBoxColumn})
        Me.appUspAnnualFillFertilizerDataGridView.DataSource = Me.AppUspAnnualFillFertilizerBindingSource
        Me.appUspAnnualFillFertilizerDataGridView.Location = New System.Drawing.Point(28, 116)
        Me.appUspAnnualFillFertilizerDataGridView.Name = "appUspAnnualFillFertilizerDataGridView"
        Me.appUspAnnualFillFertilizerDataGridView.Size = New System.Drawing.Size(842, 375)
        Me.appUspAnnualFillFertilizerDataGridView.TabIndex = 68
        '
        'AppUspAnnualFillFertilizerBindingSource
        '
        Me.AppUspAnnualFillFertilizerBindingSource.DataMember = "appUspAnnualFillFertilizer"
        Me.AppUspAnnualFillFertilizerBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspLookupUnitsBindingSource
        '
        Me.AppUspLookupUnitsBindingSource.DataMember = "appUspLookupUnits"
        Me.AppUspLookupUnitsBindingSource.DataSource = Me.LookupTableDataDataSet
        '
        'LookupTableDataDataSet
        '
        Me.LookupTableDataDataSet.DataSetName = "LookupTableDataDataSet"
        Me.LookupTableDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspAnnualFillFertilizerTableAdapter
        '
        Me.AppUspAnnualFillFertilizerTableAdapter.ClearBeforeFill = True
        '
        'AppUspLookupUnitsTableAdapter
        '
        Me.AppUspLookupUnitsTableAdapter.ClearBeforeFill = True
        '
        'FertilizerListIDDataGridViewTextBoxColumn
        '
        Me.FertilizerListIDDataGridViewTextBoxColumn.DataPropertyName = "FertilizerListID"
        Me.FertilizerListIDDataGridViewTextBoxColumn.HeaderText = "FertilizerListID"
        Me.FertilizerListIDDataGridViewTextBoxColumn.Name = "FertilizerListIDDataGridViewTextBoxColumn"
        Me.FertilizerListIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.FertilizerListIDDataGridViewTextBoxColumn.Visible = False
        '
        'FertilizerNameDataGridViewTextBoxColumn
        '
        Me.FertilizerNameDataGridViewTextBoxColumn.DataPropertyName = "FertilizerName"
        Me.FertilizerNameDataGridViewTextBoxColumn.HeaderText = "Aina ya mbolea"
        Me.FertilizerNameDataGridViewTextBoxColumn.Name = "FertilizerNameDataGridViewTextBoxColumn"
        Me.FertilizerNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FertilizerNameDataGridViewTextBoxColumn.Width = 170
        '
        'FertilizerStatusDataGridViewTextBoxColumn
        '
        Me.FertilizerStatusDataGridViewTextBoxColumn.DataPropertyName = "FertilizerStatus"
        Me.FertilizerStatusDataGridViewTextBoxColumn.HeaderText = "FertilizerStatus"
        Me.FertilizerStatusDataGridViewTextBoxColumn.Name = "FertilizerStatusDataGridViewTextBoxColumn"
        Me.FertilizerStatusDataGridViewTextBoxColumn.Visible = False
        '
        'Fertilizer03IDDataGridViewTextBoxColumn
        '
        Me.Fertilizer03IDDataGridViewTextBoxColumn.DataPropertyName = "Fertilizer03ID"
        Me.Fertilizer03IDDataGridViewTextBoxColumn.HeaderText = "Fertilizer03ID"
        Me.Fertilizer03IDDataGridViewTextBoxColumn.Name = "Fertilizer03IDDataGridViewTextBoxColumn"
        Me.Fertilizer03IDDataGridViewTextBoxColumn.Visible = False
        '
        'FertilizerIDDataGridViewTextBoxColumn
        '
        Me.FertilizerIDDataGridViewTextBoxColumn.DataPropertyName = "FertilizerID"
        Me.FertilizerIDDataGridViewTextBoxColumn.HeaderText = "FertilizerID"
        Me.FertilizerIDDataGridViewTextBoxColumn.Name = "FertilizerIDDataGridViewTextBoxColumn"
        Me.FertilizerIDDataGridViewTextBoxColumn.Visible = False
        '
        'AnnualNeedsDataGridViewTextBoxColumn
        '
        Me.AnnualNeedsDataGridViewTextBoxColumn.DataPropertyName = "AnnualNeeds"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AnnualNeedsDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.AnnualNeedsDataGridViewTextBoxColumn.HeaderText = "Mahitaji kwa mwaka (tani)" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.AnnualNeedsDataGridViewTextBoxColumn.Name = "AnnualNeedsDataGridViewTextBoxColumn"
        Me.AnnualNeedsDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AnnualNeedsDataGridViewTextBoxColumn.Width = 160
        '
        'AnnualUsageDataGridViewTextBoxColumn
        '
        Me.AnnualUsageDataGridViewTextBoxColumn.DataPropertyName = "AnnualUsage"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AnnualUsageDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AnnualUsageDataGridViewTextBoxColumn.HeaderText = "Matumizi kwa mwaka (tani)"
        Me.AnnualUsageDataGridViewTextBoxColumn.Name = "AnnualUsageDataGridViewTextBoxColumn"
        Me.AnnualUsageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AnnualUsageDataGridViewTextBoxColumn.Width = 160
        '
        'ExplanationDataGridViewTextBoxColumn
        '
        Me.ExplanationDataGridViewTextBoxColumn.DataPropertyName = "Explanation"
        Me.ExplanationDataGridViewTextBoxColumn.HeaderText = "Maelezo"
        Me.ExplanationDataGridViewTextBoxColumn.Name = "ExplanationDataGridViewTextBoxColumn"
        Me.ExplanationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ExplanationDataGridViewTextBoxColumn.Width = 309
        '
        'AnnualRecordIDDataGridViewTextBoxColumn
        '
        Me.AnnualRecordIDDataGridViewTextBoxColumn.DataPropertyName = "AnnualRecordID"
        Me.AnnualRecordIDDataGridViewTextBoxColumn.HeaderText = "AnnualRecordID"
        Me.AnnualRecordIDDataGridViewTextBoxColumn.Name = "AnnualRecordIDDataGridViewTextBoxColumn"
        Me.AnnualRecordIDDataGridViewTextBoxColumn.Visible = False
        '
        'FormSerialIDDataGridViewTextBoxColumn
        '
        Me.FormSerialIDDataGridViewTextBoxColumn.DataPropertyName = "FormSerialID"
        Me.FormSerialIDDataGridViewTextBoxColumn.HeaderText = "FormSerialID"
        Me.FormSerialIDDataGridViewTextBoxColumn.Name = "FormSerialIDDataGridViewTextBoxColumn"
        Me.FormSerialIDDataGridViewTextBoxColumn.Visible = False
        '
        'ctrlWard03Page05
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.appUspAnnualFillFertilizerDataGridView)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Name = "ctrlWard03Page05"
        Me.Size = New System.Drawing.Size(970, 600)
        CType(Me.appUspAnnualFillFertilizerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspAnnualFillFertilizerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspLookupUnitsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookupTableDataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents appUspAnnualFillFertilizerDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Expr2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PestcideListIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PestcideGroupIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PestcideTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PestcideTypeIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expr1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeedListIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeedGroupIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CropNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AppUspAnnualFillFertilizerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents AppUspAnnualFillFertilizerTableAdapter As LGMD.LGMDdataDataSetTableAdapters.appUspAnnualFillFertilizerTableAdapter
    Friend WithEvents AppUspLookupUnitsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LookupTableDataDataSet As LGMD.LookupTableDataDataSet
    Friend WithEvents AppUspLookupUnitsTableAdapter As LGMD.LookupTableDataDataSetTableAdapters.appUspLookupUnitsTableAdapter
    Friend WithEvents FertilizerListIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FertilizerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FertilizerStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fertilizer03IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FertilizerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnualNeedsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnualUsageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExplanationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnualRecordIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormSerialIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
