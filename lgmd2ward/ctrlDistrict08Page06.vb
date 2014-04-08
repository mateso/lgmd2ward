Public Class ctrlDistrict08Page06

    Private Sub ctrlDistrict08Page06_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.AppUspQuarterlyIntegratedFillMeatInspectionTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillMeatInspection, g_FormSerialNumberIQ)
            Me.RptUspQuarterlyLivestockSlaughteredTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.rptUspQuarterlyLivestockSlaughtered, "%AFRTZA001004002%Apr11%Jun11%")
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

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
