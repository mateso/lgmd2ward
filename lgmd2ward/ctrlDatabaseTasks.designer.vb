<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDatabaseTasks
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.groupBox = New System.Windows.Forms.GroupBox()
        Me.btnDetach = New System.Windows.Forms.Button()
        Me.btnAttach = New System.Windows.Forms.Button()
        Me.btnBackupFile = New System.Windows.Forms.Button()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.lblDatabaseTasks = New System.Windows.Forms.Label()
        Me.lblDatabaseName = New System.Windows.Forms.Label()
        Me.cmbDatabases = New System.Windows.Forms.ComboBox()
        Me.txtBackupFile = New System.Windows.Forms.TextBox()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.groupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.CheckFileExists = False
        Me.OpenFileDialog1.FileName = "*.bak"
        Me.OpenFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
        Me.OpenFileDialog1.InitialDirectory = "C:\"
        Me.OpenFileDialog1.Title = "Backup File"
        '
        'statusBar1
        '
        Me.statusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.statusBar1.Location = New System.Drawing.Point(0, 427)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Size = New System.Drawing.Size(802, 22)
        Me.statusBar1.TabIndex = 14
        Me.statusBar1.Text = "Ready"
        Me.statusBar1.Visible = False
        '
        'groupBox
        '
        Me.groupBox.Controls.Add(Me.btnDetach)
        Me.groupBox.Controls.Add(Me.btnAttach)
        Me.groupBox.Controls.Add(Me.btnBackupFile)
        Me.groupBox.Controls.Add(Me.txtDatabaseName)
        Me.groupBox.Controls.Add(Me.btnBackup)
        Me.groupBox.Controls.Add(Me.btnRestore)
        Me.groupBox.Controls.Add(Me.lblDatabaseTasks)
        Me.groupBox.Controls.Add(Me.lblDatabaseName)
        Me.groupBox.Controls.Add(Me.cmbDatabases)
        Me.groupBox.Controls.Add(Me.txtBackupFile)
        Me.groupBox.Location = New System.Drawing.Point(22, 14)
        Me.groupBox.Name = "groupBox"
        Me.groupBox.Size = New System.Drawing.Size(759, 127)
        Me.groupBox.TabIndex = 16
        Me.groupBox.TabStop = False
        Me.groupBox.Text = "txtGroupBox"
        '
        'btnDetach
        '
        Me.btnDetach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDetach.Location = New System.Drawing.Point(400, 84)
        Me.btnDetach.Name = "btnDetach"
        Me.btnDetach.Size = New System.Drawing.Size(75, 23)
        Me.btnDetach.TabIndex = 27
        Me.btnDetach.Text = "&Detach"
        Me.btnDetach.Visible = False
        '
        'btnAttach
        '
        Me.btnAttach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAttach.Location = New System.Drawing.Point(305, 84)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(75, 23)
        Me.btnAttach.TabIndex = 26
        Me.btnAttach.Text = "&Attach"
        Me.btnAttach.Visible = False
        '
        'btnBackupFile
        '
        Me.btnBackupFile.Location = New System.Drawing.Point(90, 55)
        Me.btnBackupFile.Name = "btnBackupFile"
        Me.btnBackupFile.Size = New System.Drawing.Size(26, 23)
        Me.btnBackupFile.TabIndex = 25
        Me.btnBackupFile.Text = "...."
        Me.btnBackupFile.UseVisualStyleBackColor = True
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(120, 27)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.ReadOnly = True
        Me.txtDatabaseName.Size = New System.Drawing.Size(188, 20)
        Me.txtDatabaseName.TabIndex = 24
        '
        'btnBackup
        '
        Me.btnBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBackup.Location = New System.Drawing.Point(119, 84)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(75, 23)
        Me.btnBackup.TabIndex = 22
        Me.btnBackup.Text = "&Backup"
        '
        'btnRestore
        '
        Me.btnRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRestore.Location = New System.Drawing.Point(212, 84)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(75, 23)
        Me.btnRestore.TabIndex = 23
        Me.btnRestore.Text = "&Restore"
        '
        'lblDatabaseTasks
        '
        Me.lblDatabaseTasks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDatabaseTasks.Location = New System.Drawing.Point(20, 58)
        Me.lblDatabaseTasks.Name = "lblDatabaseTasks"
        Me.lblDatabaseTasks.Size = New System.Drawing.Size(66, 19)
        Me.lblDatabaseTasks.TabIndex = 20
        Me.lblDatabaseTasks.Text = "Backup &File:"
        '
        'lblDatabaseName
        '
        Me.lblDatabaseName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDatabaseName.Location = New System.Drawing.Point(19, 26)
        Me.lblDatabaseName.Name = "lblDatabaseName"
        Me.lblDatabaseName.Size = New System.Drawing.Size(67, 23)
        Me.lblDatabaseName.TabIndex = 18
        Me.lblDatabaseName.Text = "&Database:"
        '
        'cmbDatabases
        '
        Me.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(120, 27)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(487, 21)
        Me.cmbDatabases.Sorted = True
        Me.cmbDatabases.TabIndex = 19
        Me.cmbDatabases.Visible = False
        '
        'txtBackupFile
        '
        Me.txtBackupFile.Location = New System.Drawing.Point(120, 57)
        Me.txtBackupFile.Name = "txtBackupFile"
        Me.txtBackupFile.Size = New System.Drawing.Size(624, 20)
        Me.txtBackupFile.TabIndex = 21
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(25, 152)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ReadOnly = True
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResults.Size = New System.Drawing.Size(756, 256)
        Me.txtResults.TabIndex = 17
        Me.txtResults.Visible = False
        '
        'ctrlDatabaseTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.groupBox)
        Me.Controls.Add(Me.statusBar1)
        Me.Name = "ctrlDatabaseTasks"
        Me.Size = New System.Drawing.Size(802, 449)
        Me.groupBox.ResumeLayout(False)
        Me.groupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents groupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnDetach As System.Windows.Forms.Button
    Friend WithEvents btnAttach As System.Windows.Forms.Button
    Friend WithEvents btnBackupFile As System.Windows.Forms.Button
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents btnBackup As System.Windows.Forms.Button
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents lblDatabaseTasks As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseName As System.Windows.Forms.Label
    Friend WithEvents cmbDatabases As System.Windows.Forms.ComboBox
    Friend WithEvents txtBackupFile As System.Windows.Forms.TextBox
    Friend WithEvents txtResults As System.Windows.Forms.TextBox

End Class
