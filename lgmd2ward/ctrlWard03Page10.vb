Imports System.Data.SqlClient

Public Class ctrlWard03Page10

    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private ThreeDListDA As New LGMDdataDataSetTableAdapters.ThreeDListTableAdapter
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private dt As New DataTable
    Private MediaListDA As New LGMDdataDataSetTableAdapters.MediaListTableAdapter
    Private TVRadioDA As New LGMDdataDataSetTableAdapters.TVAndRadioStation03TableAdapter
    Private TelecomCompListDA As New LGMDdataDataSetTableAdapters.TelecomCompaListTableAdapter
    Private TelecommunicationDA As New LGMDdataDataSetTableAdapters.Telecommunication03TableAdapter
    Private numberOfFarms As Integer?
    Private area As Double?
    Private seedProduction As Double?
    Private amountOfHayBales As Double?
    Private amountOfHayBales1 As Double?
    Private areaOfFarmsGazedInSitu As Double?
    Private numberOfVillagesCoveredTV As Integer?
    Private numberOfVillagesCoveredRadio As Integer?
    Private frequencyPerWeek As Integer?
    Private numberOfVillagesCovered As Integer?

    Private Sub ctrlWard03Page10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.ThreeDListDA.Fill(Me.LGMDdataDataSet.ThreeDList)

        Call FillImprovedPasture()

        Me.CropResidue03TableAdapter.Fill(Me.LGMDdataDataSet.CropResidue03, g_RecordID)

        Me.TVRadioDA.Fill(Me.LGMDdataDataSet.TVAndRadioStation03)
        Me.AppUspAnnualFillTVTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillTV, g_RecordID)
        Me.AppUspAnnualFillRadioTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillRadio, g_RecordID)

        Try
            If Me.LGMDdataDataSet.appUspAnnualFillTV.Rows.Count = 0 Then
                For Each row As DataRow In Me.LGMDdataDataSet.ThreeDList.Select("ListItemType='TVAndRadioStation03' AND ListItemStatus='0'")
                    Me.TVRadioDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspAnnualFillTVTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillTV, g_RecordID)
                Me.AppUspAnnualFillRadioTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillRadio, g_RecordID)
            End If
        Catch ex As Exception
        End Try

        Me.AiredPrograms03TableAdapter.Fill(Me.LGMDdataDataSet.AiredPrograms03, g_RecordID)

        Me.TelecommunicationDA.Fill(Me.LGMDdataDataSet.Telecommunication03)
        Me.AppUspAnnualFillTelecomTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillTelecom, g_RecordID)

        Try
            If Me.LGMDdataDataSet.appUspAnnualFillTelecom.Rows.Count = 0 Then
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='Telecommunication03' AND ListItemStatus=0")
                    TelecommunicationDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspAnnualFillTelecomTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillTelecom, g_RecordID)
            End If
        Catch ex As Exception
        End Try

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub DataGridView4_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.RowEnter
        If Me.DataGridView4.Rows(e.RowIndex).IsNewRow Then
            Me.DataGridView4.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView4.Rows(e.RowIndex).Cells(5).Value = g_RecordID
        End If

    End Sub

    Private Sub AppUspAnnualFillTVDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualFillTVDataGridView.RowEnter
        If Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).Cells(0).Value = 1
            Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).Cells(2).Value = Guid.NewGuid
            Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).Cells(3).Value = 1
            Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).Cells(5).Value = 1
            Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).Cells(6).Value = Guid.NewGuid
            Me.AppUspAnnualFillTVDataGridView.Rows(e.RowIndex).Cells(9).Value = g_RecordID
        End If
    End Sub

    Private Sub AppUspAnnualFillRadioDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualFillRadioDataGridView.RowEnter
        If Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).Cells(0).Value = 2
            Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).Cells(2).Value = Guid.NewGuid
            Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).Cells(3).Value = 2
            Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).Cells(5).Value = 1
            Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).Cells(6).Value = Guid.NewGuid
            Me.AppUspAnnualFillRadioDataGridView.Rows(e.RowIndex).Cells(9).Value = g_RecordID
        End If
    End Sub

    Private Sub DataGridView3_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.RowEnter
        If Me.DataGridView3.Rows(e.RowIndex).IsNewRow Then
            Me.DataGridView3.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView3.Rows(e.RowIndex).Cells(5).Value = g_RecordID
        End If
    End Sub

    Private Sub AppUspAnnualFillTelecomDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualFillTelecomDataGridView.RowEnter
        If Me.AppUspAnnualFillTelecomDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.AppUspAnnualFillTelecomDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.AppUspAnnualFillTelecomDataGridView.Rows(e.RowIndex).Cells(2).Value = 1
            Me.AppUspAnnualFillTelecomDataGridView.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid
            Me.AppUspAnnualFillTelecomDataGridView.Rows(e.RowIndex).Cells(6).Value = g_RecordID
        End If
    End Sub

    Private Sub DataGridView4_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView4.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DataGridView4.Rows
                Me.CropResidue03TableAdapter.appUspAnnualDeleteCropResidue(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub AppUspAnnualFillTVDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspAnnualFillTVDataGridView.UserDeletingRow
        If Me.AppUspAnnualFillTVDataGridView.CurrentRow.Index < 3 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspAnnualFillTVDataGridView.SelectedRows
                    Me.TVRadioDA.appUspAnnualDeleteTVAndRadio(row.Cells(7).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub AppUspAnnualFillRadioDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspAnnualFillRadioDataGridView.UserDeletingRow
        If Me.AppUspAnnualFillRadioDataGridView.CurrentRow.Index < 3 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspAnnualFillRadioDataGridView.SelectedRows
                    Me.TVRadioDA.appUspAnnualDeleteTVAndRadio(row.Cells(7).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub DataGridView3_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView3.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DataGridView4.Rows
                Me.AiredPrograms03TableAdapter.appUspAnnualDeleteAiredPrograms(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub AppUspAnnualFillTelecomDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspAnnualFillTelecomDataGridView.UserDeletingRow
        If Me.AppUspAnnualFillTelecomDataGridView.CurrentRow.Index < 6 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspAnnualFillTelecomDataGridView.SelectedRows
                    Me.TelecommunicationDA.appUspAnnualDeleteTelecom(row.Cells(4).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
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

            Try
                Me.ImprovedPasture03TableAdapter.appUspAnnualInsertImprovedPasture(Guid.NewGuid, _
                                                                                   numberOfFarms, _
                                                                                   area, _
                                                                                   seedProduction, _
                                                                                   amountOfHayBales, _
                                                                                   txtRemarks.Text, _
                                                                                   g_RecordID)
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView4.Rows
                    If row.IsNewRow Then
                    Else
                        amountOfHayBales1 = CheckIfIsNullOrEmptyDGVCell(row.Cells(2))
                        areaOfFarmsGazedInSitu = CheckIfIsNullOrEmptyDGVCell(row.Cells(3))
                        Me.CropResidue03TableAdapter.appUspAnnualInsertCropResidue(row.Cells(0).Value, _
                                                                                   row.Cells(1).Value.ToString, _
                                                                                   amountOfHayBales1, _
                                                                                   areaOfFarmsGazedInSitu, _
                                                                                   row.Cells(4).Value.ToString, _
                                                                                   row.Cells(5).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualFillTVDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        numberOfVillagesCoveredTV = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        Me.TVRadioDA.appUspAnnualUpdateTVAndRadio(row.Cells(2).Value, _
                                                                  Val(row.Cells(3).Value.ToString()), _
                                                                  row.Cells(4).Value.ToString, _
                                                                  Val(row.Cells(5).Value.ToString()), _
                                                                  row.Cells(6).Value, _
                                                                  numberOfVillagesCoveredTV, _
                                                                  row.Cells(9).Value)

                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualFillRadioDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        numberOfVillagesCoveredRadio = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        Me.TVRadioDA.appUspAnnualUpdateTVAndRadio(row.Cells(2).Value, _
                                                                  Val(row.Cells(3).Value.ToString()), _
                                                                  row.Cells(4).Value.ToString, _
                                                                  Val(row.Cells(5).Value.ToString()), _
                                                                  row.Cells(6).Value, _
                                                                  numberOfVillagesCoveredRadio, _
                                                                  row.Cells(9).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.DataGridView3.Rows
                    If row.IsNewRow Then
                    Else
                        frequencyPerWeek = CheckIfIsNullOrEmptyDGVCell(row.Cells(3))
                        Me.AiredPrograms03TableAdapter.appUspAnnualInsertAiredPrograms(row.Cells(0).Value, _
                                                                                       row.Cells(1).Value.ToString, _
                                                                                       row.Cells(2).Value.ToString, _
                                                                                       frequencyPerWeek, _
                                                                                       row.Cells(4).Value.ToString, _
                                                                                       row.Cells(5).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualFillTelecomDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        numberOfVillagesCovered = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        Me.TelecommunicationDA.appUspAnnualUpdateTelecom(row.Cells(0).Value, _
                                                                         row.Cells(1).Value.ToString(), _
                                                                         Val(row.Cells(2).Value.ToString()), _
                                                                         row.Cells(3).Value, _
                                                                         numberOfVillagesCovered, _
                                                                         row.Cells(6).Value)

                    End If
                Next
            Catch ex As Exception
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNumberOfFarms_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfFarms.TextChanged
        numberOfFarms = CheckIfIsNullOrEmptyTextbox(txtNumberOfFarms)
    End Sub

    Private Sub txtArea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        area = CheckIfIsNullOrEmptyTextbox(txtArea)
    End Sub

    Private Sub txtSeedProduction_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeedProduction.TextChanged
        seedProduction = CheckIfIsNullOrEmptyTextbox(txtSeedProduction)
    End Sub

    Private Sub txtAmountOfHayBales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountOfHayBales.TextChanged
        amountOfHayBales = CheckIfIsNullOrEmptyTextbox(txtAmountOfHayBales)
    End Sub

    Private Sub txtNumberOfFarms_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberOfFarms.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtArea_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArea.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtSeedProduction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeedProduction.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtAmountOfHayBales_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmountOfHayBales.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub DataGridView4_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView4.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillTVDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillTVDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillRadioDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillRadioDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView3_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillTelecomDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillTelecomDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView4_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView4.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillTVDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillTVDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillRadioDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillRadioDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualFillTelecomDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualFillTelecomDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub FillImprovedPasture()

        ds = New DataSet
        da = New SqlDataAdapter
        cmd = New SqlCommand
        dt = New DataTable

        With cmd
            .Connection = conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "appUspAnnuallyFillImprovedPasture"
            .Parameters.AddWithValue("@AnnualRecordID", g_RecordID)
        End With

        'fill in insert, update, and delete commands
        'Dim cmdBldr As New SqlCommandBuilder(ImprovedPastureDA)

        Me.da.SelectCommand = cmd
        Me.da.Fill(Me.ds, "ImprovedPasture03")
        Me.dt = Me.ds.Tables("ImprovedPasture03")

        If Me.dt.Rows.Count > 0 Then
            Me.txtNumberOfFarms.Text = Me.dt.Rows(0)("NumberOfFarms").ToString
            Me.txtArea.Text = Me.dt.Rows(0)("Area").ToString
            Me.txtSeedProduction.Text = Me.dt.Rows(0)("SeedProduction").ToString
            Me.txtAmountOfHayBales.Text = Me.dt.Rows(0)("AmountOfHayBales").ToString
            Me.txtRemarks.Text = Me.dt.Rows(0)("Remarks").ToString
        Else
        End If
    End Sub
End Class
