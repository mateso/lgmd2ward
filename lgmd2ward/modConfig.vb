Module modConfig

    Public Function MsgBoxBilingual(ByVal PromptEnglish As Object, ByVal PromptSwahili As Object, Optional ByVal buttons As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkOnly) As Microsoft.VisualBasic.MsgBoxResult
        Select Case g_language
            Case "Swahili"
                MsgBoxBilingual = MsgBox(PromptSwahili, buttons, "Ujumbe wa LGMD")
            Case Else
                MsgBoxBilingual = MsgBox(PromptEnglish, buttons, "LGMD System Message")
        End Select

    End Function

    Public Sub LabelTranslation(ByVal TheFormControl As Control)
        Dim i As Integer
        
        For i = 0 To TheFormControl.Controls.Count - 1
            If Mid(TheFormControl.Controls(i).Name, 1, 6) = "lblEng" Then
                Select Case g_language
                    Case "Swahili"
                        TheFormControl.Controls(i).Visible = False
                    Case Else
                        TheFormControl.Controls(i).Visible = True
                End Select
            ElseIf Mid(TheFormControl.Controls(i).Name, 1, 6) = "lblSwa" Then
                Select Case g_language
                    Case "Swahili"
                        TheFormControl.Controls(i).Visible = True
                    Case Else
                        TheFormControl.Controls(i).Visible = False
                End Select
            End If
        Next i

        Try
            TheFormControl.Controls("cmbGoTo").Width = 1.5 * TheFormControl.Controls("cmbGoTo").Width
            TheFormControl.Controls("cmdSave").Width = 0.85 * TheFormControl.Controls("cmdSave").Width
            If g_form_mode = "View" Then
                TheFormControl.Controls("gotoLbl").Hide() 'hide the goto label in viewing mode
                TheFormControl.Controls("cmbGoTo").Top = 30
                TheFormControl.Controls("cmbGoTo").Left = 10
                TheFormControl.Controls("cmdSave").Top = 30
                TheFormControl.Controls("cmdSave").Width = 0.5 * TheFormControl.Controls("cmdSave").Width
                'TheFormControl.Controls("cmdSave").Left = 110
            End If

            TheFormControl.Controls("cmdSave").Left = TheFormControl.Controls("cmbGoTo").Left + TheFormControl.Controls("cmbGoTo").Width + 25

        Catch ex As Exception
        End Try

        Try
            If g_form_mode = "View" Then
                For Each ctrlText As Control In TheFormControl.Controls
                    If ctrlText.Name.Contains("txt") Then
                        Try
                            ctrlText.BackColor = Color.Khaki
                            ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.GetType().ToString = "TextBox" Then
                        Try
                            ctrlText.BackColor = Color.Khaki
                            ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.Name.Contains("DataGrid") Then
                        Try
                            Dim objDataGrid As DataGridView
                            objDataGrid = CType(ctrlText, DataGridView)
                            objDataGrid.GridColor = Color.Khaki
                            objDataGrid.ReadOnly = True
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.Name.Contains("cmo") Then
                        Try
                            ctrlText.BackColor = Color.Khaki
                            ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.GetType().ToString = "ComboBox" Then
                        Try
                            ctrlText.BackColor = Color.Khaki
                            ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.Name.Contains("DateTimePicker1") Then
                        Try
                            Dim objDataGrid As DateTimePicker
                            objDataGrid = CType(ctrlText, DateTimePicker)
                            objDataGrid.CalendarForeColor = Color.Khaki
                            objDataGrid.CalendarMonthBackground = Color.Khaki
                            objDataGrid.Enabled = False
                            'ctrlText.BackColor = Color.Khaki
                            'ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.GetType().ToString = "DateTimePicker" Then
                        Try
                            Dim objDataGrid As DateTimePicker
                            objDataGrid = CType(ctrlText, DateTimePicker)
                            objDataGrid.CalendarForeColor = Color.Khaki
                            objDataGrid.CalendarMonthBackground = Color.Khaki
                            objDataGrid.Enabled = False
                            'ctrlText.BackColor = Color.Khaki
                            'ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If

                    If ctrlText.GetType().ToString = "NumericUpDown" Then
                        Try
                            ctrlText.BackColor = Color.Khaki
                            ctrlText.Enabled = False
                        Catch ex As Exception
                        End Try
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetGoButton(ByVal TheGoButtonControl As Control)

        Select Case g_language
            Case "Swahili"
                Select Case g_form_mode
                    Case "View"
                        TheGoButtonControl.Text = "Endelea"
                    Case Else
                        TheGoButtonControl.Text = "Hifadhi na endelea"
                End Select
            Case Else
                Select Case g_form_mode
                    Case "View"
                        TheGoButtonControl.Text = "Go"
                    Case Else
                        TheGoButtonControl.Text = "Save and go"
                End Select
        End Select
       
    End Sub

    Public Function GetConfigLevel(Optional ByVal ShowDescription As Boolean = False)
        Dim TheLevelNumber
        Dim TheColumnName As String

        TheLevelNumber = Nz(DomainLookup("config_value", "tbl_config", "config_name = 'Area_Level'"), "0")

        If ShowDescription Then
            Select Case g_language
                Case "English"
                    TheColumnName = "area_level_name_english"
                Case Else
                    TheColumnName = "area_level_name_swahili"
            End Select
            GetConfigLevel = Nz(DomainLookup(TheColumnName, "tbl_setup_area_levels", "area_level = " & TheLevelNumber), "")

        Else
            GetConfigLevel = TheLevelNumber
            ' returns "0" if not configured
        End If

    End Function

    Public Function GetConfigArea(Optional ByVal ShowDescription As Boolean = False) As String

        Dim TheAreaID

        TheAreaID = Nz(DomainLookup("config_value", "tbl_config", "config_name = 'Area_ID'"), "0")

        If ShowDescription Then
            GetConfigArea = Nz(DomainLookup("area_name", "tbl_setup_areas", "area_id = '" & TheAreaID & "'"), "")
        Else
            GetConfigArea = TheAreaID
            ' returns "0" if not configured
        End If

    End Function

    Public Function IsConfigured() As Boolean
        Select Case GetConfigArea()
            Case "", "0"
                IsConfigured = False
            Case Else
                IsConfigured = True
        End Select
    End Function

End Module
