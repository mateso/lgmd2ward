Partial Class HEMISDataSet
    Partial Class tblInstitutionsDataTable

        Private Sub tblInstitutionsDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("ShortName").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Short Name should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblInstitutionsDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("ShortName").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("Shortname", "Short name should not be empty")
                    e.Row.RowError = ("Short Name should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
    Partial Class tblStudentsDataTable

        Private Sub tblStudentsDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("StudentID").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Student ID should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblStudentsDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("StudentID").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("StudentID", "Student ID should not be empty")
                    e.Row.RowError = ("Student ID should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class

    Partial Class tblSponsorShipDataTable
        Private Sub tblSponsorShipDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("StudentID").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Student ID should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblSponsorShipDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("StudentID").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("StudentID", "Student ID should not be empty")
                    e.Row.RowError = ("Student ID should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub

    End Class
    Partial Class tblGradDataDataTable

        Private Sub tblGradDataDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                'e.Row.ClearErrors()
                'If e.Row("AwardPreparedCode").Equals(DBNull.Value) Then
                'e.Row.Delete()
                'e.Row.RowError = ("Award prepared code should not be empty")
                'End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblGradDataDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("AwardPreparedCode").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("AwardGroup", "Award Prepared should not be empty")
                    e.Row.RowError = ("Award Prepared should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
    Partial Class tblStaffsDetailedDataTable
        Private Sub tblStaffsDetailedDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("Name").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Staff Name should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblStaffsDetailedDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("Name").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("Name", "Staff name should not be empty")
                    e.Row.RowError = ("Staff name should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
    Partial Class tblFundingDataTable
        Private Sub tblFundingDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("SourceID").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Institution name should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblFundingDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("SourceID").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("SourceID", "Institution name should not be empty")
                    e.Row.RowError = ("Institution name should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
    Partial Class tblAssetUtilizationDataTable
        Private Sub tblAssetUtilizationDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("RoomName").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Room Name should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblAssetUtilizationDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("ID") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("RoomName").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("RoomName", "Room name should not be empty")
                    e.Row.RowError = ("Room name should not be empty")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
    Partial Class tblUsersDataTable

        Private Sub tblUsersDataTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanged

        End Sub
        Private Sub tblUsersDataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            Try
                e.Row.ClearErrors()
                If e.Row("UserName").Equals(DBNull.Value) Then
                    e.Row.Delete()
                    e.Row.RowError = ("Room Name should not be empty")
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub tblUsersDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            'e.Row("UserName") = Guid.NewGuid
            Try
                e.Row.ClearErrors()
                If e.Row("userName").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("UserName", "Room name should not be empty")
                    e.Row.RowError = ("User name should not be empty")
                End If
                If e.Row("Password").Equals(DBNull.Value) Then
                    e.Row.SetColumnError("Password", "Password name should not be empty")
                    e.Row.RowError = ("Password should not be empty")
                End If

            Catch ex As Exception
            End Try
        End Sub
    End Class

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
