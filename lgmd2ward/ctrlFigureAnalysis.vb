Imports System.Data.Sql
Imports System.Data.SqlClient
Imports LGMD.ctrlEditForm
Imports System.Text.RegularExpressions

Public Class ctrlFigureAnalysis
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private dt As DataTable
    Private cmd As SqlCommand
    Private indicatorSP As String
    Private indicatorColumn As String
    Private indicatorTable As String
    Private areaName As String = ""
    Private timePeriod As String = ""
    Private timePeriods As List(Of String)
    Private periodFrom As System.Nullable(Of DateTime)
    Private periodTo As System.Nullable(Of DateTime)

    Private Sub ctrlFigureAnalysis_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call Me.LoadComboBoxes()
    End Sub

    Private Sub txtSearchKeyword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchKeyword.TextChanged

        Me.lstSearchResult.DataSource = Nothing
        Me.dgvResult.DataSource = Nothing
        Call Me.ClearFigureAnalysisControls()
        If Me.txtSearchKeyword.Text.Length.Equals(0) Then
            Me.lstSearchResult.DataSource = Nothing
            Me.dgvResult.DataSource = Nothing
        End If
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click

        Me.Cursor = Cursors.WaitCursor

        ds = New DataSet
        da = New SqlDataAdapter
        dt = New DataTable
        cmd = New SqlCommand

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "fgSearchFigureAnalysis"
                .Parameters.AddWithValue("@SearchKeyword", Me.txtSearchKeyword.Text)
                .ExecuteNonQuery()
            End With

            'fill in insert, update, and delete commands
            'Dim cmdBldr As New SqlCommandBuilder(da)

            da.SelectCommand = cmd
            da.Fill(ds, "lstBox")
            dt = ds.Tables("lstBox")

            If dt.Rows.Count > 0 Then
                Me.lstSearchResult.SelectionMode = SelectionMode.None
                Me.lstSearchResult.DataSource = dt
                Me.lstSearchResult.DisplayMember = "IndicatorDescription"
                Me.lstSearchResult.ValueMember = "IndicatorDescription"
            Else
                MessageBox.Show("No result found", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.lstSearchResult.DataSource = Nothing
                Me.dgvResult.DataSource = Nothing
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Private Sub lstSearchResult_MouseEnter(sender As System.Object, e As System.EventArgs) Handles lstSearchResult.MouseEnter
        Me.lstSearchResult.SelectionMode = SelectionMode.One
    End Sub

    Private Sub lstSearchResult_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles lstSearchResult.SelectedValueChanged

        Call Me.ClearFigureAnalysisControls()

        ds = New DataSet
        da = New SqlDataAdapter
        dt = New DataTable
        cmd = New SqlCommand

        Try
            Me.Cursor = Cursors.WaitCursor
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "fgSearchFigureAnalysisIndicator"
                .Parameters.AddWithValue("@SearchKeyword", Me.lstSearchResult.SelectedValue)
                .ExecuteNonQuery()
            End With

            'fill in insert, update, and delete commands
            'Dim cmdBldr As New SqlCommandBuilder(da)

            da.SelectCommand = cmd
            da.Fill(ds, "Indicators")
            dt = ds.Tables("Indicators")

            If dt.Rows.Count > 0 Then
                Me.lblIndicatorTable.Text = dt.Rows(0)(0).ToString
                Me.lblIndicatorColumn.Text = dt.Rows(0)(1).ToString
                Me.lblIndicatorSP.Text = dt.Rows(0)(2).ToString
                Me.lblIndicatorTable.Visible = False
                Me.lblIndicatorColumn.Visible = False
                Me.lblIndicatorSP.Visible = False
                indicatorTable = dt.Rows(0)(0).ToString
                indicatorColumn = dt.Rows(0)(1).ToString
                indicatorSP = dt.Rows(0)(2).ToString

            End If

            'This code was outside if for the first time
            'Check if specified selected indicator has data

            ds = New DataSet
            da = New SqlDataAdapter
            dt = New DataTable
            cmd = New SqlCommand
            Dim selectedAreaID As String = ""

            If Me.cmoGeographicalAreas.Text = "Choose one:" Then
                selectedAreaID = GetAreaID(Me.cmoAreaName.Text)
            ElseIf Me.cmoGeographicalAreas.Text = "Choose one:" And GetConfigLevel() = 5 Then
                selectedAreaID = GetAreaID(Me.cmoAreaName.Text)
            Else
                selectedAreaID = GetAreaID(Me.cmoAreaName.Text) + "_%"
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = indicatorSP
                .Parameters.AddWithValue("@selectedAreaLevel", 5)
                .Parameters.AddWithValue("@boolOneOrMoreRecords", 1)
                .Parameters.AddWithValue("@figureAnalysisCriteria", 3)
                .Parameters.AddWithValue("@ColumnName", indicatorColumn)
                .ExecuteNonQuery()
            End With

            'fill in insert, update, and delete commands
            'Dim cmdBldr As New SqlCommandBuilder(da)

            da.SelectCommand = cmd
            da.Fill(ds, "queryResult")
            dt = ds.Tables("queryResult")

            If dt.Rows.Count = 0 Then
                Me.cmoTotalResult.Visible = False
                MessageBox.Show("No data found for this figure", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dt.Columns.Count > 6 Then
                'Me.LoadComboBoxes()
                Me.lblResultOptions.Visible = True
                Me.cmoTotalResult.Text = ""
                Me.cmoTotalResult.Visible = True
            End If

            'End of block which was outside if condition

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Private Sub btnGrid_Click(sender As System.Object, e As System.EventArgs) Handles btnGrid.Click

        Me.dgvResult.DataSource = Nothing

        Dim dgvResultColumn0 As DataGridViewTextBoxColumn
        Dim dgvResultColumn1 As DataGridViewTextBoxColumn
        Dim dgvResultColumn2 As DataGridViewTextBoxColumn
        Dim dgvResultColumn3 As DataGridViewTextBoxColumn
        Dim dgvResultColumn4 As DataGridViewTextBoxColumn
        Dim dgvResultColumn5 As DataGridViewTextBoxColumn
        Dim dgvResultColumn6 As DataGridViewTextBoxColumn

        If Me.lstSearchResult.Items.Count.Equals(0) Then
            MessageBox.Show("Choose Figure", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.lstSearchResult.SelectedValue = Nothing Then
            MessageBox.Show("Choose Figure", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmoTotalResult.Visible = True And Me.cmoTotalResult.Text = "" Then
            MessageBox.Show("Choose a breakdown option", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmoFilteredResult.Visible = True And Me.cmoFilteredResult.Text = "" Then
            MessageBox.Show("Choose a breakdown option", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmoGeographicalAreas.Text = "" Then
            MessageBox.Show("Choose geographical option", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmoAreaLevels.Visible = True And Me.cmoAreaLevels.Text = "" Then
            MessageBox.Show("Choose geographical option", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmoTimePeriods.Text = "" Then
            MessageBox.Show("Choose a time period option", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmoTime.Visible = True And Me.cmoTime.Text = "" Then
            MessageBox.Show("Choose a time period", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.cmoTime.Visible = True And Me.cmoTime.Text.Length > 0 Then
            periodFrom = CDate(Me.cmoTime.Text.Substring(0, 11))
            periodTo = CDate(Me.cmoTime.Text.Substring(14, 11))
        Else
            periodFrom = Nothing
            periodTo = Nothing
        End If

        If IsNothing(Me.dgvResult.DataSource) Then
            areaName = " - " + Me.cmoAreaName.Text
            timePeriod = " - " + Me.cmoTime.Text

            If Me.cmoGeographicalAreas.Text = "Choose one:" Then
                Me.txtFigureAnalysisDescription.Text = Me.lstSearchResult.Text + areaName + timePeriod
            ElseIf Me.cmoTimePeriods.Text = "Choose one:" Then
                Me.txtFigureAnalysisDescription.Text = Me.lstSearchResult.Text + areaName + timePeriod
            Else
                Me.txtFigureAnalysisDescription.Text = Me.lstSearchResult.Text
            End If

            ds = New DataSet
            da = New SqlDataAdapter
            dt = New DataTable
            cmd = New SqlCommand
            Dim selectedAreaLevel As Integer
            Dim selectedAreaID As String = ""
            Dim boolOneOrMoreRecords As Integer
            Dim figureAnalysisCriteria As Integer

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                If GetConfigLevel() = 5 Then
                    selectedAreaLevel = 5
                    selectedAreaID = GetConfigArea()
                    boolOneOrMoreRecords = 0
                    figureAnalysisCriteria = 3
                ElseIf GetConfigLevel() = 4 Then
                    If Me.cmoGeographicalAreas.Text = "Show in rows" Then
                        If Me.cmoAreaLevels.Text = "District" Then
                            selectedAreaLevel = 5
                            boolOneOrMoreRecords = 1
                            figureAnalysisCriteria = 3
                        ElseIf Me.cmoAreaLevels.Text = "Region" Then
                            selectedAreaLevel = 4
                            selectedAreaID = GetConfigArea()
                            boolOneOrMoreRecords = 0
                            figureAnalysisCriteria = 6
                        End If
                    ElseIf Me.cmoGeographicalAreas.Text = "Show in columns" Then
                        If Me.cmoAreaLevels.Text = "District" Then
                            selectedAreaID = GetConfigArea() + "_________"
                        ElseIf Me.cmoAreaLevels.Text = "Region" Then
                            selectedAreaID = GetConfigArea() + "______"
                        End If
                    ElseIf Me.cmoGeographicalAreas.Text = "Total" Then
                        selectedAreaID = GetConfigArea()
                    ElseIf Me.cmoGeographicalAreas.Text = "Choose one:" Then
                        selectedAreaID = GetAreaID(Me.cmoAreaName.Text)
                        If selectedAreaID.Length = 12 Then
                            selectedAreaLevel = 4
                            boolOneOrMoreRecords = 0
                            figureAnalysisCriteria = 6
                        Else
                            selectedAreaLevel = 5
                            boolOneOrMoreRecords = 0
                            figureAnalysisCriteria = 3
                        End If
                    Else
                        selectedAreaID = GetConfigArea()
                    End If
                Else
                    If Me.cmoGeographicalAreas.Text = "Show in rows" Then
                        If Me.cmoAreaLevels.Text = "District" Then
                            selectedAreaLevel = 5
                            selectedAreaID = GetConfigArea()
                            boolOneOrMoreRecords = 1
                            figureAnalysisCriteria = 3
                        ElseIf Me.cmoAreaLevels.Text = "Region" Then
                            selectedAreaLevel = 4
                            selectedAreaID = GetConfigArea()
                            boolOneOrMoreRecords = 1
                            figureAnalysisCriteria = 6
                        End If
                    ElseIf Me.cmoGeographicalAreas.Text = "Show in columns" Then
                        If Me.cmoAreaLevels.Text = "District" Then
                            selectedAreaID = GetConfigArea() + "_________"
                        ElseIf Me.cmoAreaLevels.Text = "Region" Then
                            selectedAreaID = GetConfigArea() + "______"
                        End If
                    ElseIf Me.cmoGeographicalAreas.Text = "Total" Then
                        selectedAreaID = GetConfigArea()
                    ElseIf Me.cmoGeographicalAreas.Text = "Choose one:" Then
                        selectedAreaID = GetAreaID(Me.cmoAreaName.Text)
                        If selectedAreaID.Length = 12 Then
                            selectedAreaLevel = 4
                            boolOneOrMoreRecords = 0
                            figureAnalysisCriteria = 6
                        Else
                            selectedAreaLevel = 5
                            boolOneOrMoreRecords = 0
                            figureAnalysisCriteria = 3
                        End If
                    Else
                        selectedAreaID = GetConfigArea()
                    End If
                End If

                With cmd
                    .Connection = conn
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = indicatorSP
                    .Parameters.AddWithValue("@selectedAreaLevel", selectedAreaLevel)
                    .Parameters.AddWithValue("@selectedAreaID", selectedAreaID)
                    .Parameters.AddWithValue("@boolOneOrMoreRecords", boolOneOrMoreRecords)
                    .Parameters.AddWithValue("@FigureAnalysisCriteria", figureAnalysisCriteria)
                    .Parameters.AddWithValue("@ColumnName", indicatorColumn)
                    .Parameters.AddWithValue("@ColumnItem", Me.cmoFilteredResult.Text)
                    .Parameters.AddWithValue("@PeriodFrom", Me.periodFrom)
                    .Parameters.AddWithValue("@PeriodTo", Me.periodTo)
                    .ExecuteNonQuery()
                End With

                'fill in insert, update, and delete commands
                Dim cmdBldr As New SqlCommandBuilder(da)
                da.SelectCommand = cmd
                da.Fill(ds, "dgv")
                dt = ds.Tables("dgv")

                If dt.Rows.Count > 0 Then
                    If dt.Columns.Count > 6 Then
                        dgvResultColumn0 = New DataGridViewTextBoxColumn
                        dgvResultColumn0.Name = "ID"
                        dgvResultColumn0.HeaderText = "ID"
                        dgvResultColumn0.DataPropertyName = dt.Columns(0).ToString
                        dgvResultColumn0.Visible = False

                        dgvResultColumn1 = New DataGridViewTextBoxColumn
                        dgvResultColumn1.Name = "AreaName"
                        dgvResultColumn1.HeaderText = "Area Name"
                        dgvResultColumn1.DataPropertyName = dt.Columns(1).ToString
                        dgvResultColumn1.Visible = True

                        dgvResultColumn2 = New DataGridViewTextBoxColumn
                        dgvResultColumn2.Name = "AreaID"
                        dgvResultColumn2.HeaderText = "AreaID"
                        dgvResultColumn2.DataPropertyName = dt.Columns(2).ToString
                        dgvResultColumn2.Visible = False

                        dgvResultColumn3 = New DataGridViewTextBoxColumn
                        dgvResultColumn3.Name = "FilteredResultColumn"
                        dgvResultColumn3.HeaderText = Regex.Replace(dt.Columns(3).ColumnName.ToString, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ")
                        dgvResultColumn3.DataPropertyName = dt.Columns(3).ToString

                        dgvResultColumn4 = New DataGridViewTextBoxColumn
                        dgvResultColumn4.Name = "PeriodFrom"
                        dgvResultColumn4.HeaderText = "Period From"
                        dgvResultColumn4.DataPropertyName = dt.Columns(4).ToString

                        dgvResultColumn5 = New DataGridViewTextBoxColumn
                        dgvResultColumn5.Name = "PeriodTo"
                        dgvResultColumn5.HeaderText = "Period To"
                        dgvResultColumn5.DataPropertyName = dt.Columns(5).ToString

                        dgvResultColumn6 = New DataGridViewTextBoxColumn
                        dgvResultColumn6.Name = "DataColumn"
                        dgvResultColumn6.HeaderText = Me.txtFigureAnalysisDescription.Text
                        dgvResultColumn6.DataPropertyName = dt.Columns(6).ToString

                        Me.dgvResult.Columns.Add(dgvResultColumn0)
                        Me.dgvResult.Columns.Add(dgvResultColumn1)
                        Me.dgvResult.Columns.Add(dgvResultColumn2)
                        Me.dgvResult.Columns.Add(dgvResultColumn3)
                        Me.dgvResult.Columns.Add(dgvResultColumn4)
                        Me.dgvResult.Columns.Add(dgvResultColumn5)
                        Me.dgvResult.Columns.Add(dgvResultColumn6)
                        Me.dgvResult.DataSource = dt
                    Else
                        dgvResultColumn0 = New DataGridViewTextBoxColumn
                        dgvResultColumn0.Name = "ID"
                        dgvResultColumn0.HeaderText = "ID"
                        dgvResultColumn0.DataPropertyName = dt.Columns(0).ToString
                        dgvResultColumn0.Visible = False

                        dgvResultColumn1 = New DataGridViewTextBoxColumn
                        dgvResultColumn1.Name = "AreaName"
                        dgvResultColumn1.HeaderText = "Area Name"
                        dgvResultColumn1.DataPropertyName = dt.Columns(1).ToString
                        dgvResultColumn1.Visible = True

                        dgvResultColumn2 = New DataGridViewTextBoxColumn
                        dgvResultColumn2.Name = "AreaID"
                        dgvResultColumn2.HeaderText = "AreaID"
                        dgvResultColumn2.DataPropertyName = dt.Columns(2).ToString
                        dgvResultColumn2.Visible = False

                        dgvResultColumn3 = New DataGridViewTextBoxColumn
                        dgvResultColumn3.Name = "PeriodFrom"
                        dgvResultColumn3.HeaderText = "Period From"
                        dgvResultColumn3.DataPropertyName = dt.Columns(3).ToString

                        dgvResultColumn4 = New DataGridViewTextBoxColumn
                        dgvResultColumn4.Name = "PeriodTo"
                        dgvResultColumn4.HeaderText = "Period To"
                        dgvResultColumn4.DataPropertyName = dt.Columns(4).ToString

                        dgvResultColumn5 = New DataGridViewTextBoxColumn
                        dgvResultColumn5.Name = "DataColumn"
                        dgvResultColumn5.HeaderText = Me.txtFigureAnalysisDescription.Text
                        dgvResultColumn5.DataPropertyName = dt.Columns(5).ToString

                        Me.dgvResult.Columns.Add(dgvResultColumn0)
                        Me.dgvResult.Columns.Add(dgvResultColumn1)
                        Me.dgvResult.Columns.Add(dgvResultColumn2)
                        Me.dgvResult.Columns.Add(dgvResultColumn3)
                        Me.dgvResult.Columns.Add(dgvResultColumn4)
                        Me.dgvResult.Columns.Add(dgvResultColumn5)
                        Me.dgvResult.DataSource = dt

                    End If
                Else
                    MessageBox.Show("No result found", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub btnXML_Click(sender As System.Object, e As System.EventArgs) Handles btnXML.Click

        'Call ValidateBreakDown()

        If Me.lstSearchResult.Items.Count.Equals(0) Then
            MessageBox.Show("Select Figure", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.lstSearchResult.SelectedValue = Nothing Then
            MessageBox.Show("Select Figure", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim saveFileDialogue As New SaveFileDialog
        With saveFileDialogue
            .Title = "Save XML File"
            .Filter = "LGMD2 Files(*.xml)|*.xml"
            .DefaultExt = "xml"
            .AddExtension = True
        End With
        If saveFileDialogue.ShowDialog = DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                dt.WriteXml(saveFileDialogue.FileName)
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub showResult()
        'If Me.lstSearchResult.Items.Count.Equals(0) Then
        '    MessageBox.Show("Select Figure", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        ds = New DataSet
        da = New SqlDataAdapter
        dt = New DataTable
        cmd = New SqlCommand

        Try
            conn.Open()

            'Dim cmd As New SqlCommand("select IndicatorSP from Indicators where IndicatorTable='" & Me.lblIndicator.Text & "'")

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = indicatorSP
                .Parameters.AddWithValue("@ColumnName", indicatorColumn)
                '.Parameters.AddWithValue("@AreaID", g_FormSerialNumber)
                .ExecuteNonQuery()
            End With

            'fill in insert, update, and delete commands
            'Dim cmdBldr As New SqlCommandBuilder(da)

            da.SelectCommand = cmd
            da.Fill(ds, "showResult")
            dt = ds.Tables("showResult")

            If dt.Rows.Count > 0 Then
                dgvResult.DataSource = dt
                'Me.cmoFilteredResult.DisplayMember = dt.Rows()(0).ToString
                'Me.cmoFilteredResult.ValueMember = dt.Rows()(1).ToString
                'Me.cmoFilteredResult.DataSource = dt
            Else
                MessageBox.Show("No result found", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cmoTotalResult_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmoTotalResult.SelectedValueChanged
        Me.txtFigureAnalysisDescription.Text = ""
        Me.dgvResult.DataSource = Nothing
        If Me.cmoTotalResult.Text = "Show in rows" Then
            Me.cmoFilteredResult.Visible = False
            Me.cmoFilteredResult.Text = ""
            Me.cmoFilteredResult.Items.Clear()
        ElseIf Me.cmoTotalResult.Text = "Show in columns" Then
            Me.cmoFilteredResult.Visible = False
            Me.cmoFilteredResult.Text = ""
            Me.cmoFilteredResult.Items.Clear()
        ElseIf Me.cmoTotalResult.Text = "Total" Then
            Me.cmoFilteredResult.Visible = False
            Me.cmoFilteredResult.Text = ""
            Me.cmoFilteredResult.Items.Clear()
        ElseIf Me.cmoTotalResult.Text = "Choose one:" Then
            Call lstSearchResult_SelectedValueChanged(sender, e)

            Dim list As List(Of String) = dt.AsEnumerable().Select(Function(r) r.Field(Of String)(3)).Distinct.ToList()
            Me.cmoFilteredResult.Items.AddRange(list.ToArray())
            Me.cmoFilteredResult.Visible = True
        End If
    End Sub

    Private Sub cmoFilteredResult_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmoFilteredResult.SelectedIndexChanged
        Me.txtFigureAnalysisDescription.Text = ""
        Me.dgvResult.DataSource = Nothing
    End Sub

    Private Sub cmoGeographicalAreas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmoGeographicalAreas.SelectedIndexChanged
        Me.txtFigureAnalysisDescription.Text = ""
        Me.dgvResult.DataSource = Nothing
        If Me.cmoGeographicalAreas.Text = "Show in rows" Then
            Me.cmoAreaLevels.Visible = True
            Me.cmoAreaName.Visible = False
            Me.cmoAreaName.Text = ""
            Me.cmoAreaName.DataSource = Nothing
            Me.cmoAreaName.Items.Clear()
        ElseIf Me.cmoGeographicalAreas.Text = "Show in columns" Then
            Me.cmoAreaLevels.Visible = True
            Me.cmoAreaName.Visible = False
            Me.cmoAreaName.Text = ""
            Me.cmoAreaName.DataSource = Nothing
            Me.cmoAreaName.Items.Clear()
        ElseIf Me.cmoGeographicalAreas.Text = "Total" Then

        ElseIf Me.cmoGeographicalAreas.Text = "Choose one:" Then
            Me.cmoAreaLevels.Visible = True
            Me.cmoAreaName.Visible = True
        End If
    End Sub

    Private Sub cmoAreaLevels_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmoAreaLevels.SelectedIndexChanged
        Me.txtFigureAnalysisDescription.Text = ""
        Me.dgvResult.DataSource = Nothing
        Me.cmoAreaName.Text = ""
        Me.cmoAreaName.DataSource = Nothing
        Me.cmoAreaName.Items.Clear()
        Select Case GetConfigLevel()
            Case "5"
                Me.cmoAreaName.Items.Add(GetDistrictName())
            Case "4"
                If Me.cmoAreaLevels.Text = "District" Then
                    ds = New DataSet
                    da = New SqlDataAdapter
                    dt = New DataTable
                    cmd = New SqlCommand

                    Try
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        With cmd
                            .Connection = conn
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "fgGetDistrictsPerRegion"
                            .Parameters.AddWithValue("@AreaID", GetConfigArea())
                            .ExecuteNonQuery()
                        End With

                        'fill in insert, update, and delete commands
                        'Dim cmdBldr As New SqlCommandBuilder(da)

                        da.SelectCommand = cmd
                        da.Fill(ds, "DistrictList")
                        dt = ds.Tables("DistrictList")

                        If dt.Rows.Count > 0 Then
                            Me.cmoAreaName.DataSource = dt
                            Me.cmoAreaName.DisplayMember = "Area_Name"
                            Me.cmoAreaName.ValueMember = "Area_Name"
                        Else
                            MessageBox.Show("No result found", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                    Finally
                        conn.Close()
                    End Try
                Else
                    Me.cmoAreaName.Items.Add(GetDistrictName())
                End If
            Case Else
                If Me.cmoAreaLevels.Text = "District" Then
                    ds = New DataSet
                    da = New SqlDataAdapter
                    dt = New DataTable
                    cmd = New SqlCommand

                    Try
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        With cmd
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = "select area_name from tbl_setup_areas where area_level=5 order by area_name"
                            .ExecuteNonQuery()
                        End With

                        da.SelectCommand = cmd
                        da.Fill(ds, "DistrictList")
                        dt = ds.Tables("DistrictList")

                        If dt.Rows.Count > 0 Then
                            Me.cmoAreaName.DataSource = dt
                            Me.cmoAreaName.DisplayMember = "Area_Name"
                            Me.cmoAreaName.ValueMember = "Area_Name"
                        Else
                            MessageBox.Show("No result found", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                    Finally
                        conn.Close()
                    End Try
                Else
                    ds = New DataSet
                    da = New SqlDataAdapter
                    dt = New DataTable
                    cmd = New SqlCommand

                    Try
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        With cmd
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = "select area_name from tbl_setup_areas where area_level=4 order by area_name"
                            .ExecuteNonQuery()
                        End With

                        da.SelectCommand = cmd
                        da.Fill(ds, "RegionList")
                        dt = ds.Tables("RegionList")

                        If dt.Rows.Count > 0 Then
                            Me.cmoAreaName.DataSource = dt
                            Me.cmoAreaName.DisplayMember = "Area_Name"
                            Me.cmoAreaName.ValueMember = "Area_Name"
                        Else
                            MessageBox.Show("No result found", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                    Finally
                        conn.Close()
                    End Try
                End If

        End Select
    End Sub

    Private Sub cmoTimePeriods_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmoTimePeriods.SelectedIndexChanged
        Me.txtFigureAnalysisDescription.Text = ""
        Me.dgvResult.DataSource = Nothing
        If Me.cmoTimePeriods.Text = "Show in rows" Then
            Me.cmoTime.Visible = False
            Me.cmoTime.Text = ""
            Me.cmoTime.Items.Clear()
            Me.periodFrom = Nothing
            Me.periodTo = Nothing
        ElseIf Me.cmoTimePeriods.Text = "Show in columns" Then
            Me.cmoTime.Visible = False
            Me.cmoTime.Text = ""
            Me.cmoTime.Items.Clear()
        ElseIf Me.cmoTimePeriods.Text = "Total" Then

        ElseIf Me.cmoTimePeriods.Text = "Choose one:" Then
            Me.cmoTime.Visible = True
            If Me.lstSearchResult.Text = "" Then
            Else
                Me.cmoTime.Items.AddRange(GetTimePeriods().ToArray())
            End If
        End If
    End Sub

    Private Sub cmoTime_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmoTime.SelectedIndexChanged
        'periodFrom = CDate(Me.cmoTime.Text.Substring(0, 11))
        'periodTo = CDate(Me.cmoTime.Text.Substring(14, 11))
        Me.dgvResult.DataSource = Nothing
    End Sub

    Public Sub LoadComboBoxes()
        Me.cmoTotalResult.Items.Add("Show in rows")
        'Me.cmoTotalResult.Items.Add("Show in columns")
        'Me.cmoTotalResult.Items.Add("Total")
        Me.cmoTotalResult.Items.Add("Choose one:")

        Me.cmoGeographicalAreas.Items.Add("Show in rows")
        'Me.cmoGeographicalAreas.Items.Add("Show in columns")
        'Me.cmoGeographicalAreas.Items.Add("Total")
        Me.cmoGeographicalAreas.Items.Add("Choose one:")

        Select Case GetConfigLevel()
            Case 5
                Me.cmoAreaLevels.Items.Add("District")
            Case Else
                Me.cmoAreaLevels.Items.Add("District")
                Me.cmoAreaLevels.Items.Add("Region")
        End Select

        Me.cmoTimePeriods.Items.Add("Show in rows")
        'Me.cmoTimePeriods.Items.Add("Show in columns")
        'Me.cmoTimePeriods.Items.Add("Total")
        Me.cmoTimePeriods.Items.Add("Choose one:")
    End Sub

    Public Function GetDistrictName() As String
        ds = New DataSet
        da = New SqlDataAdapter
        dt = New DataTable
        cmd = New SqlCommand
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            With cmd
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = "select area_name from tbl_setup_areas where area_id='" + GetConfigArea() + "'"
            End With
            areaName = cmd.ExecuteScalar().ToString()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
        Return areaName
    End Function

    Public Function GetTimePeriods() As List(Of String)
        ds = New DataSet
        da = New SqlDataAdapter
        dt = New DataTable
        cmd = New SqlCommand

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "fgSearchTimePeriods"
                .Parameters.AddWithValue("@foreignTable", indicatorTable)
                .Parameters.AddWithValue("@foreignKey", GetIndicatorForeignKey(indicatorTable))
                .ExecuteNonQuery()
            End With
            Dim cmdBldr As New SqlCommandBuilder(da)
            Me.da.SelectCommand = cmd
            Me.da.Fill(Me.ds, "SearchTimePeriods")
            Me.dt = Me.ds.Tables("SearchTimePeriods")
            timePeriods = New List(Of String)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    timePeriods.Add(row(0).ToString())
                Next
            End If
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
        Return timePeriods
    End Function

    Public Function GetIndicatorForeignKey(ByVal indicatorTable As String) As String
        indicatorTable = indicatorTable.Substring(Len(indicatorTable) - 2)
        Select Case indicatorTable
            Case "01"
                Return "MonthlyRecordID"
            Case "02"
                Return "RecordID"
            Case "03"
                Return "AnnualRecordID"
            Case "04"
                Return "QuarterlyRecordID"
            Case "05"
                Return "AnnuallyRecordID"
            Case "06"
                Return "AnnualRecordID"
        End Select
        Return ""
    End Function

    Public Sub ValidateBreakDown()
        If Me.lstSearchResult.Items.Count.Equals(0) Then
            MessageBox.Show("Select Figure", "LGMD System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'If Me.cmoFilteredResult.Visible = True And Me.cmoFilteredResult.Text = "" Then
        '    MessageBox.Show("Please select period", "LGMD Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
    End Sub

    Public Function GetAreaID(ByVal AreaName As String) As String
        ds = New DataSet
        da = New SqlDataAdapter
        dt = New DataTable
        cmd = New SqlCommand
        Dim myAreaID As String = ""

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            With cmd
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = "select id from areas where name='" & AreaName & "'"
            End With
        Catch ex As Exception
        Finally
            'conn.Close()
        End Try
        'If GetConfigLevel() = 5 Then
        '    Return myAreaID
        'ElseIf GetConfigLevel() = 4 And Me.cmoAreaLevels.Text = "Region" Then
        '    Return myAreaID + "_%"
        'ElseIf GetConfigLevel() = 4 And Me.cmoAreaLevels.Text = "District" Then
        '    Return myAreaID
        'End If
        Return cmd.ExecuteScalar()
    End Function

    Private Sub cmoAreaName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmoAreaName.SelectedValueChanged
        Me.dgvResult.DataSource = Nothing
    End Sub

    Public Sub ClearFigureAnalysisControls()

        Me.lblResultOptions.Visible = False
        Me.cmoTotalResult.Visible = False
        Me.cmoTotalResult.Text = ""
        'Me.cmoTotalResult.Items.Clear()
        Me.cmoFilteredResult.Visible = False
        Me.cmoFilteredResult.Text = ""
        Me.cmoFilteredResult.Items.Clear()
        Me.cmoTimePeriods.Text = ""
        Me.cmoTime.Visible = False
        Me.cmoTime.Text = ""
        Me.cmoTime.Items.Clear()
        Me.txtFigureAnalysisDescription.Text = ""
        Me.dgvResult.DataSource = Nothing
    End Sub
End Class
