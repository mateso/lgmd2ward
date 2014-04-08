Public Class ctrlDistrict08Page01

    Private Sub ctrlDistrict08Page01_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.AppUspQuarterlyIntegratedFillTargetCerealTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillTargetCereal, "%AFRTZA001004002%Apr11%Jun11%")
            Me.AppUspQuarterlyIntegratedFillTargetRootsTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillTargetRoots, "%AFRTZA001004002%Apr11%Jun11%")
            Me.AppUspQuarterlyIntegratedFillTargetIndustrialTableAdapter.Fill(Me.QuarterlyIntegratedDataSet.appUspQuarterlyIntegratedFillTargetIndustrial, "%AFRTZA001004002%Apr11%Jun11%")
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
