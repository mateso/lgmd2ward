Public Class ctrlWard03Page09

    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private LiveInfraDA As New LGMDdataDataSetTableAdapters.LivestockInfrastructure03TableAdapter
    Private GrazingLandDA As New LGMDdataDataSetTableAdapters.GrazingLand03TableAdapter
    Private working As Integer?
    Private notWorking As Integer?
    Private numberRequired As Integer?
    Private numberRegistered As Integer?

    Private Sub ctrlWard03Page09_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.LiveInfraDA.Fill(Me.LGMDdataDataSet.LivestockInfrastructure03)
        Me.AppUspAnnualFillLivestockInfrastructureTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillLivestockInfrastructure, g_RecordID)

        If Me.LGMDdataDataSet.appUspAnnualFillLivestockInfrastructure.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='LivestockInfrastructure03' AND ListItemStatus=0")
                Me.LiveInfraDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspAnnualFillLivestockInfrastructureTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillLivestockInfrastructure, g_RecordID)
        End If

        Me.GrazingLandDA.Fill(Me.LGMDdataDataSet.GrazingLand03)
        Me.GrazingLand03iTableAdapter.Fill(Me.LGMDdataDataSet.GrazingLand03i, g_RecordID)

        If Me.LGMDdataDataSet.GrazingLand03i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='GrazingLand03'")
                Me.GrazingLandDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.GrazingLand03iTableAdapter.Fill(Me.LGMDdataDataSet.GrazingLand03i, g_RecordID)
        End If

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
                For Each row As DataGridViewRow In Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        working = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        notWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        numberRequired = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        numberRegistered = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        Me.LiveInfraDA.appUspAnnualUpdateLivestockInfrastructure(row.Cells(0).Value, _
                                                                                 row.Cells(1).Value.ToString(), _
                                                                                 Val(row.Cells(2).Value.ToString()), _
                                                                                 row.Cells(3).Value, _
                                                                                 working, _
                                                                                 notWorking, _
                                                                                 numberRequired, _
                                                                                 numberRegistered, _
                                                                                 row.Cells(9).Value.ToString(), _
                                                                                 row.Cells(10).Value)
                    End If
                Next
            Catch ex As Exception
            End Try
            Me.GrazingLand03iTableAdapter.Update(Me.LGMDdataDataSet.GrazingLand03i)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub appUspAnnualFillLivestockInfrastructureDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles appUspAnnualFillLivestockInfrastructureDataGridView.RowEnter
        If Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(e.RowIndex).Cells(2).Value = 1
            Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid
            Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(e.RowIndex).Cells(10).Value = g_RecordID
        End If
    End Sub

    Private Sub appUspAnnualFillLivestockInfrastructureDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspAnnualFillLivestockInfrastructureDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView3_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspAnnualFillLivestockInfrastructureDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles appUspAnnualFillLivestockInfrastructureDataGridView.UserDeletingRow
        If Me.appUspAnnualFillLivestockInfrastructureDataGridView.CurrentRow.Index < 14 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.appUspAnnualFillLivestockInfrastructureDataGridView.SelectedRows
                    Me.LiveInfraDA.appUspAnnualDeleteLivestockInfrastructure(row.Cells(4).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub appUspAnnualFillLivestockInfrastructureDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles appUspAnnualFillLivestockInfrastructureDataGridView.Paint
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(3).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(4).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(5).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(6).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(7).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(8).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(9).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(12).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(13).Cells(8).Style.BackColor = Color.Gray
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(3).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(4).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(5).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(6).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(7).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(8).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(9).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(12).Cells(8).ReadOnly = True
        Me.appUspAnnualFillLivestockInfrastructureDataGridView.Rows(13).Cells(8).ReadOnly = True
    End Sub

    Private Sub DataGridView3_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView3.CellPainting
        If (e.ColumnIndex = 6 AndAlso e.RowIndex <> -1) Or (e.ColumnIndex = 7 AndAlso e.RowIndex <> -1) _
            Or (e.ColumnIndex = 8 AndAlso e.RowIndex <> -1) Or (e.ColumnIndex = 9 AndAlso e.RowIndex <> -1) Then

            Using gridBrush As Brush = New SolidBrush(Me.DataGridView3.GridColor),
                  backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    ' Clear cell   
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw line (bottom border and right border of current cell)   
                    'If next row cell has different content, only draw bottom border line of current cell   
                    'If e.RowIndex < DataGridView3.Rows.Count - 1 AndAlso DataGridView3.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                    '    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    'End If

                    ' Draw right border line of current cell   
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' draw/fill content in current cell, and fill only one cell of multiple same cells   
                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso DataGridView3.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
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

    Private Sub DataGridView3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles DataGridView3.Paint
        Me.DataGridView3.Rows(1).Cells(6).ReadOnly = True
        Me.DataGridView3.Rows(2).Cells(6).ReadOnly = True
        Me.DataGridView3.Rows(3).Cells(6).ReadOnly = True
        Me.DataGridView3.Rows(1).Cells(7).ReadOnly = True
        Me.DataGridView3.Rows(2).Cells(7).ReadOnly = True
        Me.DataGridView3.Rows(3).Cells(7).ReadOnly = True
        Me.DataGridView3.Rows(1).Cells(8).ReadOnly = True
        Me.DataGridView3.Rows(2).Cells(8).ReadOnly = True
        Me.DataGridView3.Rows(3).Cells(8).ReadOnly = True
        Me.DataGridView3.Rows(1).Cells(9).ReadOnly = True
        Me.DataGridView3.Rows(2).Cells(9).ReadOnly = True
        Me.DataGridView3.Rows(3).Cells(9).ReadOnly = True
    End Sub
End Class
