<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDistrict09Page02
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlDistrict09Page02))
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppUspAnnuallyIntegratedFillMachinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AnnuallyIntegratedDataSet = New LGMD.AnnuallyIntegratedDataSet()
        Me.AppUspAnnuallyIntegratedFillMachinesTableAdapter = New LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillMachinesTableAdapter()
        Me.TableAdapterManager = New LGMD.AnnuallyIntegratedDataSetTableAdapters.TableAdapterManager()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.AppUspAnnuallyIntegratedFillMachinesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspAnnuallyIntegratedFillMachinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnnuallyIntegratedDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(363, 41)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(325, 30)
        Me.lblPeriod.TabIndex = 118
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(363, 15)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(312, 29)
        Me.lblArea.TabIndex = 117
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(228, 588)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 119
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(186, 591)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 121
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(327, 584)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 120
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(980, 26)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(309, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "3 (a) Number of Agricultural Machines and Equipment"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(379, 185)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(319, 36)
        Me.TableLayoutPanel1.TabIndex = 126
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 26)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Individually owned(ii)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(82, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 26)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Group-owned (iii)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(168, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 26)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Individually owned (iv)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 26)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Group-owned (v)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label19, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label22, 1, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(379, 161)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(319, 23)
        Me.TableLayoutPanel5.TabIndex = 125
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(55, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Working"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(218, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Not working"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 387.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(15, 161)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(363, 60)
        Me.TableLayoutPanel2.TabIndex = 124
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(107, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(175, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Type of machines and equipment (i)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AppUspAnnuallyIntegratedFillMachinesDataGridView
        '
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.AllowUserToAddRows = False
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.AllowUserToDeleteRows = False
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.AutoGenerateColumns = False
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.DataSource = Me.AppUspAnnuallyIntegratedFillMachinesBindingSource
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.Location = New System.Drawing.Point(15, 222)
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.Name = "AppUspAnnuallyIntegratedFillMachinesDataGridView"
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.ReadOnly = True
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.Size = New System.Drawing.Size(683, 173)
        Me.AppUspAnnuallyIntegratedFillMachinesDataGridView.TabIndex = 128
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ListItemSw"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ListItemSw"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 322
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "WorkingIndividuallyOwned"
        Me.DataGridViewTextBoxColumn2.HeaderText = "WorkingIndividuallyOwned"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 78
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "WorkingGroupOwned"
        Me.DataGridViewTextBoxColumn3.HeaderText = "WorkingGroupOwned"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NotWorkingIndividuallyOwned"
        Me.DataGridViewTextBoxColumn4.HeaderText = "NotWorkingIndividuallyOwned"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "NotWorkingGroupowned"
        Me.DataGridViewTextBoxColumn5.HeaderText = "NotWorkingGroupowned"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'AppUspAnnuallyIntegratedFillMachinesBindingSource
        '
        Me.AppUspAnnuallyIntegratedFillMachinesBindingSource.DataMember = "appUspAnnuallyIntegratedFillMachines"
        Me.AppUspAnnuallyIntegratedFillMachinesBindingSource.DataSource = Me.AnnuallyIntegratedDataSet
        '
        'AnnuallyIntegratedDataSet
        '
        Me.AnnuallyIntegratedDataSet.DataSetName = "AnnuallyIntegratedDataSet"
        Me.AnnuallyIntegratedDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspAnnuallyIntegratedFillMachinesTableAdapter
        '
        Me.AppUspAnnuallyIntegratedFillMachinesTableAdapter.ClearBeforeFill = True
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
        'ctrlDistrict09Page02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AppUspAnnuallyIntegratedFillMachinesDataGridView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Name = "ctrlDistrict09Page02"
        Me.Size = New System.Drawing.Size(1043, 631)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.AppUspAnnuallyIntegratedFillMachinesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspAnnuallyIntegratedFillMachinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnnuallyIntegratedDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AnnuallyIntegratedDataSet As LGMD.AnnuallyIntegratedDataSet
    Friend WithEvents AppUspAnnuallyIntegratedFillMachinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspAnnuallyIntegratedFillMachinesTableAdapter As LGMD.AnnuallyIntegratedDataSetTableAdapters.appUspAnnuallyIntegratedFillMachinesTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.AnnuallyIntegratedDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AppUspAnnuallyIntegratedFillMachinesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
