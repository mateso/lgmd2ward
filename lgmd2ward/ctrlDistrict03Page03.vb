Public Class ctrlDistrict03Page03

    Dim FFSGroupDA As New DistrictAnnualDataSetTableAdapters.FFSGroupTableAdapter
    Dim ExtensionOfficersTrainedDA As New DistrictAnnualDataSetTableAdapters.ExtensionOfficersTrained05TableAdapter
    Private firstNo As Integer?
    Private secondNo As Integer?

    Private Sub ctrlDistrict03Page03_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FFSGroupDA.Fill(Me.DistrictAnnualDataSet.FFSGroup)
        Me.ExtensionOfficersTrainedDA.Fill(Me.DistrictAnnualDataSet.ExtensionOfficersTrained05, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersTrainedCropTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedCrop, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersTrainedLivestockTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedLivestock, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersTrainedFisheryTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedFishery, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersTrainedMarketingTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedMarketing, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersTrainedIrrigationTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedIrrigation, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersTrainedOthersTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedOthers, g_RecordID)
        If Me.DistrictAnnualDataSet.ExtensionOfficersTrained05.Rows.Count = 0 Then
            For index = 1 To 5
                For Each row As DataRow In Me.DistrictAnnualDataSet.FFSGroup.Rows
                    Me.ExtensionOfficersTrainedDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
            Next
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedCropTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedCrop, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedLivestockTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedLivestock, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedFisheryTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedFishery, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedMarketingTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedMarketing, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedIrrigationTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedIrrigation, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedOthersTableAdapter.Fill(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedOthers, g_RecordID)
        End If

        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")
        PopulateHeaderControls(Me)
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click

        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedCropTableAdapter.Update(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedCrop)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedLivestockTableAdapter.Update(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedLivestock)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedFisheryTableAdapter.Update(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedFishery)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedMarketingTableAdapter.Update(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedMarketing)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedIrrigationTableAdapter.Update(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedIrrigation)
            Me.AppUspDistrictAnnualFillExtensionOfficersTrainedOthersTableAdapter.Update(Me.DistrictAnnualDataSet.appUspDistrictAnnualFillExtensionOfficersTrainedOthers)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersTrainedCropDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersTrainedCropDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersTrainedCropDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Or IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
            Else
                firstNo = row.Cells(5).Value
                secondNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersTrainedLivestockDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersTrainedLivestockDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersTrainedLivestockDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Or IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
            Else
                firstNo = row.Cells(5).Value
                secondNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersTrainedFisheryDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersTrainedFisheryDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersTrainedFisheryDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Or IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
            Else
                firstNo = row.Cells(5).Value
                secondNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersTrainedMarketingDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersTrainedMarketingDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersTrainedMarketingDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Or IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
            Else
                firstNo = row.Cells(5).Value
                secondNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersTrainedIrrigationDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersTrainedIrrigationDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersTrainedIrrigationDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Or IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
            Else
                firstNo = row.Cells(5).Value
                secondNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersTrainedOthersDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersTrainedOthersDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersTrainedOthersDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Or IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
            Else
                firstNo = row.Cells(5).Value
                secondNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

End Class
