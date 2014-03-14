Public Class ctrlDistrict02Page03

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim ReproductiveInputDA As New LGMDdataDataSetTableAdapters.ReproductionInputs04TableAdapter
    Private amountRequired As Double?
    Private amountAvailable As Double?

    Private Sub ctrlDistrict02Page03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictQuarterFillReproductionInputTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillReproductionInput, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictQuarterFillReproductionInput.Rows.Count = 0 Then
            For i = 1 To 5
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='ReproductionInputs04'")
                    Me.ReproductiveInputDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspDistrictQuarterFillReproductionInputTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictQuarterFillReproductionInput, g_RecordID)
            Next
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
                For Each row As DataGridViewRow In Me.AppUspDistrictQuarterFillReproductionInputDataGridView.Rows
                    amountRequired = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                    amountAvailable = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                    Me.AppUspDistrictQuarterFillReproductionInputTableAdapter.appUspDistrictQuarterUpdateReproductionInput(row.Cells(5).Value, _
                                                                                                                           row.Cells(7).Value.ToString, _
                                                                                                                           amountRequired, _
                                                                                                                           amountAvailable, _
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

    Private Sub AppUspDistrictQuarterFillReproductionInputDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictQuarterFillReproductionInputDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictQuarterFillReproductionInputDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspDistrictQuarterFillReproductionInputDataGridView.CellPainting
        If e.ColumnIndex = 2 AndAlso e.RowIndex <> -1 Then

            Using gridBrush As Brush = New SolidBrush(Me.AppUspDistrictQuarterFillReproductionInputDataGridView.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    ' Clear cell   
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw line (bottom border and right border of current cell)   
                    'If next row cell has different content, only draw bottom border line of current cell   
                    If e.RowIndex < AppUspDistrictQuarterFillReproductionInputDataGridView.Rows.Count - 2 AndAlso AppUspDistrictQuarterFillReproductionInputDataGridView.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    End If

                    ' Draw right border line of current cell   
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' draw/fill content in current cell, and fill only one cell of multiple same cells   
                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso AppUspDistrictQuarterFillReproductionInputDataGridView.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                        Else
                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                        End If
                    End If

                    e.Handled = True
                End Using
            End Using
        End If

    End Sub

    Private Sub AppUspDistrictQuarterFillReproductionInputDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictQuarterFillReproductionInputDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
