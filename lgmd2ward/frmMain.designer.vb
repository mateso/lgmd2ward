<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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

    Friend WithEvents ToolStripContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TreeNodeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents tvMain As System.Windows.Forms.TreeView
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ListViewLargeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ListViewSmallImageList As System.Windows.Forms.ImageList

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TreeNodeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnSynchronise = New System.Windows.Forms.ToolStripButton()
        Me.tscmbSynchOptions = New System.Windows.Forms.ToolStripComboBox()
        Me.tslblLanguage = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbLanguage = New System.Windows.Forms.ToolStripComboBox()
        Me.tslblServerIP = New System.Windows.Forms.ToolStripLabel()
        Me.tstxtHostIP = New System.Windows.Forms.ToolStripTextBox()
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggregateDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LookupTablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeographicalAreasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriorEstimateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripContainer = New System.Windows.Forms.ToolStripContainer()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.tvMain = New System.Windows.Forms.TreeView()
        Me.ListViewLargeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewSmallImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.statusStrip.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.ToolStripContainer.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.ContentPanel.SuspendLayout()
        Me.ToolStripContainer.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusStrip
        '
        Me.statusStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.statusStrip.Location = New System.Drawing.Point(0, 0)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(1156, 22)
        Me.statusStrip.TabIndex = 6
        Me.statusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'TreeNodeImageList
        '
        Me.TreeNodeImageList.ImageStream = CType(resources.GetObject("TreeNodeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TreeNodeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TreeNodeImageList.Images.SetKeyName(0, "ClosedFolder")
        Me.TreeNodeImageList.Images.SetKeyName(1, "OpenFolder")
        Me.TreeNodeImageList.Images.SetKeyName(2, "NewForm.ico")
        Me.TreeNodeImageList.Images.SetKeyName(3, "oEdit2.ico")
        Me.TreeNodeImageList.Images.SetKeyName(4, "servers.ico")
        Me.TreeNodeImageList.Images.SetKeyName(5, "library1.ico")
        Me.TreeNodeImageList.Images.SetKeyName(6, "services.ico")
        Me.TreeNodeImageList.Images.SetKeyName(7, "internetconnection.ico")
        Me.TreeNodeImageList.Images.SetKeyName(8, "users.ico")
        Me.TreeNodeImageList.Images.SetKeyName(9, "Disconnect.ico")
        Me.TreeNodeImageList.Images.SetKeyName(10, "edit2.ico")
        Me.TreeNodeImageList.Images.SetKeyName(11, "report.ico")
        Me.TreeNodeImageList.Images.SetKeyName(12, "PublicQueue.ico")
        Me.TreeNodeImageList.Images.SetKeyName(13, "deleteDB.ico")
        Me.TreeNodeImageList.Images.SetKeyName(14, "restore.ico")
        Me.TreeNodeImageList.Images.SetKeyName(15, "backup.ico")
        Me.TreeNodeImageList.Images.SetKeyName(16, "changePassword.ico")
        Me.TreeNodeImageList.Images.SetKeyName(17, "import.ico")
        Me.TreeNodeImageList.Images.SetKeyName(18, "db.ico")
        Me.TreeNodeImageList.Images.SetKeyName(19, "newdb.ico")
        Me.TreeNodeImageList.Images.SetKeyName(20, "changePassword.ico")
        Me.TreeNodeImageList.Images.SetKeyName(21, "security.ico")
        Me.TreeNodeImageList.Images.SetKeyName(22, "dbutilities.ico")
        '
        'toolStrip
        '
        Me.toolStrip.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.toolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator7, Me.ToolStripSeparator8, Me.tsbtnSynchronise, Me.tscmbSynchOptions, Me.tslblLanguage, Me.tscmbLanguage, Me.tslblServerIP, Me.tstxtHostIP})
        Me.toolStrip.Location = New System.Drawing.Point(3, 24)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(605, 25)
        Me.toolStrip.TabIndex = 0
        Me.toolStrip.Text = "ToolStrip1"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnSynchronise
        '
        Me.tsbtnSynchronise.Image = CType(resources.GetObject("tsbtnSynchronise.Image"), System.Drawing.Image)
        Me.tsbtnSynchronise.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSynchronise.Name = "tsbtnSynchronise"
        Me.tsbtnSynchronise.Size = New System.Drawing.Size(91, 22)
        Me.tsbtnSynchronise.Text = "Synchronise"
        '
        'tscmbSynchOptions
        '
        Me.tscmbSynchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbSynchOptions.Items.AddRange(New Object() {"Selected Form", "All Forms"})
        Me.tscmbSynchOptions.Name = "tscmbSynchOptions"
        Me.tscmbSynchOptions.Size = New System.Drawing.Size(121, 25)
        '
        'tslblLanguage
        '
        Me.tslblLanguage.Name = "tslblLanguage"
        Me.tslblLanguage.RightToLeftAutoMirrorImage = True
        Me.tslblLanguage.Size = New System.Drawing.Size(59, 22)
        Me.tslblLanguage.Text = "Language"
        Me.tslblLanguage.Visible = False
        '
        'tscmbLanguage
        '
        Me.tscmbLanguage.Items.AddRange(New Object() {"English", "Kiswahili"})
        Me.tscmbLanguage.Name = "tscmbLanguage"
        Me.tscmbLanguage.Size = New System.Drawing.Size(121, 25)
        Me.tscmbLanguage.Visible = False
        '
        'tslblServerIP
        '
        Me.tslblServerIP.Name = "tslblServerIP"
        Me.tslblServerIP.Size = New System.Drawing.Size(52, 22)
        Me.tslblServerIP.Text = "Server IP"
        '
        'tstxtHostIP
        '
        Me.tstxtHostIP.Name = "tstxtHostIP"
        Me.tstxtHostIP.Size = New System.Drawing.Size(100, 25)
        Me.tstxtHostIP.Text = "41.86.162.25"
        Me.tstxtHostIP.ToolTipText = "Server IP Address"
        '
        'menuStrip
        '
        Me.menuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AggregateDataToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(1156, 24)
        Me.menuStrip.TabIndex = 0
        Me.menuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOffToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'LogOffToolStripMenuItem
        '
        Me.LogOffToolStripMenuItem.Image = Global.LGMD.My.Resources.Resources.logOffIcon
        Me.LogOffToolStripMenuItem.Name = "LogOffToolStripMenuItem"
        Me.LogOffToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.LogOffToolStripMenuItem.Text = "L&ogOff"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.LGMD.My.Resources.Resources.TurnOffButton
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'AggregateDataToolStripMenuItem
        '
        Me.AggregateDataToolStripMenuItem.Name = "AggregateDataToolStripMenuItem"
        Me.AggregateDataToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.AggregateDataToolStripMenuItem.Text = "&Aggregate Data"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LookupTablesToolStripMenuItem, Me.GeographicalAreasToolStripMenuItem, Me.PriorEstimateToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'LookupTablesToolStripMenuItem
        '
        Me.LookupTablesToolStripMenuItem.Image = CType(resources.GetObject("LookupTablesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LookupTablesToolStripMenuItem.Name = "LookupTablesToolStripMenuItem"
        Me.LookupTablesToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.LookupTablesToolStripMenuItem.Text = "&Lookup Tables"
        '
        'GeographicalAreasToolStripMenuItem
        '
        Me.GeographicalAreasToolStripMenuItem.Image = CType(resources.GetObject("GeographicalAreasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GeographicalAreasToolStripMenuItem.Name = "GeographicalAreasToolStripMenuItem"
        Me.GeographicalAreasToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.GeographicalAreasToolStripMenuItem.Text = "&Geographical Areas"
        '
        'PriorEstimateToolStripMenuItem
        '
        Me.PriorEstimateToolStripMenuItem.Image = CType(resources.GetObject("PriorEstimateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PriorEstimateToolStripMenuItem.Name = "PriorEstimateToolStripMenuItem"
        Me.PriorEstimateToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PriorEstimateToolStripMenuItem.Text = "Prior Estimates"
        '
        'ToolStripContainer
        '
        '
        'ToolStripContainer.BottomToolStripPanel
        '
        Me.ToolStripContainer.BottomToolStripPanel.Controls.Add(Me.statusStrip)
        '
        'ToolStripContainer.ContentPanel
        '
        Me.ToolStripContainer.ContentPanel.Controls.Add(Me.SplitContainer)
        Me.ToolStripContainer.ContentPanel.Size = New System.Drawing.Size(1156, 382)
        Me.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer.Name = "ToolStripContainer"
        Me.ToolStripContainer.Size = New System.Drawing.Size(1156, 453)
        Me.ToolStripContainer.TabIndex = 7
        Me.ToolStripContainer.Text = "ToolStripContainer1"
        '
        'ToolStripContainer.TopToolStripPanel
        '
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.menuStrip)
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.toolStrip)
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.tvMain)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.AutoScroll = True
        Me.SplitContainer.Size = New System.Drawing.Size(1156, 382)
        Me.SplitContainer.SplitterDistance = 242
        Me.SplitContainer.TabIndex = 0
        Me.SplitContainer.Text = "SplitContainer1"
        '
        'tvMain
        '
        Me.tvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvMain.ImageIndex = 0
        Me.tvMain.ImageList = Me.TreeNodeImageList
        Me.tvMain.Location = New System.Drawing.Point(0, 0)
        Me.tvMain.Name = "tvMain"
        Me.tvMain.SelectedImageIndex = 1
        Me.tvMain.ShowLines = False
        Me.tvMain.Size = New System.Drawing.Size(242, 382)
        Me.tvMain.TabIndex = 0
        '
        'ListViewLargeImageList
        '
        Me.ListViewLargeImageList.ImageStream = CType(resources.GetObject("ListViewLargeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewLargeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewLargeImageList.Images.SetKeyName(0, "Graph1")
        Me.ListViewLargeImageList.Images.SetKeyName(1, "Graph2")
        Me.ListViewLargeImageList.Images.SetKeyName(2, "Graph3")
        '
        'ListViewSmallImageList
        '
        Me.ListViewSmallImageList.ImageStream = CType(resources.GetObject("ListViewSmallImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewSmallImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewSmallImageList.Images.SetKeyName(0, "Graph1")
        Me.ListViewSmallImageList.Images.SetKeyName(1, "Graph2")
        Me.ListViewSmallImageList.Images.SetKeyName(2, "Graph3")
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 453)
        Me.Controls.Add(Me.ToolStripContainer)
        Me.Name = "frmMain"
        Me.Text = "LGMD2i"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ToolStripContainer.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tsbtnSynchronise As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscmbLanguage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents tstxtHostIP As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslblLanguage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tslblServerIP As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tscmbSynchOptions As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LogOffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AggregateDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LookupTablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeographicalAreasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PriorEstimateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
