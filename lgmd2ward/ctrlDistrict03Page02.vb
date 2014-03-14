Public Class ctrlDistrict03Page02

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim EducationLevelDA As New LGMDdataDataSetTableAdapters.EducationLevel05TableAdapter
    Dim WorkingFacilitiesDA As New LGMDdataDataSetTableAdapters.WorkingFacilities05TableAdapter
    Dim WorkingEquipmentsDA As New LGMDdataDataSetTableAdapters.WorkingEquipments05TableAdapter
    Dim DistrictInfoDA As New LGMDdataDataSetTableAdapters.DistrictInfo05TableAdapter
    Private firstNo As Integer?
    Private secondNo As Integer?
    Private thirdNo As Integer?
    Private fourthNo As Integer?
    Private fifthNo As Integer?
    Private sixthNo As Integer?

    Private Sub ctrlDistrict03Page02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictAnnualFillEducationLevelTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillEducationLevel, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillEducationLevel.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='EducationLevel05'")
                Me.EducationLevelDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillEducationLevelTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillEducationLevel, g_RecordID)
        End If

        Me.AppUspDistrictAnnualFillWorkingFacilitiesTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingFacilities, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingFacilities.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='WorkingFacilities05'")
                Me.WorkingFacilitiesDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillWorkingFacilitiesTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingFacilities, g_RecordID)
        End If

        Me.AppUspDistrictAnnualFillWorkingEquipmentsTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingEquipments, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingEquipments.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='WorkingEquipments05'")
                Me.WorkingEquipmentsDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillWorkingEquipmentsTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingEquipments, g_RecordID)
        End If

        Me.DistrictInfoDA.Fill(Me.LGMDdataDataSet.DistrictInfo05, g_RecordID)

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

            Me.AppUspDistrictAnnualFillEducationLevelTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillEducationLevel)
            Me.AppUspDistrictAnnualFillWorkingFacilitiesTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingFacilities)
            Me.AppUspDistrictAnnualFillWorkingEquipmentsTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillWorkingEquipments)
            Me.DistrictInfoDA.appUspDistrictAnnualUpdateDistrictInfoPageTwo(txtModeOfInternetAccess.Value, _
                                                                            txtNumberOfOfficersTrained.Text, _
                                                                            g_RecordID)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNumberOfOfficersTrained_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfOfficersTrained.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillEducationLevelDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillEducationLevelDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillWorkingFacilitiesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillWorkingFacilitiesDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillWorkingEquipmentsDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillWorkingEquipmentsDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillEducationLevelDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillEducationLevelDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillEducationLevelDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(8).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(9).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(12).Value
                End If
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(9).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(12).Value
                End If
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                thirdNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    secondNo = 0
                Else
                    firstNo = row.Cells(8).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(12).Value
                End If
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                fourthNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(8).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(9).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(11).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(12).Value
                End If
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                fifthNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(8).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(9).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                    sixthNo = 0
                Else
                    sixthNo = row.Cells(12).Value
                End If
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(12))) Then
                sixthNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(8).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(9))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(9).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(10))) Then
                    fourthNo = 0
                Else
                    fourthNo = row.Cells(10).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(11))) Then
                    fifthNo = 0
                Else
                    fifthNo = row.Cells(11).Value
                End If
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            Else
                firstNo = row.Cells(7).Value
                secondNo = row.Cells(8).Value
                thirdNo = row.Cells(9).Value
                fourthNo = row.Cells(10).Value
                fifthNo = row.Cells(11).Value
                sixthNo = row.Cells(12).Value
                row.Cells(13).Value = AutomateSummation(firstNo, secondNo, thirdNo, fourthNo, fifthNo, sixthNo)
            End If
        Next
    End Sub

    Private Sub Label19_Click(sender As System.Object, e As System.EventArgs) Handles Label19.Click
        'Dim txtBox As RichTextBox = New RichTextBox()
        'DirectCast(Label19, TextBox)
        'txtBox.Show()
        'Label19.Text = txtBox.Text
    End Sub

    Private Sub AppUspDistrictAnnualFillEducationLevelDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillEducationLevelDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillWorkingFacilitiesDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillWorkingFacilitiesDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillWorkingEquipmentsDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillWorkingEquipmentsDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
