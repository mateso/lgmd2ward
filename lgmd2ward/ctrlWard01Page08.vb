Imports LGMD.CalendarColumn
Public Class ctrlWard01Page08

    Private Sub ctrlWard01Page08_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CommentsOfVillageOfficer01TableAdapter.Fill(Me.LGMDdataDataSet.CommentsOfVillageOfficer01, g_RecordID)
        Me.PeopleWhoVisitTheVillage01TableAdapter.Fill(Me.LGMDdataDataSet.PeopleWhoVisitTheVillage01, g_RecordID)

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter

        If DataGridView1.Rows(e.RowIndex).IsNewRow() Then
            Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value = g_RecordID
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Me.CommentsOfVillageOfficer01TableAdapter.appUspMonthlyInsertComments(Guid.NewGuid, _
                                                                                  txtAchievement.Text.ToString, _
                                                                                  txtChallenge.Text.ToString, _
                                                                                  g_RecordID)
            Try
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.IsNewRow Then
                    Else
                        Me.PeopleWhoVisitTheVillage01TableAdapter.appUspMonthlyInsertVisitors(row.Cells(0).Value, _
                                                                                              row.Cells(1).Value.ToString, _
                                                                                              row.Cells(2).Value.ToString, _
                                                                                              row.Cells(3).Value.ToString, _
                                                                                              row.Cells(4).Value.ToString, _
                                                                                              row.Cells(5).Value.ToString, _
                                                                                              row.Cells(6).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub DataGridView1_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                Me.PeopleWhoVisitTheVillage01TableAdapter.appUspMonthlyDeleteVisitors(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
