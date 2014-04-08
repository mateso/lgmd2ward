<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlLookUpTable
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLookUpType = New System.Windows.Forms.Label()
        Me.cmbLookUpForm = New System.Windows.Forms.ComboBox()
        Me.cmbLookUpType = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AppUspFillLookUpTablesTypeDataGridView = New System.Windows.Forms.DataGridView()
        Me.btnLookUpSave = New System.Windows.Forms.Button()
        Me.btnLookUpCancel = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AppUspFillLookUpTablesTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LookupTableDataDataSet = New LGMD.LookupTableDataDataSet()
        Me.AppUspFillLookUpTablesTypeTableAdapter = New LGMD.LookupTableDataDataSetTableAdapters.appUspFillLookUpTablesTypeTableAdapter()
        Me.TableAdapterManager = New LGMD.LookupTableDataDataSetTableAdapters.TableAdapterManager()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AppUspFillLookUpTablesTypeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspFillLookUpTablesTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookupTableDataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Form Type"
        '
        'lblLookUpType
        '
        Me.lblLookUpType.AutoSize = True
        Me.lblLookUpType.Location = New System.Drawing.Point(423, 36)
        Me.lblLookUpType.Name = "lblLookUpType"
        Me.lblLookUpType.Size = New System.Drawing.Size(105, 13)
        Me.lblLookUpType.TabIndex = 1
        Me.lblLookUpType.Text = "Select LookUp Type"
        Me.lblLookUpType.Visible = False
        '
        'cmbLookUpForm
        '
        Me.cmbLookUpForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLookUpForm.FormattingEnabled = True
        Me.cmbLookUpForm.Items.AddRange(New Object() {"", "Monthly", "Quarterly", "Annually"})
        Me.cmbLookUpForm.Location = New System.Drawing.Point(95, 33)
        Me.cmbLookUpForm.Name = "cmbLookUpForm"
        Me.cmbLookUpForm.Size = New System.Drawing.Size(322, 21)
        Me.cmbLookUpForm.TabIndex = 4
        '
        'cmbLookUpType
        '
        Me.cmbLookUpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLookUpType.FormattingEnabled = True
        Me.cmbLookUpType.Location = New System.Drawing.Point(525, 33)
        Me.cmbLookUpType.Name = "cmbLookUpType"
        Me.cmbLookUpType.Size = New System.Drawing.Size(219, 21)
        Me.cmbLookUpType.TabIndex = 5
        Me.cmbLookUpType.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbLookUpForm)
        Me.GroupBox1.Controls.Add(Me.cmbLookUpType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblLookUpType)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(771, 101)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Edit LookUp Tables"
        '
        'AppUspFillLookUpTablesTypeDataGridView
        '
        Me.AppUspFillLookUpTablesTypeDataGridView.AllowUserToDeleteRows = False
        Me.AppUspFillLookUpTablesTypeDataGridView.AutoGenerateColumns = False
        Me.AppUspFillLookUpTablesTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspFillLookUpTablesTypeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.AppUspFillLookUpTablesTypeDataGridView.DataSource = Me.AppUspFillLookUpTablesTypeBindingSource
        Me.AppUspFillLookUpTablesTypeDataGridView.Location = New System.Drawing.Point(33, 146)
        Me.AppUspFillLookUpTablesTypeDataGridView.Name = "AppUspFillLookUpTablesTypeDataGridView"
        Me.AppUspFillLookUpTablesTypeDataGridView.Size = New System.Drawing.Size(595, 220)
        Me.AppUspFillLookUpTablesTypeDataGridView.TabIndex = 8
        '
        'btnLookUpSave
        '
        Me.btnLookUpSave.Location = New System.Drawing.Point(322, 373)
        Me.btnLookUpSave.Name = "btnLookUpSave"
        Me.btnLookUpSave.Size = New System.Drawing.Size(75, 31)
        Me.btnLookUpSave.TabIndex = 9
        Me.btnLookUpSave.Text = "Save"
        Me.btnLookUpSave.UseVisualStyleBackColor = True
        '
        'btnLookUpCancel
        '
        Me.btnLookUpCancel.Location = New System.Drawing.Point(487, 374)
        Me.btnLookUpCancel.Name = "btnLookUpCancel"
        Me.btnLookUpCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnLookUpCancel.TabIndex = 10
        Me.btnLookUpCancel.Text = "Cancel"
        Me.btnLookUpCancel.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "LookupID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "LookupID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "LookupSw"
        Me.DataGridViewTextBoxColumn2.HeaderText = "LookupSw"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "LookupEn"
        Me.DataGridViewTextBoxColumn3.HeaderText = "LookupEn"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LookupType"
        Me.DataGridViewTextBoxColumn4.HeaderText = "LookupType"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 2
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "LookupTypeFilter"
        Me.DataGridViewTextBoxColumn5.HeaderText = "LookupTypeFilter"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 2
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "LookupStatus"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Status (Active/Inactive)"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'AppUspFillLookUpTablesTypeBindingSource
        '
        Me.AppUspFillLookUpTablesTypeBindingSource.DataMember = "appUspFillLookUpTablesType"
        Me.AppUspFillLookUpTablesTypeBindingSource.DataSource = Me.LookupTableDataDataSet
        '
        'LookupTableDataDataSet
        '
        Me.LookupTableDataDataSet.DataSetName = "LookupTableDataDataSet"
        Me.LookupTableDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppUspFillLookUpTablesTypeTableAdapter
        '
        Me.AppUspFillLookUpTablesTypeTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = LGMD.LookupTableDataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ctrlLookUpTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnLookUpCancel)
        Me.Controls.Add(Me.btnLookUpSave)
        Me.Controls.Add(Me.AppUspFillLookUpTablesTypeDataGridView)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlLookUpTable"
        Me.Size = New System.Drawing.Size(883, 439)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AppUspFillLookUpTablesTypeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspFillLookUpTablesTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookupTableDataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLookUpType As System.Windows.Forms.Label
    Friend WithEvents cmbLookUpForm As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLookUpType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LookupTableDataDataSet As LGMD.LookupTableDataDataSet
    Friend WithEvents AppUspFillLookUpTablesTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspFillLookUpTablesTypeTableAdapter As LGMD.LookupTableDataDataSetTableAdapters.appUspFillLookUpTablesTypeTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.LookupTableDataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AppUspFillLookUpTablesTypeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnLookUpSave As System.Windows.Forms.Button
    Friend WithEvents btnLookUpCancel As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
