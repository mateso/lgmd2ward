Public Class ctrlWard01Page04

    Dim CropGroupListDA As New LGMDdataDataSetTableAdapters.CropGroupListTableAdapter
    Dim TargetDA As New LGMDdataDataSetTableAdapters.TargetImplementationAndCropPrices01TableAdapter
    Private firstNo As Double?
    Private secondNo As Double?
    Private areaDone As Double?
    Private prodDone As Double?
    Private price As Double?

    Private Sub ctrlWard01Page04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspLookupUnitsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits)

        Me.CropGroupListDA.Fill(Me.LGMDdataDataSet.CropGroupList)
        Me.TargetiTableAdapter.FillMbogamboga(Me.LgmDdataDataSet7.Targeti, g_RecordID)
        Me.TargetiTableAdapter.FillMatunda(Me.LgmDdataDataSet8.Targeti, g_RecordID)
        Me.TargetiTableAdapter.FillMaua(Me.LgmDdataDataSet9.Targeti, g_RecordID)
        Me.TargetiTableAdapter.FillMengineyo(Me.LgmDdataDataSet10.Targeti, g_RecordID)

        If Me.LgmDdataDataSet7.Targeti.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.CropGroupList.Select("Status='0'")
                Me.TargetDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.TargetiTableAdapter.FillMbogamboga(Me.LgmDdataDataSet7.Targeti, g_RecordID)
            Me.TargetiTableAdapter.FillMatunda(Me.LgmDdataDataSet8.Targeti, g_RecordID)
            Me.TargetiTableAdapter.FillMaua(Me.LgmDdataDataSet9.Targeti, g_RecordID)
            Me.TargetiTableAdapter.FillMengineyo(Me.LgmDdataDataSet10.Targeti, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
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

            Try
                For Each row As DataGridViewRow In Me.DataGridView6.Rows
                    areaDone = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                    prodDone = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                    price = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    Me.TargetiTableAdapter.appUspMonthlyUpdateTarget(row.Cells(4).Value, _
                                                                     areaDone, _
                                                                     prodDone, _
                                                                     price, _
                                                                     row.Cells(13).Value.ToString, _
                                                                     row.Cells(14).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView7.Rows
                    areaDone = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                    prodDone = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                    price = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    Me.TargetiTableAdapter.appUspMonthlyUpdateTarget(row.Cells(4).Value, _
                                                                     areaDone, _
                                                                     prodDone, _
                                                                     price, _
                                                                     row.Cells(13).Value.ToString, _
                                                                     row.Cells(14).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView8.Rows
                    areaDone = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                    prodDone = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                    price = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    Me.TargetiTableAdapter.appUspMonthlyUpdateTarget(row.Cells(4).Value, _
                                                                     areaDone, _
                                                                     prodDone, _
                                                                     price, _
                                                                     row.Cells(13).Value.ToString, _
                                                                     row.Cells(14).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet6.Targeti)
            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet7.Targeti)
            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet8.Targeti)
            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet9.Targeti)

            For Each row As DataGridViewRow In Me.DataGridView9.Rows
                Try
                    If row.IsNewRow Then
                    Else
                        firstNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                        secondNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                        price = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                        Me.TargetiTableAdapter.appUspMonthlyUpdateTargets(row.Cells(0).Value, _
                                                                          row.Cells(1).Value, _
                                                                          row.Cells(2).Value.ToString, _
                                                                          row.Cells(3).Value, _
                                                                          row.Cells(4).Value, _
                                                                          firstNo, _
                                                                          secondNo, _
                                                                          price, _
                                                                          row.Cells(13).Value.ToString, _
                                                                          g_RecordID)

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            Next

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub DataGridView9_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView9.UserDeletingRow
        If Me.DataGridView9.CurrentRow.Index < 1 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.DataGridView9.SelectedRows
                    Me.TargetiTableAdapter.appUspMonthlyDeleteTargets(row.Cells(0).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub DataGridView9_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView9.RowEnter
        If Me.DataGridView9.Rows(e.RowIndex).IsNewRow Then
            Me.DataGridView9.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView9.Rows(e.RowIndex).Cells(1).Value = 10
            Me.DataGridView9.Rows(e.RowIndex).Cells(3).Value = 1
            Me.DataGridView9.Rows(e.RowIndex).Cells(4).Value = Guid.NewGuid
            Me.DataGridView9.Rows(e.RowIndex).Cells(14).Value = g_RecordID
        End If
    End Sub

    Private Sub DataGridView6_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView6.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView7_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView7.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView8_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView8.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView9_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView9.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView6_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView6.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView6.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(10).Value
                End If
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(9).Value
                End If
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(9).Value
                secondNo = row.Cells(10).Value
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub DataGridView7_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView7.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView7.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(10).Value
                End If
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(9).Value
                End If
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(9).Value
                secondNo = row.Cells(10).Value
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub DataGridView8_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView8.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView8.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(10).Value
                End If
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(9).Value
                End If
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(9).Value
                secondNo = row.Cells(10).Value
                row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub DataGridView9_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView9.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView9.Rows
            If row.IsNewRow Then
            Else
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    firstNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(10).Value
                    End If
                    row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    secondNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(9).Value
                    End If
                    row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
                Else
                    firstNo = row.Cells(9).Value
                    secondNo = row.Cells(10).Value
                    row.Cells(11).Value = AutomateProduct(firstNo, secondNo)
                End If
            End If
        Next
    End Sub

    Private Sub DataGridView6_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView6.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView7_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView7.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView8_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView8.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView9_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView9.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
