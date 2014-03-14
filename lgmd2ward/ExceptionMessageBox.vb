
Class ExceptionMessageBox

    Private _ex As Microsoft.SqlServer.Management.Common.ConnectionFailureException
    Private _ex1 As Microsoft.SqlServer.Management.Smo.SmoException
    Private _ex2 As Exception

    Sub New(ByVal ex As Microsoft.SqlServer.Management.Common.ConnectionFailureException)
        ' TODO: Complete member initialization 
        _ex = ex
    End Sub

    Sub New(ByVal ex As Microsoft.SqlServer.Management.Smo.SmoException)
        ' TODO: Complete member initialization 
        _ex1 = ex
    End Sub

    Sub New(ByVal ex As Exception)
        ' TODO: Complete member initialization 
        _ex2 = ex
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Private textValue As String
    Public Property Text() As String
        Get
            Return textValue
        End Get
        Set(ByVal value As String)
            textValue = value
        End Set
    End Property

    Sub Show(ByVal ctrlDatabaseDetails As ctrlDatabaseDetails)
        Throw New NotImplementedException
    End Sub

    Sub Show(ByVal ctrlDatabaseTasks As ctrlDatabaseTasks)
        Throw New NotImplementedException
    End Sub

    Sub Show(ByVal ctrlDatabaseUtilities As ctrlDatabaseUtilities)
        Throw New NotImplementedException
    End Sub

    Sub Show(ByVal ctrlManageDatabases As ctrlManageDatabases)
        Throw New NotImplementedException
    End Sub

    Sub Show(ByVal frmMain As frmMain)
        Throw New NotImplementedException
    End Sub

End Class