Public Class ctrlWard02Page05

    Dim FigureIDCriteria As String = "FigureID in (201,202) and BreakdownTypeID1 in ('MAI','PDD','SGH','BMT','FMT','WHE','BLY','CSV','SWP','IPT','YAM','CYM','SCT','TBC','CFF','TEA','PYR','COC','RUB','WAT','SUG', 'JUT','SIS','CSH','SFL','SMS','GRN','PLO','CCN','SYB','COS','JTR','CWP','PGP','GBG','GNP','CPL','BBN','BEN')"
    Dim QuarterlyLookupDS As New QuarterlyDataSet
    Dim QuarterlyLookupDA As New QuarterlyDataSetTableAdapters.QuarterlyLookupTableTableAdapter
    Dim ActivityListDA As New LGMDdataDataSetTableAdapters.ActivityListTableAdapter
    Dim ProdLandDA As New LGMDdataDataSetTableAdapters.ProdLand02TableAdapter
    Private areaDestroyed As Double?
    Private areaControlled As Double?
    Private prodAreaTrekta As Double?
    Private prodAreaWanyamakazi As Double?
    Private prodAreaJembe As Double?
    Private prodAreaBilaKulima As Double?

    Private Sub ctrlWard02Page05_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.QuarterlyLookupDA.Fill(Me.QuarterlyLookupDS.QuarterlyLookupTable)

        Me.AppUspQuarterLookUpTypeOfErosionTableAdapter.Fill(Me.LookupTableDataDataSet.appUspQuarterLookUpTypeOfErosion)
        'Me.AppUspQuarterLookupErosionControlMeasuresTableAdapter.Fill(Me.LookupTableDataDataSet.appUspQuarterLookupErosionControlMeasures)
        Me.SoilErosion02TableAdapter.Fill(Me.LGMDdataDataSet.SoilErosion02, g_RecordID)

        Me.ActivityListDA.Fill(Me.LGMDdataDataSet.ActivityList)
        Me.ProdLandDA.Fill(Me.LGMDdataDataSet.ProdLand02)
        Me.ProdLand02iTableAdapter.Fill(Me.LGMDdataDataSet.ProdLand02i, g_RecordID)
        Me.ProdLand02iTableAdapter.FillVuli(Me.LgmDdataDataSet1.ProdLand02i, g_RecordID)
        Me.ProdLand02iTableAdapter.FillMasika(Me.LgmDdataDataSet2.ProdLand02i, g_RecordID)

        If Me.LGMDdataDataSet.ProdLand02i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.ActivityList.Rows
                Me.ProdLandDA.Insert(Guid.NewGuid, row.Item(0).ToString, g_RecordID, g_FormSerialNumber)
            Next
            Me.ActivityListDA.Fill(Me.LGMDdataDataSet.ActivityList)
            Me.ProdLandDA.Fill(Me.LGMDdataDataSet.ProdLand02)
            Me.ProdLand02iTableAdapter.Fill(Me.LGMDdataDataSet.ProdLand02i, g_RecordID)
            Me.ProdLand02iTableAdapter.FillVuli(Me.LgmDdataDataSet1.ProdLand02i, g_RecordID)
            Me.ProdLand02iTableAdapter.FillMasika(Me.LgmDdataDataSet2.ProdLand02i, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub SoilErosion02DataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SoilErosion02DataGridView.RowEnter
        If Me.SoilErosion02DataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.SoilErosion02DataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.SoilErosion02DataGridView.Rows(e.RowIndex).Cells(7).Value = g_RecordID
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
                For Each row As DataGridViewRow In Me.SoilErosion02DataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        areaDestroyed = CheckIfIsNullOrEmptyDGVCell(row.Cells(3))
                        areaControlled = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        Me.SoilErosion02TableAdapter.appUspQuarterlyInsertSoilErosion(row.Cells(0).Value, _
                                                                                      row.Cells(1).Value.ToString, _
                                                                                      row.Cells(2).Value.ToString, _
                                                                                      areaDestroyed, _
                                                                                      row.Cells(4).Value.ToString, _
                                                                                      areaControlled, _
                                                                                      row.Cells(6).Value.ToString, _
                                                                                      row.Cells(7).Value)
                    End If
                Next

            Catch ex As Exception
            End Try

            Me.ProdLand02iTableAdapter.Update(Me.LgmDdataDataSet1.ProdLand02i)
            Me.ProdLand02iTableAdapter.Update(Me.LgmDdataDataSet2.ProdLand02i)
            
            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub SoilErosion02DataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles SoilErosion02DataGridView.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.SoilErosion02DataGridView.Rows
                Me.SoilErosion02TableAdapter.appUspQuarterlyDeleteSoilErosion(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SoilErosion02DataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles SoilErosion02DataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub ProdLand02iDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ProdLand02iDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub ProdLand02iDataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ProdLand02iDataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub ProdLand02iDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProdLand02iDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.ProdLand02iDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                prodAreaTrekta = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    prodAreaWanyamakazi = 0
                Else
                    prodAreaWanyamakazi = row.Cells(6).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    prodAreaJembe = 0
                Else
                    prodAreaJembe = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    prodAreaBilaKulima = 0
                Else
                    prodAreaBilaKulima = row.Cells(8).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                prodAreaWanyamakazi = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    prodAreaTrekta = 0
                Else
                    prodAreaTrekta = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    prodAreaJembe = 0
                Else
                    prodAreaJembe = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    prodAreaBilaKulima = 0
                Else
                    prodAreaBilaKulima = row.Cells(8).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                prodAreaJembe = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    prodAreaTrekta = 0
                Else
                    prodAreaTrekta = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    prodAreaWanyamakazi = 0
                Else
                    prodAreaWanyamakazi = row.Cells(6).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    prodAreaBilaKulima = 0
                Else
                    prodAreaBilaKulima = row.Cells(8).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                prodAreaBilaKulima = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    prodAreaTrekta = 0
                Else
                    prodAreaTrekta = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    prodAreaWanyamakazi = 0
                Else
                    prodAreaWanyamakazi = row.Cells(6).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    prodAreaJembe = 0
                Else
                    prodAreaJembe = row.Cells(7).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            Else
                prodAreaTrekta = row.Cells(5).Value
                prodAreaWanyamakazi = row.Cells(6).Value
                prodAreaJembe = row.Cells(7).Value
                prodAreaBilaKulima = row.Cells(8).Value
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            End If
        Next
    End Sub

    Private Sub ProdLand02iDataGridView1_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProdLand02iDataGridView1.CellValidated
        For Each row As DataGridViewRow In Me.ProdLand02iDataGridView1.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                prodAreaTrekta = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    prodAreaWanyamakazi = 0
                Else
                    prodAreaWanyamakazi = row.Cells(6).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    prodAreaJembe = 0
                Else
                    prodAreaJembe = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    prodAreaBilaKulima = 0
                Else
                    prodAreaBilaKulima = row.Cells(8).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                prodAreaWanyamakazi = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    prodAreaTrekta = 0
                Else
                    prodAreaTrekta = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    prodAreaJembe = 0
                Else
                    prodAreaJembe = row.Cells(7).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    prodAreaBilaKulima = 0
                Else
                    prodAreaBilaKulima = row.Cells(8).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                prodAreaJembe = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    prodAreaTrekta = 0
                Else
                    prodAreaTrekta = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    prodAreaWanyamakazi = 0
                Else
                    prodAreaWanyamakazi = row.Cells(6).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                    prodAreaBilaKulima = 0
                Else
                    prodAreaBilaKulima = row.Cells(8).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(8))) Then
                prodAreaBilaKulima = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    prodAreaTrekta = 0
                Else
                    prodAreaTrekta = row.Cells(5).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    prodAreaWanyamakazi = 0
                Else
                    prodAreaWanyamakazi = row.Cells(6).Value
                End If
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    prodAreaJembe = 0
                Else
                    prodAreaJembe = row.Cells(7).Value
                End If
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            Else
                prodAreaTrekta = row.Cells(5).Value
                prodAreaWanyamakazi = row.Cells(6).Value
                prodAreaJembe = row.Cells(7).Value
                prodAreaBilaKulima = row.Cells(8).Value
                row.Cells(9).Value = AutomateSummation(prodAreaTrekta, prodAreaWanyamakazi, prodAreaJembe, prodAreaBilaKulima)
            End If
        Next
    End Sub

    Private Sub SoilErosion02DataGridView_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SoilErosion02DataGridView.CellValueChanged
        If (e.ColumnIndex = 1 And e.RowIndex >= 0) Then

            Dim selectedSoilErosion As String = SoilErosion02DataGridView.Rows(e.RowIndex).Cells(1).Value.ToString()
            Dim dgvCell As DataGridViewComboBoxCell
            If TypeOf SoilErosion02DataGridView.Rows(e.RowIndex).Cells(4) Is DataGridViewComboBoxCell Then
                dgvCell = DirectCast(SoilErosion02DataGridView.Rows(e.RowIndex).Cells(4), DataGridViewComboBoxCell)
                SoilErosion02DataGridView.Rows(e.RowIndex).Cells(4).Value = Nothing
                dgvCell.DataSource = Me.QuarterlyLookupDA.GetDataErosion(selectedSoilErosion)
            Else
                dgvCell = New DataGridViewComboBoxCell
                dgvCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                dgvCell.FlatStyle = FlatStyle.Flat
                dgvCell.DisplayMember = "LookupEn"
                dgvCell.ValueMember = "LookupEn"

                SoilErosion02DataGridView.Rows(e.RowIndex).Cells(4).Value = Nothing

                dgvCell.DataSource = Me.QuarterlyLookupDA.GetDataErosion(selectedSoilErosion)

                SoilErosion02DataGridView.Rows(e.RowIndex).Cells(4) = dgvCell
            End If

        End If
    End Sub

    Private Sub SoilErosion02DataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles SoilErosion02DataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub ProdLand02iDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ProdLand02iDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub ProdLand02iDataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ProdLand02iDataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
