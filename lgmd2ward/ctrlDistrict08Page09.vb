Public Class ctrlDistrict08Page09

    Private Sub ctrlDistrict08Page09_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.AppUspQuarterlyIntegratedFillReproductionInputTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillReproductionInput, g_FormSerialNumberIQ)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspQuarterlyIntegratedFillReproductionInputDataGridView_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles AppUspQuarterlyIntegratedFillReproductionInputDataGridView.CellPainting
        If e.ColumnIndex = 2 AndAlso e.RowIndex <> -1 Then

            Using gridBrush As Brush = New SolidBrush(Me.AppUspQuarterlyIntegratedFillReproductionInputDataGridView.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    ' Clear cell   
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw line (bottom border and right border of current cell)   
                    'If next row cell has different content, only draw bottom border line of current cell   
                    If e.RowIndex < AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Rows.Count - 2 AndAlso AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    End If

                    ' Draw right border line of current cell   
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' draw/fill content in current cell, and fill only one cell of multiple same cells   
                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso AppUspQuarterlyIntegratedFillReproductionInputDataGridView.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                        Else
                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                        End If
                    End If

                    e.Handled = True
                End Using
            End Using
        End If
    End Sub

End Class
