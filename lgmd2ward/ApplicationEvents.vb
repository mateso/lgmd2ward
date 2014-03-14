Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public Property RestartOnShutdown As Boolean

        Public Sub MyApplication_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown

            If Me.RestartOnShutdown Then
                Try
                    System.Windows.Forms.Application.Restart()
                Catch ex As Exception

                End Try
            End If

        End Sub

    End Class


End Namespace

