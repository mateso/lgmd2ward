Imports System.Data
Imports System.Data.SqlClient
Imports LGMD

Public Class frmConfig

    Private Sub frmConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LabelTranslation(Me)

        Me.Udp_area_levels_configureTableAdapter.Fill(Me.LGMDdataDataSet.udp_area_levels_configure, g_language)
        Me.cmbPlace.SelectedIndex = -1
    End Sub

    Private Sub cmbPlace_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlace.SelectedIndexChanged
        If Me.cmbPlace.SelectedIndex <> -1 Then
            Me.Udp_geo_list_configureTableAdapter.Fill(Me.LGMDdataDataSet.udp_geo_list_configure, Me.cmbPlace.SelectedValue)
            Me.cmbAreaID.SelectedIndex = -1
        End If

    End Sub

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        If Me.cmbPlace.SelectedIndex = -1 Then
            MsgBoxBilingual("Choose a geographical level", "Chagua kiwango")
            Exit Sub
        End If

        If Me.cmbAreaID.SelectedIndex = -1 Then
            MsgBoxBilingual("Choose a geographical area", "Chagua eneo")
            Exit Sub
        End If

        Dim Configure As New SqlCommand

        Dim TheConnection As New SqlConnection
        TheConnection.ConnectionString = My.Settings.DataConnectionString
        TheConnection.Open()

        Dim prmArea_Level As New SqlParameter
        prmArea_Level.ParameterName = "Area_Level"
        prmArea_Level.SqlValue = Me.cmbPlace.SelectedValue

        Dim prmArea_ID As New SqlParameter
        prmArea_ID.ParameterName = "Area_ID"
        prmArea_ID.SqlValue = Me.cmbAreaID.SelectedValue

        With Configure
            .CommandType = CommandType.StoredProcedure
            .Connection = TheConnection
            .CommandText = "udp_configure"
            .Parameters.Add(prmArea_Level)
            .Parameters.Add(prmArea_ID)
            .ExecuteNonQuery()
            .Parameters.Clear()
        End With

        'Dim oconn As New SqlClient.SqlConnection
        'oconn.ConnectionString = My.Settings.LGMDdataConnectionString
        'Dim cmd As New SqlClient.SqlCommand
        ' Dim oReader As SqlClient.SqlDataReader
        '  oconn.Open()
        '   cmd.Connection = oconn
        '    cmd.CommandType = CommandType.Text

        '     cmd.CommandText = "update tblappversioncontrol set StationCode='" & cmbPlace.Text & "'"


        '      cmd.ExecuteNonQuery()

        '       cmd.CommandText = "Select StationCode,StationDesc from tblappversioncontrol"

        '        oReader = cmd.ExecuteReader

        'oReader.Read()

        'If oReader.GetSqlValue(0).ToString <> "Null" Then
        '    My.Settings.StationCode = oReader.GetValue(0)
        '    My.Settings.StationDesc = oReader.GetValue(1).ToString
        '    My.Settings.CurrentUserStationCode = oReader.GetValue(0).ToString
        '    My.Settings.Save()
        'End If
        Me.Close()
    End Sub

    Private Sub frmConfig_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If IsConfigured() = False Then
            Application.Exit()
        End If

    End Sub
End Class