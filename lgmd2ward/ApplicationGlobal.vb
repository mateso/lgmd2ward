Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Smo

Public Class ApplicationGlobal
    Public Shared sqlServer As Server
    Public Shared sqlServerConnection As ServerConnection
    Public Shared objFrmLogin As frmLogin
    Public Shared objFrmMain As frmMain
    Public Shared objUserctrl As New UserControl
    Public Shared dbCurrentDatabase As String
    Public Shared dbCurrentForm As Int32
    Public Shared gstrCurrentPeriod As String
    Public Shared gIsMacro As String
    Public Shared gCurrentFigureSerialNumber As String

    <STAThread()> _
    Shared Sub Main()
        ' Start the application.
        objfrmLogin = New frmLogin
        Dim hh As New ServerConnection
        sqlServerConnection = hh
        If My.Settings.DataConnectionString.Length = 0 Then
            objFrmMain = New frmMain
            objFrmMain.getControl("ServerConnection")
            Application.Run(objFrmMain)
        Else
            hh.ConnectionString = My.Settings.DataConnectionString
            Application.Run(objFrmLogin)
        End If
    End Sub

End Class
