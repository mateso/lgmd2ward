Imports System.Data
Imports System.Data.SqlClient
Imports LGMD.LGMDdataDataSetTableAdapters

Module modSaveLoad

    Private cmd As SqlCommand
    Private FormSerialNumberIQ As String
    Private FormSerialNumberIA As String

    Public Sub SaveForm(Optional ByVal strUserID As String = "", Optional ByVal SubmissionDate As Date = Nothing, Optional ExistingID As Guid = Nothing)

        cmd = New SqlCommand
        g_FormSerialNumber = ProduceFormSerialNumber()
        FormSerialNumberIQ = ProduceFormSerialNumberForIQ()
        FormSerialNumberIA = ProduceFormSerialNumberForIA()

        If g_form_mode = "Add" And ExistingID = Nothing Then
            g_RecordID = Guid.NewGuid()
        End If

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .CommandType = CommandType.StoredProcedure
                .Connection = conn
                .CommandText = "udp_insert_form"
                .Parameters.AddWithValue("@RecordID", g_RecordID)
                .Parameters.AddWithValue("@AreaID", g_AreaID)
                .Parameters.AddWithValue("@OfficerName", strUserID)
                .Parameters.AddWithValue("@SubmissionDate", IIf(SubmissionDate = Nothing, Now.Date, SubmissionDate))
                .Parameters.AddWithValue("@PeriodFrom", g_PeriodFrom)
                .Parameters.AddWithValue("@PeriodTo", g_PeriodTo)
                .Parameters.AddWithValue("@FormTypeNumber", g_FormTypeNumber)
                .Parameters.AddWithValue("@DateCaptured", Date.Now)
                .Parameters.AddWithValue("@CapturedByUserID", g_user_id)
                .Parameters.AddWithValue("@OrganisationID", g_OrganisationID)
                .Parameters.AddWithValue("@FormSerialNumber", g_FormSerialNumber)
                .Parameters.AddWithValue("@FormSerialNumberIQ", FormSerialNumberIQ)
                .Parameters.AddWithValue("@FormSerialNumberIA", FormSerialNumberIA)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub DeleteForm(ByVal recordID As Guid, ByVal formTypeNumber As Int32)

        cmd = New SqlCommand

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Select Case formTypeNumber
                Case 1
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .Connection = conn
                        .CommandText = "appUspMonthlyDeleteForm"
                        .Parameters.AddWithValue("@RecordID", recordID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Case 2
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .Connection = conn
                        .CommandText = "appUspQuarterlyDeleteForm"
                        .Parameters.AddWithValue("@RecordID", recordID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Case 3
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .Connection = conn
                        .CommandText = "appUspAnnuallyDeleteForm"
                        .Parameters.AddWithValue("@RecordID", recordID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Case 4
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .Connection = conn
                        .CommandText = "appUspDistrictQuarterlyDeleteForm"
                        .Parameters.AddWithValue("@RecordID", recordID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Case 5
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .Connection = conn
                        .CommandText = "appUspDistrictAnnuallyDeleteForm"
                        .Parameters.AddWithValue("@RecordID", recordID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Case 6
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .Connection = conn
                        .CommandText = "appUspAnnualTargetDeleteForm"
                        .Parameters.AddWithValue("@RecordID", recordID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Case Else
            End Select
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

    End Sub

    Public Function LookupFreeText(ByVal FreeTextDataTable As DataTable, ByVal BreakdownTypes As String, ByVal BreakdownFreeTextNumber As Long) As String

        For Each dr As DataRow In FreeTextDataTable.Rows
            If dr.Item("BreakdownTypes").ToString() = BreakdownTypes And dr.Item("BreakdownFreeTextNumber").ToString() = BreakdownFreeTextNumber Then
                LookupFreeText = dr.Item("BreakdownTypeFreeText").ToString()
                Exit Function
            End If
        Next
        LookupFreeText = ""
    End Function

    Public Function GetControlValueIfControlExists(ByVal TheFormControl As Control, ByVal TheControlName As String)
        On Error GoTo err_GetControlValueIfControlExists
        GetControlValueIfControlExists = TheFormControl.Controls(TheControlName).Text
exit_GetControlValueIfControlExists:
        Exit Function
err_GetControlValueIfControlExists:
        GetControlValueIfControlExists = 0
    End Function

    Public Sub SetReadOnly(ByVal TheControl As Control)
        On Error Resume Next
        Dim txtControl As New TextBox
        Dim cmoControl As New ComboBox
        Dim ctrl As New Control

        If TheControl.Name.StartsWith("txt") Then txtControl = TheControl ' there are some labels in form03page03 which start with "txt" for special reasons, error should just be ignored

        If g_form_mode = "View" Then

            If TheControl.Name.StartsWith("txt") Or TheControl.Name.StartsWith("cmo") Then
                txtControl.ReadOnly = True
            Else
                TheControl.Enabled = False
            End If
            TheControl.BackColor = Color.Khaki

        Else
            If TheControl.Name.StartsWith("txt") Or TheControl.Name.StartsWith("cmo") Then
                txtControl.ReadOnly = False
            Else
                TheControl.Enabled = True
            End If
            TheControl.BackColor = Color.White
        End If
    End Sub

    Public Sub ModuleClearGlobalVariables()
        g_FormTypeNumber = Nothing
    End Sub

End Module
