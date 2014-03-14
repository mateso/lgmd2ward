<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DependenciesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.WhereUsedContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WhereUsedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DependenciesTreeView = New System.Windows.Forms.TreeView
        Me.ScriptTextBox = New System.Windows.Forms.TextBox
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.WhereUsedContextMenuStrip.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WhereUsedContextMenuStrip
        '
        Me.WhereUsedContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WhereUsedToolStripMenuItem})
        Me.WhereUsedContextMenuStrip.Name = "WhereUsedContextMenuStrip"
        Me.WhereUsedContextMenuStrip.Size = New System.Drawing.Size(134, 26)
        '
        'WhereUsedToolStripMenuItem
        '
        Me.WhereUsedToolStripMenuItem.Name = "WhereUsedToolStripMenuItem"
        Me.WhereUsedToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.WhereUsedToolStripMenuItem.Text = "&Where Used"
        '
        'DependenciesTreeView
        '
        Me.DependenciesTreeView.ContextMenuStrip = Me.WhereUsedContextMenuStrip
        Me.DependenciesTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DependenciesTreeView.Location = New System.Drawing.Point(0, 0)
        Me.DependenciesTreeView.Name = "DependenciesTreeView"
        Me.DependenciesTreeView.Size = New System.Drawing.Size(247, 462)
        Me.DependenciesTreeView.TabIndex = 0
        '
        'ScriptTextBox
        '
        Me.ScriptTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScriptTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.ScriptTextBox.Location = New System.Drawing.Point(2, 3)
        Me.ScriptTextBox.Multiline = True
        Me.ScriptTextBox.Name = "ScriptTextBox"
        Me.ScriptTextBox.ReadOnly = True
        Me.ScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ScriptTextBox.Size = New System.Drawing.Size(983, 829)
        Me.ScriptTextBox.TabIndex = 0
        Me.ScriptTextBox.WordWrap = False
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.DependenciesTreeView)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.ScriptTextBox)
        Me.splitContainer1.Size = New System.Drawing.Size(778, 462)
        Me.splitContainer1.SplitterDistance = 247
        Me.splitContainer1.TabIndex = 1
        Me.splitContainer1.Text = "splitContainer1"
        '
        'DependenciesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 462)
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "DependenciesForm"
        Me.Text = "DependenciesForm"
        Me.WhereUsedContextMenuStrip.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.Panel2.PerformLayout()
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents WhereUsedContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Private WithEvents WhereUsedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents DependenciesTreeView As System.Windows.Forms.TreeView
    Private WithEvents ScriptTextBox As System.Windows.Forms.TextBox
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
End Class
