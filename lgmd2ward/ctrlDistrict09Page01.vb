Public Class ctrlDistrict09Page01
    
    Private Sub ctrlDistrict09Page01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.AppUspAnnuallyIntegratedFillDistrictInfoTableAdapter.Fill(Me.AnnuallyIntegratedDataSet.appUspAnnuallyIntegratedFillDistrictInfo, g_FormSerialNumberIA)
            Me.AppUspAnnuallyIntegratedFillFoodSituationTableAdapter.Fill(Me.AnnuallyIntegratedDataSet.appUspAnnuallyIntegratedFillFoodSituation, g_FormSerialNumberIA)
            Me.AppUspAnnuallyIntegratedFillIrrigationSchemeTableAdapter.Fill(Me.AnnuallyIntegratedDataSet.appUspAnnuallyIntegratedFillIrrigationScheme, g_FormSerialNumberIA)
            Me.AppUspAnnuallyIntegratedFillIrrigationTableAdapter.Fill(Me.AnnuallyIntegratedDataSet.appUspAnnuallyIntegratedFillIrrigation, g_FormSerialNumberIA)
        Catch ex As System.Exception
            'System.Windows.Forms.MessageBox.Show(ex.Message)
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
