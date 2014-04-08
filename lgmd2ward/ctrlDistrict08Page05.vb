Public Class ctrlDistrict08Page05

    Private Sub ctrlDistrict08Page05_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AppUspQuarterlyIntegratedFillPlantHealthTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillPlantHealth, g_FormSerialNumberIQ)
        Me.AppUspQuarterlyIntegratedFillLivestockMovementTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillLivestockMovement, g_FormSerialNumberIQ)
        Me.AppUspQuarterlyIntegratedFillProductsMovementTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillProductsMovement, g_FormSerialNumberIQ)

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
