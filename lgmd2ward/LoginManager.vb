Imports System.Security.Principal
Imports System.Data.SqlClient

Public Class LoginManager
Implements IPrincipal
    Private identityValue As CustomIdentity
    Private roles As New List(Of String)
    Private rights As New List(Of String)

    Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            Return identityValue
        End Get
    End Property

    Private Shared Function ProductGT10(ByVal p As String) As Int16
        If p.Split("@").GetValue(0).ToString = My.Settings.ObjectID.Split("@").GetValue(0).ToString Then
            My.Settings.ObjectID = CInt(p.Split("@").GetValue(1).ToString)
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function IsInRole(ByVal strRightID As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        Dim intAction As Int16 = 1
        My.Settings.ObjectID = strRightID
        Select Case strRightID.Split("@").GetValue(1)
            Case "Edit"
                intAction = 2
            Case "Delete"
                intAction = 8
            Case "Add"
                intAction = 16
            Case Else
                intAction = 1
        End Select

        Array.Find(rights.ToArray, AddressOf ProductGT10)
        If My.Settings.ObjectID.Contains("@") Then My.Settings.ObjectID = 0
        Dim intCompare As Int16 = CType(My.Settings.ObjectID, Int16)
        If (intAction And intCompare) = intAction Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub New(ByVal name As String, ByVal password As String)
        identityValue = New CustomIdentity(name, password)
        If identityValue.IsAuthenticated Then
            fetchRoles()
        End If
    End Sub

    Public Shared Sub Login(ByVal username As String, ByVal password As String)
        Dim t As LoginManager = New LoginManager(username, password)
        If t.identityValue.AuthenticationType = "CustomAuthentication" Then
            My.User.CurrentPrincipal = t
        End If

    End Sub

    Private Sub fetchRoles()

        '   SAM Using gt As New HEMISSQLDBEntities
        ''Using gt As New HEMISEntities.HEMISDataSet
        ''    Dim t = From role As HEMISEntities.HEMISDataSet.tblGroupRightsRow In gt.tblGroupRights Join ri In gt.tblRights On role.RightID Equals ri.RightID _
        ''            Join gr In gt.tblGroups On role.GroupID Equals gr.GroupID Join usegroup In gt.tblUserGroup On usegroup.GroupID Equals gr.GroupID _
        ''            Join user In gt.tblUsers On user.UserName Equals usegroup.UserName Where user.UserName = identityValue.Name Select role

        ''    For Each vbg As HEMISEntities.HEMISDataSet.tblGroupRightsRow In t
        ''        roles.Add(vbg.RightID)
        ''    Next

        ''    'Assumes that connection is a valid SqlConnection object.
        ''    Dim queryString As String = _
        ''      "select  UserName,RightID from tblUserGroup inner join tblGroupRights  on tblUserGroup.GroupID = tblGroupRights.GroupID  where lower(username) = '" & identityValue.Name.ToLower & "'"




        ''    Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
        ''      queryString, My.Settings.DataConnectionString)


        ''    Dim customers As DataSet = New DataSet("customers")
        ''    Dim TempTable As DataTable = customers.Tables.Add("TempTable")

        ''    Dim pkOrderID As DataColumn = TempTable.Columns.Add("RightID", Type.GetType("System.String"))
        ''    TempTable.Columns.Add("UserName", Type.GetType("System.String"))

        ''    TempTable.PrimaryKey = New DataColumn() {pkOrderID}



        ''    adapter.Fill(customers, "TempTable")


        ''    For Each vbg As DataRow In TempTable.Rows
        ''        roles.Add(vbg.Item("RightID"))
        ''    Next

        ''    Dim strQuery As String
        ''    strQuery = "select RightID, isnull([Allow],0) + isnull([add],0)*16+ " & _
        ''            "isnull([Edit],0)*2+isnull([Delete],0)*8 as Rights " & _
        ''            "from( SELECT [RightID],max(cast(isnull([Allow],0) as int) ) as Allow  ,max(cast(isnull([add],0) as int)) as [Add] " & _
        ''            ",max(cast(isnull([Edit],0) as int)) as Edit ,max(cast(isnull([Delete],0) as int)) as [Delete]  " & _
        ''            "FROM [dbo].[tblGroupRights]  where GroupID in (select GroupID from [tblUserGroup] where Username ='" & identityValue.Name & "') group by RightID   )  DerQry"

        ''    Dim RightAdapter As SqlDataAdapter = New SqlDataAdapter( _
        ''      strQuery, My.Settings.DataConnectionString)

        ''    Dim dsRight As DataSet = New DataSet("Rights")
        ''    Dim tblRightTable As DataTable = dsRight.Tables.Add("RightsTable")
        ''    RightAdapter.Fill(dsRight.Tables("RightsTable"))


        ''    For Each rightRow As DataRow In tblRightTable.Rows
        ''        rights.Add(rightRow.Item("RightID") & "@" & rightRow.Item("Rights"))
        ''    Next

        ''End Using

    End Sub
End Class

