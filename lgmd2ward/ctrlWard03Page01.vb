Public Class ctrlWard03Page01

    Dim Group2DDA As New LGMDdataDataSetTableAdapters.Group2DTableAdapter
    Dim ContractFarmingDA As New LGMDdataDataSetTableAdapters.ContractFarming03TableAdapter
    Dim SchemeListDA As New LGMDdataDataSetTableAdapters.SchemeGroupTableAdapter
    Dim IrrigationSchemeDA As New LGMDdataDataSetTableAdapters.IrrigationScheme03TableAdapter
    Private firstNo As Integer?
    Private secondNo As Integer?

    Private Sub ctrlWard03Page01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If g_form_mode = "Add" Then
            Call SaveForm(Me.txtOfficerName.Text, DateTimePicker1.Text)
            g_form_mode = "Edit"
        End If

        Me.BasicInformation03TableAdapter.Fill(Me.LGMDdataDataSet.BasicInformation03, g_RecordID)
        Me.RecordInfoTableAdapter.Fill(Me.LGMDdataDataSet.RecordInfo, g_RecordID)

        Me.Group2DDA.Fill(Me.LGMDdataDataSet.Group2D)
        Me.ContractFarmingDA.Fill(Me.LGMDdataDataSet.ContractFarming03)
        Me.ContractFarming03iTableAdapter.Fill(Me.LGMDdataDataSet.ContractFarming03i, g_RecordID)

        If Me.LGMDdataDataSet.ContractFarming03i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.Group2D.Rows
                ContractFarmingDA.Insert(Guid.NewGuid, row.Item(0).ToString, g_RecordID, g_FormSerialNumber)
            Next
            Me.Group2DDA.Fill(Me.LGMDdataDataSet.Group2D)
            Me.ContractFarmingDA.Fill(Me.LGMDdataDataSet.ContractFarming03)
            Me.ContractFarming03iTableAdapter.Fill(Me.LGMDdataDataSet.ContractFarming03i, g_RecordID)
        End If

        Me.AppUspLookupSeasonIrrigatedTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupSeasonIrrigated)
        Me.AppUspLookupStatusOfSchemeTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupStatusOfScheme)
        Me.SchemeListDA.Fill(Me.LGMDdataDataSet.SchemeGroup)
        Me.IrrigationSchemeDA.Fill(Me.LGMDdataDataSet.IrrigationScheme03)
        Me.IrrigationScheme03iTableAdapter.Fill(Me.LGMDdataDataSet.IrrigationScheme03i, g_RecordID)
        Me.IrrigationScheme03iTableAdapter.FillImproved(Me.LgmDdataDataSet1.IrrigationScheme03i, g_RecordID)
        Me.IrrigationScheme03iTableAdapter.FillNatural(Me.LgmDdataDataSet2.IrrigationScheme03i, g_RecordID)

        If Me.LGMDdataDataSet.IrrigationScheme03i.Rows.Count = 0 Then

            For i = 1 To 4
                For Each row As DataRow In Me.LGMDdataDataSet.SchemeGroup.Rows
                    Me.IrrigationSchemeDA.Insert(Guid.NewGuid, row.Item(0).ToString, g_RecordID, g_FormSerialNumber)
                Next
            Next

            Me.SchemeListDA.Fill(Me.LGMDdataDataSet.SchemeGroup)
            Me.IrrigationSchemeDA.Fill(Me.LGMDdataDataSet.IrrigationScheme03)
            Me.IrrigationScheme03iTableAdapter.Fill(Me.LGMDdataDataSet.IrrigationScheme03i, g_RecordID)
            Me.IrrigationScheme03iTableAdapter.FillImproved(Me.LgmDdataDataSet1.IrrigationScheme03i, g_RecordID)
            Me.IrrigationScheme03iTableAdapter.FillNatural(Me.LgmDdataDataSet2.IrrigationScheme03i, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading.Replace("Ward: ", "")

        Me.txtYear.Text = g_PeriodHeading
        Me.txtWardName.Text = g_AreaHeading.Replace("Ward: ", "")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            Call SaveForm(Me.txtOfficerName.Text, Me.DateTimePicker1.Text)
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Me.BasicInformation03TableAdapter.appUspAnnualInsertBasicInformation(Guid.NewGuid, _
                                                                                 Val(txtMaleHeadedHousehold.Text), _
                                                                                 Val(txtFemaleHeadedHousehold.Text), _
                                                                                 Val(txtNumberOfHouseholdEngagingInAgriculture.Text), _
                                                                                 Val(txtMalePopulation.Text), _
                                                                                 Val(txtFemalePopulation.Text), _
                                                                                 Val(txtPopulationEngagingInAgriculture.Text), _
                                                                                 g_RecordID)

            Me.ContractFarming03iTableAdapter.Update(Me.LGMDdataDataSet.ContractFarming03i)
            Me.IrrigationScheme03iTableAdapter.Update(Me.LgmDdataDataSet1.IrrigationScheme03i)
            Me.IrrigationScheme03iTableAdapter.Update(Me.LgmDdataDataSet2.IrrigationScheme03i)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtMaleHeadedHousehold_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaleHeadedHousehold.TextChanged
        'If IsNothing(CheckIfIsNullOrEmptyTextbox(Me.txtMaleHeadedHousehold)) Then
        '    firstNo = 0
        '    If IsNothing(CheckIfIsNullOrEmptyTextbox(Me.txtFemaleHeadedHousehold)) Then
        '        secondNo = 0
        '    Else
        '        secondNo = Val(Me.txtFemaleHeadedHousehold.Text)
        '    End If
        '    txtTotalNumberOfHousehold.Text = AutomateSummation(firstNo, secondNo).ToString
        'Else
        '    firstNo = Val(Me.txtMaleHeadedHousehold.Text)
        '    secondNo = Val(Me.txtFemaleHeadedHousehold.Text)
        '    txtTotalNumberOfHousehold.Text = AutomateSummation(firstNo, secondNo).ToString
        'End If

        If String.IsNullOrEmpty(txtMaleHeadedHousehold.Text) Then
            txtMaleHeadedHousehold.Text = 0
        End If
        txtTotalNumberOfHousehold.Text = Val(txtMaleHeadedHousehold.Text) + Val(txtFemaleHeadedHousehold.Text)
    End Sub

    Private Sub txtFemaleHeadedHousehold_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFemaleHeadedHousehold.TextChanged
        'If IsNothing(CheckIfIsNullOrEmptyTextbox(Me.txtFemaleHeadedHousehold)) Then
        '    secondNo = 0
        '    If IsNothing(CheckIfIsNullOrEmptyTextbox(Me.txtMaleHeadedHousehold)) Then
        '        firstNo = 0
        '    Else
        '        firstNo = Val(Me.txtMaleHeadedHousehold.Text)
        '    End If
        '    txtTotalNumberOfHousehold.Text = AutomateSummation(firstNo, secondNo).ToString
        'Else
        '    firstNo = Val(Me.txtMaleHeadedHousehold.Text)
        '    secondNo = Val(Me.txtFemaleHeadedHousehold.Text)
        '    txtTotalNumberOfHousehold.Text = AutomateSummation(firstNo, secondNo).ToString
        'End If

        If String.IsNullOrEmpty(txtFemaleHeadedHousehold.Text) Then
            txtFemaleHeadedHousehold.Text = 0
        End If
        txtTotalNumberOfHousehold.Text = Val(txtMaleHeadedHousehold.Text) + Val(txtFemaleHeadedHousehold.Text)
    End Sub

    Private Sub txtMalePopulation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMalePopulation.TextChanged
        If String.IsNullOrEmpty(txtMalePopulation.Text) Then
            txtMalePopulation.Text = 0
        End If
        txtTotalPopulation.Text = Val(txtMalePopulation.Text) + Val(txtFemalePopulation.Text)
    End Sub

    Private Sub txtFemalePopulation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFemalePopulation.TextChanged
        If String.IsNullOrEmpty(txtFemalePopulation.Text) Then
            txtFemalePopulation.Text = 0
        End If
        txtTotalPopulation.Text = Val(txtMalePopulation.Text) + Val(txtFemalePopulation.Text)
    End Sub

    Private Sub txtMaleHeadedHousehold_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaleHeadedHousehold.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtFemaleHeadedHousehold_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFemaleHeadedHousehold.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtNumberOfHouseholdEngagingInAgriculture_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfHouseholdEngagingInAgriculture.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtMalePopulation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMalePopulation.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtFemalePopulation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFemalePopulation.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtPopulationEngagingInAgriculture_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPopulationEngagingInAgriculture.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
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

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
