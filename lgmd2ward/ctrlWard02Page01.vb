Imports System.Data.SqlClient

Public Class ctrlWard02Page01

    Dim FigureIDCriteria As String = "FigureID in (201,202) and BreakdownTypeID1 in ('MAI','PDD','SGH','BMT','FMT','WHE','BLY','CSV','SWP','IPT','YAM','CYM','SCT','TBC','CFF','TEA','PYR','COC','RUB','WAT','SUG', 'JUT','SIS','CSH','SFL','SMS','GRN','PLO','CCN','SYB','COS','JTR','CWP','PGP','GBG','GNP','CPL','BBN','BEN')"
    Private QuarterlyLookupDA As New LookupTableDataDataSetTableAdapters.appUspQuarterlyLookupVillageFoodSituationTableAdapter
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private dt As DataTable
    Private numberNoFood As Integer?
    Private numberLessFood As Integer?
    Private numberEnoughFood As Integer?
    Private numberExcessFood As Integer?

    Private Sub ctrlWard02Page01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.QuarterlyLookupDA.Fill(Me.LookupTableDataDataSet.appUspQuarterlyLookupVillageFoodSituation)

        Me.RecordInfoTableAdapter.Fill(Me.LGMDdataDataSet.RecordInfo, g_RecordID)

        Call FillFoodCondition()

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading.Replace("Ward: ", "")
        Me.txtWardName.Text = g_AreaHeading.Replace("Ward: ", "")


        If g_PeriodHeading.Contains("July - September") Then
            Me.txtQuarter.Text = 1
            Me.txtMonthStart.Text = "Jul"
            Me.txtMonthEnd.Text = "Sep"
            Me.txtYear.Text = g_PeriodHeading.Replace("July - September", "") & "/" & Val(g_PeriodHeading.Replace("July - September", "")) + 1
        End If

        If g_PeriodHeading.Contains("October - December") Then
            Me.txtQuarter.Text = 2
            Me.txtMonthStart.Text = "Oct"
            Me.txtMonthEnd.Text = "Dec"
            Me.txtYear.Text = g_PeriodHeading.Replace("October - December", "") & "/" & Val(g_PeriodHeading.Replace("October - December", "")) + 1
        End If

        If g_PeriodHeading.Contains("January - March") Then
            Me.txtQuarter.Text = 3
            Me.txtMonthStart.Text = "Jan"
            Me.txtMonthEnd.Text = "Mar"
            Me.txtYear.Text = Val(g_PeriodHeading.Replace("January - March", "")) - 1 & "/" & g_PeriodHeading.Replace("January - March", "")

        End If

        If g_PeriodHeading.Contains("April - June") Then
            Me.txtQuarter.Text = 4
            Me.txtMonthStart.Text = "Apr"
            Me.txtMonthEnd.Text = "Jun"
            Me.txtYear.Text = Val(g_PeriodHeading.Replace("April - June", "")) - 1 & "/" & g_PeriodHeading.Replace("April - June", "")
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If g_form_mode = "Add" Then
            Call SaveForm(Me.txtOfficerName.Text, Me.DateTimePicker1.Text)
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            Call SaveForm(Me.txtOfficerName.Text, Me.DateTimePicker1.Text)
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Me.FoodCondition02TableAdapter.appUspQuarterlyInsertFoodCondition(Guid.NewGuid, _
                                                                              cmoFoodStatus.SelectedValue, _
                                                                              txtRemarks.Text.ToString, _
                                                                              numberNoFood, _
                                                                              numberLessFood, _
                                                                              numberEnoughFood, _
                                                                              numberExcessFood, _
                                                                              g_RecordID)


            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNoFood_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoFood.TextChanged
        numberNoFood = CheckIfIsNullOrEmptyTextbox(txtNoFood)
        'If Not String.IsNullOrEmpty(txtNoFood.Text.ToString.Trim) Then
        '    numberNoFood = txtNoFood.Text
        'Else
        '    numberNoFood = Nothing
        'End If
    End Sub

    Private Sub txtLessFood_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLessFood.TextChanged
        numberLessFood = CheckIfIsNullOrEmptyTextbox(txtLessFood)
        'If Not String.IsNullOrEmpty(txtLessFood.Text.ToString.Trim) Then
        '    numberLessFood = txtLessFood.Text
        'Else
        '    numberLessFood = Nothing
        'End If
    End Sub

    Private Sub txtEnoughFood_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnoughFood.TextChanged
        numberEnoughFood = CheckIfIsNullOrEmptyTextbox(txtEnoughFood)
        'If Not String.IsNullOrEmpty(txtEnoughFood.Text.ToString.Trim) Then
        '    numberEnoughFood = txtEnoughFood.Text
        'Else
        '    numberEnoughFood = Nothing
        'End If
    End Sub

    Private Sub txtExcessFood_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExcessFood.TextChanged
        numberExcessFood = CheckIfIsNullOrEmptyTextbox(txtExcessFood)
        'If Not String.IsNullOrEmpty(txtExcessFood.Text.ToString.Trim) Then
        '    numberExcessFood = txtExcessFood.Text
        'Else
        '    numberExcessFood = Nothing
        'End If
    End Sub

    Private Sub txtNoFood_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoFood.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtLessFood_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLessFood.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtEnoughFood_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEnoughFood.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtExcessFood_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExcessFood.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub FillFoodCondition()

        ds = New DataSet
        da = New SqlDataAdapter
        cmd = New SqlCommand
        dt = New DataTable

        With cmd
            .Connection = conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "appUspQuarterlyFillFoodCondition"
            .Parameters.AddWithValue("@RecordID", g_RecordID)
        End With

        'fill in insert, update, and delete commands
        'Dim cmdBldr As New SqlCommandBuilder(Me.FoodConditionDA)

        Me.da.SelectCommand = cmd
        Me.da.Fill(Me.ds, "FoodCondition02")
        Me.dt = Me.ds.Tables("FoodCondition02")

        If Me.dt.Rows.Count > 0 Then
            Me.cmoFoodStatus.SelectedValue = Me.dt.Rows(0)("FoodStatusID").ToString
            Me.txtRemarks.Text = Me.dt.Rows(0)("Remarks").ToString
            Me.txtNoFood.Text = Me.dt.Rows(0)("FamilyNoFood").ToString
            Me.txtLessFood.Text = Me.dt.Rows(0)("FamilyLessFood").ToString
            Me.txtEnoughFood.Text = Me.dt.Rows(0)("FamilyEnoughFood").ToString
            Me.txtExcessFood.Text = Me.dt.Rows(0)("FamilyExcessFood").ToString
        Else
        End If

    End Sub
End Class
