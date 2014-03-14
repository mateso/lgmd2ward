Public Class ctrlWard03Page07

    Dim AnnuallyDS As New AnnuallyDataDataSet
    Dim AnnuallyDA As New AnnuallyDataDataSetTableAdapters.appUspAnnualLookupAinaYaMbeguBoraOthersTableAdapter
    Dim SeedListDA As New LGMDdataDataSetTableAdapters.SeedGroupTableAdapter
    Dim ImprovedSeedDA As New LGMDdataDataSetTableAdapters.ImprovedSeeds03TableAdapter

    Private Sub ctrlWard03Page07_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AnnuallyDA.Fill(Me.AnnuallyDS.appUspAnnualLookupAinaYaMbeguBoraOthers)

        Me.AppUspAnnualLookupAinaYaMbeguBoraMaizeTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraMaize)
        Me.AppUspAnnualLookupAinaYaMbeguBoraMpungaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraMpunga)
        Me.AppUspAnnualLookupAinaYaMbeguBoraMaharageTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraMaharage)
        Me.AppUspAnnualLookupAinaYaMbeguBoraMtamaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraMtama)
        Me.AppUspAnnualLookupAinaYaMbeguBoraNganoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraNgano)
        Me.AppUspAnnualLookupAinaYaMbeguBoraAlizetiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraAlizeti)
        'Me.AppUspAnnualLookupAinaYaMbeguBoraOthersTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualLookupAinaYaMbeguBoraOthers)

        Me.SeedListDA.Fill(Me.LGMDdataDataSet.SeedGroup)
        Me.ImprovedSeedDA.Fill(Me.LGMDdataDataSet.ImprovedSeeds03)
        Me.AppUspAnnualFillImprovedSeedsMahindiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMahindi, g_RecordID)
        Me.AppUspAnnualFillImprovedSeedsMpungaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMpunga, g_RecordID)
        Me.AppUspAnnualFillImprovedSeedsMaharageTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMaharage, g_RecordID)
        Me.AppUspAnnualFillImprovedSeedsMtamaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMtama, g_RecordID)
        Me.AppUspAnnualFillImprovedSeedsNganoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsNgano, g_RecordID)
        Me.AppUspAnnualFillImprovedSeedsAlizetiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsAlizeti, g_RecordID)
        Me.AppUspAnnualFillImprovedSeedsOthersTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsOthers, g_RecordID)

        If Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMahindi.Rows.Count = 0 Then

            For I As Integer = 1 To 5
                For Each row As DataRow In Me.LGMDdataDataSet.SeedGroup.Rows
                    Me.ImprovedSeedDA.Insert(Guid.NewGuid, row.Item(0).ToString, g_RecordID, g_FormSerialNumber)
                Next
            Next
            Me.AppUspAnnualFillImprovedSeedsMahindiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMahindi, g_RecordID)
            Me.AppUspAnnualFillImprovedSeedsMpungaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMpunga, g_RecordID)
            Me.AppUspAnnualFillImprovedSeedsMaharageTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMaharage, g_RecordID)
            Me.AppUspAnnualFillImprovedSeedsMtamaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMtama, g_RecordID)
            Me.AppUspAnnualFillImprovedSeedsNganoTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsNgano, g_RecordID)
            Me.AppUspAnnualFillImprovedSeedsAlizetiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsAlizeti, g_RecordID)
            Me.AppUspAnnualFillImprovedSeedsOthersTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsOthers, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading

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
            Me.AppUspAnnualFillImprovedSeedsMahindiTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMahindi)
            Me.AppUspAnnualFillImprovedSeedsMpungaTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMpunga)
            Me.AppUspAnnualFillImprovedSeedsMaharageTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMaharage)
            Me.AppUspAnnualFillImprovedSeedsMtamaTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsMtama)
            Me.AppUspAnnualFillImprovedSeedsNganoTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsNgano)
            Me.AppUspAnnualFillImprovedSeedsAlizetiTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsAlizeti)
            Me.AppUspAnnualFillImprovedSeedsOthersTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillImprovedSeedsOthers)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMahindiDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsMahindiDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMpungaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsMpungaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMaharageDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsMaharageDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMtamaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsMtamaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsNganoDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsNganoDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsAlizetiDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsAlizetiDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsOthersDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillImprovedSeedsOthersDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    'Private Sub AppUspAnnualFillImprovedSeedsOthersDataGridView_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualFillImprovedSeedsOthersDataGridView.CellValueChanged
    '    If (e.ColumnIndex = 4 And e.RowIndex >= 0) Then

    '        Dim selectedSeed As String = AppUspAnnualFillImprovedSeedsOthersDataGridView.Rows(e.RowIndex).Cells(4).Value.ToString()
    '        Dim dgvCell As DataGridViewComboBoxCell
    '        If TypeOf AppUspAnnualFillImprovedSeedsOthersDataGridView.Rows(e.RowIndex).Cells(6) Is DataGridViewComboBoxCell Then
    '            dgvCell = DirectCast(AppUspAnnualFillImprovedSeedsOthersDataGridView.Rows(e.RowIndex).Cells(6), DataGridViewComboBoxCell)
    '            AppUspAnnualFillImprovedSeedsOthersDataGridView.Rows(e.RowIndex).Cells(6).Value = Nothing
    '            dgvCell.DataSource = Me.AnnuallyDA.GetDataByOthers(selectedSeed)
    '        Else
    '            dgvCell = New DataGridViewComboBoxCell
    '            dgvCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
    '            dgvCell.FlatStyle = FlatStyle.Flat
    '            dgvCell.DisplayMember = "LookupEn"
    '            dgvCell.ValueMember = "LookupEn"

    '            AppUspAnnualFillImprovedSeedsOthersDataGridView.Rows(e.RowIndex).Cells(6).Value = Nothing

    '            dgvCell.DataSource = Me.AnnuallyDA.GetDataByOthers(selectedSeed)

    '            AppUspAnnualFillImprovedSeedsOthersDataGridView.Rows(e.RowIndex).Cells(6) = dgvCell
    '        End If

    '    End If
    'End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMahindiDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspAnnualFillImprovedSeedsMahindiDataGridView.CellPainting
        Call DGVCellPainting(sender, e, AppUspAnnualFillImprovedSeedsMahindiDataGridView, 4)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMpungaDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspAnnualFillImprovedSeedsMpungaDataGridView.CellPainting
        Call DGVCellPainting(sender, e, AppUspAnnualFillImprovedSeedsMpungaDataGridView, 4)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMaharageDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspAnnualFillImprovedSeedsMaharageDataGridView.CellPainting
        Call DGVCellPainting(sender, e, AppUspAnnualFillImprovedSeedsMaharageDataGridView, 4)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMtamaDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspAnnualFillImprovedSeedsMtamaDataGridView.CellPainting
        Call DGVCellPainting(sender, e, AppUspAnnualFillImprovedSeedsMtamaDataGridView, 4)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsNganoDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspAnnualFillImprovedSeedsNganoDataGridView.CellPainting
        Call DGVCellPainting(sender, e, AppUspAnnualFillImprovedSeedsNganoDataGridView, 4)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsAlizetiDataGridView_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles AppUspAnnualFillImprovedSeedsAlizetiDataGridView.CellPainting
        Call DGVCellPainting(sender, e, AppUspAnnualFillImprovedSeedsAlizetiDataGridView, 4)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMahindiDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles AppUspAnnualFillImprovedSeedsMahindiDataGridView.Paint
        Call DGVCellPaintingReadOnly(sender, e, Me.AppUspAnnualFillImprovedSeedsMahindiDataGridView)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMpungaDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles AppUspAnnualFillImprovedSeedsMpungaDataGridView.Paint
        Call DGVCellPaintingReadOnly(sender, e, Me.AppUspAnnualFillImprovedSeedsMpungaDataGridView)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMaharageDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles AppUspAnnualFillImprovedSeedsMaharageDataGridView.Paint
        Call DGVCellPaintingReadOnly(sender, e, Me.AppUspAnnualFillImprovedSeedsMaharageDataGridView)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMtamaDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles AppUspAnnualFillImprovedSeedsMtamaDataGridView.Paint
        Call DGVCellPaintingReadOnly(sender, e, Me.AppUspAnnualFillImprovedSeedsMtamaDataGridView)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsNganoDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles AppUspAnnualFillImprovedSeedsNganoDataGridView.Paint
        Call DGVCellPaintingReadOnly(sender, e, Me.AppUspAnnualFillImprovedSeedsNganoDataGridView)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsAlizetiDataGridView_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles AppUspAnnualFillImprovedSeedsAlizetiDataGridView.Paint
        Call DGVCellPaintingReadOnly(sender, e, Me.AppUspAnnualFillImprovedSeedsAlizetiDataGridView)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMahindiDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsMahindiDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMpungaDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsMpungaDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMaharageDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsMaharageDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsMtamaDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsMtamaDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsNganoDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsNganoDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsAlizetiDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsAlizetiDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillImprovedSeedsOthersDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillImprovedSeedsOthersDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
