'Imports HEMISDataModel.HEMISSQLDBModel
Public Class ctrlChangePassword
    Inherits MainControl

    Dim data As New DataSet()
    Dim stu As New LGMDdataDataSet
    'Dim masterDataAdapter As New HEMISDAL.HEMISDataSetTableAdapters.tblUsersTableAdapter

    Private Sub ctrlChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = g_user_id
    End Sub

    Overrides Sub Save()
        Dim o As New CustomIdentity
        If o.ValidatePassword(TextBox1.Text, TextBox2.Text) = False Then
            MsgBox("The old password is invalid")
            Exit Sub
        End If
        If TextBox3.Text <> TextBox4.Text Then
            MsgBox("New passwords do not match")
            Exit Sub
        End If

        Dim masterDataAdapter As New LGMDdataDataSetTableAdapters.tblUsersTableAdapter
        masterDataAdapter.Fill(stu.tblUsers)

        data = stu

        Dim nnmmm As New BindingSource
        nnmmm.DataMember = "tblUsers"
        nnmmm.DataSource = data
        nnmmm.Filter() = "Username='" & Me.TextBox1.Text & "'"
        nnmmm.Current.item("password") = o.CreateDBPassword(TextBox3.Text.ToString) 'TextBox2.Text

        'Dim p As New HEMISSQLDBEntities

        'Dim t = From b As tblUsers In p.tblUsers Select b Where b.UserName = TextBox1.Text

        'For Each bj As tblUsers In t
        'bj.Password = o.CreateDBPassword(TextBox3.Text.ToString)

        nnmmm.EndEdit()
        masterDataAdapter.Update(data)


        MsgBox("Password succesfully changed")

        'Exit For
        'Next


        'p.SaveChanges()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Save()
    End Sub
End Class
