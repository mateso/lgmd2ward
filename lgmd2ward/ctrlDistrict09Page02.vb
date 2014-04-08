Public Class ctrlDistrict09Page02

    Private Sub ctrlDistrict09Page02_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.AppUspAnnuallyIntegratedFillMachinesTableAdapter.Fill(Me.AnnuallyIntegratedDataSet.appUspAnnuallyIntegratedFillMachines, g_FormSerialNumberIA)
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
