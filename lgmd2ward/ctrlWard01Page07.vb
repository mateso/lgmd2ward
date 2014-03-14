Public Class ctrlWard01Page07

    Private MonthlyDS As New MonthlyDataDataSet
    Private MonthlyLookupDA As New MonthlyDataDataSetTableAdapters.MonthlyLookupTableTableAdapter
    Private LivestockServiceDA As New LGMDdataDataSetTableAdapters.LivestockService01TableAdapter
    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private numberAffected As Integer?
    Private numberTreated As Integer?
    Private numberHealed As Integer?
    Private numberDead As Integer?
    Private numberDipped As Integer?
    Private numberSprayed As Integer?
    Private numberVaccinated As Integer?
    Private cuttingHoof As Integer?
    Private castration As Integer?
    Private AI As Integer?
    Private cuttingHorn As Integer?
    Private branding As Integer?
    Private cuttingTail As Integer?
    Private cuttingTeeth As Integer?
    Private cuttingBillBeek As Integer?


    Private Sub ctrlWard01Page07_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.MonthlyLookupDA.Fill(Me.MonthlyDS.MonthlyLookupTable)

        Me.AppUspMonthlyLookupTypeOfLivestockTableAdapter.Fill(Me.LookupTableDataDataSet.appUspMonthlyLookupTypeOfLivestock)
        Me.Medication01TableAdapter.Fill(Me.LGMDdataDataSet.Medication01, g_RecordID)

        Me.AppUspMonthlyLookupTypeOfLivestockTableAdapter.Fill(Me.LookupTableDataDataSet.appUspMonthlyLookupTypeOfLivestock)
        Me.AppUspMonthlyLookupDipSprayTableAdapter.Fill(Me.LookupTableDataDataSet.appUspMonthlyLookupDipSpray)
        Me.AppUspMonthlyLookupVaccineTableAdapter.Fill(Me.LookupTableDataDataSet.appUspMonthlyLookupVaccine)
        Me.DippingSprayingVaccination01TableAdapter.Fill(Me.LGMDdataDataSet.DippingSprayingVaccination01, g_RecordID)

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.LivestockServiceDA.Fill(Me.LGMDdataDataSet.LivestockService01)
        'Inserting records to a combinde table
        Me.AppUspMonthlyFillLivestockServicesTableAdapter.Fill(Me.MonthlyDataDataSet.appUspMonthlyFillLivestockServices, g_RecordID)
        'Determine whether there was inserted record before
        If Me.MonthlyDataDataSet.appUspMonthlyFillLivestockServices.Rows.Count = 0 Then
            ' Inserting records to a secondary table,if poreviously not filled/inserted
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='LivestockService01' AND ListItemStatus=0")
                Me.LivestockServiceDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            'Load inserted record
            Me.AppUspMonthlyFillLivestockServicesTableAdapter.Fill(Me.MonthlyDataDataSet.appUspMonthlyFillLivestockServices, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading

    End Sub

    Private Sub Medication01DataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Medication01DataGridView.RowEnter
        If Me.Medication01DataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.Medication01DataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid()
            Me.Medication01DataGridView.Rows(e.RowIndex).Cells(8).Value = g_RecordID
        End If
    End Sub

    Private Sub DataGridView2_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.RowEnter
        If Me.DataGridView2.Rows(e.RowIndex).IsNewRow() Then
            Me.DataGridView2.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView2.Rows(e.RowIndex).Cells(8).Value = g_RecordID
        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Try
                For Each row As DataGridViewRow In Me.Medication01DataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        numberAffected = CheckIfIsNullOrEmptyDGVCell(row.Cells(3))
                        numberTreated = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                        numberHealed = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        numberDead = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))

                        Me.Medication01TableAdapter.appUspMonthlyInsertMedication(row.Cells(0).Value, _
                                                                                  row.Cells(1).Value.ToString, _
                                                                                  row.Cells(2).Value.ToString, _
                                                                                  numberAffected, _
                                                                                  numberTreated, _
                                                                                  numberHealed, _
                                                                                  numberDead, _
                                                                                  row.Cells(7).Value.ToString, _
                                                                                  row.Cells(8).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView2.Rows
                    If row.IsNewRow() Then
                    Else
                        numberDipped = CheckIfIsNullOrEmptyDGVCell(row.Cells(2))
                        numberSprayed = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                        numberVaccinated = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))

                        Me.DippingSprayingVaccination01TableAdapter.appUspMonthlyInsertDipping(row.Cells(0).Value, _
                                                                                               row.Cells(1).Value.ToString, _
                                                                                               numberDipped, _
                                                                                               row.Cells(3).Value.ToString, _
                                                                                               numberSprayed, _
                                                                                               row.Cells(5).Value.ToString, _
                                                                                               numberVaccinated, _
                                                                                               row.Cells(7).Value.ToString, _
                                                                                               row.Cells(8).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.appUspMonthlyFillLivestockServicesDataGridView.Rows
                    cuttingHoof = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                    castration = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                    AI = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    cuttingHorn = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    branding = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                    cuttingTail = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                    cuttingTeeth = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                    cuttingBillBeek = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                    Me.AppUspMonthlyFillLivestockServicesTableAdapter.appUspMonthlyUpdateLivestockServices(row.Cells(2).Value, _
                                                                                                           cuttingHoof, _
                                                                                                           castration, _
                                                                                                           AI, _
                                                                                                           cuttingHorn, _
                                                                                                           branding, _
                                                                                                           cuttingTail, _
                                                                                                           cuttingTeeth, _
                                                                                                           cuttingBillBeek, _
                                                                                                           row.Cells(12).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.AppUspMonthlyFillLivestockServicesTableAdapter.Update(Me.MonthlyDataDataSet.appUspMonthlyFillLivestockServices)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub Medication01DataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles Medication01DataGridView.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.Medication01DataGridView.Rows
                Me.Medication01TableAdapter.appUspMonthlyDeleteMedication(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DataGridView2_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView2.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DataGridView2.Rows
                Me.DippingSprayingVaccination01TableAdapter.appUspMonthlyDeleteDipping(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Medication01DataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Medication01DataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView2_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspMonthlyFillLivestockServicesDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspMonthlyFillLivestockServicesDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspMonthlyFillLivestockServicesDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles appUspMonthlyFillLivestockServicesDataGridView.Paint
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(0).Cells(9).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(0).Cells(10).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(0).Cells(11).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(1).Cells(9).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(1).Cells(10).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(1).Cells(11).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(2).Cells(10).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(2).Cells(11).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(3).Cells(7).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(3).Cells(9).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(3).Cells(11).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(6).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(7).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(8).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(9).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(10).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(4).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(5).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(6).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(7).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(8).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(9).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(10).Style.BackColor = Color.Black
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(0).Cells(9).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(0).Cells(10).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(0).Cells(11).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(1).Cells(9).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(1).Cells(10).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(1).Cells(11).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(2).Cells(10).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(2).Cells(11).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(3).Cells(7).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(3).Cells(9).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(3).Cells(11).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(4).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(5).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(6).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(7).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(8).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(9).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(4).Cells(10).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(4).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(5).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(6).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(7).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(8).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(9).ReadOnly = True
        Me.appUspMonthlyFillLivestockServicesDataGridView.Rows(5).Cells(10).ReadOnly = True
    End Sub

    Private Sub Medication01DataGridView_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Medication01DataGridView.CellValueChanged
        If (e.ColumnIndex = 1 And e.RowIndex >= 0) Then

            Dim selectedAnimal As String = Medication01DataGridView.Rows(e.RowIndex).Cells(1).Value.ToString()
            Dim dgvCell As DataGridViewComboBoxCell
            If TypeOf Medication01DataGridView.Rows(e.RowIndex).Cells(2) Is DataGridViewComboBoxCell Then
                dgvCell = DirectCast(Medication01DataGridView.Rows(e.RowIndex).Cells(2), DataGridViewComboBoxCell)
                Medication01DataGridView.Rows(e.RowIndex).Cells(2).Value = Nothing
                dgvCell.DataSource = Me.MonthlyLookupDA.GetDataByDisease(selectedAnimal)
            Else
                dgvCell = New DataGridViewComboBoxCell
                dgvCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                dgvCell.FlatStyle = FlatStyle.Flat
                dgvCell.DisplayMember = "LookupEn"
                dgvCell.ValueMember = "LookupEn"

                Medication01DataGridView.Rows(e.RowIndex).Cells(2).Value = Nothing

                dgvCell.DataSource = Me.MonthlyLookupDA.GetDataByDisease(selectedAnimal)

                Medication01DataGridView.Rows(e.RowIndex).Cells(2) = dgvCell
            End If

        End If
    End Sub
End Class
