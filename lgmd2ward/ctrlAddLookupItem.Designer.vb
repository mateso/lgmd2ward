<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlAddLookupItem
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddDeleteLookupItem = New System.Windows.Forms.Button()
        Me.cmbLookupItemType = New System.Windows.Forms.ComboBox()
        Me.txtLookupItemName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLookupItemName)
        Me.GroupBox1.Controls.Add(Me.cmbLookupItemType)
        Me.GroupBox1.Controls.Add(Me.btnAddDeleteLookupItem)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(593, 199)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Lookup Item"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Lookup Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(169, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Lookup Item Name"
        '
        'btnAddDeleteLookupItem
        '
        Me.btnAddDeleteLookupItem.Location = New System.Drawing.Point(272, 125)
        Me.btnAddDeleteLookupItem.Name = "btnAddDeleteLookupItem"
        Me.btnAddDeleteLookupItem.Size = New System.Drawing.Size(75, 23)
        Me.btnAddDeleteLookupItem.TabIndex = 2
        Me.btnAddDeleteLookupItem.Text = "AddDelete"
        Me.btnAddDeleteLookupItem.UseVisualStyleBackColor = True
        '
        'cmbLookupItemType
        '
        Me.cmbLookupItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLookupItemType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbLookupItemType.FormattingEnabled = True
        Me.cmbLookupItemType.Location = New System.Drawing.Point(272, 51)
        Me.cmbLookupItemType.Name = "cmbLookupItemType"
        Me.cmbLookupItemType.Size = New System.Drawing.Size(121, 21)
        Me.cmbLookupItemType.TabIndex = 3
        '
        'txtLookupItemName
        '
        Me.txtLookupItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLookupItemName.Location = New System.Drawing.Point(272, 90)
        Me.txtLookupItemName.Name = "txtLookupItemName"
        Me.txtLookupItemName.Size = New System.Drawing.Size(263, 20)
        Me.txtLookupItemName.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(593, 106)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Action"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(21, 49)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(134, 49)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ctrlAddLookupItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlAddLookupItem"
        Me.Size = New System.Drawing.Size(648, 385)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLookupItemName As System.Windows.Forms.TextBox
    Friend WithEvents cmbLookupItemType As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddDeleteLookupItem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button

End Class
