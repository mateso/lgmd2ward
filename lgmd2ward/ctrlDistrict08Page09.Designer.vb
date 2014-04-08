<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDistrict08Page09
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.QuarterlyIntegratedDataSet = New LGMD.QuarterlyIntegratedDataSet()
        Me.AppUspQuarterlyIntegratedFillReproductionInputBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AppUspQuarterlyIntegratedFillReproductionInputTableAdapter = New LGMD.QuarterlyIntegratedDataSetTableAdapters.appUspQuarterlyIntegratedFillReproductionInputTableAdapter()
        Me.TableAdapterManager = New LGMD.QuarterlyIntegratedDataSetTableAdapters.TableAdapterManager()
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
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
        CType(Me.QuarterlyIntegratedDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspQuarterlyIntegratedFillReproductionInputBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(265, 552)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 59
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(223, 555)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 61
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(364, 548)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 60
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(294, 48)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(325, 30)
        Me.lblPeriod.TabIndex = 114
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(294, 22)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(312, 29)
        Me.lblArea.TabIndex = 113
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 13)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "7 (b). Inputs for reproduction of improved livestock"
        '
        'QuarterlyIntegratedDataSet
        '
        Me.QuarterlyIntegratedDataSet.DataSetName = "QuarterlyIntegratedDataSet"
        Me.QuarterlyIntegratedDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspQuarterlyIntegratedFillReproductionInputBindingSource
        '
        Me.AppUspQuarterlyIntegratedFillReproductionInputBindingSource.DataMember = "appUspQuarterlyIntegratedFillReproductionInput"
        Me.AppUspQuarterlyIntegratedFillReproductionInputBindingSource.DataSource = Me.QuarterlyIntegratedDataSet
        '
        'AppUspQuarterlyIntegratedFillReproductionInputTableAdapter
        '
        Me.AppUspQuarterlyIntegratedFillReproductionInputTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = LGMD.QuarterlyIntegratedDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AppUspQuarterlyIntegratedFillReproductionInputDataGridView
        '
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.AllowUserToAddRows = False
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.AllowUserToDeleteRows = False
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.DataSource = Me.AppUspQuarterlyIntegratedFillReproductionInputBindingSource
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Location = New System.Drawing.Point(29, 116)
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Name = "AppUspQuarterlyIntegratedFillReproductionInputDataGridView"
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.ReadOnly = True
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Size = New System.Drawing.Size(843, 366)
        Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.TabIndex = 117
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(26, 503)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(358, 15)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Note: (iii) and (iv) Number of doses for semen; numbers for bulls and heifer."
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
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
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
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ListItemStatus"
        Me.DataGridViewTextBoxColumn5.HeaderText = "ListItemStatus"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ReproductionInputsID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ReproductionInputsID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "InputID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "InputID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Breed"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Breed (ii)"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "AmountRequired"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Amount required in the quarter (doses or number) (iii)"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 150
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "AmountAvailable"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Amount available in the quarter (doses or number) (iv)"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 150
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Remarks"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Remarks (v)"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 300
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "QuarterlyRecordID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "QuarterlyRecordID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'ctrlDistrict08Page09
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Name = "ctrlDistrict08Page09"
        Me.Size = New System.Drawing.Size(1059, 612)
        CType(Me.QuarterlyIntegratedDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspQuarterlyIntegratedFillReproductionInputBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents QuarterlyIntegratedDataSet As LGMD.QuarterlyIntegratedDataSet
    Friend WithEvents AppUspQuarterlyIntegratedFillReproductionInputBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspQuarterlyIntegratedFillReproductionInputTableAdapter As LGMD.QuarterlyIntegratedDataSetTableAdapters.appUspQuarterlyIntegratedFillReproductionInputTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.QuarterlyIntegratedDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AppUspQuarterlyIntegratedFillReproductionInputDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
