<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlAggregateData
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMonthQuarter = New System.Windows.Forms.ComboBox()
        Me.cmbFinancialYear = New System.Windows.Forms.ComboBox()
        Me.cmbFormType = New System.Windows.Forms.ComboBox()
        Me.btnAggregate = New System.Windows.Forms.Button()
        Me.lblMonthQuarter = New System.Windows.Forms.Label()
        Me.lblFinancialYear = New System.Windows.Forms.Label()
        Me.lblFormType = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbMonthQuarter)
        Me.GroupBox1.Controls.Add(Me.cmbFinancialYear)
        Me.GroupBox1.Controls.Add(Me.cmbFormType)
        Me.GroupBox1.Controls.Add(Me.btnAggregate)
        Me.GroupBox1.Controls.Add(Me.lblMonthQuarter)
        Me.GroupBox1.Controls.Add(Me.lblFinancialYear)
        Me.GroupBox1.Controls.Add(Me.lblFormType)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(611, 209)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aggregate Data"
        '
        'cmbMonthQuarter
        '
        Me.cmbMonthQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthQuarter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMonthQuarter.FormattingEnabled = True
        Me.cmbMonthQuarter.Location = New System.Drawing.Point(131, 93)
        Me.cmbMonthQuarter.Name = "cmbMonthQuarter"
        Me.cmbMonthQuarter.Size = New System.Drawing.Size(121, 21)
        Me.cmbMonthQuarter.TabIndex = 6
        Me.cmbMonthQuarter.Visible = False
        '
        'cmbFinancialYear
        '
        Me.cmbFinancialYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinancialYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFinancialYear.FormattingEnabled = True
        Me.cmbFinancialYear.Location = New System.Drawing.Point(389, 35)
        Me.cmbFinancialYear.Name = "cmbFinancialYear"
        Me.cmbFinancialYear.Size = New System.Drawing.Size(121, 21)
        Me.cmbFinancialYear.TabIndex = 5
        Me.cmbFinancialYear.Visible = False
        '
        'cmbFormType
        '
        Me.cmbFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFormType.FormattingEnabled = True
        Me.cmbFormType.Location = New System.Drawing.Point(131, 35)
        Me.cmbFormType.Name = "cmbFormType"
        Me.cmbFormType.Size = New System.Drawing.Size(174, 21)
        Me.cmbFormType.TabIndex = 4
        '
        'btnAggregate
        '
        Me.btnAggregate.Location = New System.Drawing.Point(252, 147)
        Me.btnAggregate.Name = "btnAggregate"
        Me.btnAggregate.Size = New System.Drawing.Size(75, 23)
        Me.btnAggregate.TabIndex = 3
        Me.btnAggregate.Text = "Aggregate"
        Me.btnAggregate.UseVisualStyleBackColor = True
        '
        'lblMonthQuarter
        '
        Me.lblMonthQuarter.AutoSize = True
        Me.lblMonthQuarter.Location = New System.Drawing.Point(9, 96)
        Me.lblMonthQuarter.Name = "lblMonthQuarter"
        Me.lblMonthQuarter.Size = New System.Drawing.Size(116, 13)
        Me.lblMonthQuarter.TabIndex = 2
        Me.lblMonthQuarter.Text = "Select Month / Quarter"
        Me.lblMonthQuarter.Visible = False
        '
        'lblFinancialYear
        '
        Me.lblFinancialYear.AutoSize = True
        Me.lblFinancialYear.Location = New System.Drawing.Point(321, 38)
        Me.lblFinancialYear.Name = "lblFinancialYear"
        Me.lblFinancialYear.Size = New System.Drawing.Size(62, 13)
        Me.lblFinancialYear.TabIndex = 1
        Me.lblFinancialYear.Text = "Select Year"
        Me.lblFinancialYear.Visible = False
        '
        'lblFormType
        '
        Me.lblFormType.AutoSize = True
        Me.lblFormType.Location = New System.Drawing.Point(35, 38)
        Me.lblFormType.Name = "lblFormType"
        Me.lblFormType.Size = New System.Drawing.Size(90, 13)
        Me.lblFormType.TabIndex = 0
        Me.lblFormType.Text = "Select Form Type"
        '
        'ctrlAggregateData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlAggregateData"
        Me.Size = New System.Drawing.Size(637, 359)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMonthQuarter As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFinancialYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFormType As System.Windows.Forms.ComboBox
    Friend WithEvents btnAggregate As System.Windows.Forms.Button
    Friend WithEvents lblMonthQuarter As System.Windows.Forms.Label
    Friend WithEvents lblFinancialYear As System.Windows.Forms.Label
    Friend WithEvents lblFormType As System.Windows.Forms.Label

End Class
