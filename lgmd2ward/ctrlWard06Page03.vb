Public Class ctrlWard06Page03

    Dim CropGroupListDA As New AnnualTargetDataSetTableAdapters.CropGroupListTableAdapter
    Private firstNo As Double?
    Private secondNo As Double?
    Private expectedArea As Double?
    Private expectedProd As Double?

    Private Sub ctrlWard06Page03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CropGroupListDA.Fill(Me.AnnualTargetDataSet.CropGroupList)
        Me.AppUspAnnualTargetFillViungoTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillViungo, g_RecordID)
        Me.AppUspAnnualTargetFillMbogambogaTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillMbogamboga, g_RecordID)

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
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillViungoDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillViungoTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMbogambogaDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillMbogambogaTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.AppUspAnnualTargetFillViungoTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillViungo)
            'Me.AppUspAnnualTargetFillMbogambogaTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillMbogamboga)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspAnnualTargetFillViungoDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillViungoDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillMbogambogaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillMbogambogaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillViungoDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillViungoDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillViungoDataGridView.Rows
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

    Private Sub AppUspAnnualTargetFillMbogambogaDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMbogambogaDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMbogambogaDataGridView.Rows
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

    Private Sub AppUspAnnualTargetFillViungoDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillViungoDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualTargetFillMbogambogaDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillMbogambogaDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
