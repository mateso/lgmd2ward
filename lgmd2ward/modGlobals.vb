Imports System.Data.SqlClient

Module modGlobals

    Public g_form_mode As String
    Public g_PeriodFrom As Date
    Public g_PeriodTo As Date
    Public g_AreaID As String
    Public g_PeriodHeading As String
    Public g_AreaHeading As String
    Public g_OrganisationID As Long
    Public g_user_id As String
    Public g_FormTypeNumber As Long
    Public g_RecordID As Guid
    Public g_bViewOnly As Boolean = False
    Public g_language As String = "English"
    Public g_LastRowVersion As Long
    Public g_LastAcknowledgedRV As Long
    Public g_FormSerialNumber As String
    Public g_FormSerialNumberIQ As String
    Public g_FormSerialNumberIA As String
    Public g_bSeleted As Boolean = False
    Public strSelectedNode As String
    Public gStrHost As String
    Public gStrFigure As Long

    Public g_DBName As String
    Public g_LGAName As String

    Public conn As New SqlConnection(My.Settings.DataConnectionString)

End Module
