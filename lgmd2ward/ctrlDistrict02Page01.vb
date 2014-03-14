Public Class ctrlDistrict02Page01

    Dim LivestockListDA As New LGMDdataDataSetTableAdapters.LivestockListTableAdapter
    Dim LivestockMovementDA As New LGMDdataDataSetTableAdapters.LivestockMovement04TableAdapter
    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim ProductsMovementDA As New LGMDdataDataSetTableAdapters.ProductsMovement04TableAdapter
    Dim LivestockSlaughListDA As New DistrictQuarterDataSetTableAdapters.LivestockSlaughListTableAdapter
    Dim LivestockSlaughteredDA As New LGMDdataDataSetTableAdapters.LivestockSlaughtered01TableAdapter
    Dim CarcassDA As New DistrictQuarterDataSetTableAdapters.Carcass04TableAdapter
    Dim LivestockMarketingDA As New LGMDdataDataSetTableAdapters.LivestockMarketing04TableAdapter
    Private animalsIntoNonTrade As Integer?
    Private animalsIntoTradeFromLGA As Integer?
    Private animalsIntoTradeFromCountries As Integer?
    Private animalsToNonTrade As Integer?
    Private animalsToTradeLGA As Integer?
    Private animalsToTradeCountries As Integer?
    Private animalsTransNonTrade As Integer?
    Private animalsTransTrade As Integer?
    Private soldWithinDistricts As Double?
    Private soldOtherDistricts As Double?
    Private soldOtherCountries As Double?
    Private warmThisQuarter As Double?
    Private chilledThisQuarter As Double?
    Private frozenThisQuarter As Double?
    Private totalCarcassWeight As Double?

    Private Sub ctrlDistrict02Page01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LivestockListDA.Fill(Me.LGMDdataDataSet.LivestockList)
        Me.AppUspDistrictQuarterFillLivestockMovementTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillLivestockMovement, g_RecordID)

        If Me.LGMDdataDataSet.appUspDistrictQuarterFillLivestockMovement.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.LivestockList.Select("AI < '5' ")
                Me.LivestockMovementDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictQuarterFillLivestockMovementTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillLivestockMovement, g_RecordID)
        End If

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictQuarterFillProductsMovementTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillProductsMovement, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictQuarterFillProductsMovement.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='ProductsMovement04'")
                Me.ProductsMovementDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictQuarterFillProductsMovementTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillProductsMovement, g_RecordID)
        End If

        Me.LivestockSlaughListDA.Fill(Me.DistrictQuarterDataSet.LivestockSlaughList)
        Me.LivestockSlaughteredDA.Fill(Me.LGMDdataDataSet.LivestockSlaughtered01)
        Me.AppUspDistrictQuarterFillCarcassWeightTableAdapter.Fill(Me.DistrictQuarterDataSet.appUspDistrictQuarterFillCarcassWeight, g_RecordID, g_FormSerialNumber)
        If Me.DistrictQuarterDataSet.appUspDistrictQuarterFillCarcassWeight.Rows.Count = 0 Then
            For Each row As DataRow In Me.DistrictQuarterDataSet.LivestockSlaughList.Rows
                Me.CarcassDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictQuarterFillCarcassWeightTableAdapter.Fill(Me.DistrictQuarterDataSet.appUspDistrictQuarterFillCarcassWeight, g_RecordID, g_FormSerialNumber)
        End If

        Me.AppUspDistrictQuarterFillLivestockMarketingTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillLivestockMarketing, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictQuarterFillLivestockMarketing.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='LivestockMarketing04'")
                Me.LivestockMarketingDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictQuarterFillLivestockMarketingTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillLivestockMarketing, g_RecordID)
        End If

        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        PopulateHeaderControls(Me)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm(, , g_RecordID)
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillLivestockMovementDataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        animalsIntoNonTrade = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        animalsIntoTradeFromLGA = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        animalsIntoTradeFromCountries = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        animalsToNonTrade = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                        animalsToTradeLGA = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                        animalsToTradeCountries = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                        animalsTransNonTrade = CheckIfIsNullOrEmptyDGVCell(row.Cells(12))
                        animalsTransTrade = CheckIfIsNullOrEmptyDGVCell(row.Cells(13))
                        Me.LivestockMovementDA.appUspDistrictQuarterUpdateLivestockMovement(row.Cells(0).Value, _
                                                                                            row.Cells(1).Value.ToString, _
                                                                                            Val(row.Cells(3).Value.ToString), _
                                                                                            row.Cells(4).Value, _
                                                                                            animalsIntoNonTrade, _
                                                                                            animalsIntoTradeFromLGA, _
                                                                                            animalsIntoTradeFromCountries, _
                                                                                            animalsToNonTrade, _
                                                                                            animalsToTradeLGA, _
                                                                                            animalsToTradeCountries, _
                                                                                            animalsTransNonTrade, _
                                                                                            animalsTransTrade, _
                                                                                            row.Cells(14).Value)
                    End If
                Next
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString)
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillProductsMovementDataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        soldWithinDistricts = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        soldOtherDistricts = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        soldOtherCountries = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                        Me.ProductsMovementDA.appUspDistrictQuarterUpdateProductsMovement(row.Cells(0).Value, _
                                                                                          row.Cells(1).Value.ToString, _
                                                                                          row.Cells(2).Value.ToString, _
                                                                                          row.Cells(3).Value.ToString, _
                                                                                          row.Cells(4).Value, _
                                                                                          row.Cells(5).Value, _
                                                                                          soldWithinDistricts,
                                                                                          soldOtherDistricts,
                                                                                          soldOtherCountries,
                                                                                          row.Cells(10).Value)
                    End If
                Next
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString)
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillCarcassWeightDataGridView.Rows
                    totalCarcassWeight = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                    Me.CarcassDA.appUspDistrictQuarterUpdateCarcassWeight(row.Cells(2).Value, totalCarcassWeight, g_RecordID)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillLivestockMarketingDataGridView.Rows
                    warmThisQuarter = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    chilledThisQuarter = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                    frozenThisQuarter = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                    Me.AppUspDistrictQuarterFillLivestockMarketingTableAdapter.appUspDistrictQuarterUpdateLivestockMarketing(row.Cells(5).Value, _
                                                                                                                             warmThisQuarter, _
                                                                                                                             chilledThisQuarter, _
                                                                                                                             frozenThisQuarter, _
                                                                                                                             row.Cells(10).Value.ToString, _
                                                                                                                             row.Cells(11).Value)
                Next
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString)
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspDistrictQuarterFillLivestockMovementDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspDistrictQuarterFillLivestockMovementDataGridView.UserDeletingRow
        If Me.AppUspDistrictQuarterFillLivestockMovementDataGridView.CurrentRow.Index < 4 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillLivestockMovementDataGridView.SelectedRows
                    Me.LivestockMovementDA.appUspDistrictQuarterDeleteLivestockMovement(row.Cells(0).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub AppUspDistrictQuarterFillLivestockMovementDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictQuarterFillLivestockMovementDataGridView.RowEnter
        If Me.AppUspDistrictQuarterFillLivestockMovementDataGridView.Rows(e.RowIndex).IsNewRow Then
            AppUspDistrictQuarterFillLivestockMovementDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            AppUspDistrictQuarterFillLivestockMovementDataGridView.Rows(e.RowIndex).Cells(3).Value = 1
            AppUspDistrictQuarterFillLivestockMovementDataGridView.Rows(e.RowIndex).Cells(4).Value = Guid.NewGuid
            AppUspDistrictQuarterFillLivestockMovementDataGridView.Rows(e.RowIndex).Cells(14).Value = g_RecordID

        End If
    End Sub

    Private Sub AppUspDistrictQuarterFillProductsMovementDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictQuarterFillProductsMovementDataGridView.RowEnter
        If Me.AppUspDistrictQuarterFillProductsMovementDataGridView.Rows(e.RowIndex).IsNewRow Then
            AppUspDistrictQuarterFillProductsMovementDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            AppUspDistrictQuarterFillProductsMovementDataGridView.Rows(e.RowIndex).Cells(3).Value = "ProductsMovement04"
            AppUspDistrictQuarterFillProductsMovementDataGridView.Rows(e.RowIndex).Cells(4).Value = 1
            AppUspDistrictQuarterFillProductsMovementDataGridView.Rows(e.RowIndex).Cells(5).Value = Guid.NewGuid
            AppUspDistrictQuarterFillProductsMovementDataGridView.Rows(e.RowIndex).Cells(10).Value = g_RecordID

        End If
    End Sub

    Private Sub AppUspDistrictQuarterFillProductsMovementDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspDistrictQuarterFillProductsMovementDataGridView.UserDeletingRow
        If Me.AppUspDistrictQuarterFillProductsMovementDataGridView.CurrentRow.Index < 1 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillProductsMovementDataGridView.SelectedRows
                    Me.ProductsMovementDA.appUspDistrictQuarterDeleteProductsMovement(row.Cells(0).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub AppUspDistrictQuarterFillLivestockMovementDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictQuarterFillLivestockMovementDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictQuarterFillProductsMovementDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictQuarterFillProductsMovementDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictQuarterFillLivestockMarketingDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictQuarterFillLivestockMarketingDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictQuarterFillLivestockMovementDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictQuarterFillLivestockMovementDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictQuarterFillProductsMovementDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictQuarterFillProductsMovementDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictQuarterFillLivestockMarketingDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictQuarterFillLivestockMarketingDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictQuarterFillCarcassWeightDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles AppUspDistrictQuarterFillCarcassWeightDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub
End Class
