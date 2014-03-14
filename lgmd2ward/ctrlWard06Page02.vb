Public Class ctrlWard06Page02

    Dim CropGroupListDA As New AnnualTargetDataSetTableAdapters.CropGroupListTableAdapter
    Dim TargetDA As New AnnualTargetDataSetTableAdapters.TargetImplementationAndCropPrices06TableAdapter
    Private firstNo As Double?
    Private secondNo As Double?
    Private expectedArea As Double?
    Private expectedProd As Double?

    Private Sub ctrlWard06Page02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CropGroupListDA.Fill(Me.AnnualTargetDataSet.CropGroupList)
        Me.TargetDA.Fill(Me.AnnualTargetDataSet.TargetImplementationAndCropPrices06)
        Me.AppUspAnnualTargetFillViwandaniTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillViwandani, g_RecordID)
        Me.AppUspAnnualTargetFillMafutaTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillMafuta, g_RecordID)
        Me.AppUspAnnualTargetFillKundeTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillKunde, g_RecordID)

        If Me.AnnualTargetDataSet.appUspAnnualTargetFillViwandani.Rows.Count = 0 Then
            For Each row As DataRow In Me.AnnualTargetDataSet.CropGroupList.Select("Status=0")
                Me.TargetDA.Insert(Guid.NewGuid(), row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspAnnualTargetFillViwandaniTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillViwandani, g_RecordID)
            Me.AppUspAnnualTargetFillMafutaTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillMafuta, g_RecordID)
            Me.AppUspAnnualTargetFillKundeTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillKunde, g_RecordID)
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
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillViwandaniDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillViwandaniTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMafutaDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillMafutaTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillKundeDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillKundeTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.AppUspAnnualTargetFillViwandaniTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillViwandani)
            'Me.AppUspAnnualTargetFillMafutaTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillMafuta)
            'Me.AppUspAnnualTargetFillKundeTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillKunde)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspAnnualTargetFillViwandaniDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillViwandaniDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillMafutaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillMafutaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillKundeDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillKundeDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillViwandaniDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillViwandaniDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillViwandaniDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspAnnualTargetFillMafutaDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMafutaDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMafutaDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspAnnualTargetFillKundeDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillKundeDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillKundeDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspAnnualTargetFillViwandaniDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillViwandaniDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualTargetFillMafutaDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillMafutaDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualTargetFillKundeDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillKundeDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
