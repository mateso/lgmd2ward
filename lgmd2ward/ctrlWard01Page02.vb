Public Class ctrlWard01Page02

    Dim CropGroupListDA As New LGMDdataDataSetTableAdapters.CropGroupListTableAdapter
    Dim TargetDA As New LGMDdataDataSetTableAdapters.TargetImplementationAndCropPrices01TableAdapter
    Private firstNo As Double?
    Private secondNo As Double?
    Private areaDone As Double?
    Private prodDone As Double?
    Private price As Double?

    Private Sub ctrlWard01Page02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspLookupUnitsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits)

        Me.CropGroupListDA.Fill(Me.LGMDdataDataSet.CropGroupList)
        Me.TargetiTableAdapter.FillNafaka(Me.LgmDdataDataSet1.Targeti, g_RecordID)
        Me.TargetiTableAdapter.FillMizizi(Me.LgmDdataDataSet2.Targeti, g_RecordID)
        Me.TargetiTableAdapter.FillViwandani(Me.LgmDdataDataSet3.Targeti, g_RecordID)

        If Me.LgmDdataDataSet1.Targeti.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.CropGroupList.Select("Status='0'")
                Me.TargetDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.TargetiTableAdapter.FillNafaka(Me.LgmDdataDataSet1.Targeti, g_RecordID)
            Me.TargetiTableAdapter.FillMizizi(Me.LgmDdataDataSet2.Targeti, g_RecordID)
            Me.TargetiTableAdapter.FillViwandani(Me.LgmDdataDataSet3.Targeti, g_RecordID)
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
                For Each row As DataGridViewRow In Me.TargetiDataGridView.Rows
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
                For Each row As DataGridViewRow In Me.DataGridView1.Rows
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
                For Each row As DataGridViewRow In Me.DataGridView2.Rows
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

            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet1.Targeti)
            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet2.Targeti)
            'Me.TargetiTableAdapter.Update(Me.LgmDdataDataSet3.Targeti)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub TargetiDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TargetiDataGridView.DataError
        MessageBox.Show("Please enter a number", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        e.Cancel = True
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub TargetiDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TargetiDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.TargetiDataGridView.Rows
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

    Private Sub DataGridView1_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
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

    Private Sub DataGridView2_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView2.Rows
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

    Private Sub TargetiDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TargetiDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
