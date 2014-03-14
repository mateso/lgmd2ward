Public Class ctrlAddUser5

    Private Sub ctrlAddUser5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AppUspFillUsersBindingNavigator.AddNewItem.Enabled = False
        Me.AppUspFillUsersBindingNavigator.DeleteItem.Enabled = False
        Me.TblUserGroupTableAdapter.Fill(Me.LGMDdataDataSet.tblUserGroup)
        Me.AppUspFillUsersTableAdapter.Fill(Me.LGMDdataDataSet.appUspFillUsers)
    End Sub

    Private Sub AppUspFillUsersDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspFillUsersDataGridView.RowEnter
        If Me.AppUspFillUsersDataGridView.Rows(e.RowIndex).IsNewRow Then
            Dim defaultPassword As String = "demo"
            Dim customIdentity As New CustomIdentity
            Me.AppUspFillUsersDataGridView.Rows(e.RowIndex).Cells(1).Value = customIdentity.CreateDBPassword(defaultPassword)
            Me.AppUspFillUsersDataGridView.Rows(e.RowIndex).Cells(3).Value = False
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        For Each row As DataGridViewRow In Me.AppUspFillUsersDataGridView.Rows
            If row.IsNewRow Then
            Else
                Try
                    Me.AppUspFillUsersTableAdapter.appUspAddUser(row.Cells(0).Value.ToString, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub AppUspFillUsersDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspFillUsersDataGridView.DataError
        For Each row As DataGridViewRow In Me.AppUspFillUsersDataGridView.Rows
            If row.IsNewRow Then
            Else
                If String.IsNullOrEmpty(row.Cells(0).Value.ToString) Then
                    MessageBox.Show("Please fill username", "LGMD Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    e.Cancel = True
                End If
            End If
        Next
    End Sub

    Private Sub AppUspFillUsersDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspFillUsersDataGridView.UserDeletingRow
        If (MessageBox.Show("Are you sure you want to delete this record?", "LGMD Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then
            e.Cancel = True
        End If
        Try
            Me.AppUspFillUsersTableAdapter.appUspDeleteUser(Me.AppUspFillUsersDataGridView.CurrentRow.Cells(0).Value.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
