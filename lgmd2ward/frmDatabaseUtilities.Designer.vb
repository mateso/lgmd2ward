<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabaseUtilities
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.progressBarLogin = New System.Windows.Forms.ProgressBar()
        Me.btnInitiate = New System.Windows.Forms.Button()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblAdvancedOption = New System.Windows.Forms.Label()
        Me.radioBtnSqlServerAuthentication = New System.Windows.Forms.RadioButton()
        Me.cmbDatabases = New System.Windows.Forms.ComboBox()
        Me.cmbServerNames = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblSeconds = New System.Windows.Forms.Label()
        Me.lblAuthentication = New System.Windows.Forms.Label()
        Me.checkBoxDisplayEvents = New System.Windows.Forms.CheckBox()
        Me.lblConnectTimeout = New System.Windows.Forms.Label()
        Me.panelSecurity = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.radioBtnWindowsAuthentication = New System.Windows.Forms.RadioButton()
        Me.lblServerName = New System.Windows.Forms.Label()
        Me.numericUpDownTimeout = New System.Windows.Forms.NumericUpDown()
        Me.panelSecurity.SuspendLayout()
        CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'progressBarLogin
        '
        Me.progressBarLogin.Location = New System.Drawing.Point(228, 249)
        Me.progressBarLogin.Maximum = 3
        Me.progressBarLogin.Name = "progressBarLogin"
        Me.progressBarLogin.Size = New System.Drawing.Size(253, 21)
        Me.progressBarLogin.Step = 1
        Me.progressBarLogin.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressBarLogin.TabIndex = 53
        '
        'btnInitiate
        '
        Me.btnInitiate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnInitiate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInitiate.Location = New System.Drawing.Point(142, 358)
        Me.btnInitiate.Name = "btnInitiate"
        Me.btnInitiate.Size = New System.Drawing.Size(106, 23)
        Me.btnInitiate.TabIndex = 57
        Me.btnInitiate.Text = "Initiate"
        Me.btnInitiate.Visible = False
        '
        'lblDatabase
        '
        Me.lblDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDatabase.Location = New System.Drawing.Point(26, 310)
        Me.lblDatabase.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(65, 18)
        Me.lblDatabase.TabIndex = 55
        Me.lblDatabase.Text = "&Database:"
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(329, 165)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(143, 21)
        Me.cmbTables.TabIndex = 54
        Me.cmbTables.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.Black
        Me.lblProgress.Location = New System.Drawing.Point(280, 210)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(200, 23)
        Me.lblProgress.TabIndex = 52
        Me.lblProgress.Text = "Getting server list..."
        Me.lblProgress.Visible = False
        '
        'lblAdvancedOption
        '
        Me.lblAdvancedOption.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAdvancedOption.Location = New System.Drawing.Point(28, 250)
        Me.lblAdvancedOption.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblAdvancedOption.Name = "lblAdvancedOption"
        Me.lblAdvancedOption.Size = New System.Drawing.Size(118, 17)
        Me.lblAdvancedOption.TabIndex = 51
        Me.lblAdvancedOption.Text = "Advanced option:"
        Me.lblAdvancedOption.Visible = False
        '
        'radioBtnSqlServerAuthentication
        '
        Me.radioBtnSqlServerAuthentication.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radioBtnSqlServerAuthentication.Location = New System.Drawing.Point(-2, 76)
        Me.radioBtnSqlServerAuthentication.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.radioBtnSqlServerAuthentication.Name = "radioBtnSqlServerAuthentication"
        Me.radioBtnSqlServerAuthentication.Size = New System.Drawing.Size(252, 24)
        Me.radioBtnSqlServerAuthentication.TabIndex = 1
        Me.radioBtnSqlServerAuthentication.Text = "Use a specific user &ID and password:"
        '
        'cmbDatabases
        '
        Me.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(101, 309)
        Me.cmbDatabases.Margin = New System.Windows.Forms.Padding(0, 3, 3, 1)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(187, 21)
        Me.cmbDatabases.Sorted = True
        Me.cmbDatabases.TabIndex = 56
        '
        'cmbServerNames
        '
        Me.cmbServerNames.FormattingEnabled = True
        Me.cmbServerNames.Location = New System.Drawing.Point(111, 19)
        Me.cmbServerNames.Margin = New System.Windows.Forms.Padding(0, 3, 3, 1)
        Me.cmbServerNames.Name = "cmbServerNames"
        Me.cmbServerNames.Size = New System.Drawing.Size(187, 21)
        Me.cmbServerNames.Sorted = True
        Me.cmbServerNames.TabIndex = 38
        Me.cmbServerNames.Text = "(Local)\SQLEXPRESS"
        '
        'btnConnect
        '
        Me.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnConnect.Location = New System.Drawing.Point(30, 358)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(106, 23)
        Me.btnConnect.TabIndex = 49
        Me.btnConnect.Text = "Connect"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(132, 165)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.txtPassword.MaxLength = 128
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(155, 20)
        Me.txtPassword.TabIndex = 44
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Location = New System.Drawing.Point(132, 138)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.txtUsername.MaxLength = 128
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(155, 20)
        Me.txtUsername.TabIndex = 42
        '
        'lblPassword
        '
        Me.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPassword.Location = New System.Drawing.Point(25, 164)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(95, 21)
        Me.lblPassword.TabIndex = 43
        Me.lblPassword.Text = "&Password:"
        '
        'lblUsername
        '
        Me.lblUsername.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUsername.Location = New System.Drawing.Point(25, 138)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(95, 20)
        Me.lblUsername.TabIndex = 41
        Me.lblUsername.Text = "&User name:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(254, 358)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "Cancel"
        '
        'lblSeconds
        '
        Me.lblSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSeconds.Location = New System.Drawing.Point(203, 208)
        Me.lblSeconds.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(63, 20)
        Me.lblSeconds.TabIndex = 47
        Me.lblSeconds.Text = "seconds"
        '
        'lblAuthentication
        '
        Me.lblAuthentication.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAuthentication.Location = New System.Drawing.Point(24, 47)
        Me.lblAuthentication.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.lblAuthentication.Name = "lblAuthentication"
        Me.lblAuthentication.Size = New System.Drawing.Size(100, 19)
        Me.lblAuthentication.TabIndex = 39
        Me.lblAuthentication.Text = "Authentication:"
        '
        'checkBoxDisplayEvents
        '
        Me.checkBoxDisplayEvents.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.checkBoxDisplayEvents.Location = New System.Drawing.Point(29, 273)
        Me.checkBoxDisplayEvents.Name = "checkBoxDisplayEvents"
        Me.checkBoxDisplayEvents.Size = New System.Drawing.Size(275, 24)
        Me.checkBoxDisplayEvents.TabIndex = 48
        Me.checkBoxDisplayEvents.Text = "&Display each event messages in a dialog"
        Me.checkBoxDisplayEvents.Visible = False
        '
        'lblConnectTimeout
        '
        Me.lblConnectTimeout.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConnectTimeout.Location = New System.Drawing.Point(27, 208)
        Me.lblConnectTimeout.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.lblConnectTimeout.Name = "lblConnectTimeout"
        Me.lblConnectTimeout.Size = New System.Drawing.Size(108, 20)
        Me.lblConnectTimeout.TabIndex = 45
        Me.lblConnectTimeout.Text = "&Connection time-out:"
        '
        'panelSecurity
        '
        Me.panelSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelSecurity.Controls.Add(Me.RadioButton1)
        Me.panelSecurity.Controls.Add(Me.radioBtnSqlServerAuthentication)
        Me.panelSecurity.Controls.Add(Me.radioBtnWindowsAuthentication)
        Me.panelSecurity.Location = New System.Drawing.Point(28, 70)
        Me.panelSecurity.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.panelSecurity.Name = "panelSecurity"
        Me.panelSecurity.Size = New System.Drawing.Size(276, 61)
        Me.panelSecurity.TabIndex = 40
        '
        'RadioButton1
        '
        Me.RadioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadioButton1.Location = New System.Drawing.Point(12, 31)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(252, 24)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.Text = "Use a specific user &ID and password:"
        '
        'radioBtnWindowsAuthentication
        '
        Me.radioBtnWindowsAuthentication.Checked = True
        Me.radioBtnWindowsAuthentication.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radioBtnWindowsAuthentication.Location = New System.Drawing.Point(13, 8)
        Me.radioBtnWindowsAuthentication.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.radioBtnWindowsAuthentication.Name = "radioBtnWindowsAuthentication"
        Me.radioBtnWindowsAuthentication.Size = New System.Drawing.Size(252, 24)
        Me.radioBtnWindowsAuthentication.TabIndex = 0
        Me.radioBtnWindowsAuthentication.TabStop = True
        Me.radioBtnWindowsAuthentication.Text = "Use &Windows NT Integrated Security"
        '
        'lblServerName
        '
        Me.lblServerName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblServerName.Location = New System.Drawing.Point(22, 21)
        Me.lblServerName.Margin = New System.Windows.Forms.Padding(3, 3, 1, 1)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(79, 18)
        Me.lblServerName.TabIndex = 37
        Me.lblServerName.Text = "&Server Name:"
        '
        'numericUpDownTimeout
        '
        Me.numericUpDownTimeout.Location = New System.Drawing.Point(148, 208)
        Me.numericUpDownTimeout.Margin = New System.Windows.Forms.Padding(1, 3, 2, 3)
        Me.numericUpDownTimeout.Name = "numericUpDownTimeout"
        Me.numericUpDownTimeout.Size = New System.Drawing.Size(48, 20)
        Me.numericUpDownTimeout.TabIndex = 46
        Me.numericUpDownTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericUpDownTimeout.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'frmDatabaseUtilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 401)
        Me.Controls.Add(Me.progressBarLogin)
        Me.Controls.Add(Me.btnInitiate)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.lblAdvancedOption)
        Me.Controls.Add(Me.cmbDatabases)
        Me.Controls.Add(Me.cmbServerNames)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblSeconds)
        Me.Controls.Add(Me.lblAuthentication)
        Me.Controls.Add(Me.checkBoxDisplayEvents)
        Me.Controls.Add(Me.lblConnectTimeout)
        Me.Controls.Add(Me.panelSecurity)
        Me.Controls.Add(Me.lblServerName)
        Me.Controls.Add(Me.numericUpDownTimeout)
        Me.Name = "frmDatabaseUtilities"
        Me.Text = "frmDatabaseUtilities"
        Me.panelSecurity.ResumeLayout(False)
        CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents progressBarLogin As System.Windows.Forms.ProgressBar
    Friend WithEvents btnInitiate As System.Windows.Forms.Button
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
    Private WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents lblAdvancedOption As System.Windows.Forms.Label
    Friend WithEvents radioBtnSqlServerAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents cmbDatabases As System.Windows.Forms.ComboBox
    Friend WithEvents cmbServerNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSeconds As System.Windows.Forms.Label
    Friend WithEvents lblAuthentication As System.Windows.Forms.Label
    Friend WithEvents checkBoxDisplayEvents As System.Windows.Forms.CheckBox
    Friend WithEvents lblConnectTimeout As System.Windows.Forms.Label
    Friend WithEvents panelSecurity As System.Windows.Forms.Panel
    Friend WithEvents radioBtnWindowsAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents numericUpDownTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
