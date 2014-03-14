<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDatabaseDetails
    'Inherits System.Windows.Forms.UserControl
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlDatabaseDetails))
        Me.ListViewContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.objConnectMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.objDisConnectMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.objTasksMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.objShrinkMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.objAttachMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.objDetachMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.objBackupMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.objRestoreMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.objRunScriptMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.objDeleteMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.objNewDatabaseMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SqlServerTreeView = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.serverVersionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ListView = New System.Windows.Forms.ListView
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.speedToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ListViewContextMenuStrip.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewContextMenuStrip
        '
        Me.ListViewContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.objConnectMenuItem, Me.ToolStripSeparator1, Me.objDisConnectMenuItem, Me.objTasksMenuItem, Me.ToolStripSeparator2, Me.objNewDatabaseMenuItem})
        Me.ListViewContextMenuStrip.Name = "contextMenuStrip1"
        Me.ListViewContextMenuStrip.Size = New System.Drawing.Size(153, 126)
        '
        'objConnectMenuItem
        '
        Me.objConnectMenuItem.Name = "objConnectMenuItem"
        Me.objConnectMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objConnectMenuItem.Text = "&Connect"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'objDisConnectMenuItem
        '
        Me.objDisConnectMenuItem.Name = "objDisConnectMenuItem"
        Me.objDisConnectMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objDisConnectMenuItem.Text = "D&isconnect"
        '
        'objTasksMenuItem
        '
        Me.objTasksMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.objShrinkMenuItem, Me.ToolStripSeparator5, Me.objAttachMenuItem, Me.objDetachMenuItem, Me.ToolStripSeparator4, Me.objBackupMenuItem, Me.objRestoreMenuItem, Me.ToolStripSeparator3, Me.objRunScriptMenuItem, Me.objDeleteMenuItem})
        Me.objTasksMenuItem.Name = "objTasksMenuItem"
        Me.objTasksMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objTasksMenuItem.Text = "Tasks"
        '
        'objShrinkMenuItem
        '
        Me.objShrinkMenuItem.Name = "objShrinkMenuItem"
        Me.objShrinkMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objShrinkMenuItem.Text = "Shrink"
        Me.objShrinkMenuItem.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(149, 6)
        '
        'objAttachMenuItem
        '
        Me.objAttachMenuItem.Name = "objAttachMenuItem"
        Me.objAttachMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objAttachMenuItem.Text = "Attach"
        '
        'objDetachMenuItem
        '
        Me.objDetachMenuItem.Name = "objDetachMenuItem"
        Me.objDetachMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objDetachMenuItem.Text = "Detach"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(149, 6)
        '
        'objBackupMenuItem
        '
        Me.objBackupMenuItem.Name = "objBackupMenuItem"
        Me.objBackupMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objBackupMenuItem.Text = "Back Up..."
        '
        'objRestoreMenuItem
        '
        Me.objRestoreMenuItem.Name = "objRestoreMenuItem"
        Me.objRestoreMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objRestoreMenuItem.Text = "Restore"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(149, 6)
        '
        'objRunScriptMenuItem
        '
        Me.objRunScriptMenuItem.Name = "objRunScriptMenuItem"
        Me.objRunScriptMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objRunScriptMenuItem.Text = "Run Script"
        Me.objRunScriptMenuItem.Visible = False
        '
        'objDeleteMenuItem
        '
        Me.objDeleteMenuItem.Name = "objDeleteMenuItem"
        Me.objDeleteMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objDeleteMenuItem.Text = "Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'objNewDatabaseMenuItem
        '
        Me.objNewDatabaseMenuItem.Name = "objNewDatabaseMenuItem"
        Me.objNewDatabaseMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.objNewDatabaseMenuItem.Text = "New Database"
        '
        'SqlServerTreeView
        '
        Me.SqlServerTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SqlServerTreeView.ImageIndex = 0
        Me.SqlServerTreeView.ImageList = Me.ImageList1
        Me.SqlServerTreeView.Location = New System.Drawing.Point(0, 0)
        Me.SqlServerTreeView.Name = "SqlServerTreeView"
        Me.SqlServerTreeView.SelectedImageIndex = 0
        Me.SqlServerTreeView.Size = New System.Drawing.Size(225, 457)
        Me.SqlServerTreeView.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Server.bmp")
        Me.ImageList1.Images.SetKeyName(1, "Database.bmp")
        Me.ImageList1.Images.SetKeyName(2, "Folder.bmp")
        '
        'serverVersionToolStripStatusLabel
        '
        Me.serverVersionToolStripStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.serverVersionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.serverVersionToolStripStatusLabel.Name = "serverVersionToolStripStatusLabel"
        Me.serverVersionToolStripStatusLabel.Size = New System.Drawing.Size(109, 19)
        Me.serverVersionToolStripStatusLabel.Text = "SQL Server Version"
        '
        'ListView
        '
        Me.ListView.ContextMenuStrip = Me.ListViewContextMenuStrip
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.FullRowSelect = True
        Me.ListView.GridLines = True
        Me.ListView.Location = New System.Drawing.Point(0, 0)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(578, 457)
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.SqlServerTreeView)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.ListView)
        Me.splitContainer1.Size = New System.Drawing.Size(807, 457)
        Me.splitContainer1.SplitterDistance = 225
        Me.splitContainer1.TabIndex = 3
        Me.splitContainer1.Text = "splitContainer1"
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.serverVersionToolStripStatusLabel, Me.speedToolStripStatusLabel})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 457)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(807, 24)
        Me.statusStrip1.TabIndex = 2
        Me.statusStrip1.Text = "statusStrip1"
        '
        'speedToolStripStatusLabel
        '
        Me.speedToolStripStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.speedToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.speedToolStripStatusLabel.Name = "speedToolStripStatusLabel"
        Me.speedToolStripStatusLabel.Size = New System.Drawing.Size(102, 19)
        Me.speedToolStripStatusLabel.Text = "Execution Speeds"
        '
        'ctrlDatabaseDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "ctrlDatabaseDetails"
        Me.Size = New System.Drawing.Size(807, 481)
        Me.ListViewContextMenuStrip.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ListViewContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Private WithEvents objConnectMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents objNewDatabaseMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SqlServerTreeView As System.Windows.Forms.TreeView
    Private WithEvents serverVersionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ListView As System.Windows.Forms.ListView
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents speedToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents objDisConnectMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents objTasksMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents objDetachMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents objShrinkMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents objBackupMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents objRestoreMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents objDeleteMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents objRunScriptMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents objAttachMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
