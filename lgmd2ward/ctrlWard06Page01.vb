Public Class ctrlWard06Page01

    Dim CropGroupListDA As New AnnualTargetDataSetTableAdapters.CropGroupListTableAdapter
    Dim TargetDA As New AnnualTargetDataSetTableAdapters.TargetImplementationAndCropPrices06TableAdapter
    Private firstNo As Double?
    Private secondNo As Double?
    Private expectedArea As Double?
    Private expectedProd As Double?

    Private Sub ctrlWard06Page01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If g_form_mode = "Add" Then
            Call SaveForm(Me.txtOfficerName.Text, DateTimePicker1.Text)
            g_form_mode = "Edit"
        End If
        Me.RecordInfoTableAdapter.Fill(Me.LGMDdataDataSet.RecordInfo, g_RecordID)

        Me.CropGroupListDA.Fill(Me.AnnualTargetDataSet.CropGroupList)
        Me.AppUspAnnualTargetFillCerealTableAdapter.Fill(AnnualTargetDataSet.appUspAnnualTargetFillCereal, g_RecordID)
        Me.AppUspAnnualTargetFillMiziziTableAdapter.Fill(AnnualTargetDataSet.appUspAnnualTargetFillMizizi, g_RecordID)

        If Me.AnnualTargetDataSet.appUspAnnualTargetFillCereal.Rows.Count = 0 Then
            For Each row As DataRow In Me.AnnualTargetDataSet.CropGroupList.Select("Status=0")
                Me.TargetDA.Insert(Guid.NewGuid(), row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspAnnualTargetFillCerealTableAdapter.Fill(AnnualTargetDataSet.appUspAnnualTargetFillCereal, g_RecordID)
            Me.AppUspAnnualTargetFillMiziziTableAdapter.Fill(AnnualTargetDataSet.appUspAnnualTargetFillMizizi, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading.Replace("Ward: ", "")

        Me.txtYear.Text = g_PeriodHeading
        Me.txtWardName.Text = g_AreaHeading.Replace("Ward: ", "")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            Call SaveForm(Me.txtOfficerName.Text, Me.DateTimePicker1.Text)
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillCerealDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillCerealTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMiziziDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillMiziziTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.AppUspAnnualTargetFillCerealTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillCereal)
            'Me.AppUspAnnualTargetFillMiziziTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillMizizi)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspAnnualTargetFillCerealDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillCerealDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillMiziziDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillMiziziDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillCerealDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillCerealDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillCerealDataGridView.Rows
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

    Private Sub AppUspAnnualTargetFillMiziziDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMiziziDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMiziziDataGridView.Rows
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

    Private Sub AppUspAnnualTargetFillCerealDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillCerealDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualTargetFillMiziziDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillMiziziDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class