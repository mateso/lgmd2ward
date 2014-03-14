Public Class ctrlDistrict03Page01

    Dim DistrictInfoDA As New LGMDdataDataSetTableAdapters.DistrictInfo05TableAdapter
    Dim ThreeDListDA As New LGMDdataDataSetTableAdapters.ThreeDListTableAdapter
    Dim FoodSituationDA As New LGMDdataDataSetTableAdapters.FoodSituation05TableAdapter
    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim OxenizingDA As New LGMDdataDataSetTableAdapters.Oxenizing05TableAdapter
    Dim ExtensionOfficersDA As New LGMDdataDataSetTableAdapters.ExtensionOfficers05TableAdapter
    Private foodSituationFirstNo As Double?
    Private foodSituationSecondNo As Double?
    Private firstNo As Integer?
    Private secondNo As Integer?
    Private thirdNo As Integer?
    Private fourthNo As Integer?
    Private fifthNo As Integer?
    Private sixthNo As Integer?
    Private seventhNo As Integer?
    Private eighthNo As Integer?

    Private Sub ctrlDistrict03Page01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DistrictInfoDA.Fill(Me.LGMDdataDataSet.DistrictInfo05, g_RecordID)
        If Me.LGMDdataDataSet.DistrictInfo05.Rows.Count = 0 Then
            'Me.DistrictInfoDA.appUspDistrictAnnualInsertDistrictInfo(Guid.NewGuid, 0, 0, 0, 0, 0, 0, 0, 0, g_RecordID)
            Me.DistrictInfoDA.Insert(Guid.NewGuid, g_RecordID)
            Me.DistrictInfoDA.Fill(Me.LGMDdataDataSet.DistrictInfo05, g_RecordID)
        End If

        Me.ThreeDListDA.Fill(Me.LGMDdataDataSet.ThreeDList)
        Me.AppUspDistrictAnnualFillFoodSituationTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillFoodSituation, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillFoodSituation.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.ThreeDList.Select("ListItemType='FoodSituation05'")
                Me.FoodSituationDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillFoodSituationTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillFoodSituation, g_RecordID)
        End If

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictAnnualFillOxenizingTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillOxenizing, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillOxenizing.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='Oxenization05'")
                Me.OxenizingDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillOxenizingTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillOxenizing, g_RecordID)
        End If

        Me.AppUspDistrictAnnualFillExtensionOfficersCropTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersCrop, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersLivestockTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersLivestock, g_RecordID)
        Me.AppUspDistrictAnnualFillExtensionOfficersOthersTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersOthers, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersCrop.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.ThreeDList.Select("ListItemType='ExtensionOfficers05' AND ListItemStatus='0'")
                Me.ExtensionOfficersDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillExtensionOfficersCropTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersCrop, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersLivestock, g_RecordID)
            Me.AppUspDistrictAnnualFillExtensionOfficersOthersTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersOthers, g_RecordID)
        End If

        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        PopulateHeaderControls(Me)

        Call LoadFactors()

    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersCropDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.UserDeletingRow
        If Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.CurrentRow.Index < 6 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.SelectedRows
                    Me.ExtensionOfficersDA.appUspDistrictAnnualDeleteExtensionOfficer(row.Cells(9).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.UserDeletingRow
        If Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.CurrentRow.Index < 4 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.SelectedRows
                    Me.ExtensionOfficersDA.appUspDistrictAnnualDeleteExtensionOfficer(row.Cells(9).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersCropDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.RowEnter
        If Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(0).Value = 3
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(2).Value = Guid.NewGuid
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(3).Value = 3
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(6).Value = "ExtensionOfficers05"
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(7).Value = 1
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(8).Value = Guid.NewGuid
            Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows(e.RowIndex).Cells(18).Value = g_RecordID
        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.RowEnter
        If Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(0).Value = 4
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(2).Value = Guid.NewGuid
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(3).Value = 4
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(6).Value = "ExtensionOfficers05"
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(7).Value = 1
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(8).Value = Guid.NewGuid
            Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(e.RowIndex).Cells(18).Value = g_RecordID
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm(, , g_RecordID)
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)

            Me.DistrictInfoDA.appUspDistrictAnnualUpdateDistrictInfoPageOne(txtNumberOfWards.Text, _
                                                                            txtNumberOfVillages.Text, _
                                                                            txtNumberOfHousehold.Text, _
                                                                            txtNumberOfHouseholdAgriculture.Text, _
                                                                            txtDistrictPopulation.Text, _
                                                                            g_RecordID)
            Me.AppUspDistrictAnnualFillFoodSituationTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillFoodSituation)
            Me.AppUspDistrictAnnualFillOxenizingTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillOxenizing)

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        firstNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                        secondNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                        thirdNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                        fourthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                        fifthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(14))
                        sixthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(15))
                        eighthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(17))
                        Me.ExtensionOfficersDA.appUspDistrictAnnualUpdateExtensionOfficersCrop(row.Cells(2).Value, _
                                                                                               Val(row.Cells(3).Value.ToString), _
                                                                                               row.Cells(4).Value.ToString, _
                                                                                               row.Cells(5).Value.ToString, _
                                                                                               row.Cells(6).Value.ToString, _
                                                                                               row.Cells(7).Value.ToString, _
                                                                                               row.Cells(8).Value, _
                                                                                               firstNo, _
                                                                                               secondNo, _
                                                                                               thirdNo, _
                                                                                               fourthNo, _
                                                                                               fifthNo, _
                                                                                               sixthNo, _
                                                                                               eighthNo, _
                                                                                               row.Cells(18).Value)

                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        firstNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                        secondNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                        thirdNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                        fourthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                        fifthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(14))
                        sixthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(15))
                        eighthNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(17))
                        Me.ExtensionOfficersDA.appUspDistrictAnnualUpdateExtensionOfficersLivestock(row.Cells(2).Value, _
                                                                                                    Val(row.Cells(3).Value.ToString), _
                                                                                                    row.Cells(4).Value.ToString, _
                                                                                                    row.Cells(5).Value.ToString, _
                                                                                                    row.Cells(6).Value.ToString, _
                                                                                                    row.Cells(7).Value.ToString, _
                                                                                                    row.Cells(8).Value, _
                                                                                                    firstNo, _
                                                                                                    secondNo, _
                                                                                                    thirdNo, _
                                                                                                    fourthNo, _
                                                                                                    fifthNo, _
                                                                                                    sixthNo, _
                                                                                                    eighthNo, _
                                                                                                    row.Cells(18).Value)
                    End If
                Next
            Catch ex As Exception

            End Try

            Me.AppUspDistrictAnnualFillExtensionOfficersOthersTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillExtensionOfficersOthers)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNumberOfWards_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfWards.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtNumberOfVillages_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfVillages.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtNumberOfHousehold_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfHousehold.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtNumberOfHouseholdAgriculture_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfHouseholdAgriculture.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtDistrictPopulation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDistrictPopulation.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillFoodSituationDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillFoodSituationDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillOxenizingDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillOxenizingDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersCropDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillFoodSituationDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillFoodSituationDataGridView.CellValidated

        Dim total As Integer = 0

        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows
            If (IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Or _
                IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11)))) Then
            Else
                foodSituationFirstNo = row.Cells(10).Value
                foodSituationSecondNo = row.Cells(11).Value
                row.Cells(12).Value = AutomateProduct(foodSituationFirstNo, foodSituationSecondNo)
                total += row.Cells(12).Value
            End If
        Next
        For j As Integer = 0 To CInt(Me.AppUspDistrictAnnualFillFoodSituationDataGridView.RowCount - 1)
            Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(j).Cells(13).Value = total
            Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(j).Cells(14).Value = 0.65 * Val(Me.txtDistrictPopulation.Text) * (365 / 1000)
        Next

        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows
            If (IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Or _
                IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14)))) Then
            Else
                foodSituationFirstNo = row.Cells(13).Value
                foodSituationSecondNo = row.Cells(14).Value
                row.Cells(15).Value = AutomateSubtraction(foodSituationFirstNo, foodSituationSecondNo)
            End If
        Next

    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersCropDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.Rows
            If row.IsNewRow Then
            Else
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                Else
                    firstNo = row.Cells(10).Value
                    secondNo = row.Cells(11).Value
                    thirdNo = row.Cells(12).Value
                    fourthNo = row.Cells(13).Value
                    fifthNo = row.Cells(14).Value
                    sixthNo = row.Cells(15).Value
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                End If
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows
            If row.IsNewRow Then
            Else
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                        sixthNo = 0
                    Else
                        sixthNo = row.Cells(15).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(10).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(11).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                        thirdNo = 0
                    Else
                        thirdNo = row.Cells(12).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                        fourthNo = 0
                    Else
                        fourthNo = row.Cells(13).Value
                    End If
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                        fifthNo = 0
                    Else
                        fifthNo = row.Cells(14).Value
                    End If
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                Else
                    firstNo = row.Cells(10).Value
                    secondNo = row.Cells(11).Value
                    thirdNo = row.Cells(12).Value
                    fourthNo = row.Cells(13).Value
                    fifthNo = row.Cells(14).Value
                    sixthNo = row.Cells(15).Value
                    row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
                End If
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(12).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(13).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(14).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(15).Value
                End If
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(12).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(13).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(14).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(15).Value
                End If
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                thirdNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(13).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(14).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(15).Value
                End If
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                fourthNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(12).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(14).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(15).Value
                End If
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                fifthNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(12).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(13).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(15).Value
                End If
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(15))) Then
                sixthNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(12).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(13))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(13).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(14))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(14).Value
                End If
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            Else
                firstNo = row.Cells(10).Value
                secondNo = row.Cells(11).Value
                thirdNo = row.Cells(12).Value
                fourthNo = row.Cells(13).Value
                fifthNo = row.Cells(14).Value
                sixthNo = row.Cells(15).Value
                row.Cells(16).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            End If
        Next
    End Sub

    Private Sub AppUspDistrictAnnualFillFoodSituationDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspDistrictAnnualFillFoodSituationDataGridView.CellPainting
        If (e.ColumnIndex = 1 AndAlso e.RowIndex <> -1) Or _
            (e.ColumnIndex = 13 AndAlso e.RowIndex <> -1) Or _
            (e.ColumnIndex = 14 AndAlso e.RowIndex <> -1) Or _
            (e.ColumnIndex = 15 AndAlso e.RowIndex <> -1) Then

            Using gridBrush As Brush = New SolidBrush(Me.AppUspDistrictAnnualFillFoodSituationDataGridView.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    ' Clear cell   
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw line (bottom border and right border of current cell)   
                    'If next row cell has different content, only draw bottom border line of current cell   
                    If e.RowIndex < AppUspDistrictAnnualFillFoodSituationDataGridView.Rows.Count - 2 AndAlso AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    End If

                    ' Draw right border line of current cell   
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' draw/fill content in current cell, and fill only one cell of multiple same cells   
                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                        Else
                            'e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            Try
                                e.Graphics.DrawString(e.Value, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5)
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                    e.Handled = True
                End Using
            End Using
        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillFoodSituationDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillFoodSituationDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillOxenizingDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillOxenizingDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersCropDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersCropDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersOthersDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub LoadFactors()
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(0).Cells(11).Value = 1
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(1).Cells(11).Value = 0.65
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(2).Cells(11).Value = 1
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(3).Cells(11).Value = 1
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(4).Cells(11).Value = 0.201
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(5).Cells(11).Value = 0.34
        Me.AppUspDistrictAnnualFillFoodSituationDataGridView.Rows(6).Cells(11).Value = 0.255

    End Sub

    Private Sub AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView_Paint(sender As Object, e As PaintEventArgs) Handles AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Paint
        Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(1).Cells(17).Style.BackColor = Color.White
        Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(2).Cells(17).Style.BackColor = Color.White
        Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(1).Cells(17).ReadOnly = False
        Me.AppUspDistrictAnnualFillExtensionOfficersLivestockDataGridView.Rows(2).Cells(17).ReadOnly = False
    End Sub

    Private Sub AppUspDistrictAnnualFillOxenizingDataGridView_Paint(sender As Object, e As PaintEventArgs) Handles AppUspDistrictAnnualFillOxenizingDataGridView.Paint
        Me.AppUspDistrictAnnualFillOxenizingDataGridView.Rows(1).Cells(8).Style.BackColor = Color.Gray
        Me.AppUspDistrictAnnualFillOxenizingDataGridView.Rows(1).Cells(9).Style.BackColor = Color.Gray
        Me.AppUspDistrictAnnualFillOxenizingDataGridView.Rows(1).Cells(8).ReadOnly = True
        Me.AppUspDistrictAnnualFillOxenizingDataGridView.Rows(1).Cells(9).ReadOnly = True
    End Sub
End Class
