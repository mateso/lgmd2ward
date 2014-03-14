<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDatabaseUtilities
    Inherits MainControl

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
        Me.radioBtnWindowsAuthentication = New System.Windows.Forms.RadioButton()
        Me.lblAdvancedOption = New System.Windows.Forms.Label()
        Me.cmbServerNames = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblServerName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblSeconds = New System.Windows.Forms.Label()
        Me.numericUpDownTimeout = New System.Windows.Forms.NumericUpDown()
        Me.lblAuthentication = New System.Windows.Forms.Label()
        Me.radioBtnSqlServerAuthentication = New System.Windows.Forms.RadioButton()
        Me.checkBoxDisplayEvents = New System.Windows.Forms.CheckBox()
        Me.lblConnectTimeout = New System.Windows.Forms.Label()
        Me.panelSecurity = New System.Windows.Forms.Panel()
        Me.progressBarServerList = New System.Windows.Forms.ProgressBar()
        Me.lblGettingServerList = New System.Windows.Forms.Label()
        Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.cmbDatabases = New System.Windows.Forms.ComboBox()
        Me.btnInitiate = New System.Windows.Forms.Button()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelSecurity.SuspendLayout()
        Me.SuspendLayout()
        '
        'radioBtnWindowsAuthentication
        '
        Me.radioBtnWindowsAuthentication.Checked = True
        Me.radioBtnWindowsAuthentication.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radioBtnWindowsAuthentication.Location = New System.Drawing.Point(14, 5)
        Me.radioBtnWindowsAuthentication.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.radioBtnWindowsAuthentication.Name = "radioBtnWindowsAuthentication"
        Me.radioBtnWindowsAuthentication.Size = New System.Drawing.Size(252, 24)
        Me.radioBtnWindowsAuthentication.TabIndex = 0
        Me.radioBtnWindowsAuthentication.TabStop = True
        Me.radioBtnWindowsAuthentication.Text = "Use &Windows NT Integrated Security"
        '
        'lblAdvancedOption
        '
        Me.lblAdvancedOption.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAdvancedOption.Location = New System.Drawing.Point(13, 239)
        Me.lblAdvancedOption.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblAdvancedOption.Name = "lblAdvancedOption"
        Me.lblAdvancedOption.Size = New System.Drawing.Size(118, 17)
        Me.lblAdvancedOption.TabIndex = 29
        Me.lblAdvancedOption.Text = "Advanced option:"
        Me.lblAdvancedOption.Visible = False
        '
        'cmbServerNames
        '
        Me.cmbServerNames.FormattingEnabled = True
        Me.cmbServerNames.Location = New System.Drawing.Point(103, 8)
        Me.cmbServerNames.Margin = New System.Windows.Forms.Padding(0, 3, 3, 1)
        Me.cmbServerNames.Name = "cmbServerNames"
        Me.cmbServerNames.Size = New System.Drawing.Size(187, 21)
        Me.cmbServerNames.Sorted = True
        Me.cmbServerNames.TabIndex = 16
        Me.cmbServerNames.Text = "(Local)\SQLEXPRESS"
        '
        'btnConnect
        '
        Me.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnConnect.Location = New System.Drawing.Point(16, 347)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(106, 23)
        Me.btnConnect.TabIndex = 27
        Me.btnConnect.Text = "Connect"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(118, 154)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.txtPassword.MaxLength = 128
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(155, 20)
        Me.txtPassword.TabIndex = 22
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Location = New System.Drawing.Point(118, 127)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.txtUsername.MaxLength = 128
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(155, 20)
        Me.txtUsername.TabIndex = 20
        '
        'lblPassword
        '
        Me.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPassword.Location = New System.Drawing.Point(11, 153)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(95, 21)
        Me.lblPassword.TabIndex = 21
        Me.lblPassword.Text = "&Password:"
        '
        'lblUsername
        '
        Me.lblUsername.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUsername.Location = New System.Drawing.Point(11, 127)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(95, 20)
        Me.lblUsername.TabIndex = 19
        Me.lblUsername.Text = "&User name:"
        '
        'lblServerName
        '
        Me.lblServerName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblServerName.Location = New System.Drawing.Point(14, 10)
        Me.lblServerName.Margin = New System.Windows.Forms.Padding(3, 3, 1, 1)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(79, 18)
        Me.lblServerName.TabIndex = 15
        Me.lblServerName.Text = "&Server Name:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(240, 347)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'lblSeconds
        '
        Me.lblSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSeconds.Location = New System.Drawing.Point(191, 197)
        Me.lblSeconds.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(63, 20)
        Me.lblSeconds.TabIndex = 25
        Me.lblSeconds.Text = "seconds"
        '
        'numericUpDownTimeout
        '
        Me.numericUpDownTimeout.Location = New System.Drawing.Point(136, 197)
        Me.numericUpDownTimeout.Margin = New System.Windows.Forms.Padding(1, 3, 2, 3)
        Me.numericUpDownTimeout.Name = "numericUpDownTimeout"
        Me.numericUpDownTimeout.Size = New System.Drawing.Size(48, 20)
        Me.numericUpDownTimeout.TabIndex = 24
        Me.numericUpDownTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericUpDownTimeout.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'lblAuthentication
        '
        Me.lblAuthentication.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAuthentication.Location = New System.Drawing.Point(14, 36)
        Me.lblAuthentication.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.lblAuthentication.Name = "lblAuthentication"
        Me.lblAuthentication.Size = New System.Drawing.Size(100, 19)
        Me.lblAuthentication.TabIndex = 17
        Me.lblAuthentication.Text = "Authentication:"
        '
        'radioBtnSqlServerAuthentication
        '
        Me.radioBtnSqlServerAuthentication.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radioBtnSqlServerAuthentication.Location = New System.Drawing.Point(14, 31)
        Me.radioBtnSqlServerAuthentication.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.radioBtnSqlServerAuthentication.Name = "radioBtnSqlServerAuthentication"
        Me.radioBtnSqlServerAuthentication.Size = New System.Drawing.Size(252, 24)
        Me.radioBtnSqlServerAuthentication.TabIndex = 1
        Me.radioBtnSqlServerAuthentication.Text = "Use a specific user &ID and password:"
        '
        'checkBoxDisplayEvents
        '
        Me.checkBoxDisplayEvents.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.checkBoxDisplayEvents.Location = New System.Drawing.Point(16, 262)
        Me.checkBoxDisplayEvents.Name = "checkBoxDisplayEvents"
        Me.checkBoxDisplayEvents.Size = New System.Drawing.Size(275, 24)
        Me.checkBoxDisplayEvents.TabIndex = 26
        Me.checkBoxDisplayEvents.Text = "&Display each event messages in a dialog"
        Me.checkBoxDisplayEvents.Visible = False
        '
        'lblConnectTimeout
        '
        Me.lblConnectTimeout.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConnectTimeout.Location = New System.Drawing.Point(13, 197)
        Me.lblConnectTimeout.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblConnectTimeout.Name = "lblConnectTimeout"
        Me.lblConnectTimeout.Size = New System.Drawing.Size(108, 20)
        Me.lblConnectTimeout.TabIndex = 23
        Me.lblConnectTimeout.Text = "&Connection time-out:"
        '
        'panelSecurity
        '
        Me.panelSecurity.Controls.Add(Me.radioBtnSqlServerAuthentication)
        Me.panelSecurity.Controls.Add(Me.radioBtnWindowsAuthentication)
        Me.panelSecurity.Location = New System.Drawing.Point(14, 59)
        Me.panelSecurity.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.panelSecurity.Name = "panelSecurity"
        Me.panelSecurity.Size = New System.Drawing.Size(276, 61)
        Me.panelSecurity.TabIndex = 18
        '
        'progressBarServerList
        '
        Me.progressBarServerList.Location = New System.Drawing.Point(241, 261)
        Me.progressBarServerList.Maximum = 200
        Me.progressBarServerList.Name = "progressBarServerList"
        Me.progressBarServerList.Size = New System.Drawing.Size(199, 21)
        Me.progressBarServerList.Step = 20
        Me.progressBarServerList.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressBarServerList.TabIndex = 31
        '
        'lblGettingServerList
        '
        Me.lblGettingServerList.AutoSize = True
        Me.lblGettingServerList.BackColor = System.Drawing.Color.Transparent
        Me.lblGettingServerList.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGettingServerList.ForeColor = System.Drawing.Color.Black
        Me.lblGettingServerList.Location = New System.Drawing.Point(238, 233)
        Me.lblGettingServerList.Name = "lblGettingServerList"
        Me.lblGettingServerList.Size = New System.Drawing.Size(200, 23)
        Me.lblGettingServerList.TabIndex = 30
        Me.lblGettingServerList.Text = "Getting server list..."
        '
        'backgroundWorker
        '
        Me.backgroundWorker.WorkerReportsProgress = True
        '
        'lblDatabase
        '
        Me.lblDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDatabase.Location = New System.Drawing.Point(13, 299)
        Me.lblDatabase.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(65, 18)
        Me.lblDatabase.TabIndex = 34
        Me.lblDatabase.Text = "&Database:"
        '
        'cmbDatabases
        '
        Me.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(88, 298)
        Me.cmbDatabases.Margin = New System.Windows.Forms.Padding(0, 3, 3, 1)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(187, 21)
        Me.cmbDatabases.Sorted = True
        Me.cmbDatabases.TabIndex = 35
        '
        'btnInitiate
        '
        Me.btnInitiate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnInitiate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInitiate.Location = New System.Drawing.Point(128, 347)
        Me.btnInitiate.Name = "btnInitiate"
        Me.btnInitiate.Size = New System.Drawing.Size(106, 23)
        Me.btnInitiate.TabIndex = 36
        Me.btnInitiate.Text = "Initiate"
        Me.btnInitiate.Visible = False
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(103, 33)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(187, 21)
        Me.cmbTables.TabIndex = 33
        Me.cmbTables.Visible = False
        '
        'ctrlDatabaseUtilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.progressBarServerList)
        Me.Controls.Add(Me.btnInitiate)
        Me.Controls.Add(Me.cmbDatabases)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.lblGettingServerList)
        Me.Controls.Add(Me.lblAdvancedOption)
        Me.Controls.Add(Me.cmbServerNames)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblServerName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblSeconds)
        Me.Controls.Add(Me.numericUpDownTimeout)
        Me.Controls.Add(Me.lblAuthentication)
        Me.Controls.Add(Me.checkBoxDisplayEvents)
        Me.Controls.Add(Me.lblConnectTimeout)
        Me.Controls.Add(Me.panelSecurity)
        Me.Name = "ctrlDatabaseUtilities"
        Me.Size = New System.Drawing.Size(452, 427)
        CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelSecurity.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radioBtnWindowsAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents lblAdvancedOption As System.Windows.Forms.Label
    Friend WithEvents cmbServerNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSeconds As System.Windows.Forms.Label
    Friend WithEvents numericUpDownTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAuthentication As System.Windows.Forms.Label
    Friend WithEvents radioBtnSqlServerAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents checkBoxDisplayEvents As System.Windows.Forms.CheckBox
    Friend WithEvents lblConnectTimeout As System.Windows.Forms.Label
    Friend WithEvents panelSecurity As System.Windows.Forms.Panel
    Private WithEvents progressBarServerList As System.Windows.Forms.ProgressBar
    Private WithEvents lblGettingServerList As System.Windows.Forms.Label
    Private WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents cmbDatabases As System.Windows.Forms.ComboBox
    Friend WithEvents btnInitiate As System.Windows.Forms.Button
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox

End Class
