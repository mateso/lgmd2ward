Public Class ctrlWard02Page03

    Dim FFSListDA As New LGMDdataDataSetTableAdapters.FFSGroupTableAdapter
    Dim FFS02DA As New LGMDdataDataSetTableAdapters.FarmersFieldSchool02TableAdapter

    Dim FigureIDCriteria As String = "FigureID in (201,202) and BreakdownTypeID1 in ('MAI','PDD','SGH','BMT','FMT','WHE','BLY','CSV','SWP','IPT','YAM','CYM','SCT','TBC','CFF','TEA','PYR','COC','RUB','WAT','SUG', 'JUT','SIS','CSH','SFL','SMS','GRN','PLO','CCN','SYB','COS','JTR','CWP','PGP','GBG','GNP','CPL','BBN','BEN')"

    Private Sub ctrlWard02Page03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FFSListDA.Fill(Me.LGMDdataDataSet.FFSGroup)
        Me.FFS02DA.Fill(Me.LGMDdataDataSet.FarmersFieldSchool02)
        Me.FarmersFieldSchool02iTableAdapter.Fill(Me.LGMDdataDataSet.FarmersFieldSchool02i, g_RecordID)
        Me.FarmersFieldSchool02iTableAdapter.FillMazao(Me.LgmDdataDataSet1.FarmersFieldSchool02i, g_RecordID)
        Me.FarmersFieldSchool02iTableAdapter.FillUfugaji(Me.LgmDdataDataSet2.FarmersFieldSchool02i, g_RecordID)
        Me.FarmersFieldSchool02iTableAdapter.FillUvuvi(Me.LgmDdataDataSet3.FarmersFieldSchool02i, g_RecordID)
        Me.FarmersFieldSchool02iTableAdapter.FillMasoko(Me.LgmDdataDataSet4.FarmersFieldSchool02i, g_RecordID)
        Me.FarmersFieldSchool02iTableAdapter.FillUmwagiliaji(Me.LgmDdataDataSet5.FarmersFieldSchool02i, g_RecordID)

        If Me.LGMDdataDataSet.FarmersFieldSchool02i.Rows.Count = 0 Then

            For i = 1 To 5
                For Each row As DataRow In Me.LGMDdataDataSet.FFSGroup.Rows
                    Me.FFS02DA.Insert(Guid.NewGuid, row.Item(0).ToString, g_RecordID, g_FormSerialNumber)
                Next
            Next

            Me.FarmersFieldSchool02iTableAdapter.Fill(Me.LGMDdataDataSet.FarmersFieldSchool02i, g_RecordID)
            Me.FarmersFieldSchool02iTableAdapter.FillMazao(Me.LgmDdataDataSet1.FarmersFieldSchool02i, g_RecordID)
            Me.FarmersFieldSchool02iTableAdapter.FillUfugaji(Me.LgmDdataDataSet2.FarmersFieldSchool02i, g_RecordID)
            Me.FarmersFieldSchool02iTableAdapter.FillUvuvi(Me.LgmDdataDataSet3.FarmersFieldSchool02i, g_RecordID)
            Me.FarmersFieldSchool02iTableAdapter.FillMasoko(Me.LgmDdataDataSet4.FarmersFieldSchool02i, g_RecordID)
            Me.FarmersFieldSchool02iTableAdapter.FillUmwagiliaji(Me.LgmDdataDataSet5.FarmersFieldSchool02i, g_RecordID)
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
                Me.FarmersFieldSchool02iTableAdapter.Update(Me.LgmDdataDataSet1.FarmersFieldSchool02i)
                Me.FarmersFieldSchool02iTableAdapter.Update(Me.LgmDdataDataSet2.FarmersFieldSchool02i)
                Me.FarmersFieldSchool02iTableAdapter.Update(Me.LgmDdataDataSet3.FarmersFieldSchool02i)
                Me.FarmersFieldSchool02iTableAdapter.Update(Me.LgmDdataDataSet4.FarmersFieldSchool02i)
                Me.FarmersFieldSchool02iTableAdapter.Update(Me.LgmDdataDataSet5.FarmersFieldSchool02i)
            Catch ex As Exception
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView3_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView4_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView4.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView5_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView5.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView4_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView4.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView5_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView5.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
