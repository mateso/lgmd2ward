Public Class ctrlWard02Page04

    Dim FigureIDCriteria As String = "FigureID in (201,202) and BreakdownTypeID1 in ('MAI','PDD','SGH','BMT','FMT','WHE','BLY','CSV','SWP','IPT','YAM','CYM','SCT','TBC','CFF','TEA','PYR','COC','RUB','WAT','SUG', 'JUT','SIS','CSH','SFL','SMS','GRN','PLO','CCN','SYB','COS','JTR','CWP','PGP','GBG','GNP','CPL','BBN','BEN')"
    Private areaControlled As Double?
    Private numberOfHouseholdInvolved As Integer?
    Private plantedAreaMasika As Double?
    Private plantedAreaKiangazi As Double?
    Private productionAreaMasika As Double?
    Private productionAreaKiangazi As Double?
    Private prdkt1 As Double?
    Private prdkt2 As Double?

    Private Sub ctrlWard02Page04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspQuarterlyLookupNameOfPestsDiseaseTableAdapter.Fill(Me.QuarterlyDataSet.appUspQuarterlyLookupNameOfPestsDisease)

        Me.AppUspLookupCropsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupCrops)
        Me.PlantHealth02TableAdapter.Fill(Me.LGMDdataDataSet.PlantHealth02, g_RecordID)
        Me.Irrigation02TableAdapter.Fill(Me.LGMDdataDataSet.Irrigation02, g_RecordID)

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub PlantHealthDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PlantHealthDataGridView.RowEnter
        If Me.PlantHealthDataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.PlantHealthDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.PlantHealthDataGridView.Rows(e.RowIndex).Cells(7).Value = g_RecordID
        End If
        
    End Sub

    Private Sub IrrigationDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles IrrigationDataGridView.RowEnter
        If Me.IrrigationDataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.IrrigationDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.IrrigationDataGridView.Rows(e.RowIndex).Cells(8).Value = g_RecordID
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
                For Each row As DataGridViewRow In Me.PlantHealthDataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        areaControlled = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                        numberOfHouseholdInvolved = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        Me.PlantHealth02TableAdapter.appUspQuarterlyInsertPlantHealth(row.Cells(0).Value, _
                                                                                      row.Cells(1).Value.ToString, _
                                                                                      row.Cells(2).Value.ToString, _
                                                                                      row.Cells(3).Value.ToString, _
                                                                                      areaControlled, _
                                                                                      numberOfHouseholdInvolved, _
                                                                                      row.Cells(6).Value.ToString, _
                                                                                      row.Cells(7).Value)
                    End If

                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In IrrigationDataGridView.Rows
                    If row.IsNewRow Then
                    Else
                        plantedAreaMasika = CheckIfIsNullOrEmptyDGVCell(row.Cells(2))
                        plantedAreaKiangazi = CheckIfIsNullOrEmptyDGVCell(row.Cells(3))
                        productionAreaMasika = CheckIfIsNullOrEmptyDGVCell(row.Cells(4))
                        productionAreaKiangazi = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        Me.Irrigation02TableAdapter.appUspQuarterlyInsertIrrigation(row.Cells(0).Value, _
                                                                                    row.Cells(1).Value.ToString, _
                                                                                    plantedAreaMasika, _
                                                                                    plantedAreaKiangazi, _
                                                                                    productionAreaMasika, _
                                                                                    productionAreaKiangazi, _
                                                                                    row.Cells(8).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub PlantHealthDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles PlantHealthDataGridView.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.PlantHealthDataGridView.Rows
                Me.PlantHealth02TableAdapter.appUspQuarterlyDeletePlantHealth(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub IrrigationDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles IrrigationDataGridView.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.IrrigationDataGridView.Rows
                Me.Irrigation02TableAdapter.appUspQuarterlyDeleteIrrigation(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PlantHealthDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles PlantHealthDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub IrrigationDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles IrrigationDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub IrrigationDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles IrrigationDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.IrrigationDataGridView.Rows
            If row.IsNewRow Then
            Else
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(2))) Then
                    plantedAreaMasika = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                        productionAreaMasika = 0
                    Else
                        productionAreaMasika = row.Cells(4).Value
                    End If
                    row.Cells(6).Value = AutomateProduct(plantedAreaMasika, productionAreaMasika)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(4))) Then
                    productionAreaMasika = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(2))) Then
                        plantedAreaMasika = 0
                    Else
                        plantedAreaMasika = row.Cells(2).Value
                    End If
                    row.Cells(6).Value = AutomateProduct(plantedAreaMasika, productionAreaMasika)
                Else
                    plantedAreaMasika = row.Cells(2).Value
                    productionAreaMasika = row.Cells(4).Value
                    row.Cells(6).Value = AutomateProduct(plantedAreaMasika, productionAreaMasika)
                End If


                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(3))) Then
                    plantedAreaKiangazi = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                        productionAreaKiangazi = 0
                    Else
                        productionAreaKiangazi = row.Cells(5).Value
                    End If
                    row.Cells(7).Value = AutomateProduct(plantedAreaKiangazi, productionAreaKiangazi)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(5))) Then
                    productionAreaKiangazi = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(3))) Then
                        plantedAreaKiangazi = 0
                    Else
                        plantedAreaKiangazi = row.Cells(3).Value
                    End If
                    row.Cells(7).Value = AutomateProduct(plantedAreaKiangazi, productionAreaKiangazi)
                Else
                    plantedAreaKiangazi = row.Cells(3).Value
                    productionAreaKiangazi = row.Cells(5).Value
                    row.Cells(7).Value = AutomateProduct(plantedAreaKiangazi, productionAreaKiangazi)
                End If
            End If
        Next
    End Sub

    Private Sub PlantHealthDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles PlantHealthDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub IrrigationDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles IrrigationDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
