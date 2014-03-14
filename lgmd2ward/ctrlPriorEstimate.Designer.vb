<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlPriorEstimate
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblListItem = New System.Windows.Forms.Label()
        Me.cmbListItem = New System.Windows.Forms.ComboBox()
        Me.lblIndicatorName = New System.Windows.Forms.Label()
        Me.cmbIndicatorList = New System.Windows.Forms.ComboBox()
        Me.AppUspFillPriorEstimatesDataGridView = New System.Windows.Forms.DataGridView()
        Me.AppUspFillPriorEstimatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DistrictAggregatedDataSet = New LGMD.DistrictAggregatedDataSet()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.AppUspFillPriorEstimatesTableAdapter = New LGMD.DistrictAggregatedDataSetTableAdapters.appUspFillPriorEstimatesTableAdapter()
        Me.TableAdapterManager = New LGMD.DistrictAggregatedDataSetTableAdapters.TableAdapterManager()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AppUspFillPriorEstimatesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppUspFillPriorEstimatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DistrictAggregatedDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblListItem)
        Me.GroupBox1.Controls.Add(Me.cmbListItem)
        Me.GroupBox1.Controls.Add(Me.lblIndicatorName)
        Me.GroupBox1.Controls.Add(Me.cmbIndicatorList)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(704, 85)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Indicator"
        '
        'lblListItem
        '
        Me.lblListItem.AutoSize = True
        Me.lblListItem.Location = New System.Drawing.Point(410, 40)
        Me.lblListItem.Name = "lblListItem"
        Me.lblListItem.Size = New System.Drawing.Size(63, 13)
        Me.lblListItem.TabIndex = 3
        Me.lblListItem.Text = "Select Item:"
        Me.lblListItem.Visible = False
        '
        'cmbListItem
        '
        Me.cmbListItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbListItem.FormattingEnabled = True
        Me.cmbListItem.Location = New System.Drawing.Point(481, 36)
        Me.cmbListItem.Name = "cmbListItem"
        Me.cmbListItem.Size = New System.Drawing.Size(208, 21)
        Me.cmbListItem.TabIndex = 2
        Me.cmbListItem.Visible = False
        '
        'lblIndicatorName
        '
        Me.lblIndicatorName.AutoSize = True
        Me.lblIndicatorName.Location = New System.Drawing.Point(10, 40)
        Me.lblIndicatorName.Name = "lblIndicatorName"
        Me.lblIndicatorName.Size = New System.Drawing.Size(82, 13)
        Me.lblIndicatorName.TabIndex = 1
        Me.lblIndicatorName.Text = "Indicator Name:"
        '
        'cmbIndicatorList
        '
        Me.cmbIndicatorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIndicatorList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIndicatorList.FormattingEnabled = True
        Me.cmbIndicatorList.Location = New System.Drawing.Point(98, 36)
        Me.cmbIndicatorList.Name = "cmbIndicatorList"
        Me.cmbIndicatorList.Size = New System.Drawing.Size(274, 21)
        Me.cmbIndicatorList.TabIndex = 0
        '
        'AppUspFillPriorEstimatesDataGridView
        '
        Me.AppUspFillPriorEstimatesDataGridView.AllowUserToAddRows = False
        Me.AppUspFillPriorEstimatesDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AppUspFillPriorEstimatesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.AppUspFillPriorEstimatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppUspFillPriorEstimatesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.ListID, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.AppUspFillPriorEstimatesDataGridView.DataSource = Me.AppUspFillPriorEstimatesBindingSource
        Me.AppUspFillPriorEstimatesDataGridView.Location = New System.Drawing.Point(19, 117)
        Me.AppUspFillPriorEstimatesDataGridView.Name = "AppUspFillPriorEstimatesDataGridView"
        Me.AppUspFillPriorEstimatesDataGridView.Size = New System.Drawing.Size(360, 220)
        Me.AppUspFillPriorEstimatesDataGridView.TabIndex = 3
        Me.AppUspFillPriorEstimatesDataGridView.Visible = False
        '
        'AppUspFillPriorEstimatesBindingSource
        '
        Me.AppUspFillPriorEstimatesBindingSource.DataMember = "appUspFillPriorEstimates"
        Me.AppUspFillPriorEstimatesBindingSource.DataSource = Me.DistrictAggregatedDataSet
        '
        'DistrictAggregatedDataSet
        '
        Me.DistrictAggregatedDataSet.DataSetName = "DistrictAggregatedDataSet"
        Me.DistrictAggregatedDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(116, 349)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(212, 349)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.btnPrevious.TabIndex = 5
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        Me.btnPrevious.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(307, 349)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'AppUspFillPriorEstimatesTableAdapter
        '
        Me.AppUspFillPriorEstimatesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AreasTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.PriorEstimateTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = LGMD.DistrictAggregatedDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Ward Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 180
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IndicatorListID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IndicatorListID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PriorEstimateID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PriorEstimateID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'ListID
        '
        Me.ListID.DataPropertyName = "ListID"
        Me.ListID.HeaderText = "ListID"
        Me.ListID.Name = "ListID"
        Me.ListID.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "EstimatedValue"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "Estimated Value"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PeriodFrom"
        Me.DataGridViewTextBoxColumn5.HeaderText = "PeriodFrom"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PeriodTo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PeriodTo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'ctrlPriorEstimate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.AppUspFillPriorEstimatesDataGridView)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlPriorEstimate"
        Me.Size = New System.Drawing.Size(743, 415)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AppUspFillPriorEstimatesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppUspFillPriorEstimatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DistrictAggregatedDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblIndicatorName As System.Windows.Forms.Label
    Friend WithEvents cmbIndicatorList As System.Windows.Forms.ComboBox
    Friend WithEvents DistrictAggregatedDataSet As LGMD.DistrictAggregatedDataSet
    Friend WithEvents AppUspFillPriorEstimatesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppUspFillPriorEstimatesTableAdapter As LGMD.DistrictAggregatedDataSetTableAdapters.appUspFillPriorEstimatesTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.DistrictAggregatedDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AppUspFillPriorEstimatesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblListItem As System.Windows.Forms.Label
    Friend WithEvents cmbListItem As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
