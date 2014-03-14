Public Class ctrlAddForm

    Dim ThePeriod As String
    Dim TheAreaLevel As Long

    Private Sub ctrlAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case g_language
            Case "Swahili"
                Me.cmbForm.DisplayMember = "FormNameSwahili"
                Me.cmbPlace.DisplayMember = "Area_Level_Name_Swahili"
                Me.cmdAddForm.Text = "Ongeza fomu"
                Me.lblEngFormNumber.Visible = False
                Me.lblSwaFormNumber.Visible = True
            Case Else
                Me.cmbForm.DisplayMember = "FormNameEnglish"
                Me.cmbPlace.DisplayMember = "Area_Level_Name_English"
                Me.cmdAddForm.Text = "Add form"
                Me.lblEngFormNumber.Visible = True
                Me.lblSwaFormNumber.Visible = False
        End Select

        Me.Tbl_setup_form_typesTableAdapter.Fill(Me.LGMDdataDataSet.tbl_setup_form_types)
        Me.Udp_area_levels_data_entryTableAdapter.Fill(Me.LGMDdataDataSet.udp_area_levels_data_entry)

        Call FillWithFinancialYears(Me.cmbFinYear, Format(Now.Date, "yyyy") - 4, Format(Now.Date, "yyyy"))
        Call FillWithFinancialYears(Me.cmbYear, Format(Now.Date, "yyyy") - 4, Format(Now.Date, "yyyy"))
        Call FillWithQuarters(Me.cmbQuarter)
        Call FillWithMonths(Me.cmbMonth)

        Me.cmbForm.SelectedIndex = -1

        Me.cmbPlace.SelectedIndex = -1
    End Sub

    Private Sub cmbForm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbForm.SelectedIndexChanged

        ThePeriod = Nz(DomainLookup("Period", "tbl_setup_form_types", "FormTypeNumber = " & Nz(Me.cmbForm.SelectedValue, 0)), "")
        Call RefreshPeriod(True)

        TheAreaLevel = Nz(DomainLookup("Area_Level", "tbl_setup_form_types", "FormTypeNumber = " & Nz(Me.cmbForm.SelectedValue, 0)), 0)
        Call RefreshArea(True)

    End Sub

    Private Sub cmbPlace_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPlace.SelectedIndexChanged

        TheAreaLevel = Me.cmbPlace.SelectedValue
        Call RefreshArea(False)

    End Sub

    Private Sub cmbPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        ThePeriod = Me.cmbPeriod.Text
        Call RefreshPeriod(False)
    End Sub

    Private Sub RefreshArea(ByVal MakePlaceInvisible As Boolean)
        Dim AreaLabelVisible As Boolean

        If (MakePlaceInvisible And TheAreaLevel <> 0) Or Me.cmbForm.SelectedIndex = -1 Then
            Me.cmbPlace.Visible = False
        Else
            Me.cmbPlace.Visible = True
        End If

        Me.Udp_geo_listTableAdapter.Fill(Me.LGMDdataDataSet.udp_geo_list, TheAreaLevel)
        If Me.cmbAreaID.Items.Count = 1 Then
            Me.cmbAreaID.SelectedIndex = 0
        Else
            Me.cmbAreaID.SelectedIndex = -1
        End If

        Select Case TheAreaLevel
            Case 0
                Me.cmbAreaID.Visible = False
                AreaLabelVisible = False
            Case Else
                Me.cmbAreaID.Visible = True
                AreaLabelVisible = True
        End Select

        Me.lblEngPlace.Visible = False
        Me.lblSwaPlace.Visible = False
        Me.lblEngAreaID.Visible = False
        Me.lblSwaAreaID.Visible = False

        Select Case g_language
            Case "Swahili"
                Me.lblSwaPlace.Visible = Me.cmbPlace.Visible
                Me.lblSwaAreaID.Visible = AreaLabelVisible
            Case Else
                Me.lblEngPlace.Visible = Me.cmbPlace.Visible
                Me.lblEngAreaID.Visible = AreaLabelVisible
        End Select
    End Sub

    Private Sub RefreshPeriod(ByVal MakePeriodTypeInvisible)
        Dim PeriodLabelVisible As Boolean

        If (MakePeriodTypeInvisible And ThePeriod <> "") Or Me.cmbForm.SelectedIndex = -1 Then
            Me.cmbPeriod.Visible = False
        Else
            Me.cmbPeriod.Visible = True
        End If

        Me.lblEngPeriodType.Visible = False
        Me.lblSwaPeriodType.Visible = False

        Select Case g_language
            Case "Swahili"
                Me.lblSwaPeriodType.Visible = Me.cmbPeriod.Visible
            Case Else
                Me.lblEngPeriodType.Visible = Me.cmbPeriod.Visible
        End Select

        Select Case ThePeriod.ToString.Trim
            Case "Annual"
                Me.cmbFinYear.Visible = True
                Me.cmbYear.Visible = False
                Me.cmbQuarter.Visible = False
                Me.cmbMonth.Visible = False
                PeriodLabelVisible = True
            Case "Quarterly"
                Me.cmbFinYear.Visible = False
                Me.cmbYear.Visible = True
                Me.cmbQuarter.Visible = True
                Me.cmbMonth.Visible = False
                PeriodLabelVisible = True
            Case "Monthly"
                Me.cmbFinYear.Visible = False
                Me.cmbYear.Visible = True
                Me.cmbQuarter.Visible = False
                Me.cmbMonth.Visible = True
                PeriodLabelVisible = True
            Case Else
                Me.cmbFinYear.Visible = False
                Me.cmbYear.Visible = False
                Me.cmbQuarter.Visible = False
                Me.cmbMonth.Visible = False
                PeriodLabelVisible = False

        End Select

        Me.lblEngPeriodType.Visible = False
        Me.lblSwaPeriodType.Visible = False
        Me.lblEngPeriod.Visible = False
        Me.lblSwaPeriod.Visible = False

        Select Case g_language
            Case "Swahili"
                Me.lblSwaPeriodType.Visible = Me.cmbPeriod.Visible
                Me.lblSwaPeriod.Visible = PeriodLabelVisible
            Case Else
                Me.lblEngPeriodType.Visible = Me.cmbPeriod.Visible
                Me.lblEngPeriod.Visible = PeriodLabelVisible
        End Select
    End Sub

    Private Sub cmdAddForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddForm.Click

        Call ModuleClearGlobalVariables()

        If Me.cmbForm.SelectedIndex = -1 Then
            MsgBoxBilingual("Please choose a form", "Chagua fomu")
            Exit Sub
        End If

        If Me.cmbPlace.Visible = True Then
            If Me.cmbPlace.SelectedIndex = -1 Then
                MsgBoxBilingual("Please choose a geographical level", "Chagua kiwango")
                Exit Sub
            End If
        End If

        If Me.cmbAreaID.SelectedIndex = -1 Then
            MsgBoxBilingual("Please choose a geographical area", "Chagua maeneo")
            Exit Sub
        End If

        If Me.cmbPeriod.Visible = True Then
            If Me.cmbPeriod.SelectedIndex = -1 Then
                MsgBoxBilingual("Please choose a period type", "Chagua aina ya kipindi")
                Exit Sub
            End If
        End If

        If Me.cmbFinYear.Visible = True Then
            If Me.cmbFinYear.SelectedIndex = -1 Then
                MsgBoxBilingual("Please choose a year", "Chagua mwaka")
                Exit Sub
            End If
        End If

        If Me.cmbYear.Visible = True Then
            If Me.cmbYear.SelectedIndex = -1 Then
                MsgBoxBilingual("Please choose a year", "Chagua mwaka")
                Exit Sub
            End If
        End If

        If Me.cmbMonth.Visible = True Then
            If Me.cmbMonth.SelectedIndex = -1 Then
                MsgBoxBilingual("Please choose a month", "Chagua mwezi")
                Exit Sub
            End If
        End If

        If Me.cmbQuarter.Visible = True Then
            If Me.cmbQuarter.SelectedIndex = -1 Then
                MsgBoxBilingual("Please choose a quarter", "Chagua robo")
                Exit Sub
            End If
        End If

        g_FormTypeNumber = CLng(Me.cmbForm.SelectedValue)
        g_AreaID = Me.cmbAreaID.SelectedValue.ToString
        g_OrganisationID = 0
        g_AreaHeading = Me.cmbAreaID.Text
        Me.cmbPlace.SelectedValue = TheAreaLevel
        g_RecordID = New Guid

        Select Case Trim(ThePeriod)
            Case "Annual"
                g_PeriodFrom = CDate("1-jul-" & Mid(Me.cmbFinYear.Text, 1, 4))
                g_PeriodTo = CDate("30-jun-" & Mid(Me.cmbFinYear.Text, 6, 4))
                g_PeriodHeading = Me.cmbFinYear.Text
            Case "Quarterly"
                Select Case Me.cmbQuarter.Text

                    Case "January - March"
                        g_PeriodFrom = CDate("1-jan-" & Mid(Me.cmbYear.Text, 6, 4))
                        g_PeriodTo = CDate("31-mar-" & Mid(Me.cmbYear.Text, 6, 4))
                    Case "April - June"
                        g_PeriodFrom = CDate("1-apr-" & Mid(Me.cmbYear.Text, 6, 4))
                        g_PeriodTo = CDate("30-jun-" & Mid(Me.cmbYear.Text, 6, 4))
                    Case "July - September"
                        g_PeriodFrom = CDate("1-jul-" & Mid(Me.cmbYear.Text, 1, 4))
                        g_PeriodTo = CDate("30-sep-" & Mid(Me.cmbYear.Text, 1, 4))
                    Case "October - December"
                        g_PeriodFrom = CDate("1-oct-" & Mid(Me.cmbYear.Text, 1, 4))
                        g_PeriodTo = CDate("31-dec-" & Mid(Me.cmbYear.Text, 1, 4))
                End Select
                g_PeriodHeading = Me.cmbQuarter.Text & " " & Me.cmbYear.Text
            Case "Monthly"
                Dim strMonth As String = Me.cmbYear.Text

                If CDate("1-" & Me.cmbMonth.Text & "-2010") < CDate("1-July-2010") Then
                    strMonth = strMonth.Substring(5, 4)
                Else
                    strMonth = strMonth.Substring(0, 4)
                End If

                g_PeriodFrom = CDate("1-" & Me.cmbMonth.Text & "-" & strMonth)
                g_PeriodTo = EndOfMonth(g_PeriodFrom)
                g_PeriodHeading = Me.cmbMonth.Text & " " & strMonth
        End Select

        If DCount("*", "RecordInfo", "FormSerialNumber = '" & ProduceFormSerialNumber() & "'") > 0 Then
            MsgBoxBilingual("A form for this area for this period has already been entered", "Fomu ya eneo hili ya kipindi hichi tayari imeingizwa")
            Exit Sub
        End If

        g_form_mode = "Add"

        Dim ctrl As New System.Windows.Forms.UserControl
        If LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Count > 0 Then
        End If
        LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.RemoveAt(0)

        Select Case g_FormTypeNumber
            Case 1, 2, 3
                g_AreaHeading = "Ward: " & g_AreaHeading
            Case 4, 5
                g_AreaHeading = "District: " & g_AreaHeading
            Case 4, 5
        End Select

        Select Case g_FormTypeNumber
            Case 1
                'ctrl = New ctrlForm01Page01
                ctrl = New ctrlWard01Page01
            Case 2
                'ctrl = New ctrlForm02Page01
                ctrl = New ctrlWard02Page01
            Case 3
                'ctrl = New vvvvctrlForm03Page01
                ctrl = New ctrlWard03Page01
            Case 4

                Call SaveForm()
                ctrl = New ctrlDistrict02Page01

            Case 5
                Call SaveForm()
                ctrl = New ctrlDistrict03Page01

            Case 6
                'Call SaveForm()
                ctrl = New ctrlWard06Page01
        End Select
        LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Add(ctrl)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

End Class