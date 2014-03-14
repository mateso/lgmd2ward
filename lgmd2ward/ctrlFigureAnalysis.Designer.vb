<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlFigureAnalysis
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
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblIndicatorTable = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmoTotalResult = New System.Windows.Forms.ComboBox()
        Me.cmoGeographicalAreas = New System.Windows.Forms.ComboBox()
        Me.cmoAreaLevels = New System.Windows.Forms.ComboBox()
        Me.cmoTimePeriods = New System.Windows.Forms.ComboBox()
        Me.btnXML = New System.Windows.Forms.Button()
        Me.btnGrid = New System.Windows.Forms.Button()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.lstSearchResult = New System.Windows.Forms.ListBox()
        Me.lblIndicatorColumn = New System.Windows.Forms.Label()
        Me.cmoAreaName = New System.Windows.Forms.ComboBox()
        Me.cmoTime = New System.Windows.Forms.ComboBox()
        Me.cmoFilteredResult = New System.Windows.Forms.ComboBox()
        Me.txtFigureAnalysisDescription = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.lblIndicatorSP = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.lblIndicatorCategory = New System.Windows.Forms.Label()
        Me.lblIndicatorSubCategory = New System.Windows.Forms.Label()
        Me.lblResultOptions = New System.Windows.Forms.Label()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearchKeyword
        '
        Me.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchKeyword.Location = New System.Drawing.Point(49, 41)
        Me.txtSearchKeyword.Name = "txtSearchKeyword"
        Me.txtSearchKeyword.Size = New System.Drawing.Size(126, 20)
        Me.txtSearchKeyword.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(213, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(102, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblIndicatorTable
        '
        Me.lblIndicatorTable.AutoSize = True
        Me.lblIndicatorTable.Location = New System.Drawing.Point(46, 285)
        Me.lblIndicatorTable.Name = "lblIndicatorTable"
        Me.lblIndicatorTable.Size = New System.Drawing.Size(75, 13)
        Me.lblIndicatorTable.TabIndex = 3
        Me.lblIndicatorTable.Text = "IndicatorTable"
        Me.lblIndicatorTable.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 485)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Geographical areas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 541)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Time periods"
        '
        'cmoTotalResult
        '
        Me.cmoTotalResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoTotalResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoTotalResult.FormattingEnabled = True
        Me.cmoTotalResult.Location = New System.Drawing.Point(254, 285)
        Me.cmoTotalResult.Name = "cmoTotalResult"
        Me.cmoTotalResult.Size = New System.Drawing.Size(121, 21)
        Me.cmoTotalResult.TabIndex = 10
        Me.cmoTotalResult.Visible = False
        '
        'cmoGeographicalAreas
        '
        Me.cmoGeographicalAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoGeographicalAreas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoGeographicalAreas.FormattingEnabled = True
        Me.cmoGeographicalAreas.Location = New System.Drawing.Point(157, 482)
        Me.cmoGeographicalAreas.Name = "cmoGeographicalAreas"
        Me.cmoGeographicalAreas.Size = New System.Drawing.Size(121, 21)
        Me.cmoGeographicalAreas.TabIndex = 11
        '
        'cmoAreaLevels
        '
        Me.cmoAreaLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoAreaLevels.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoAreaLevels.FormattingEnabled = True
        Me.cmoAreaLevels.Location = New System.Drawing.Point(317, 481)
        Me.cmoAreaLevels.Name = "cmoAreaLevels"
        Me.cmoAreaLevels.Size = New System.Drawing.Size(194, 21)
        Me.cmoAreaLevels.TabIndex = 12
        Me.cmoAreaLevels.Visible = False
        '
        'cmoTimePeriods
        '
        Me.cmoTimePeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoTimePeriods.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoTimePeriods.FormattingEnabled = True
        Me.cmoTimePeriods.Location = New System.Drawing.Point(157, 538)
        Me.cmoTimePeriods.Name = "cmoTimePeriods"
        Me.cmoTimePeriods.Size = New System.Drawing.Size(121, 21)
        Me.cmoTimePeriods.TabIndex = 13
        '
        'btnXML
        '
        Me.btnXML.Location = New System.Drawing.Point(520, 503)
        Me.btnXML.Name = "btnXML"
        Me.btnXML.Size = New System.Drawing.Size(72, 23)
        Me.btnXML.TabIndex = 14
        Me.btnXML.Text = "Get XML"
        Me.btnXML.UseVisualStyleBackColor = True
        '
        'btnGrid
        '
        Me.btnGrid.Location = New System.Drawing.Point(519, 534)
        Me.btnGrid.Name = "btnGrid"
        Me.btnGrid.Size = New System.Drawing.Size(75, 23)
        Me.btnGrid.TabIndex = 15
        Me.btnGrid.Text = "Show in Grid"
        Me.btnGrid.UseVisualStyleBackColor = True
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(49, 620)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.Size = New System.Drawing.Size(620, 256)
        Me.dgvResult.TabIndex = 16
        '
        'lstSearchResult
        '
        Me.lstSearchResult.BackColor = System.Drawing.SystemColors.Window
        Me.lstSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSearchResult.FormattingEnabled = True
        Me.lstSearchResult.Location = New System.Drawing.Point(49, 82)
        Me.lstSearchResult.Name = "lstSearchResult"
        Me.lstSearchResult.Size = New System.Drawing.Size(620, 184)
        Me.lstSearchResult.TabIndex = 17
        '
        'lblIndicatorColumn
        '
        Me.lblIndicatorColumn.AutoSize = True
        Me.lblIndicatorColumn.Location = New System.Drawing.Point(46, 301)
        Me.lblIndicatorColumn.Name = "lblIndicatorColumn"
        Me.lblIndicatorColumn.Size = New System.Drawing.Size(83, 13)
        Me.lblIndicatorColumn.TabIndex = 18
        Me.lblIndicatorColumn.Text = "IndicatorColumn"
        Me.lblIndicatorColumn.Visible = False
        '
        'cmoAreaName
        '
        Me.cmoAreaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoAreaName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoAreaName.FormattingEnabled = True
        Me.cmoAreaName.Location = New System.Drawing.Point(317, 505)
        Me.cmoAreaName.Name = "cmoAreaName"
        Me.cmoAreaName.Size = New System.Drawing.Size(194, 21)
        Me.cmoAreaName.TabIndex = 20
        Me.cmoAreaName.Visible = False
        '
        'cmoTime
        '
        Me.cmoTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoTime.FormattingEnabled = True
        Me.cmoTime.Location = New System.Drawing.Point(317, 537)
        Me.cmoTime.Name = "cmoTime"
        Me.cmoTime.Size = New System.Drawing.Size(194, 21)
        Me.cmoTime.TabIndex = 21
        Me.cmoTime.Visible = False
        '
        'cmoFilteredResult
        '
        Me.cmoFilteredResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmoFilteredResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmoFilteredResult.FormattingEnabled = True
        Me.cmoFilteredResult.Location = New System.Drawing.Point(398, 285)
        Me.cmoFilteredResult.Name = "cmoFilteredResult"
        Me.cmoFilteredResult.Size = New System.Drawing.Size(271, 21)
        Me.cmoFilteredResult.TabIndex = 22
        Me.cmoFilteredResult.Visible = False
        '
        'txtFigureAnalysisDescription
        '
        Me.txtFigureAnalysisDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFigureAnalysisDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFigureAnalysisDescription.Location = New System.Drawing.Point(49, 573)
        Me.txtFigureAnalysisDescription.Multiline = True
        Me.txtFigureAnalysisDescription.Name = "txtFigureAnalysisDescription"
        Me.txtFigureAnalysisDescription.ReadOnly = True
        Me.txtFigureAnalysisDescription.Size = New System.Drawing.Size(620, 46)
        Me.txtFigureAnalysisDescription.TabIndex = 23
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(253, 314)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 24
        Me.ComboBox1.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(398, 314)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(271, 21)
        Me.ComboBox2.TabIndex = 25
        Me.ComboBox2.Visible = False
        '
        'lblIndicatorSP
        '
        Me.lblIndicatorSP.AutoSize = True
        Me.lblIndicatorSP.Location = New System.Drawing.Point(45, 369)
        Me.lblIndicatorSP.Name = "lblIndicatorSP"
        Me.lblIndicatorSP.Size = New System.Drawing.Size(62, 13)
        Me.lblIndicatorSP.TabIndex = 26
        Me.lblIndicatorSP.Text = "IndicatorSP"
        Me.lblIndicatorSP.Visible = False
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(252, 341)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(123, 21)
        Me.ComboBox3.TabIndex = 27
        Me.ComboBox3.Visible = False
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(398, 341)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(271, 21)
        Me.ComboBox4.TabIndex = 28
        Me.ComboBox4.Visible = False
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(157, 432)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox5.TabIndex = 29
        Me.ComboBox5.Visible = False
        '
        'lblIndicatorCategory
        '
        Me.lblIndicatorCategory.AutoSize = True
        Me.lblIndicatorCategory.Location = New System.Drawing.Point(46, 317)
        Me.lblIndicatorCategory.Name = "lblIndicatorCategory"
        Me.lblIndicatorCategory.Size = New System.Drawing.Size(90, 13)
        Me.lblIndicatorCategory.TabIndex = 30
        Me.lblIndicatorCategory.Text = "IndicatorCategory"
        Me.lblIndicatorCategory.Visible = False
        '
        'lblIndicatorSubCategory
        '
        Me.lblIndicatorSubCategory.AutoSize = True
        Me.lblIndicatorSubCategory.Location = New System.Drawing.Point(44, 340)
        Me.lblIndicatorSubCategory.Name = "lblIndicatorSubCategory"
        Me.lblIndicatorSubCategory.Size = New System.Drawing.Size(109, 13)
        Me.lblIndicatorSubCategory.TabIndex = 31
        Me.lblIndicatorSubCategory.Text = "IndicatorSubCategory"
        Me.lblIndicatorSubCategory.Visible = False
        '
        'lblResultOptions
        '
        Me.lblResultOptions.AutoSize = True
        Me.lblResultOptions.Location = New System.Drawing.Point(162, 289)
        Me.lblResultOptions.Name = "lblResultOptions"
        Me.lblResultOptions.Size = New System.Drawing.Size(76, 13)
        Me.lblResultOptions.TabIndex = 32
        Me.lblResultOptions.Text = "Result Options"
        Me.lblResultOptions.Visible = False
        '
        'ctrlFigureAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.lblResultOptions)
        Me.Controls.Add(Me.lblIndicatorSubCategory)
        Me.Controls.Add(Me.lblIndicatorCategory)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.lblIndicatorSP)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.txtFigureAnalysisDescription)
        Me.Controls.Add(Me.cmoFilteredResult)
        Me.Controls.Add(Me.cmoTime)
        Me.Controls.Add(Me.cmoAreaName)
        Me.Controls.Add(Me.lblIndicatorColumn)
        Me.Controls.Add(Me.lstSearchResult)
        Me.Controls.Add(Me.dgvResult)
        Me.Controls.Add(Me.btnGrid)
        Me.Controls.Add(Me.btnXML)
        Me.Controls.Add(Me.cmoTimePeriods)
        Me.Controls.Add(Me.cmoAreaLevels)
        Me.Controls.Add(Me.cmoGeographicalAreas)
        Me.Controls.Add(Me.cmoTotalResult)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblIndicatorTable)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchKeyword)
        Me.Name = "ctrlFigureAnalysis"
        Me.Size = New System.Drawing.Size(708, 918)
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblIndicatorTable As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmoTotalResult As System.Windows.Forms.ComboBox
    Friend WithEvents cmoGeographicalAreas As System.Windows.Forms.ComboBox
    Friend WithEvents cmoAreaLevels As System.Windows.Forms.ComboBox
    Friend WithEvents cmoTimePeriods As System.Windows.Forms.ComboBox
    Friend WithEvents btnXML As System.Windows.Forms.Button
    Friend WithEvents btnGrid As System.Windows.Forms.Button
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents lstSearchResult As System.Windows.Forms.ListBox
    Friend WithEvents lblIndicatorColumn As System.Windows.Forms.Label
    Friend WithEvents cmoAreaName As System.Windows.Forms.ComboBox
    Friend WithEvents cmoTime As System.Windows.Forms.ComboBox
    Friend WithEvents cmoFilteredResult As System.Windows.Forms.ComboBox
    Friend WithEvents txtFigureAnalysisDescription As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblIndicatorSP As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents lblIndicatorCategory As System.Windows.Forms.Label
    Friend WithEvents lblIndicatorSubCategory As System.Windows.Forms.Label
    Friend WithEvents lblResultOptions As System.Windows.Forms.Label

End Class
