Public Class ctrlWard03Page04

    Dim LGMDDS As New LGMDdataDataSet
    Dim FFSListDA As New LGMDdataDataSetTableAdapters.FFSGroupTableAdapter
    Dim FFSDA As New LGMDdataDataSetTableAdapters.FarmersFieldSchool03TableAdapter

    Private Sub ctrlWard03Page04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FFSListDA.Fill(Me.LGMDDS.FFSGroup)
        Me.FFSDA.Fill(Me.LGMDDS.FarmersFieldSchool03)
        Me.AppUspAnnualFillFFSMazaoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMazao, g_RecordID)
        Me.AppUspAnnualFillFFSUfugajiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSUfugaji, g_RecordID)
        Me.AppUspAnnualFillFFSUvuviTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSUvuvi, g_RecordID)
        Me.AppUspAnnualFillFFSMasokoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMasoko, g_RecordID)
        Me.AppUspAnnualFillFFSMengineyoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMengineyo, g_RecordID)

        If Me.AnnuallyDataDataSet.appUspAnnualFillFFSMazao.Rows.Count = 0 Then

            For I = 1 To 6
                For Each row As DataRow In Me.LGMDDS.FFSGroup.Rows
                    Me.FFSDA.Insert(Guid.NewGuid, row.Item(0).ToString, g_RecordID, g_FormSerialNumber)
                Next
            Next
            Me.AppUspAnnualFillFFSMazaoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMazao, g_RecordID)
            Me.AppUspAnnualFillFFSUfugajiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSUfugaji, g_RecordID)
            Me.AppUspAnnualFillFFSUvuviTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSUvuvi, g_RecordID)
            Me.AppUspAnnualFillFFSMasokoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMasoko, g_RecordID)
            Me.AppUspAnnualFillFFSMengineyoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMengineyo, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
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

    Private Sub DataGridView5_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView5.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView6_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView6.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            'Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Me.AppUspAnnualFillFFSMazaoTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMazao)
            Me.AppUspAnnualFillFFSUfugajiTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillFFSUfugaji)
            Me.AppUspAnnualFillFFSUvuviTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillFFSUvuvi)
            Me.AppUspAnnualFillFFSMasokoTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMasoko)
            Me.AppUspAnnualFillFFSMengineyoTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillFFSMengineyo)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub appUspAnnualFillProcessingMachineDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        Call DGVChangeEnterKeyBehaviour(sender, e)
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

    Private Sub DataGridView5_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView5.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView6_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView6.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
