Public Class ctrlWard02Page02

    Private FigureIDCriteria As String = "FigureID in (201,202) and BreakdownTypeID1 in ('MAI','PDD','SGH','BMT','FMT','WHE','BLY','CSV','SWP','IPT','YAM','CYM','SCT','TBC','CFF','TEA','PYR','COC','RUB','WAT','SUG', 'JUT','SIS','CSH','SFL','SMS','GRN','PLO','CCN','SYB','COS','JTR','CWP','PGP','GBG','GNP','CPL','BBN','BEN')"
    Private ThreeDListDA As New LGMDdataDataSetTableAdapters.ThreeDListTableAdapter
    Private CoopGroup02DA As New LGMDdataDataSetTableAdapters.CoopGroup02TableAdapter
    Private firstNo As Integer?
    Private secondNo As Integer?

    Private Sub ctrlFarmersGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CoopSaccos02TableAdapter.Fill(Me.LGMDdataDataSet.CoopSaccos02, g_RecordID)

        Me.ThreeDListDA.Fill(Me.LGMDdataDataSet.ThreeDList)
        Me.CoopGroup02iTableAdapter.Fill(Me.LGMDdataDataSet.CoopGroup02i, g_RecordID)
        Me.CoopGroup02iTableAdapter.FillCrop(Me.LgmDdataDataSet1.CoopGroup02i, g_RecordID)
        Me.CoopGroup02iTableAdapter.FillLivestock(Me.LgmDdataDataSet2.CoopGroup02i, g_RecordID)
        Me.CoopGroup02iTableAdapter.FillFisheries(Me.LgmDdataDataSet3.CoopGroup02i, g_RecordID)
        If Me.LGMDdataDataSet.CoopGroup02i.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.ThreeDList.Select("ListItemType = 'CoopGroup02'")
                CoopGroup02DA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.CoopGroup02iTableAdapter.Fill(Me.LGMDdataDataSet.CoopGroup02i, g_RecordID)
            Me.CoopGroup02iTableAdapter.FillCrop(Me.LgmDdataDataSet1.CoopGroup02i, g_RecordID)
            Me.CoopGroup02iTableAdapter.FillLivestock(Me.LgmDdataDataSet2.CoopGroup02i, g_RecordID)
            Me.CoopGroup02iTableAdapter.FillFisheries(Me.LgmDdataDataSet3.CoopGroup02i, g_RecordID)
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

            CoopSaccos02TableAdapter.appUspQuarterlyInsertCoopSaccos(Guid.NewGuid, _
                                                                     Val(txtNumberOfSaccoss.Text), _
                                                                     Val(txtMembersMale.Text), _
                                                                     Val(txtMembersFemale.Text), _
                                                                     Val(txtMembersGroups.Text), _
                                                                     Val(txtLoanCrops.Text), _
                                                                     Val(txtLoanLivestock.Text), _
                                                                     Val(txtLoanFishing.Text), _
                                                                     Val(txtLoanMarketing.Text), _
                                                                     g_RecordID)

            Me.CoopGroup02iTableAdapter.Update(Me.LgmDdataDataSet1.CoopGroup02i)
            Me.CoopGroup02iTableAdapter.Update(Me.LgmDdataDataSet2.CoopGroup02i)
            Me.CoopGroup02iTableAdapter.Update(Me.LgmDdataDataSet3.CoopGroup02i)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNumberOfSaccoss_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfSaccoss.TextChanged
        If String.IsNullOrEmpty(txtNumberOfSaccoss.Text) Then
            txtNumberOfSaccoss.Text = 0
        End If
    End Sub

    Private Sub txtMembersMale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMembersMale.TextChanged
        If String.IsNullOrEmpty(txtMembersMale.Text) Then
            txtMembersMale.Text = 0
        End If
        txtMembersTotal.Text = Val(txtMembersMale.Text) + Val(txtMembersFemale.Text) + Val(txtMembersGroups.Text)
    End Sub

    Private Sub txtMembersFemale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMembersFemale.TextChanged
        If String.IsNullOrEmpty(txtMembersFemale.Text) Then
            txtMembersFemale.Text = 0
        End If
        txtMembersTotal.Text = Val(txtMembersMale.Text) + Val(txtMembersFemale.Text) + Val(txtMembersGroups.Text)
    End Sub

    Private Sub txtMembersGroups_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMembersGroups.TextChanged
        If String.IsNullOrEmpty(txtMembersGroups.Text) Then
            txtMembersGroups.Text = 0
        End If
        txtMembersTotal.Text = Val(txtMembersMale.Text) + Val(txtMembersFemale.Text) + Val(txtMembersGroups.Text)
    End Sub

    Private Sub txtLoanCrops_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoanCrops.TextChanged
        If String.IsNullOrEmpty(txtLoanCrops.Text) Then
            txtLoanCrops.Text = 0
        End If
        txtLoanTotal.Text = Val(txtLoanCrops.Text) + Val(txtLoanLivestock.Text) + Val(txtLoanFishing.Text) + Val(txtLoanMarketing.Text)
    End Sub

    Private Sub txtLoanLivestock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoanLivestock.TextChanged
        If String.IsNullOrEmpty(txtLoanLivestock.Text) Then
            txtLoanLivestock.Text = 0
        End If
        txtLoanTotal.Text = Val(txtLoanCrops.Text) + Val(txtLoanLivestock.Text) + Val(txtLoanFishing.Text) + Val(txtLoanMarketing.Text)
    End Sub

    Private Sub txtLoanFishing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoanFishing.TextChanged
        If String.IsNullOrEmpty(txtLoanFishing.Text) Then
            txtLoanFishing.Text = 0
        End If
        txtLoanTotal.Text = Val(txtLoanCrops.Text) + Val(txtLoanLivestock.Text) + Val(txtLoanFishing.Text) + Val(txtLoanMarketing.Text)
    End Sub

    Private Sub txtLoanMarketing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoanMarketing.TextChanged
        If String.IsNullOrEmpty(txtLoanFishing.Text) Then
            txtLoanMarketing.Text = 0
        End If
        txtLoanTotal.Text = Val(txtLoanCrops.Text) + Val(txtLoanLivestock.Text) + Val(txtLoanFishing.Text) + Val(txtLoanMarketing.Text)
    End Sub

    Private Sub CoopOtherDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles CoopOtherDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub txtNumberOfSaccoss_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfSaccoss.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub txtMembersMale_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMembersMale.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub txtMembersGroups_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMembersGroups.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub txtLoanCrops_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoanCrops.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub txtLoanLivestock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoanLivestock.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub txtLoanFishing_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoanFishing.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub txtLoanMarketing_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoanMarketing.KeyPress
        Call TextBoxKeyPressEventError(sender, e)
    End Sub

    Private Sub CoopOtherDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CoopOtherDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.CoopOtherDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub DataGridView1_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub DataGridView2_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValidated
        For Each row As DataGridViewRow In Me.DataGridView2.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateSummation(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub CoopOtherDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles CoopOtherDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
