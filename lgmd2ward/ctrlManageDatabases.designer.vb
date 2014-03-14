<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlManageDatabases
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
        Me.lstDateCreated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstCompatibilityLevel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstSpaceAvailable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstDatabaseName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtNewDatabase = New System.Windows.Forms.TextBox()
        Me.lblNewDatabase = New System.Windows.Forms.Label()
        Me.btnCreateDatabase = New System.Windows.Forms.Button()
        Me.sbrStatus = New System.Windows.Forms.StatusBar()
        Me.DisplayLabel = New System.Windows.Forms.Label()
        Me.listViewDatabases = New System.Windows.Forms.ListView()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.ShowSqlStatementsCheckBox = New System.Windows.Forms.CheckBox()
        Me.txtEventLog = New System.Windows.Forms.TextBox()
        Me.ShowServerMessagesCheckBox = New System.Windows.Forms.CheckBox()
        Me.btnDeleteDatabase = New System.Windows.Forms.Button()
        Me.lblDatabases = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstDateCreated
        '
        Me.lstDateCreated.Text = "Date Created"
        Me.lstDateCreated.Width = 150
        '
        'lstSize
        '
        Me.lstSize.Text = "Size"
        Me.lstSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstSize.Width = 100
        '
        'lstCompatibilityLevel
        '
        Me.lstCompatibilityLevel.Text = "Compatibility Level"
        Me.lstCompatibilityLevel.Width = 100
        '
        'lstSpaceAvailable
        '
        Me.lstSpaceAvailable.Text = "Space Available"
        Me.lstSpaceAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstSpaceAvailable.Width = 100
        '
        'lstDatabaseName
        '
        Me.lstDatabaseName.Text = "Database Name"
        Me.lstDatabaseName.Width = 150
        '
        'txtNewDatabase
        '
        Me.txtNewDatabase.Location = New System.Drawing.Point(119, 254)
        Me.txtNewDatabase.Name = "txtNewDatabase"
        Me.txtNewDatabase.Size = New System.Drawing.Size(384, 20)
        Me.txtNewDatabase.TabIndex = 31
        '
        'lblNewDatabase
        '
        Me.lblNewDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNewDatabase.Location = New System.Drawing.Point(7, 257)
        Me.lblNewDatabase.Name = "lblNewDatabase"
        Me.lblNewDatabase.Size = New System.Drawing.Size(126, 14)
        Me.lblNewDatabase.TabIndex = 30
        Me.lblNewDatabase.Text = "&New database name:"
        '
        'btnCreateDatabase
        '
        Me.btnCreateDatabase.BackColor = System.Drawing.SystemColors.Control
        Me.btnCreateDatabase.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCreateDatabase.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnCreateDatabase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCreateDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCreateDatabase.Location = New System.Drawing.Point(509, 254)
        Me.btnCreateDatabase.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCreateDatabase.Name = "btnCreateDatabase"
        Me.btnCreateDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCreateDatabase.Size = New System.Drawing.Size(128, 23)
        Me.btnCreateDatabase.TabIndex = 32
        Me.btnCreateDatabase.Text = "&Create Database"
        Me.btnCreateDatabase.UseVisualStyleBackColor = False
        '
        'sbrStatus
        '
        Me.sbrStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.sbrStatus.Location = New System.Drawing.Point(0, 577)
        Me.sbrStatus.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.sbrStatus.Name = "sbrStatus"
        Me.sbrStatus.Size = New System.Drawing.Size(650, 25)
        Me.sbrStatus.TabIndex = 35
        Me.sbrStatus.Text = "Ready"
        Me.sbrStatus.Visible = False
        '
        'DisplayLabel
        '
        Me.DisplayLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisplayLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DisplayLabel.Location = New System.Drawing.Point(653, 8)
        Me.DisplayLabel.Name = "DisplayLabel"
        Me.DisplayLabel.Size = New System.Drawing.Size(101, 14)
        Me.DisplayLabel.TabIndex = 26
        Me.DisplayLabel.Text = "Display:"
        '
        'listViewDatabases
        '
        Me.listViewDatabases.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstDatabaseName, Me.lstDateCreated, Me.lstSize, Me.lstSpaceAvailable, Me.lstCompatibilityLevel})
        Me.listViewDatabases.FullRowSelect = True
        Me.listViewDatabases.HideSelection = False
        Me.listViewDatabases.Location = New System.Drawing.Point(7, 29)
        Me.listViewDatabases.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.listViewDatabases.MultiSelect = False
        Me.listViewDatabases.Name = "listViewDatabases"
        Me.listViewDatabases.Size = New System.Drawing.Size(628, 192)
        Me.listViewDatabases.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.listViewDatabases.TabIndex = 25
        Me.listViewDatabases.UseCompatibleStateImageBehavior = False
        Me.listViewDatabases.View = System.Windows.Forms.View.Details
        '
        'lblResults
        '
        Me.lblResults.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblResults.Location = New System.Drawing.Point(7, 286)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(76, 14)
        Me.lblResults.TabIndex = 33
        Me.lblResults.Text = "&Results:"
        Me.lblResults.Visible = False
        '
        'ShowSqlStatementsCheckBox
        '
        Me.ShowSqlStatementsCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowSqlStatementsCheckBox.BackColor = System.Drawing.SystemColors.Control
        Me.ShowSqlStatementsCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ShowSqlStatementsCheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.ShowSqlStatementsCheckBox.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.ShowSqlStatementsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ShowSqlStatementsCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ShowSqlStatementsCheckBox.Location = New System.Drawing.Point(656, 93)
        Me.ShowSqlStatementsCheckBox.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.ShowSqlStatementsCheckBox.Name = "ShowSqlStatementsCheckBox"
        Me.ShowSqlStatementsCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowSqlStatementsCheckBox.Size = New System.Drawing.Size(114, 54)
        Me.ShowSqlStatementsCheckBox.TabIndex = 28
        Me.ShowSqlStatementsCheckBox.Text = "Show S&QL statements in results pane."
        Me.ShowSqlStatementsCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ShowSqlStatementsCheckBox.UseVisualStyleBackColor = False
        '
        'txtEventLog
        '
        Me.txtEventLog.Location = New System.Drawing.Point(10, 304)
        Me.txtEventLog.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.txtEventLog.Multiline = True
        Me.txtEventLog.Name = "txtEventLog"
        Me.txtEventLog.ReadOnly = True
        Me.txtEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEventLog.Size = New System.Drawing.Size(625, 257)
        Me.txtEventLog.TabIndex = 34
        Me.txtEventLog.Visible = False
        '
        'ShowServerMessagesCheckBox
        '
        Me.ShowServerMessagesCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowServerMessagesCheckBox.BackColor = System.Drawing.SystemColors.Control
        Me.ShowServerMessagesCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ShowServerMessagesCheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.ShowServerMessagesCheckBox.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.ShowServerMessagesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ShowServerMessagesCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ShowServerMessagesCheckBox.Location = New System.Drawing.Point(656, 28)
        Me.ShowServerMessagesCheckBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 1)
        Me.ShowServerMessagesCheckBox.Name = "ShowServerMessagesCheckBox"
        Me.ShowServerMessagesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowServerMessagesCheckBox.Size = New System.Drawing.Size(101, 63)
        Me.ShowServerMessagesCheckBox.TabIndex = 27
        Me.ShowServerMessagesCheckBox.Text = "Show server &messages in results pane."
        Me.ShowServerMessagesCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ShowServerMessagesCheckBox.UseVisualStyleBackColor = False
        '
        'btnDeleteDatabase
        '
        Me.btnDeleteDatabase.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteDatabase.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDeleteDatabase.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.btnDeleteDatabase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeleteDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDeleteDatabase.Location = New System.Drawing.Point(509, 225)
        Me.btnDeleteDatabase.Name = "btnDeleteDatabase"
        Me.btnDeleteDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteDatabase.Size = New System.Drawing.Size(128, 23)
        Me.btnDeleteDatabase.TabIndex = 29
        Me.btnDeleteDatabase.Text = "&Delete Database"
        Me.btnDeleteDatabase.UseVisualStyleBackColor = False
        '
        'lblDatabases
        '
        Me.lblDatabases.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDatabases.Location = New System.Drawing.Point(7, 9)
        Me.lblDatabases.Name = "lblDatabases"
        Me.lblDatabases.Size = New System.Drawing.Size(76, 14)
        Me.lblDatabases.TabIndex = 36
        Me.lblDatabases.Text = "Databases:"
        '
        'ctrlManageDatabases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDatabases)
        Me.Controls.Add(Me.txtNewDatabase)
        Me.Controls.Add(Me.lblNewDatabase)
        Me.Controls.Add(Me.btnCreateDatabase)
        Me.Controls.Add(Me.sbrStatus)
        Me.Controls.Add(Me.DisplayLabel)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.ShowSqlStatementsCheckBox)
        Me.Controls.Add(Me.txtEventLog)
        Me.Controls.Add(Me.ShowServerMessagesCheckBox)
        Me.Controls.Add(Me.btnDeleteDatabase)
        Me.Controls.Add(Me.listViewDatabases)
        Me.Name = "ctrlManageDatabases"
        Me.Size = New System.Drawing.Size(650, 602)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstDateCreated As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstCompatibilityLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstSpaceAvailable As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstDatabaseName As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtNewDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblNewDatabase As System.Windows.Forms.Label
    Friend WithEvents btnCreateDatabase As System.Windows.Forms.Button
    Friend WithEvents sbrStatus As System.Windows.Forms.StatusBar
    Friend WithEvents DisplayLabel As System.Windows.Forms.Label
    Friend WithEvents listViewDatabases As System.Windows.Forms.ListView
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents ShowSqlStatementsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents txtEventLog As System.Windows.Forms.TextBox
    Friend WithEvents ShowServerMessagesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteDatabase As System.Windows.Forms.Button
    Friend WithEvents lblDatabases As System.Windows.Forms.Label

End Class
