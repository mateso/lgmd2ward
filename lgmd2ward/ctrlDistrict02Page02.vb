Public Class ctrlDistrict02Page02

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim AnimalFeedsDA As New LGMDdataDataSetTableAdapters.AnimalsFeeds04TableAdapter
    Private QuarterlyRequirement As Double?
    Private QuarterlyAmountUsed As Double?
    Private LowPrice As Double?
    Private HighPrice As Double?

    Private Sub ctrlDistrict02Page02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspLookupSourceOfBudgetTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupSourceOfBudget)
        Me.AppUspLookupUnits2TableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits2)

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictQuarterFillAnimalFeedsTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillAnimalFeeds, g_RecordID)
        Me.AppUspDistrictQuarterFillAcaricidesTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillAcaricides, g_RecordID)
        Me.AppUspDistrictQuarterFillVaccinesTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillVaccines, g_RecordID)
        Me.AppUspDistrictQuarterFillTreatment_Drugs_TableAdapter.Fill(Me.LGMDdataDataSet._appUspDistrictQuarterFillTreatment_Drugs_, g_RecordID)

        If Me.LGMDdataDataSet.appUspDistrictQuarterFillAnimalFeeds.Rows.Count = 0 Then

            For i = 1 To 5
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='AnimalFeeds'")
                    Me.AnimalFeedsDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
            Next
            Me.AppUspDistrictQuarterFillAnimalFeedsTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillAnimalFeeds, g_RecordID)
            Me.AppUspDistrictQuarterFillAcaricidesTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillAcaricides, g_RecordID)
            Me.AppUspDistrictQuarterFillVaccinesTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillVaccines, g_RecordID)
            Me.AppUspDistrictQuarterFillTreatment_Drugs_TableAdapter.Fill(Me.LGMDdataDataSet._appUspDistrictQuarterFillTreatment_Drugs_, g_RecordID)
        End If

        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")
        PopulateHeaderControls(Me)


    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillAnimalFeedsDataGridView.Rows
                    QuarterlyRequirement = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                    QuarterlyAmountUsed = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    LowPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                    HighPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(14))
                    Me.AppUspDistrictQuarterFillAnimalFeedsTableAdapter.appUspDistrictQuarterUpdateAnimalFeeds(row.Cells(5).Value, row.Cells(7).Value.ToString, row.Cells(8).Value.ToString, row.Cells(9).Value.ToString, row.Cells(10).Value.ToString, QuarterlyRequirement, QuarterlyAmountUsed, LowPrice, HighPrice, row.Cells(15).Value.ToString, row.Cells(16).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView1.Rows
                    QuarterlyRequirement = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                    QuarterlyAmountUsed = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    LowPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                    HighPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(14))
                    Me.AppUspDistrictQuarterFillAcaricidesTableAdapter.appUspDistrictQuarterUpdateAnimalFeeds(row.Cells(5).Value, row.Cells(7).Value.ToString, row.Cells(8).Value.ToString, row.Cells(9).Value.ToString, row.Cells(10).Value.ToString, QuarterlyRequirement, QuarterlyAmountUsed, LowPrice, HighPrice, row.Cells(15).Value.ToString, row.Cells(16).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView2.Rows
                    QuarterlyRequirement = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                    QuarterlyAmountUsed = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    LowPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                    HighPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(14))
                    Me.AppUspDistrictQuarterFillVaccinesTableAdapter.appUspDistrictQuarterUpdateAnimalFeeds(row.Cells(5).Value, row.Cells(7).Value.ToString, row.Cells(8).Value.ToString, row.Cells(9).Value.ToString, row.Cells(10).Value.ToString, QuarterlyRequirement, QuarterlyAmountUsed, LowPrice, HighPrice, row.Cells(15).Value.ToString, row.Cells(16).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView3.Rows
                    QuarterlyRequirement = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                    QuarterlyAmountUsed = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                    LowPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                    HighPrice = CheckIfIsNullOrEmptyDGVCell(row.Cells(14))
                    Me.AppUspDistrictQuarterFillTreatment_Drugs_TableAdapter.appUspDistrictQuarterUpdateAnimalFeeds(row.Cells(5).Value, row.Cells(7).Value.ToString, row.Cells(8).Value.ToString, row.Cells(9).Value.ToString, row.Cells(10).Value.ToString, QuarterlyRequirement, QuarterlyAmountUsed, LowPrice, HighPrice, row.Cells(15).Value.ToString, row.Cells(16).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.AppUspDistrictQuarterFillAnimalFeedsTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictQuarterFillAnimalFeeds)
            'Me.AppUspDistrictQuarterFillAcaricidesTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictQuarterFillAcaricides)
            'Me.AppUspDistrictQuarterFillVaccinesTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictQuarterFillVaccines)
            'Me.AppUspDistrictQuarterFillTreatment_Drugs_TableAdapter.Update(Me.LGMDdataDataSet._appUspDistrictQuarterFillTreatment_Drugs_)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspDistrictQuarterFillAnimalFeedsDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictQuarterFillAnimalFeedsDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView3_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictQuarterFillAnimalFeedsDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictQuarterFillAnimalFeedsDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
