Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports LGMD.LGMDdataDataSetTableAdapters

Public Class ctrlAddUser
    Dim data As New DataSet()
    Dim stu As New HEMISEntities.HEMISDataSet
    Dim masterDataAdapter As New tblUsersTableAdapter
    Dim detailsDataAdapter As New tblUserGroupTableAdapter
    'Dim localProxy As New HEMISDAL.HEMISManager

    Friend WithEvents objComboColumn As System.Windows.Forms.DataGridViewComboBoxColumn

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Bind the DataGridView controls to the BindingSource
        ' components and load the data from the database.

        GetData()
        masterDataGridView.DataSource = masterBindingSource
        detailsDataGridView.DataSource = detailsBindingSource

        If detailsDataGridView.Columns.Count > 0 Then
            Me.detailsDataGridView.Columns("RowVersionID").Visible = False
            Me.detailsDataGridView.Columns("Year").Visible = False
            Me.detailsDataGridView.Columns("SourceID").Visible = False
            Me.detailsDataGridView.Columns("bDeleted").Visible = False
            Me.detailsDataGridView.Columns("Username").Visible = False
        End If

        Me.detailsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        Me.detailsDataGridView.MultiSelect = False
        Me.detailsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.detailsDataGridView.AllowUserToOrderColumns = True

        ' Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        detailsDataGridView.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub GetData()
        Try
            ' Specify a connection string. Replace the given value with a 
            ' valid connection string for a Northwind SQL Server sample
            ' database accessible to your system.
            ' Create a DataSet.
            'Me.TblInstitutionsBindingSource. 

            data.Locale = System.Globalization.CultureInfo.InvariantCulture

            ' Dim v As New HEMISDAL.HEMISDataSetTableAdapters.tblInstitutionsTableAdapter
            'v.Fill(stu.tblInstitutions)

            'HEMISDataSet.Merge(localProxy.GetObject("tblInstitutions", My.Settings.DataConnectionString))

            ''Dim vv As New HEMISDAL.HEMISDataSetTableAdapters.tblGroupsTableAdapter
            ''vv.Fill(stu.tblGroups)
            'HEMISDataSet.AcceptChanges()
            ''masterDataAdapter.Fill(stu.tblUsers)
            'HEMISDataSet.Merge(localProxy.GetObject("tblUsers", My.Settings.DataConnectionString))

            ''detailsDataAdapter.Fill(stu.tblUserGroup)
            'HEMISDataSet.Merge(localProxy.GetObject("tblUserGroup", My.Settings.DataConnectionString))
            'HEMISDataSet.Merge(localProxy.GetObject("tblGroups", My.Settings.DataConnectionString))

            'data = stu

            ' Bind the master data connector to the Customers table.
            Me.TblInstitutionsBindingSource.DataSource = HEMISDataSet 'data
            Me.TblInstitutionsBindingSource.DataMember = "tblInstitutions"
            Me.TblInstitutionsBindingSource.Sort = "ShortName"


            'If My.Settings.CurrentUserStationCode.Length > 0 Then
            '    Me.TblInstitutionsBindingSource.Filter() = "ShortName='" & My.Settings.CurrentUserStationCode & "'"
            'End If

            masterBindingSource.DataSource = HEMISDataSet ' data
            masterBindingSource.DataMember = "tblUsers"

            ' Bind the details data connector to the master data connector,
            ' using the DataRelation name to filter the information in the 
            ' details table based on the current row in the master table. 
            detailsBindingSource.DataSource = masterBindingSource
            detailsBindingSource.DataMember = "FK_UserGroup_Users"

            'samuel
            ' Me.masterDataGridView.Columns("RowVersionID").Visible = False
            'Me.masterDataGridView.Columns("Year").Visible = False
            'Me.masterDataGridView.Columns("SourceID").Visible = False
            'Me.masterDataGridView.Columns("bDeleted").Visible = False
            If detailsDataGridView.Columns.Count > 0 Then
                Me.detailsDataGridView.Columns("RowVersionID").Visible = False
                Me.detailsDataGridView.Columns("Year").Visible = False
                Me.detailsDataGridView.Columns("SourceID").Visible = False
                Me.detailsDataGridView.Columns("bDeleted").Visible = False
                Me.detailsDataGridView.Columns("GroupID").Visible = False
            End If
            'end samuel
            ' Me.detailsDataGridView.Columns.Add(objComboColumn)
            ' objComboColumn.DataSource = TblInstitutionsBindingSource
            ' objComboColumn.DataPropertyName = "GroupID"
            ' objComboColumn.DisplayMember = "GroupID"
            'objComboColumn.ValueMember = "GroupID"
            'Dim strCategory As String = ""
            'strCategory = reader("Tag").ToString
            Dim nnmmm As New BindingSource
            nnmmm.DataMember = "tblGroups"
            nnmmm.DataSource = HEMISDataSet 'data 'localProxy.GetObject("tblList")        '
            '  nnmmm.Filter() = "Category = '" & strCategory & "'"
            ' nnmmm.Sort() = "Description"

            'Dim strCategory As String = ""
            'strCategory = reader("Tag").tostring
            'Dim t2 = From c2 As tblList In pm2.tblList Where c2.Category = "" + strCategory + "" Select c2.[ListCode], c2.[Description], c2.[SourceID], c2.[ListTag]
            Me.objComboColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

            With Me.objComboColumn
                .DisplayMember = "GroupID"
                .ValueMember = "GroupID"
                .DataSource = nnmmm 'localProxy.GetObject("tblList")        '
                .Name = "strColumn"
            End With
            Me.objComboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            Me.objComboColumn.SortMode = DataGridViewColumnSortMode.Programmatic
            Me.objComboColumn.FlatStyle = FlatStyle.Popup
            objComboColumn.DataPropertyName = "GroupID" '.Columns(strColumn).DataPropertyName
            objComboColumn.HeaderText = "User Group" 'reader("Caption").ToString"
            '.Columns.RemoveAt(.Columns.IndexOf(.Columns(strColumn)))
            '.Columns.Insert(reader("DisplayIndex").ToString - 1, Me.objComboColumn)
            Me.detailsDataGridView.Columns.Add(objComboColumn)

        Catch ex As SqlException
            MessageBox.Show("To run this application, replace the value of the " & _
                "connectionString variable with a connection string that is " & _
                "valid for your system.")
        End Try

    End Sub

    Private Sub txtPassword_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Validated

        Try
            If Not Me.masterBindingSource.Current Is Nothing And txtPassword.Text.ToString.ToLower <> "password" And txtPassword.Text.ToString.Length > 0 Then
                Dim objIdentity As New CustomIdentity
                Me.masterBindingSource.Current.item("Password") = objIdentity.CreateDBPassword(txtPassword.Text.ToString)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub masterBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles masterBindingSource.CurrentChanged
        Me.txtPassword.Text = "password"
        Try
            If Me.masterBindingSource.Current.item("Username").ToString.Equals("") And Not Me.masterBindingSource.Current.isnew Then
                Me.ErrorProvider1.SetError(Me.UserNameTextBox, "Student ID must be filled")
                Exit Sub
            Else
                Me.ErrorProvider1.SetError(Me.UserNameTextBox, "")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Overrides Sub Save()
        If Me.UserNameTextBox.Text.Length.Equals(0) Then
            Me.ErrorProvider1.SetError(Me.UserNameTextBox, "User name must be filled")
            Exit Sub
        Else
            Me.ErrorProvider1.SetError(Me.UserNameTextBox, "")
        End If
        If Me.txtPassword.Text.Length.Equals(0) Then
            Me.ErrorProvider1.SetError(Me.txtPassword, "Password must be filled")
            Exit Sub
        Else
            Me.ErrorProvider1.SetError(Me.txtPassword, "")
        End If
        'Me.TblUserGroupBindingSource.DataSource
        ErrorProvider1.Clear()

        Try
            'Me.masterBindingSource.Current.item("Password") = kkk.CreateDBPassword(txtPassword.Text.ToString)
            masterBindingSource.EndEdit()
            detailsBindingSource.EndEdit()
            'masterDataAdapter.Update(data)
            'detailsDataAdapter.Update(data)


            Dim changes As HEMISEntities.HEMISDataSet = CType(HEMISDataSet.GetChanges, HEMISEntities.HEMISDataSet)
            If Not changes Is Nothing Then
                'If localProxy.SaveObject(changes, "tblUsers", My.Settings.DataConnectionString) = False Then
                '    ' MsgBox("There are errors please correct them before saving")
                'Else
                '    'Me.HasUnsavedChanges = False
                '    'masterBindingSource.DataSource.AcceptChanges()
                'End If
                'If localProxy.SaveObject(changes, "tblUserGroup", My.Settings.DataConnectionString) = False Then
                '    'MsgBox("There are errors please correct them before saving")
                'Else
                '    'Me.HasUnsavedChanges = False
                '    'masterBindingSource.DataSource.AcceptChanges()
                'End If

                Me.HasUnsavedChanges = False
                HEMISDataSet.AcceptChanges()
            End If

            'Dim changes1 As HEMISEntities.HEMISDataSet = CType(detailsBindingSource.DataSource.GetChanges, HEMISEntities.HEMISDataSet)
            'Dim changes1 As HEMISEntities.HEMISDataSet = CType(HEMISDataSet, HEMISEntities.HEMISDataSet)
            'If Not changes1 Is Nothing Then
            ' If localProxy.SaveObject(changes1, "tblUserGroup", My.Settings.HEMISConnectionString) = False Then
            ' MsgBox("There are errors please correct them before saving")
            ' Else
            ' Me.HasUnsavedChanges = False
            ' masterBindingSource.DataSource.AcceptChanges()
            ' End If
            ' End If
            '
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Sub Add()

        Save()
        '        If My.Settings.CurrentYear.ToString = "<ALL>" Or My.Settings.CurrentYear.Length = 0 Then
        'MsgBox("Default Academic year is not yet set" & vbCrLf & "Nothing will be added")
        'Exit Sub
        'End If
        Me.txtPassword.Text = ""
        Try
            masterBindingSource.AddNew()
        Catch ex As Exception

        End Try

    End Sub

    Public Overrides Sub delete()

        Me.masterBindingSource.RemoveCurrent()
        Try
            masterBindingSource.EndEdit()
            detailsBindingSource.EndEdit()
            detailsDataAdapter.Update(data)
            masterDataAdapter.Update(data)

        Catch ex As Exception

        End Try
        Save()

    End Sub

    Private Sub masterDataGridView_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles masterDataGridView.RowValidated
        Dim objIdentity As New CustomIdentity

        If txtPassword.Text.ToString.ToLower <> "password" Then
            masterDataGridView.Rows(e.RowIndex).Cells("Password").Value = objIdentity.CreateDBPassword(txtPassword.Text.ToString)
        End If
    End Sub

    Private Sub detailsDataGridView_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles detailsDataGridView.Enter
        Save()
    End Sub

    Private Sub txtPassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPassword.Validating
        Try
            If Not Me.masterBindingSource.Current Is Nothing And txtPassword.Text.ToString.ToLower <> "password" And txtPassword.Text.ToString.Length > 0 Then
                Dim objIdentity As New CustomIdentity
                Me.masterBindingSource.Current.item("Password") = objIdentity.CreateDBPassword(txtPassword.Text.ToString)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Save()
    End Sub
End Class