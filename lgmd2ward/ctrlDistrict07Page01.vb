Public Class ctrlDistrict07Page01

    Private PlantHealthDA As New MonthlyAggregatedDataSetTableAdapters.DistrictChemicalControl01TableAdapter
    
    Private Sub ctrlDistrict07Page01_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.PlantHealthDA.Fill(Me.MonthlyAggregatedDataSet.DistrictChemicalControl01)

    End Sub
End Class
