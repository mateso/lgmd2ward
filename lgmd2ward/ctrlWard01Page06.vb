Public Class ctrlWard01Page06

    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private MonthlyLookupDS As New MonthlyDataDataSet
    Private MonthlyLookupDA As New MonthlyDataDataSetTableAdapters.MonthlyLookupTableTableAdapter
    Private ProdMilkDA As New LGMDdataDataSetTableAdapters.ProdMilk01TableAdapter
    Private ProdSkinDA As New LGMDdataDataSetTableAdapters.ProdSkin01TableAdapter
    Private numberOfAnimalsAffected As Integer?
    Private numberOfCases As Integer?
    Private amountThisMonth As Double?
    Private drySuspended As Integer?
    Private drySalted As Integer?
    Private wetBlue As Integer?


    Private Sub ctrlWard01Page06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MonthlyLookupDA.Fill(Me.MonthlyLookupDS.MonthlyLookupTable)

        Me.AppUspMonthlyLookupLivestockSlaughTableAdapter.Fill(Me.LookupTableDataDataSet.appUspMonthlyLookupLivestockSlaugh)

        Me.MeatInspection01TableAdapter.Fill(Me.LGMDdataDataSet.MeatInspection01, g_RecordID)

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.ProdMilkDA.Fill(Me.LGMDdataDataSet.ProdMilk01)
        Me.ProdMilk01iTableAdapter.Fill(Me.LGMDdataDataSet.ProdMilk01i, g_RecordID)

        If Me.LGMDdataDataSet.ProdMilk01i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='ProdMilk01'")
                Me.ProdMilkDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.ProdMilk01iTableAdapter.Fill(Me.LGMDdataDataSet.ProdMilk01i, g_RecordID)
        End If

        Me.ProdSkinDA.Fill(Me.LGMDdataDataSet.ProdSkin01)
        Me.ProdSkin01iTableAdapter.Fill(Me.LGMDdataDataSet.ProdSkin01i, g_RecordID)

        If Me.LGMDdataDataSet.ProdSkin01i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("IndicatorListID=15")
                Me.ProdSkinDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.ProdSkin01iTableAdapter.Fill(Me.LGMDdataDataSet.ProdSkin01i, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        If Me.DataGridView1.Rows(e.RowIndex).IsNewRow() Then
            Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value = g_RecordID
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
                        numberOfAnimalsAffected = CheckIfIsNullOrEmptyDGVCell(row.Cells(3))
                        numberOfCases = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))

                        Me.MeatInspection01TableAdapter.appUspMonthlyInsertMeatInspection(row.Cells(0).Value, _
                                                                                          row.Cells(1).Value.ToString, _
                                                                                          row.Cells(2).Value.ToString, _
                                                                                          numberOfAnimalsAffected, _
                                                                                          row.Cells(4).Value.ToString, _
                                                                                          numberOfCases, _
                                                                                          row.Cells(6).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.ProdMilk01DataGridView.Rows
                    amountThisMonth = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                    Me.ProdMilk01iTableAdapter.appUspMonthlyUpdateProdMilk(row.Cells(2).Value, _
                                                                           amountThisMonth, _
                                                                           row.Cells(5).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView3.Rows
                    drySuspended = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                    drySalted = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                    wetBlue = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    Me.ProdSkin01iTableAdapter.appUspMonthlyUpdateProdSkin(row.Cells(2).Value, _
                                                                           drySuspended, _
                                                                           drySalted, _
                                                                           wetBlue, _
                                                                           row.Cells(7).Value.ToString, _
                                                                           row.Cells(8).Value)

                Next
            Catch ex As Exception
            End Try

            'Me.ProdMilk01iTableAdapter.Update(Me.LGMDdataDataSet.ProdMilk01i)
            'Me.ProdSkin01iTableAdapter.Update(Me.LGMDdataDataSet.ProdSkin01i)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub DataGridView1_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow

        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                Me.MeatInspection01TableAdapter.appUspMonthlyDeleteMeatInspection(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub ProdMilk01DataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ProdMilk01DataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView3_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If (e.ColumnIndex = 2 And e.RowIndex >= 0) Then

            Dim selectedAnimal As String = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
            Dim dgvCell As DataGridViewComboBoxCell
            If TypeOf DataGridView1.Rows(e.RowIndex).Cells(4) Is DataGridViewComboBoxCell Then
                dgvCell = DirectCast(DataGridView1.Rows(e.RowIndex).Cells(4), DataGridViewComboBoxCell)
                DataGridView1.Rows(e.RowIndex).Cells(4).Value = Nothing
                dgvCell.DataSource = Me.MonthlyLookupDA.GetDataCondemn(selectedAnimal)
            Else
                dgvCell = New DataGridViewComboBoxCell
                dgvCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                dgvCell.FlatStyle = FlatStyle.Flat
                dgvCell.DisplayMember = "LookupEn"
                dgvCell.ValueMember = "LookupEn"

                DataGridView1.Rows(e.RowIndex).Cells(4).Value = Nothing

                dgvCell.DataSource = Me.MonthlyLookupDA.GetDataCondemn(selectedAnimal)

                DataGridView1.Rows(e.RowIndex).Cells(4) = dgvCell
            End If

        End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub ProdMilk01DataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ProdMilk01DataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
