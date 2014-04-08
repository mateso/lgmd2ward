Public Class ctrlDistrict08Page08

    Private Sub ctrlDistrict08Page08_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AppUspQuarterlyIntegratedFillAnimalsFeedsTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillAnimalsFeeds, g_FormSerialNumberIQ)
        Me.AppUspQuarterlyIntegratedFillAcaricidesTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillAcaricides, g_FormSerialNumberIQ)
        Me.AppUspQuarterlyIntegratedFillVaccinesTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillVaccines, g_FormSerialNumberIQ)
        Me.AppUspQuarterlyIntegratedFillTreatmentTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillTreatment, g_FormSerialNumberIQ)

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

End Class
