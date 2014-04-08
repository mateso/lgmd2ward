<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlReportsLocal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlReportsLocal))
        Me.tvAvailableReports = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.cmbValues = New System.Windows.Forms.ComboBox()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvAvailableReports
        '
        Me.tvAvailableReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvAvailableReports.ImageIndex = 0
        Me.tvAvailableReports.ImageList = Me.ImageList1
        Me.tvAvailableReports.Location = New System.Drawing.Point(0, 0)
        Me.tvAvailableReports.Name = "tvAvailableReports"
        Me.tvAvailableReports.SelectedImageKey = "REFBAR.ICO"
        Me.tvAvailableReports.Size = New System.Drawing.Size(225, 481)
        Me.tvAvailableReports.StateImageList = Me.ImageList1
        Me.tvAvailableReports.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "library.ico")
        Me.ImageList1.Images.SetKeyName(1, "REFBAR.ICO")
        Me.ImageList1.Images.SetKeyName(2, "Server.bmp")
        Me.ImageList1.Images.SetKeyName(3, "Database.bmp")
        Me.ImageList1.Images.SetKeyName(4, "Folder.bmp")
        Me.ImageList1.Images.SetKeyName(5, "library.bmp")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.tvAvailableReports)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.splitContainer1.Size = New System.Drawing.Size(807, 481)
        Me.splitContainer1.SplitterDistance = 225
        Me.splitContainer1.TabIndex = 3
        Me.splitContainer1.Text = "splitContainer1"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "LGMD.Quarterly Report Page1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
        Me.ReportViewer1.Size = New System.Drawing.Size(578, 481)
        Me.ReportViewer1.TabIndex = 1
        '
        'cmbValues
        '
        Me.cmbValues.Location = New System.Drawing.Point(0, 0)
        Me.cmbValues.Name = "cmbValues"
        Me.cmbValues.Size = New System.Drawing.Size(121, 21)
        Me.cmbValues.TabIndex = 0
        Me.cmbValues.Visible = False
        '
        'ctrlReportsLocal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "ctrlReportsLocal"
        Me.Size = New System.Drawing.Size(807, 481)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tvAvailableReports As System.Windows.Forms.TreeView
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cmbValues As System.Windows.Forms.ComboBox
End Class
