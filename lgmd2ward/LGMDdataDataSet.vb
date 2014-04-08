Partial Class LGMDdataDataSet

    Partial Class Telecommunication03DataTable

        Private Sub Telecommunication03DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TelecomCompIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class TVAndRadioStation03DataTable

        Private Sub TVAndRadioStation03DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.StationIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class appUspDistrictAnnualFillLivestockInfrastructureFourthPartDataTable

        Private Sub appUspDistrictAnnualFillLivestockInfrastructureFourthPartDataTable_appUspDistrictAnnualFillLivestockInfrastructureFourthPartRowChanging(sender As System.Object, e As appUspDistrictAnnualFillLivestockInfrastructureFourthPartRowChangeEvent) Handles Me.appUspDistrictAnnualFillLivestockInfrastructureFourthPartRowChanging

        End Sub

    End Class

    Partial Class AreasDataTable

        Private Sub AreasDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.BlockColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace LGMDdataDataSetTableAdapters
    
    Partial Class ContractFarming03iTableAdapter

    End Class

    Partial Class ProdLand02iTableAdapter

    End Class

    Partial Class appUspAnnualFillTelecomTableAdapter

    End Class

    Partial Class Fertilizer03TableAdapter

    End Class

    Partial Public Class TargetiTableAdapter
    End Class
End Namespace

Namespace LGMDdataDataSetTableAdapters

    Partial Public Class FarmersFieldSchool03iTableAdapter
    End Class
End Namespace
