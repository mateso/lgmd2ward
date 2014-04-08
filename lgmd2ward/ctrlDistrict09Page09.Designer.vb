<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDistrict09Page09
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
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbGoTo = New System.Windows.Forms.ComboBox()
        Me.gotoLbl = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(163, 48)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(325, 30)
        Me.lblPeriod.TabIndex = 118
        Me.lblPeriod.Text = " Period heading"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArea
        '
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(163, 22)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(312, 29)
        Me.lblArea.TabIndex = 117
        Me.lblArea.Text = " Area heading"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbGoTo
        '
        Me.cmbGoTo.FormattingEnabled = True
        Me.cmbGoTo.Location = New System.Drawing.Point(243, 334)
        Me.cmbGoTo.Name = "cmbGoTo"
        Me.cmbGoTo.Size = New System.Drawing.Size(93, 21)
        Me.cmbGoTo.TabIndex = 119
        Me.cmbGoTo.TabStop = False
        '
        'gotoLbl
        '
        Me.gotoLbl.AutoSize = True
        Me.gotoLbl.Location = New System.Drawing.Point(201, 337)
        Me.gotoLbl.Name = "gotoLbl"
        Me.gotoLbl.Size = New System.Drawing.Size(36, 13)
        Me.gotoLbl.TabIndex = 121
        Me.gotoLbl.Text = "Go to:"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(342, 330)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(133, 27)
        Me.cmdSave.TabIndex = 120
        Me.cmdSave.Text = "Save and go"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ctrlDistrict09Page09
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbGoTo)
        Me.Controls.Add(Me.gotoLbl)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblArea)
        Me.Name = "ctrlDistrict09Page09"
        Me.Size = New System.Drawing.Size(635, 374)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents gotoLbl As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button

End Class
