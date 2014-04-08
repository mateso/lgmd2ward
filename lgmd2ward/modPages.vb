
Module modPages

    Public Sub FillWithGoTo(ByVal ComboBoxControl As ComboBox, ByVal FormNumber As Long, ByVal SelectedPage As String)
        Dim PageDesc As String
        Dim ExitDesc As String

        Select Case g_language
            Case "Swahili"
                PageDesc = "Kurasa ya "
                ExitDesc = "Funga fomu"
            Case Else
                PageDesc = "Page "
                ExitDesc = "Close form"
        End Select

        Select Case FormNumber
            Case 1
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 2 Part I")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 2 Part II")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 2 Part III")
                ComboBoxControl.Items.Add(PageDesc & "5 Table 3 - 4")
                ComboBoxControl.Items.Add(PageDesc & "6 Table 5 - 6.2")
                ComboBoxControl.Items.Add(PageDesc & "7 Table 7 - 7.3")
                ComboBoxControl.Items.Add(PageDesc & "8 Table 8 - 9")

            Case 2

                ComboBoxControl.Items.Add(PageDesc & "1 Table 1")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 2 - 2.2")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 3")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 4 - 5")
                ComboBoxControl.Items.Add(PageDesc & "5 Table 6 - 7")

            Case 3
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1 - 3.1")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 4 - 4.2")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 4.3 - 4.4")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 5.1")
                ComboBoxControl.Items.Add(PageDesc & "5 Table 6.1")
                ComboBoxControl.Items.Add(PageDesc & "6 Table 6.2")
                ComboBoxControl.Items.Add(PageDesc & "7 Table 6.3")
                ComboBoxControl.Items.Add(PageDesc & "8 Table 7")
                ComboBoxControl.Items.Add(PageDesc & "9 Table 8 - 9")
                ComboBoxControl.Items.Add(PageDesc & "10 Table 10 - 11.2")

            Case 4
                ComboBoxControl.Items.Add(PageDesc & "1 Table 3, 6a")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 7a")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 7b")

            Case 5
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1, 3, 5a")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 5b-5e")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 5e II")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 5h, 8, 9")
                ComboBoxControl.Items.Add(PageDesc & "5 Table 11")
                ComboBoxControl.Items.Add(PageDesc & "6 Table 12")

            Case 6
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1 Part I")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 1 Part II")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 1 Part III")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 1 Part IV")

            Case 7
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1 Part I")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 1 Part II")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 1 Part III")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 1 Part IV")

            Case 8
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1 Part I")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 1 Part II")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 1 Part III")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 1 Part IV")
                ComboBoxControl.Items.Add(PageDesc & "5 Table 2, 3a, 3b")
                ComboBoxControl.Items.Add(PageDesc & "6 Table 4, 5")
                ComboBoxControl.Items.Add(PageDesc & "7 Table 6a, 6b, 6c")
                ComboBoxControl.Items.Add(PageDesc & "8 Table 7a")
                ComboBoxControl.Items.Add(PageDesc & "9 Table 7b")

            Case 9
                ComboBoxControl.Items.Add(PageDesc & "1 Table 1, 2a, 2b")
                ComboBoxControl.Items.Add(PageDesc & "2 Table 3a, 3b, 3c")
                ComboBoxControl.Items.Add(PageDesc & "3 Table 3d, 3e")
                ComboBoxControl.Items.Add(PageDesc & "4 Table 3f, 3g")
                ComboBoxControl.Items.Add(PageDesc & "5 Table 4a, 4b, 4c")
                ComboBoxControl.Items.Add(PageDesc & "6 Table 5a, 5b")
                ComboBoxControl.Items.Add(PageDesc & "7 Table 5c, 5d, 5e")
                ComboBoxControl.Items.Add(PageDesc & "8 Table 5f, 5g, 5h")
                ComboBoxControl.Items.Add(PageDesc & "9 Table 6a, 6b, 7, 8")
                ComboBoxControl.Items.Add(PageDesc & "10 Table 9, 10")
                ComboBoxControl.Items.Add(PageDesc & "11 Table 11, 12")
                ComboBoxControl.Items.Add(PageDesc & "12 Table 13, 14a, 14b")
                ComboBoxControl.Items.Add(PageDesc & "13 Table 15a, 15b, 16")

        End Select

        ComboBoxControl.Items.Add(ExitDesc)

        If ComboBoxControl.Items.Count <> Val(Right(ComboBoxControl.Parent.Name, 1)) + 1 Then
            'Comparing the numnber of controls and the filled selection. It is therefor important to name the controls in the right order
            ComboBoxControl.Text = getPageLabels(FormNumber, PageDesc & Val(Right(ComboBoxControl.Parent.Name, 1)) + 1)
        Else
            'For closing Control
            ComboBoxControl.Text = ExitDesc
        End If

    End Sub

    Public Sub GotoNextPage(ByVal FormNumber As Long, ByVal SelectedOption As String)
        If ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Count > 0 Then LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.RemoveAt(0)

        Dim ctrl As New System.Windows.Forms.UserControl
        Select Case FormNumber
            Case 1
                Select Case getPageLabels(FormNumber, SelectedOption)
                    Case "Kurasa ya 1", "Page 1 Table 1"
                        ctrl = New ctrlWard01Page01
                    Case "Kurasa ya 2", "Page 2 Table 2 Part I"
                        ctrl = New ctrlWard01Page02
                    Case "Kurasa ya 3", "Page 3 Table 2 Part II"
                        ctrl = New ctrlWard01Page03
                    Case "Kurasa ya 4", "Page 4 Table 2 Part III"
                        ctrl = New ctrlWard01Page04
                    Case "Kurasa ya 5", "Page 5 Table 3 - 4"
                        ctrl = New ctrlWard01Page05
                    Case "Kurasa ya 6", "Page 6 Table 5 - 6.2"
                        ctrl = New ctrlWard01Page06
                    Case "Kurasa ya 7", "Page 7 Table 7 - 7.3"
                        ctrl = New ctrlWard01Page07
                    Case "Kurasa ya 8", "Page 8 Table 8 - 9"
                        ctrl = New ctrlWard01Page08
                End Select

            Case 2
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1"
                        ctrl = New ctrlWard02Page01
                    Case "Kurasa ya 2", "Page 2 Table 2 - 2.2"
                        ctrl = New ctrlWard02Page02
                    Case "Kurasa ya 3", "Page 3 Table 3"
                        ctrl = New ctrlWard02Page03
                    Case "Kurasa ya 4", "Page 4 Table 4 - 5"
                        ctrl = New ctrlWard02Page04
                    Case "Kurasa ya 5", "Page 5 Table 6 - 7"
                        ctrl = New ctrlWard02Page05
                End Select

            Case 3
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1 - 3.1"
                        ctrl = New ctrlWard03Page01
                    Case "Kurasa ya 2", "Page 2 Table 4 - 4.2"
                        ctrl = New ctrlWard03Page02
                    Case "Kurasa ya 3", "Page 3 Table 4.3 - 4.4"
                        ctrl = New ctrlWard03Page03
                    Case "Kurasa ya 4", "Page 4 Table 5.1"
                        ctrl = New ctrlWard03Page04
                    Case "Kurasa ya 5", "Page 5 Table 6.1"
                        ctrl = New ctrlWard03Page05
                    Case "Kurasa ya 6", "Page 6 Table 6.2"
                        ctrl = New ctrlWard03Page06
                    Case "Kurasa ya 7", "Page 7 Table 6.3"
                        ctrl = New ctrlWard03Page07
                    Case "Kurasa ya 8", "Page 8 Table 7"
                        ctrl = New ctrlWard03Page08
                    Case "Kurasa ya 9", "Page 9 Table 8 - 9"
                        ctrl = New ctrlWard03Page09
                    Case "Kurasa ya 10", "Page 10 Table 10 - 11.2"
                        ctrl = New ctrlWard03Page10
                End Select

            Case 4
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 3, 6a"
                        ctrl = New ctrlDistrict02Page01
                    Case "Kurasa ya 2", "Page 2 Table 7a"
                        ctrl = New ctrlDistrict02Page02
                    Case "Kurasa ya 3", "Page 3 Table 7b"
                        ctrl = New ctrlDistrict02Page03
                End Select

            Case 5
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1, 3, 5a"
                        ctrl = New ctrlDistrict03Page01
                    Case "Kurasa ya 2", "Page 2 Table 5b-5e"
                        ctrl = New ctrlDistrict03Page02
                    Case "Kurasa ya 3", "Page 3 Table 5e II"
                        ctrl = New ctrlDistrict03Page03
                    Case "Kurasa ya 4", "Page 4 Table 5h, 8, 9"
                        ctrl = New ctrlDistrict03Page04
                    Case "Kurasa ya 5", "Page 5 Table 11"
                        ctrl = New ctrlDistrict03Page05
                    Case "Kurasa ya 6", "Page 6 Table 12"
                        ctrl = New ctrlDistrict03Page06
                End Select

            Case 6
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1 Part I"
                        ctrl = New ctrlWard06Page01
                    Case "Kurasa ya 2", "Page 2 Table 1 Part II"
                        ctrl = New ctrlWard06Page02
                    Case "Kurasa ya 3", "Page 3 Table 1 Part III"
                        ctrl = New ctrlWard06Page03
                    Case "Kurasa ya 4", "Page 4 Table 1 Part IV"
                        ctrl = New ctrlWard06Page04
                End Select

            Case 7
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1 Part I"
                        ctrl = New ctrlWard06Page01
                    Case "Kurasa ya 2", "Page 2 Table 1 Part II"
                        ctrl = New ctrlWard06Page02
                    Case "Kurasa ya 3", "Page 3 Table 1 Part III"
                        ctrl = New ctrlWard06Page03
                    Case "Kurasa ya 4", "Page 4 Table 1 Part IV"
                        ctrl = New ctrlWard06Page04
                End Select

            Case 8
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1 Part I"
                        ctrl = New ctrlDistrict08Page01
                    Case "Kurasa ya 2", "Page 2 Table 1 Part II"
                        ctrl = New ctrlDistrict08Page02
                    Case "Kurasa ya 3", "Page 3 Table 1 Part III"
                        ctrl = New ctrlDistrict08Page03
                    Case "Kurasa ya 4", "Page 4 Table 1 Part IV"
                        ctrl = New ctrlDistrict08Page04
                    Case "Kurasa ya 5", "Page 5 Table 2, 3a, 3b"
                        ctrl = New ctrlDistrict08Page05
                    Case "Kurasa ya 6", "Page 6 Table 4, 5"
                        ctrl = New ctrlDistrict08Page06
                    Case "Kurasa ya 7", "Page 7 Table 6a, 6b, 6c"
                        ctrl = New ctrlDistrict08Page07
                    Case "Kurasa ya 8", "Page 8 Table 7a"
                        ctrl = New ctrlDistrict08Page08
                    Case "Kurasa ya 9", "Page 9 Table 7b"
                        ctrl = New ctrlDistrict08Page09
                End Select

            Case 9
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1 Table 1, 2a, 2b"
                        ctrl = New ctrlDistrict09Page01
                    Case "Kurasa ya 2", "Page 2 Table 3a, 3b, 3c"
                        ctrl = New ctrlDistrict09Page02
                    Case "Kurasa ya 3", "Page 3 Table 3d, 3e"
                        ctrl = New ctrlDistrict09Page03
                    Case "Kurasa ya 4", "Page 4 Table 3f, 3g"
                        ctrl = New ctrlDistrict09Page04
                    Case "Kurasa ya 5", "Page 5 4a, 4b, 4c"
                        ctrl = New ctrlDistrict09Page05
                    Case "Kurasa ya 6", "Page 6 Table 5a, 5b"
                        ctrl = New ctrlDistrict09Page06
                    Case "Kurasa ya 7", "Page 7 Table 5c, 5d, 5e"
                        ctrl = New ctrlDistrict09Page07
                    Case "Kurasa ya 8", "Page 8 Table 5f, 5g, 5h"
                        ctrl = New ctrlDistrict09Page08
                    Case "Kurasa ya 9", "Page 9 Table 6a, 6b, 7, 8"
                        ctrl = New ctrlDistrict09Page09
                    Case "Kurasa ya 10", "Page 10 Table 9, 10"
                        ctrl = New ctrlDistrict09Page10
                    Case "Kurasa ya 11", "Page 11 Table 11, 12"
                        ctrl = New ctrlDistrict09Page11
                    Case "Kurasa ya 12", "Page 12 Table 13, 14a, 14b"
                        ctrl = New ctrlDistrict09Page12
                    Case "Kurasa ya 13", "Page 13 Table 15a, 15b, 16"
                        ctrl = New ctrlDistrict09Page13
                End Select
        End Select
        ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Add(ctrl)

    End Sub

    Private Function getPageLabels(ByVal FormNumber As Int16, ByVal SelectedOption As String) As String
        Dim strLabel As String = ""
        Select Case FormNumber
            Case 1

                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 2 Part I"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 2 Part II"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 2 Part III"
                    Case "Kurasa ya 5", "Page 5"
                        strLabel = "Page 5 Table 3 - 4"
                    Case "Kurasa ya 6", "Page 6"
                        strLabel = "Page 6 Table 5 - 6.2"
                    Case "Kurasa ya 7", "Page 7"
                        strLabel = "Page 7 Table 7 - 7.3"
                    Case "Kurasa ya 8", "Page 8"
                        strLabel = "Page 8 Table 8 - 9"

                End Select

            Case 2
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 2 - 2.2"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 3"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 4 - 5"
                    Case "Kurasa ya 5", "Page 5"
                        strLabel = "Page 5 Table 6 - 7"
                End Select

            Case 3
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1 - 3.1"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 4 - 4.2"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 4.3 - 4.4"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 5.1"
                    Case "Kurasa ya 5", "Page 5"
                        strLabel = "Page 5 Table 6.1"
                    Case "Kurasa ya 6", "Page 6"
                        strLabel = "Page 6 Table 6.2"
                    Case "Kurasa ya 7", "Page 7"
                        strLabel = "Page 7 Table 6.3"
                    Case "Kurasa ya 8", "Page 8"
                        strLabel = "Page 8 Table 7"
                    Case "Kurasa ya 9", "Page 9"
                        strLabel = "Page 9 Table 8 - 9"
                    Case "Kurasa ya 10", "Page 10"
                        strLabel = "Page 10 Table 10 - 11.2"
                End Select

            Case 4
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 3, 6"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 7a"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 7b"
                End Select

            Case 5
                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1, 3, 5a"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 5b-5e"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 5e II"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 5h, 8, 9"
                    Case "Kurasa ya 5", "Page 5"
                        strLabel = "Page 5 Table 11"
                    Case "Kurasa ya 6", "Page 6"
                        strLabel = "Page 6 Table 12"
                End Select

            Case 6

                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1 Part I"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 1 Part II"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 1 Part III"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 1 Part IV"
                End Select

            Case 7

                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1 Part I"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 1 Part II"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 1 Part III"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 1 Part IV"
                End Select

            Case 8

                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1 Part I"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 1 Part II"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 1 Part III"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 1 Part IV"
                    Case "Kurasa ya 5", "Page 5"
                        strLabel = "Page 5 Table 2, 3a, 3b"
                    Case "Kurasa ya 6", "Page 6"
                        strLabel = "Page 6 Table 4, 5"
                    Case "Kurasa ya 7", "Page 7"
                        strLabel = "Page 7 Table 6a, 6b, 6c"
                    Case "Kurasa ya 8", "Page 8"
                        strLabel = "Page 8 Table 7a"
                    Case "Kurasa ya 9", "Page 9"
                        strLabel = "Page 9 Table 7b"
                End Select

            Case 9

                Select Case SelectedOption
                    Case "Kurasa ya 1", "Page 1"
                        strLabel = "Page 1 Table 1, 2a, 2b"
                    Case "Kurasa ya 2", "Page 2"
                        strLabel = "Page 2 Table 3a, 3b, 3c"
                    Case "Kurasa ya 3", "Page 3"
                        strLabel = "Page 3 Table 3d, 3e"
                    Case "Kurasa ya 4", "Page 4"
                        strLabel = "Page 4 Table 3f, 3g"
                    Case "Kurasa ya 5", "Page 5"
                        strLabel = "Page 5 4a, 4b, 4c"
                    Case "Kurasa ya 6", "Page 6"
                        strLabel = "Page 6 Table 5a, 5b"
                    Case "Kurasa ya 7", "Page 7"
                        strLabel = "Page 7 Table 5c, 5d, 5e"
                    Case "Kurasa ya 8", "Page 8"
                        strLabel = "Page 8 Table 5f, 5g, 5h"
                    Case "Kurasa ya 9", "Page 9"
                        strLabel = "Page 9 Table 6a, 6b, 7, 8"
                    Case "Kurasa ya 10", "Page 10"
                        strLabel = "Page 10 Table 9, 10"
                    Case "Kurasa ya 11", "Page 11"
                        strLabel = "Page 11 Table 11, 12"
                    Case "Kurasa ya 12", "Page 12"
                        strLabel = "Page 12 Table 13, 14a, 14b"
                    Case "Kurasa ya 13", "Page 13"
                        strLabel = "Page 13 Table 15a, 15b, 16"
                End Select

        End Select

        If strLabel = "" Then
            Return SelectedOption
        Else
            Return strLabel
        End If

    End Function

    Public Sub PopulateHeaderControls(ByVal callingFrm As Object)
        Try
            callingFrm.controls("txtNameOfLGA").Text = g_AreaHeading.Replace("District: ", "")
            callingFrm.controls("txtNameOfLGA").enabled = False
            If callingFrm.name.contains("02P") Then

                If g_PeriodHeading.Contains("July - September") Then
                    callingFrm.controls("txtQuarter").Text = "Jul - Sep"
                    'callingFrm.controls("txtFinancialYear").Text = g_PeriodHeading.Replace("July - September", "") & "/" & Val(g_PeriodHeading.Replace("July - September", "")) + 1
                    callingFrm.controls("txtFinancialYear").Text = DatePart(DateInterval.Year, StartOfFinancialYear(g_PeriodFrom)).ToString + "/" + DatePart(DateInterval.Year, EndOfFinancialYear(g_PeriodTo)).ToString
                End If

                If g_PeriodHeading.Contains("October - December") Then
                    callingFrm.controls("txtQuarter").Text = "Oct - Dec"
                    'callingFrm.controls("txtFinancialYear").Text = g_PeriodHeading.Replace("October - December", "") & "/" & Val(g_PeriodHeading.Replace("October - December", "")) + 1
                    callingFrm.controls("txtFinancialYear").Text = DatePart(DateInterval.Year, StartOfFinancialYear(g_PeriodFrom)).ToString + "/" + DatePart(DateInterval.Year, EndOfFinancialYear(g_PeriodTo)).ToString
                End If

                If g_PeriodHeading.Contains("January - March") Then
                    callingFrm.controls("txtQuarter").Text = "Jan - Mar"
                    'callingFrm.controls("txtFinancialYear").Text = Val(g_PeriodHeading.Replace("January - March", "")) - 1 & "/" & g_PeriodHeading.Replace("January - March", "")
                    callingFrm.controls("txtFinancialYear").Text = DatePart(DateInterval.Year, StartOfFinancialYear(g_PeriodFrom)).ToString + "/" + DatePart(DateInterval.Year, EndOfFinancialYear(g_PeriodTo)).ToString
                End If

                If g_PeriodHeading.Contains("April - June") Then
                    callingFrm.controls("txtQuarter").Text = "Apr - Jun"
                    'callingFrm.txtFinancialYear.Text = Val(g_PeriodHeading.Replace("April - June", "")) - 1 & "/" & g_PeriodHeading.Replace("April - June", "")
                    callingFrm.controls("txtFinancialYear").Text = DatePart(DateInterval.Year, StartOfFinancialYear(g_PeriodFrom)).ToString + "/" + DatePart(DateInterval.Year, EndOfFinancialYear(g_PeriodTo)).ToString
                End If
                callingFrm.controls("txtQuarter").enabled = False
                callingFrm.controls("txtFinancialYear").enabled = False
            End If
            If callingFrm.name.contains("03P") Then
                callingFrm.controls("txtFinancialYear").Text = g_PeriodHeading
                callingFrm.controls("txtFinancialYear").enabled = False
                callingFrm.controls("txtNameOfLGA").enabled = False

            End If
        Catch ex As Exception
        End Try
    End Sub
End Module