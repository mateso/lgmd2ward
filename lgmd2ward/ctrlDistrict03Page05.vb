Public Class ctrlDistrict03Page05

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim ProductsProcessingDA As New LGMDdataDataSetTableAdapters.ProductsProcessing05TableAdapter

    Private Sub ctrlDistrict03Page05_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspLookupUnits1TableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits1)

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictAnnualFillProductsProcessingMilkTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMilk, g_RecordID)
        Me.AppUspDistrictAnnualFillProductsProcessingMeatTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMeat, g_RecordID)
        Me.AppUspDistrictAnnualFillProductsProcessingHideTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingHide, g_RecordID)
        Me.AppUspDistrictAnnualFillProductsProcessingAnimalTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingAnimal, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMilk.Rows.Count = 0 Then

            For i = 1 To 5
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='ProductsProcessing05'")
                    Me.ProductsProcessingDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspDistrictAnnualFillProductsProcessingMilkTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMilk, g_RecordID)
                Me.AppUspDistrictAnnualFillProductsProcessingMeatTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMeat, g_RecordID)
                Me.AppUspDistrictAnnualFillProductsProcessingHideTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingHide, g_RecordID)
                Me.AppUspDistrictAnnualFillProductsProcessingAnimalTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingAnimal, g_RecordID)
            Next
        End If
        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")
        PopulateHeaderControls(Me)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)

            Me.AppUspDistrictAnnualFillProductsProcessingMilkTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMilk)
            Me.AppUspDistrictAnnualFillProductsProcessingMeatTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingMeat)
            Me.AppUspDistrictAnnualFillProductsProcessingHideTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingHide)
            Me.AppUspDistrictAnnualFillProductsProcessingAnimalTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillProductsProcessingAnimal)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingMilkDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingMilkDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingMeatDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingMeatDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingHideDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingHideDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingAnimalDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingAnimalDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingMilkDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingMilkDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingMeatDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingMeatDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingHideDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingHideDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillProductsProcessingAnimalDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillProductsProcessingAnimalDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
