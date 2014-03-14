Imports System.Data.SqlClient

Public Class ctrlWard01Page01

    Private ds As DataSet
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private cmdBldr As SqlCommandBuilder
    Private dt As DataTable
    Private numberOfDays As Integer?
    Private amountOfRain As Integer?

    Private Sub ctrlWard01Page01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Method to populate weather control
        Me.RecordInfoTableAdapter.Fill(Me.LGMDdataDataSet.RecordInfo, g_RecordID)
        'Me.WeatherCondition01TableAdapter.Fill(Me.LGMDdataDataSet.WeatherCondition01, g_RecordID)
        Call FillWeatherCondition()

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading

        Me.txtWardName.Text = g_AreaHeading.Replace("Ward: ", "")
        Me.txtMonth.Text = g_PeriodHeading.Split(" ")(0)
        'Me.cmoYear.Text = g_PeriodHeading.Split(" ")(1)
        Me.txtFinancialYear.Text = DatePart(DateInterval.Year, StartOfFinancialYear(g_PeriodFrom)).ToString + "/" + DatePart(DateInterval.Year, EndOfFinancialYear(g_PeriodTo)).ToString

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm(Me.txtOfficerName.Text, DateTimePicker1.Text)
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)
            Call SaveForm(Me.txtOfficerName.Text, DateTimePicker1.Text)

            'Call InsertUpdateWeatherCondition()

            Me.WeatherCondition01TableAdapter.appUspMonthlyInsertWeatherCondition(Guid.NewGuid, _
                                                                                  numberOfDays, _
                                                                                  amountOfRain, _
                                                                                  cmoRemarks.Text.ToString, _
                                                                                  txtDisaster.Text.ToString, _
                                                                                  txtActivities.Text.ToString, _
                                                                                  g_RecordID)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNumberOfDays_TextChanged(sender As Object, e As EventArgs) Handles txtNumberOfDays.TextChanged
        numberOfDays = CheckIfIsNullOrEmptyTextbox(txtNumberOfDays)
        'If Not String.IsNullOrEmpty(txtNumberOfDays.Text) Then
        '    numberOfDays = txtNumberOfDays.Text
        'Else
        '    numberOfDays = Nothing
        'End If
    End Sub

    Private Sub txtAmountOfRain_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountOfRain.TextChanged
        amountOfRain = CheckIfIsNullOrEmptyTextbox(txtAmountOfRain)
        'If Not String.IsNullOrEmpty(txtAmountOfRain.Text) Then
        '    amountOfRain = txtAmountOfRain.Text
        'Else
        '    amountOfRain = Nothing
        'End If
    End Sub

    Private Sub txtNumberOfDays_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumberOfDays.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub txtAmountOfRain_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmountOfRain.KeyPress
        If Asc(e.KeyChar) <> 46 AndAlso Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Public Sub FillWeatherCondition()

        ds = New DataSet()
        cmd = New SqlCommand()
        da = New SqlDataAdapter()

        With cmd
            .Connection = conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "appUspMonthlyFillWeatherCondition"
            .Parameters.AddWithValue("@MonthlyRecordID", g_RecordID)
        End With

        da.SelectCommand = cmd
        da.Fill(ds, "WeatherCondition01")
        dt = ds.Tables("WeatherCondition01")

        If dt.Rows.Count > 0 Then
            Me.txtNumberOfDays.Text = dt.Rows(0)("NumberOfDays").ToString
            Me.txtAmountOfRain.Text = dt.Rows(0)("AmountOfRain").ToString
            Me.cmoRemarks.Text = dt.Rows(0)("Explanation").ToString
            Me.txtDisaster.Text = dt.Rows(0)("Disaster").ToString
            Me.txtActivities.Text = dt.Rows(0)("Activity").ToString
        Else
        End If

    End Sub

    'Public Sub InsertUpdateWeatherCondition()
    '    Dim cmdInsertUpdateWeatherCondition As New SqlClient.SqlCommand

    '    Dim prmWeatherConditionID As New Data.SqlClient.SqlParameter("@WeatherCondition", Guid.NewGuid)
    '    Dim prmNumberOfDays As New SqlClient.SqlParameter("@NumberOfDays", txtNumberOfDays.Text)
    '    Dim prmAmountOfRain As New SqlClient.SqlParameter("@AmountOfRain", txtAmountOfRain.Text)
    '    Dim prmRemarks As New SqlClient.SqlParameter("@Explanation", cmoRemarks.SelectedValue)
    '    Dim prmDisaster As New SqlClient.SqlParameter("@Disaster", txtDisaster.Text)
    '    Dim prmActivities As New SqlClient.SqlParameter("@Activity", txtActivities.Text)
    '    Dim prmRecordID As New SqlClient.SqlParameter("@MonthlyRecordID", g_RecordID)

    '    With cmdInsertUpdateWeatherCondition
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "appUspMonthlyInsertWeatherCondition"
    '        .Parameters.Add(prmWeatherConditionID)
    '        .Parameters.Add(prmNumberOfDays)
    '        .Parameters.Add(prmAmountOfRain)
    '        .Parameters.Add(prmRemarks)
    '        .Parameters.Add(prmDisaster)
    '        .Parameters.Add(prmActivities)
    '        .Parameters.Add(prmRecordID)
    '    End With

    '    Me.WeatherConditionDA.UpdateCommand = cmdInsertUpdateWeatherCondition
    '    Me.WeatherConditionDA.Update(Me.LGMD2iDS, "WeatherCondition01")

    'End Sub

    Private Sub ctrlWard01Page01_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating
        Call ValidatingUserControl(sender, e)
    End Sub

End Class
