Public Class ctrlWard03Page08

    Private ThreeDListDA As New LGMDdataDataSetTableAdapters.ThreeDListTableAdapter
    Private Livestock03DA As New LGMDdataDataSetTableAdapters.Livestock03TableAdapter
    Private firstNo As Integer?
    Private secondNo As Integer?
    Private thirdNo As Integer?

    Private Sub ctrlWard03Page08_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ThreeDListDA.Fill(Me.LGMDdataDataSet.ThreeDList)
        Me.Livestock03DA.Fill(Me.LGMDdataDataSet.Livestock03)
        Me.Livestock03iTableAdapter.Fill(Me.LGMDdataDataSet.Livestock03i, g_RecordID)
        Me.Livestock03iTableAdapter.FillNgombe(Me.LgmDdataDataSet1.Livestock03i, g_RecordID)
        Me.Livestock03iTableAdapter.FillKondoo(Me.LgmDdataDataSet2.Livestock03i, g_RecordID)
        Me.Livestock03iTableAdapter.FillMbuzi(Me.LgmDdataDataSet3.Livestock03i, g_RecordID)
        Me.Livestock03iTableAdapter.FillMifugoMingine(Me.LgmDdataDataSet4.Livestock03i, g_RecordID)
        Me.Livestock03iTableAdapter.FillNdege(Me.LgmDdataDataSet5.Livestock03i, g_RecordID)

        If Me.LGMDdataDataSet.Livestock03i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.ThreeDList.Select("ListItemType='Livestock03'")
                Me.Livestock03DA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.Livestock03iTableAdapter.Fill(Me.LGMDdataDataSet.Livestock03i, g_RecordID)
            Me.Livestock03iTableAdapter.FillNgombe(Me.LgmDdataDataSet1.Livestock03i, g_RecordID)
            Me.Livestock03iTableAdapter.FillKondoo(Me.LgmDdataDataSet2.Livestock03i, g_RecordID)
            Me.Livestock03iTableAdapter.FillMbuzi(Me.LgmDdataDataSet3.Livestock03i, g_RecordID)
            Me.Livestock03iTableAdapter.FillMifugoMingine(Me.LgmDdataDataSet4.Livestock03i, g_RecordID)
            Me.Livestock03iTableAdapter.FillNdege(Me.LgmDdataDataSet5.Livestock03i, g_RecordID)
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

            Me.Livestock03iTableAdapter.Update(Me.LgmDdataDataSet1.Livestock03i)
            Me.Livestock03iTableAdapter.Update(Me.LgmDdataDataSet2.Livestock03i)
            Me.Livestock03iTableAdapter.Update(Me.LgmDdataDataSet3.Livestock03i)
            Me.Livestock03iTableAdapter.Update(Me.LgmDdataDataSet4.Livestock03i)
            Me.Livestock03iTableAdapter.Update(Me.LgmDdataDataSet5.Livestock03i)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView4_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView4.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView5_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView5.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView6_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView6.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView7_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView7.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
        Me.DataGridView1.Rows(6).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView1.Rows(6).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView1.Rows(6).Cells(5).ReadOnly = True
        Me.DataGridView1.Rows(6).Cells(6).ReadOnly = True
    End Sub

    Private Sub DataGridView6_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles DataGridView6.Paint
        Me.DataGridView6.Rows(2).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(2).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(3).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(3).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(4).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(4).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(5).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(5).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(6).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(6).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(7).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(7).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView6.Rows(2).Cells(5).ReadOnly = True
        Me.DataGridView6.Rows(2).Cells(6).ReadOnly = True
        Me.DataGridView6.Rows(3).Cells(5).ReadOnly = True
        Me.DataGridView6.Rows(3).Cells(6).ReadOnly = True
        Me.DataGridView6.Rows(4).Cells(5).ReadOnly = True
        Me.DataGridView6.Rows(4).Cells(6).ReadOnly = True
        Me.DataGridView6.Rows(5).Cells(5).ReadOnly = True
        Me.DataGridView6.Rows(5).Cells(6).ReadOnly = True
        Me.DataGridView6.Rows(6).Cells(5).ReadOnly = True
        Me.DataGridView6.Rows(6).Cells(6).ReadOnly = True
        Me.DataGridView6.Rows(7).Cells(5).ReadOnly = True
        Me.DataGridView6.Rows(7).Cells(6).ReadOnly = True
    End Sub

    Private Sub DataGridView7_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles DataGridView7.Paint
        Me.DataGridView7.Rows(1).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView7.Rows(1).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView7.Rows(2).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView7.Rows(2).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView7.Rows(3).Cells(5).Style.BackColor = Color.Gray
        Me.DataGridView7.Rows(3).Cells(6).Style.BackColor = Color.Gray
        Me.DataGridView7.Rows(1).Cells(5).ReadOnly = True
        Me.DataGridView7.Rows(1).Cells(6).ReadOnly = True
        Me.DataGridView7.Rows(2).Cells(5).ReadOnly = True
        Me.DataGridView7.Rows(2).Cells(6).ReadOnly = True
        Me.DataGridView7.Rows(3).Cells(5).ReadOnly = True
        Me.DataGridView7.Rows(3).Cells(6).ReadOnly = True
    End Sub

    Private Sub DataGridView1_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                thirdNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            Else
                firstNo = row.Cells(4).Value
                secondNo = row.Cells(5).Value
                thirdNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            End If
        Next
    End Sub

    Private Sub DataGridView4_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView4.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            Else
                firstNo = row.Cells(4).Value
                secondNo = row.Cells(5).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub DataGridView5_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView5.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView5.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                thirdNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            Else
                firstNo = row.Cells(4).Value
                secondNo = row.Cells(5).Value
                thirdNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            End If
        Next
    End Sub

    Private Sub DataGridView6_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView6.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView6.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                thirdNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            Else
                firstNo = row.Cells(4).Value
                secondNo = row.Cells(5).Value
                thirdNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            End If
        Next
    End Sub

    Private Sub DataGridView7_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView7.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView7.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    thirdNo = 0
                Else
                    thirdNo = row.Cells(6).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                thirdNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(4).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(5).Value
                End If
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            Else
                firstNo = row.Cells(4).Value
                secondNo = row.Cells(5).Value
                thirdNo = row.Cells(6).Value
                row.Cells(7).Value = AutomateSummation(firstNo, secondNo, thirdNo)
            End If
        Next
    End Sub
End Class
