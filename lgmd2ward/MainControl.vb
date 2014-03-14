Public Class MainControl
    Private HasChanged As Boolean
    Private ColumnNameToSort As String
    Public Overridable Sub Save()
        t = False
    End Sub
    Public Overridable Sub delete()

    End Sub
    Public Overridable Sub Add()

    End Sub
    Public Overridable ReadOnly Property CorrespondingDataEntry() As MainControl
        Get

            Return New MainControl
        End Get
    End Property
    Private t As Boolean = False
    Public Overridable Function HasChanges() As Boolean
        Return t
    End Function

    Protected Sub TriggerChanges()
        t = True
    End Sub

    Private Sub MainControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Property HasUnsavedChanges() As Boolean
        Get
            Return HasChanged
        End Get
        Set(ByVal value As Boolean)
            HasChanged = value
        End Set
    End Property
    Public Property ColumnToSort() As String
        Get
            Return ColumnNameToSort
        End Get
        Set(ByVal value As String)
            ColumnNameToSort = value
        End Set
    End Property
    Protected Overridable Sub Changed(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)

    End Sub
End Class
