Imports System.Data.SqlClient

Module modGeneral

    Private cmd As SqlCommand
    Private reader As SqlDataReader

    Public Sub FillWithFinancialYears(ByVal ComboBoxControl As ComboBox, ByVal FromYear As Long, ByVal ToYear As Long)
        Dim FinancialYear As String
        For i = FromYear To ToYear
            FinancialYear = i & "/" & i + 1
            ComboBoxControl.Items.Add(FinancialYear)
        Next
    End Sub

    Public Sub FillWithYears(ByVal ComboBoxControl As ComboBox, ByVal FromYear As Long, ByVal ToYear As Long)
        For i = FromYear To ToYear
            ComboBoxControl.Items.Add(i)
        Next
    End Sub

    Public Sub FillWithMonths(ByVal ComboBoxControl As ComboBox)
        For i = 1 To 12
            ComboBoxControl.Items.Add(MonthName(i))
        Next
    End Sub

    Public Sub FillWithQuarters(ByVal ComboBoxControl As ComboBox)
        Dim StartMonth As String
        Dim EndMonth As String

        For i = 3 To 4
            StartMonth = MonthName(i * 3 - 2)
            EndMonth = MonthName(i * 3)
            ComboBoxControl.Items.Add(StartMonth & " - " & EndMonth)
        Next
        For i = 1 To 2
            StartMonth = MonthName(i * 3 - 2)
            EndMonth = MonthName(i * 3)
            ComboBoxControl.Items.Add(StartMonth & " - " & EndMonth)
        Next

    End Sub

    Public Function fnGetParams(ByVal strOption As String) As String()

        conn = New SqlConnection
        cmd = New SqlCommand
        Dim strField As String = "FormSerialNumber"
        Dim sParams() As String
        Dim ii As Long
        ReDim sParams(0)

        If strOption.ToLower.Contains("financial year") Or strOption.ToLower.Contains("tender id") Then
            Dim previousConnectionState As ConnectionState = conn.State
            Try
            Finally
                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If
            End Try
        Else
            sParams(ii) = strOption
        End If
        Return sParams

    End Function

    Public Function DomainLookup(ByVal OutputField, ByVal Table, ByVal Criteria)

        conn = New SqlConnection(My.Settings.DataConnectionString)
        cmd = New SqlCommand()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "udp_domain"
                .Parameters.AddWithValue("@TheOutputField", OutputField)
                .Parameters.AddWithValue("@TheTable", Table)
                .Parameters.AddWithValue("@TheCriteria", Criteria)
            End With

            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    Return (reader.GetValue(0).ToString)
                End While
            End Using
        Finally
            'conn.Close()
        End Try

    End Function

    Public Function DCount(ByVal FieldToCount, ByVal Table, ByVal Criteria)

        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand()
        Dim prmTable As New SqlParameter
        Dim prmFieldToCount As New SqlParameter
        Dim prmCriteria As New SqlParameter

        conn.ConnectionString = My.Settings.DataConnectionString
        conn.Open()

        cmd.Connection = conn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "udp_count"

        ' Create a SqlParameter for each parameter in the stored procedure.
        ' Dim TheParam As New SqlParameter(ParameterName, ParameterValue)
        prmFieldToCount.ParameterName = "TheFieldToCount"
        prmFieldToCount.Value = FieldToCount
        cmd.Parameters.Add(prmFieldToCount)

        ' Create a SqlParameter for each parameter in the stored procedure.
        ' Dim TheParam As New SqlParameter(ParameterName, ParameterValue)
        prmTable.ParameterName = "TheTable"
        prmTable.Value = Table
        cmd.Parameters.Add(prmTable)

        ' Create a SqlParameter for each parameter in the stored procedure.
        ' Dim TheParam As New SqlParameter(ParameterName, ParameterValue)
        prmCriteria.ParameterName = "TheCriteria"
        prmCriteria.Value = Criteria
        cmd.Parameters.Add(prmCriteria)

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = conn.State
        Try
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    Return (reader.GetValue(0).ToString)
                End While
            End Using
        Finally
            conn.Close()
        End Try
    End Function

    Public Function Nz(ByVal TheInput, ByVal TheOutput)
        If TheInput Is Nothing Then
            Return TheOutput
        Else
            If IsDBNull(TheInput) Or TheInput.ToString.Length = 0 Then
                Return TheOutput
            Else
                Return TheInput
            End If
        End If
    End Function

    Public Function EndOfMonth(ByVal BegOfMonth As Date) As Date
        EndOfMonth = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, BegOfMonth))
    End Function

    Public Function CheckInteger(ByVal TheControl As Control, Optional ByVal TheFormat As String = "") As Boolean
        Try
            CheckInteger = True
            'Dim TestIntegerHolder As Long
            If TheControl.Text.ToString <> "" Then
                If IsNumeric(TheControl.Text) Then
                    If TheControl.Text.Contains(".") Then
                        TheControl.Text = FormatNumber(TheControl.Text) 'format the input to a nice number format with two decimal places
                    Else
                        TheControl.Text = FormatNumber(TheControl.Text, 0)
                    End If
                Else
                    Throw New Exception("Input not a number")
                End If
                'If TheFormat <> "" Then
                '    If TheControl.Text <> 0 Then
                '        TheControl.Text = Format(TestIntegerHolder, TheFormat)
                '    End If
                'End If
            End If
        Catch ex As Exception
            If ex.Message.ToString Like "Conversion from string * to type 'Long' is not valid." Or ex.Message Like "Input not a number" Then
                MsgBoxBilingual("Please enter a number only", "Ingiza namba")
                TheControl.Text = ""
                TheControl.Focus()
                CheckInteger = False
            Else
                MsgBox(ex.Message)
                CheckInteger = False
            End If
        End Try
    End Function

    Public Function ProduceFormSerialNumber()
        ProduceFormSerialNumber = CStr(g_FormTypeNumber).PadLeft(3, "0") & g_AreaID.PadRight(21, "_") & CStr(g_OrganisationID).PadLeft(3, "0") & Format(g_PeriodFrom, "ddMMMyy") & Format(g_PeriodTo, "ddMMMyy")
    End Function

    Public Function ProduceFormSerialNumberForIQ()
        Dim intPeriodFrom As Integer = DatePart(DateInterval.Quarter, g_PeriodFrom)
        Dim intYear As Integer = DatePart(DateInterval.Year, g_PeriodFrom)
        Dim periodQuarter As String = String.Empty
        Select Case intPeriodFrom
            Case 1
                periodQuarter = "01Jan" & CStr(intYear).Substring(2, 2) & "31Mar" & CStr(intYear).Substring(2, 2)
            Case 2
                periodQuarter = "01Apr" & CStr(intYear).Substring(2, 2) & "30Jun" & CStr(intYear).Substring(2, 2)
            Case 3
                periodQuarter = "01Jul" & CStr(intYear).Substring(2, 2) & "30Sep" & CStr(intYear).Substring(2, 2)
            Case 4
                periodQuarter = "01Oct" & CStr(intYear).Substring(2, 2) & "31Dec" & CStr(intYear).Substring(2, 2)
        End Select
        ProduceFormSerialNumberForIQ = g_AreaID.PadRight(21, "_") & CStr(g_OrganisationID).PadLeft(3, "0") & periodQuarter
    End Function

    Public Function ProduceFormSerialNumberForIA() As String
        Dim intPeriodFrom As Integer = DatePart(DateInterval.Month, g_PeriodFrom)
        Dim periodYear As String = String.Empty

        'Select Case intPeriodFrom
        '    Case Is < 3
        '        periodYear = "01Jul" & CStr(DatePart(DateInterval.Year, g_PeriodFrom)).Substring(2, 2) & "30Jun" & CStr(DatePart(DateInterval.Year, g_PeriodFrom) + 1).Substring(2, 2)
        '    Case Is > 2
        '        periodYear = "01Jul" & CStr(DatePart(DateInterval.Year, g_PeriodFrom) - 1).Substring(2, 2) & "30Jun" & CStr(DatePart(DateInterval.Year, g_PeriodFrom)).Substring(2, 2)
        'End Select
        'ProduceFormSerialNumberForIA = g_AreaID.PadRight(21, "_") & CStr(g_OrganisationID).PadLeft(3, "0") & periodYear
        Select Case intPeriodFrom
            Case Is < 7
                periodYear = "01Jul" & CStr(DatePart(DateInterval.Year, g_PeriodFrom) - 1).Substring(2, 2) & "30Jun" & CStr(DatePart(DateInterval.Year, g_PeriodFrom)).Substring(2, 2)
            Case Is > 6
                periodYear = "01Jul" & CStr(DatePart(DateInterval.Year, g_PeriodFrom)).Substring(2, 2) & "30Jun" & CStr(DatePart(DateInterval.Year, g_PeriodFrom) + 1).Substring(2, 2)
        End Select
        Return g_AreaID.PadRight(21, "_") & CStr(g_OrganisationID).PadLeft(3, "0") & periodYear
    End Function

    Public Function ProduceFormSerialNumberForYearAndForm(ByVal FormNumber As Long)
        Dim StartYear As Date
        Dim EndYear As Date

        Select Case CLng(Format(g_PeriodFrom, "MM"))
            Case 1, 2, 3, 4, 5, 6
                StartYear = "1-jul-" & (Format(g_PeriodFrom, "yyyy") - 1)
                EndYear = "30-jun-" & Format(g_PeriodFrom, "yyyy")
            Case 7, 8, 9, 10, 11, 12
                StartYear = "1-jul-" & Format(g_PeriodFrom, "yyyy")
                EndYear = "30-jun-" & (Format(g_PeriodFrom, "yyyy") + 1)
        End Select

        ProduceFormSerialNumberForYearAndForm = CStr(FormNumber).PadLeft(3, "0") & g_AreaID.PadRight(21, "_") & CStr(g_OrganisationID).PadLeft(3, "0") & Format(StartYear, "ddMMMyy") & Format(EndYear, "ddMMMyy")
    End Function

    Public Function StartOfFinancialYear(ByVal TheDate As Date) As Date
        Select Case CLng(Format(TheDate, "MM"))
            Case 1, 2, 3, 4, 5, 6
                StartOfFinancialYear = "1-jul-" & (Format(g_PeriodFrom, "yyyy") - 1)
            Case 7, 8, 9, 10, 11, 12
                StartOfFinancialYear = "1-jul-" & Format(g_PeriodFrom, "yyyy")
        End Select
    End Function

    Public Function EndOfFinancialYear(ByVal TheDate As Date) As Date
        Select Case CLng(Format(TheDate, "MM"))
            Case 1, 2, 3, 4, 5, 6
                EndOfFinancialYear = "30-jun-" & Format(g_PeriodFrom, "yyyy")
            Case 7, 8, 9, 10, 11, 12
                EndOfFinancialYear = "30-jun-" & (Format(g_PeriodFrom, "yyyy") + 1)
        End Select
    End Function

    Public Function Domain(ByVal DomainType As String, ByVal Expr As String, ByVal DomainName As String, Optional ByVal Criteria As String = "") As String

        Dim TheConnection As New SqlConnection
        Dim TheCommand As New SqlCommand
        Dim TheDataSet As New DataSet
        Dim TheDataTable As New DataTable
        Dim TheSQLDataAdapter As New SqlDataAdapter
        Dim TheSQL As String

        TheConnection.ConnectionString = My.Settings.DataConnectionString
        Try
            TheConnection.Open()
        Catch ex As Exception
            MsgBox("Can not start, SQL Server service is unavailable or is stopped")
        End Try

        TheSQL = "select " & Expr & " As TheExpression from " & DomainName
        If Criteria <> "" Then
            TheSQL = TheSQL & " where " & Criteria
        End If
        Select Case DomainType
            Case "dmin"
                TheSQL = TheSQL & " Order by " & Expr
            Case "dmax"
                TheSQL = TheSQL & " Order by " & Expr & " DESC "
        End Select
        If TheConnection.State <> ConnectionState.Open Then Return ""

        TheCommand.CommandText = TheSQL
        TheCommand.CommandType = CommandType.Text
        TheCommand.Connection = TheConnection
        TheSQLDataAdapter.SelectCommand() = TheCommand
        TheDataTable.TableName = "tb"
        TheDataSet.Tables.Add(TheDataTable)
        TheSQLDataAdapter.Fill(TheDataSet.Tables("tb"))

        Select Case DomainType
            Case "dcount"
                Domain = TheDataTable.Rows.Count
            Case Else
                If TheDataTable.Rows.Count > 0 Then
                    Domain = TheDataTable.Rows(0).Item("TheExpression").ToString
                Else
                    Domain = ""
                End If
        End Select

        TheConnection.Close()
    End Function

    Public Function PeriodHeading(ByVal PeriodFrom As Date, ByVal PeriodTo As Date) As String
        PeriodHeading = ""
        If DateAdd(DateInterval.Month, 1, PeriodFrom) = DateAdd(DateInterval.Day, 1, PeriodTo) Then
            ' Monthly
            PeriodHeading = Format(PeriodTo, "MMMM yyyy")
        ElseIf DateAdd(DateInterval.Month, 3, PeriodFrom) = DateAdd(DateInterval.Day, 1, PeriodTo) Then
            'Quarterly
            PeriodHeading = Format(PeriodFrom, "MMMM") & " - " & Format(PeriodTo, "MMMM yyyy")
        ElseIf DateAdd(DateInterval.Month, 12, PeriodFrom) = DateAdd(DateInterval.Day, 1, PeriodTo) Then
            ' Annual
            PeriodHeading = Format(PeriodFrom, "yyyy") & "/" & Format(PeriodTo, "yyyy")
        End If
        Return PeriodHeading
    End Function

    Public Sub DGVNumericError(ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs, ByVal sender As System.Object)

        MessageBox.Show("Enter a valid data", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)

        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If
    End Sub

    Public Sub TextBoxKeyPressEventError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Public Sub DGVShadedValue(ByVal sender As System.Object, ByVal e As System.EventArgs, ByRef DGV As System.Object)
        DGV.Rows(0).Cells(3).Value = 0
        DGV.Rows(0).Cells(4).Value = 0
        DGV.Rows(0).Cells(5).Value = 0
        DGV.Rows(0).Cells(6).Value = 0
        DGV.Rows(0).Cells(7).Value = 0
        DGV.Rows(0).Cells(8).Value = 0
        DGV.Rows(1).Cells(3).Value = 0
        DGV.Rows(1).Cells(4).Value = 0
        DGV.Rows(1).Cells(5).Value = 0
        DGV.Rows(1).Cells(6).Value = 0
        DGV.Rows(1).Cells(7).Value = 0
        DGV.Rows(1).Cells(8).Value = 0
        DGV.Rows(2).Cells(3).Value = 0
        DGV.Rows(2).Cells(4).Value = 0
        DGV.Rows(2).Cells(5).Value = 0
        DGV.Rows(2).Cells(6).Value = 0
        DGV.Rows(2).Cells(7).Value = 0
        DGV.Rows(2).Cells(8).Value = 0
        DGV.Rows(2).Cells(9).Value = 0
        DGV.Rows(3).Cells(3).Value = 0
        DGV.Rows(3).Cells(4).Value = 0
        DGV.Rows(3).Cells(5).Value = 0
        DGV.Rows(3).Cells(6).Value = 0
        DGV.Rows(3).Cells(8).Value = 0
        DGV.Rows(3).Cells(10).Value = 0
        DGV.Rows(4).Cells(11).Value = 0
        DGV.Rows(5).Cells(11).Value = 0
    End Sub

    Public Sub DGVCellPainting(ByVal sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, ByRef DGV As System.Object, ByVal i As System.Object)
        If (e.ColumnIndex = i AndAlso e.RowIndex <> -1) Then

            Using gridBrush As Brush = New SolidBrush(DGV.GridColor),
                  backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    ' Clear cell   
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw line (bottom border and right border of current cell)   
                    'If next row cell has different content, only draw bottom border line of current cell   
                    'If e.RowIndex < DataGridView3.Rows.Count - 1 AndAlso DataGridView3.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                    '    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    'End If

                    ' Draw right border line of current cell   
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' draw/fill content in current cell, and fill only one cell of multiple same cells   
                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso DGV.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                        Else
                            'e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            Try
                                e.Graphics.DrawString(e.Value, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5)
                            Catch ex As Exception
                            End Try
                        End If
                    End If

                    e.Handled = True
                End Using
            End Using
        End If
    End Sub

    Public Sub DGVCellPaintingReadOnly(sender As System.Object, e As System.Windows.Forms.PaintEventArgs, ByRef DGV As System.Object)
        DGV.Rows(1).Cells(4).ReadOnly = True
        DGV.Rows(2).Cells(4).ReadOnly = True
        DGV.Rows(3).Cells(4).ReadOnly = True
        DGV.Rows(4).Cells(4).ReadOnly = True
    End Sub

    Public Sub DGVChangeEnterKeyBehaviour(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Function CheckIfIsNullOrEmptyDGVCell(ByVal DGVCell As System.Windows.Forms.DataGridViewCell) As Double?
        Dim DGVCellValue As Double?
        If Not String.IsNullOrEmpty(DGVCell.Value.ToString.Trim) Then
            DGVCellValue = DGVCell.Value.ToString.Trim
        Else
            DGVCellValue = Nothing
        End If
        Return DGVCellValue
    End Function

    Public Function CheckIfIsNullOrEmptyTextbox(ByVal txtBox As System.Windows.Forms.TextBox) As Double?
        Dim txtBoxValue As Double?
        If Not String.IsNullOrEmpty(txtBox.Text.ToString.Trim) Then
            txtBoxValue = txtBox.Text
        Else
            txtBoxValue = Nothing
        End If
        Return txtBoxValue
    End Function

    Public Function AutomateProduct(ByVal firstNo As Double, secondNo As Double) As Double
        Return firstNo * secondNo
    End Function

    Public Function AutomateSummation(ByVal firstNo As Double, secondNo As Double) As Double
        Return firstNo + secondNo
    End Function

    Public Function AutomateSummation(ByVal firstNo As Double, ByVal secondNo As Double, ByVal thirdNo As Double) As Double
        Return firstNo + secondNo + thirdNo
    End Function

    Public Function AutomateSummation(ByVal firstNo As Double, secondNo As Double, ByVal thirdNo As Double, ByVal fourthNo As Double) As Double
        Return firstNo + secondNo + thirdNo + fourthNo
    End Function

    Public Function AutomateSummation(ByVal firstNo As Double, secondNo As Double, ByVal thirdNo As Double, ByVal fourthNo As Double, ByVal fifthNo As Double, sixthNo As Double) As Double
        Return firstNo + secondNo + thirdNo + fourthNo + fifthNo + sixthNo
    End Function

    Public Function AutomateSubtraction(ByVal firstNo As Double, ByVal secondNo As Double) As Double
        Return firstNo - secondNo
    End Function

    Public Sub ValidatingUserControl(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Select Case g_form_mode
            Case "Edit", "Add"
                If MsgBox("You have not saved the data entered. Are you sure you want to exit?", 68, "System Message") = vbNo Then
                    e.Cancel = True
                Else
                    GotoNextPage(g_FormTypeNumber, "")
                End If
        End Select
    End Sub

    'Public Sub LockControls(ByVal controlName As UserControl)
    '    Dim control As Control

    '    If GetConfigLevel() < 5 Then
    '        For Each control In controlName.Controls
    '            If TypeOf control Is TextBox Then
    '                Dim ctrTextBox As TextBox
    '                ctrTextBox = TryCast(control, TextBox)
    '                ctrTextBox.ReadOnly = True
    '                ctrTextBox.BackColor = Color.Khaki

    '            ElseIf TypeOf control Is ComboBox Then
    '                Dim ctrlComboBox As ComboBox
    '                ctrlComboBox = TryCast(control, ComboBox)
    '                ctrlComboBox.Enabled = False
    '                control.BackColor = Color.Khaki

    '            ElseIf TypeOf control Is DataGridView Then
    '                Dim ctrGridView As DataGridView
    '                ctrGridView = TryCast(control, DataGridView)
    '                'control.Enabled = False
    '                For Each ctrlDataGridViewColumn As DataGridViewColumn In ctrGridView.Columns
    '                    ctrlDataGridViewColumn.ReadOnly = True
    '                    ctrlDataGridViewColumn.DefaultCellStyle.BackColor = Color.Khaki
    '                Next
    '            End If
    '        Next
    '        controlName.Controls("cmbGoTo").Enabled = True
    '    End If

    'End Sub
End Module