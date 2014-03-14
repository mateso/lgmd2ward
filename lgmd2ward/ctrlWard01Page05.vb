Public Class ctrlWard01Page05

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim LivestockSlaughteredDA As New LGMDdataDataSetTableAdapters.LivestockSlaughtered01TableAdapter
    Private affectedArea As Double?
    Private numberOfVillageAffected As Integer?
    Private amountOfPestcideApplied As Double?
    Private numberOfVillagesServed As Integer?
    Private numberOfHouseholdServed As Integer?
    Private areaRescued As Double?
    Private totalNumberSlaughteredThisMonth As Integer?
    Private averageRetailPriceKg As Double?

    Private Sub ctrlWard01Page05_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspMonthlyLookupNameOfPestsDiseaseTableAdapter.Fill(Me.LookupTableDataDataSet.appUspMonthlyLookupNameOfPestsDisease)
        Me.AppUspLookupCropsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupCrops)
        Me.AppUspLookupSeverityTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupSeverity)
        Me.AppUspLookupUnitsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits)
        Me.ChemicalControl01TableAdapter.Fill(Me.LGMDdataDataSet.ChemicalControl01, g_RecordID)

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.LivestockSlaughteredDA.Fill(Me.LGMDdataDataSet.LivestockSlaughtered01)
        Me.LivestockSlaughtered01iTableAdapter.Fill(Me.LGMDdataDataSet.LivestockSlaughtered01i, g_RecordID)
        If (Me.LGMDdataDataSet.LivestockSlaughtered01i.Rows.Count = 0) Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='LivestockSlaughtered01' AND ListItemStatus='0'")
                Me.LivestockSlaughteredDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.LivestockSlaughtered01iTableAdapter.Fill(Me.LGMDdataDataSet.LivestockSlaughtered01i, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        If Me.DataGridView1.Rows(e.RowIndex).IsNewRow Then
            Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value = g_RecordID

        End If
    End Sub

    Private Sub DataGridView2_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.RowEnter
        If Me.DataGridView2.Rows(e.RowIndex).IsNewRow Then
            Me.DataGridView2.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView2.Rows(e.RowIndex).Cells(2).Value = 1
            Me.DataGridView2.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid
            Me.DataGridView2.Rows(e.RowIndex).Cells(7).Value = g_RecordID
        End If
    End Sub

    Private Sub DataGridView2_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView2.UserDeletingRow
        If Me.DataGridView2.CurrentRow.Index < 6 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.DataGridView2.SelectedRows
                    Me.LivestockSlaughtered01iTableAdapter.appUspMonthlyDeleteLivestockSlaughtered(row.Cells(0).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
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
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.IsNewRow Then
                    Else
                        affectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                        numberOfVillageAffected = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        amountOfPestcideApplied = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        numberOfVillagesServed = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                        numberOfHouseholdServed = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                        areaRescued = CheckIfIsNullOrEmptyDGVCell(row.Cells(11))
                        Me.ChemicalControl01TableAdapter.appUspMonthlyInsertChemicalControl(row.Cells(0).Value, _
                                                                                            row.Cells(1).Value.ToString, _
                                                                                            row.Cells(2).Value.ToString, _
                                                                                            row.Cells(3).Value.ToString, _
                                                                                            affectedArea, _
                                                                                            numberOfVillageAffected, _
                                                                                            row.Cells(6).Value.ToString, _
                                                                                            amountOfPestcideApplied, _
                                                                                            row.Cells(8).Value.ToString, _
                                                                                            numberOfVillagesServed, _
                                                                                            numberOfHouseholdServed, _
                                                                                            areaRescued, _
                                                                                            row.Cells(12).Value.ToString, _
                                                                                            row.Cells(13).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView2.Rows
                    If row.IsNewRow Then
                    Else
                        totalNumberSlaughteredThisMonth = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        averageRetailPriceKg = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))

                        Me.LivestockSlaughtered01iTableAdapter.appUspMonthlyUpdateLivestockSlaughtered(row.Cells(0).Value, _
                                                                                                       row.Cells(1).Value.ToString, _
                                                                                                       row.Cells(2).Value.ToString, _
                                                                                                       row.Cells(3).Value, _
                                                                                                       totalNumberSlaughteredThisMonth, _
                                                                                                       averageRetailPriceKg, _
                                                                                                       row.Cells(7).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub DataGridView1_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow

        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                Me.ChemicalControl01TableAdapter.appUspMonthlyDeleteChemicalControl(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    'Public Sub UpdateLivestockSlaughtered()
    '    With LGMDCmd
    '        .Connection = New SqlClient.SqlConnection(My.Settings.DataConnectionString)
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "appUspMonthlyUpdateLivestockSlaughtered"
    '    End With
    'End Sub
End Class
