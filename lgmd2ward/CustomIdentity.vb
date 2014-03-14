Imports System.Security.Cryptography
'Imports HEMIS.HEMISSQLDBModel
Imports System.Security.Principal
Imports System.Configuration
Imports System.Data.SqlClient

Public Class CustomIdentity
Implements IIdentity

    Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType
        Get
            'Return ConfigurationManager.AppSettings("AuthenticationType")
            Return My.Settings.AuthenticationType
        End Get
    End Property

    Private _IsAuthenticated As Boolean

    Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated
        Get
            Return _IsAuthenticated
        End Get
    End Property

    Private _Name As String

    Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
        Get
            Return _Name
        End Get
    End Property

    Public Sub New()
    End Sub

    Friend Sub New(ByVal name As String, ByVal password As String)
        If IsValidUser(name, password) Then
            _IsAuthenticated = True
            _Name = name
        Else
            Throw New InvalidOperationException("Invalid User /Password combination")
        End If
    End Sub

    Private Function IsValidUser(ByVal name As String, ByVal password As String) As Boolean
        If ComparePasswords(GetDBPassword(name), password) Then
            Return True
        End If
        Return False
    End Function

    Public Function ValidatePassword(ByVal name As String, ByVal password As String) As Boolean
        If ComparePasswords(GetDBPassword(name), password) Then
            Return True
        End If
        Return False
    End Function

    Private Function GetDBPassword(ByVal name As String) As Byte()
        Try
            Dim tmpTbl As New DataTable
            Dim dsLGMDDataset As New LGMDdataDataSet

            tmpTbl = dsLGMDDataset.Tables("tblUsers")
            Dim hhh As New Object
            Dim found As Boolean = False

            Dim RightAdapter As SqlDataAdapter = New SqlDataAdapter("select * from tblUsers", My.Settings.DataConnectionString)

            RightAdapter.Fill(tmpTbl)

            For Each f In tmpTbl.Rows
                If f.username.ToString.ToLower = name.ToLower Then
                    found = True
                    Return f.Password
                    Exit For
                End If
            Next
            If found = False Then
                Throw New InvalidOperationException("Invalid/Udefined User")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Const SaltLength As Integer = 24
    ' This function compares a hashed password against the 
    ' hashed and salted password from the database.
    ' It returns true if authentication succeeds.
    Public Function ComparePasswords(ByVal storedPassword() As Byte, ByVal suppliedPassword As String) As Boolean

        ' Extract the salt value from the salted hash.
        If storedPassword Is Nothing Then Return False
        Dim SaltValue(SaltLength - 1) As Byte
        Dim SaltOffset As Integer = storedPassword.Length - SaltLength
        Dim i As Integer
        For i = 0 To SaltLength - 1
            SaltValue(i) = storedPassword(SaltOffset + i)
        Next

        ' Cpnvert the password supplied by the user
        ' to a salted password , using the salt value
        ' from a database record 
        Dim HashedPassword As Byte() = CreatePasswordHash(suppliedPassword)
        Dim SaltedPassword As Byte() = CreateSaltedPassword(SaltValue, HashedPassword)

        ' Compare the two salted password
        ' If they are the same , authentication has succeded
        Return compareByteArray(storedPassword, SaltedPassword)
    End Function

    Public Function CreateDBPassword(ByVal Password As String) As Byte()
        ' Create the unsalted password hash
        Dim unsaltedPassword() As Byte = CreatePasswordHash(Password)

        ' Generate a random salt value
        Dim SaltValue(SaltLength - 1) As Byte
        Dim Rng As New System.Security.Cryptography.RNGCryptoServiceProvider
        Rng.GetBytes(SaltValue)

        ' Create the salted hash
        Return CreateSaltedPassword(SaltValue, unsaltedPassword)
    End Function
    
    ' this function returns a password hash
    ' that hasn't been salted
    Public Function CreatePasswordHash(ByVal password As String) As Byte()
        Dim Sha1 As New System.Security.Cryptography.SHA1Managed
        Return Sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
    End Function
    ' this function accepts the password hash, and salts it
    ' with a given salt value.
    Public Function CreateSaltedPassword(ByVal saltValue As Byte(), ByVal unsaltedPassword() As Byte) As Byte()

        ' add salt to the hash
        Dim RawSalted(unsaltedPassword.Length + saltValue.Length - 1) As Byte
        unsaltedPassword.CopyTo(RawSalted, unsaltedPassword.Length)

        ' Create the salted hash
        Dim sha1 As New SHA1Managed
        Dim saltedPassword() As Byte = sha1.ComputeHash(RawSalted)

        ' Add the salt value to the salted hash
        Dim DbPassword(saltedPassword.Length + saltValue.Length - 1) As Byte
        saltedPassword.CopyTo(DbPassword, 0)
        saltValue.CopyTo(DbPassword, saltedPassword.Length)
        Return DbPassword
    End Function

    ' This helper function Compares the two byte arrays , and returns true
    ' if they contain the same series of bytes.
    Private Function compareByteArray(ByVal ArrayA() As Byte, ByVal ArrayB() As Byte) As Boolean

        ' Make sure that array are the same size
        If ArrayA.Length <> ArrayB.Length Then
            Return False
        End If

        ' Compare each byte in the two arrays

        Dim i As Integer
        For i = 0 To ArrayA.Length - 1
            If Not ArrayA(i).Equals(ArrayB(i)) Then
                Return False
            End If
        Next

        ' Both tests succeeded , the array match
        Return True
    End Function

End Class
