<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lblSwaAreaID = New System.Windows.Forms.Label
        Me.lblSwaPlace = New System.Windows.Forms.Label
        Me.lblEngAreaID = New System.Windows.Forms.Label
        Me.lblEngPlace = New System.Windows.Forms.Label
        Me.cmbPlace = New System.Windows.Forms.ComboBox
        Me.Udp_area_levels_configureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LGMDdataDataSet = New LGMDdataDataSet
        Me.cmbAreaID = New System.Windows.Forms.ComboBox
        Me.Udp_geo_list_configureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Udp_area_levels_configureTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.udp_area_levels_configureTableAdapter
        Me.TableAdapterManager = New LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
        Me.Udp_geo_list_configureTableAdapter = New LGMD.LGMDdataDataSetTableAdapters.udp_geo_list_configureTableAdapter
        Me.btnConfig = New System.Windows.Forms.Button
        CType(Me.Udp_area_levels_configureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Udp_geo_list_configureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSwaAreaID
        '
        Me.lblSwaAreaID.AutoSize = True
        Me.lblSwaAreaID.Location = New System.Drawing.Point(23, 143)
        Me.lblSwaAreaID.Name = "lblSwaAreaID"
        Me.lblSwaAreaID.Size = New System.Drawing.Size(49, 13)
        Me.lblSwaAreaID.TabIndex = 23
        Me.lblSwaAreaID.Text = "Maeneo:"
        Me.lblSwaAreaID.Visible = False
        '
        'lblSwaPlace
        '
        Me.lblSwaPlace.AutoSize = True
        Me.lblSwaPlace.Location = New System.Drawing.Point(23, 109)
        Me.lblSwaPlace.Name = "lblSwaPlace"
        Me.lblSwaPlace.Size = New System.Drawing.Size(51, 13)
        Me.lblSwaPlace.TabIndex = 22
        Me.lblSwaPlace.Text = "Kiwango:"
        Me.lblSwaPlace.Visible = False
        '
        'lblEngAreaID
        '
        Me.lblEngAreaID.AutoSize = True
        Me.lblEngAreaID.Location = New System.Drawing.Point(23, 143)
        Me.lblEngAreaID.Name = "lblEngAreaID"
        Me.lblEngAreaID.Size = New System.Drawing.Size(97, 13)
        Me.lblEngAreaID.TabIndex = 21
        Me.lblEngAreaID.Text = "Geographical area:"
        Me.lblEngAreaID.Visible = False
        '
        'lblEngPlace
        '
        Me.lblEngPlace.AutoSize = True
        Me.lblEngPlace.Location = New System.Drawing.Point(23, 109)
        Me.lblEngPlace.Name = "lblEngPlace"
        Me.lblEngPlace.Size = New System.Drawing.Size(98, 13)
        Me.lblEngPlace.TabIndex = 20
        Me.lblEngPlace.Text = "Geographical level:"
        Me.lblEngPlace.Visible = False
        '
        'cmbPlace
        '
        Me.cmbPlace.DataSource = Me.Udp_area_levels_configureBindingSource
        Me.cmbPlace.DisplayMember = "Area_Level_Name"
        Me.cmbPlace.FormattingEnabled = True
        Me.cmbPlace.Location = New System.Drawing.Point(130, 106)
        Me.cmbPlace.Name = "cmbPlace"
        Me.cmbPlace.Size = New System.Drawing.Size(139, 21)
        Me.cmbPlace.TabIndex = 1
        Me.cmbPlace.ValueMember = "Area_Level"
        '
        'Udp_area_levels_configureBindingSource
        '
        Me.Udp_area_levels_configureBindingSource.DataMember = "udp_area_levels_configure"
        Me.Udp_area_levels_configureBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'LGMDdataDataSet
        '
        Me.LGMDdataDataSet.DataSetName = "LGMDdataDataSet"
        Me.LGMDdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbAreaID
        '
        Me.cmbAreaID.DataSource = Me.Udp_geo_list_configureBindingSource
        Me.cmbAreaID.DisplayMember = "Area_Name"
        Me.cmbAreaID.FormattingEnabled = True
        Me.cmbAreaID.Location = New System.Drawing.Point(130, 140)
        Me.cmbAreaID.Name = "cmbAreaID"
        Me.cmbAreaID.Size = New System.Drawing.Size(139, 21)
        Me.cmbAreaID.TabIndex = 2
        Me.cmbAreaID.ValueMember = "Area_ID"
        '
        'Udp_geo_list_configureBindingSource
        '
        Me.Udp_geo_list_configureBindingSource.DataMember = "udp_geo_list_configure"
        Me.Udp_geo_list_configureBindingSource.DataSource = Me.LGMDdataDataSet
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Welcome to LGMD2"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(48, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 30)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Please configure the system by choosing which level you are at"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Udp_area_levels_configureTableAdapter
        '
        Me.Udp_area_levels_configureTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        'Me.TableAdapterManager.tbl_setup_form_typesTableAdapter = Nothing
        'Me.TableAdapterManager.tblGroupRightsTableAdapter = Nothing
        'Me.TableAdapterManager.tblGroupsTableAdapter = Nothing
        'Me.TableAdapterManager.tblInstitutionsTableAdapter = Nothing
        'Me.TableAdapterManager.tblRightsTableAdapter = Nothing
        Me.TableAdapterManager.tblUserGroupTableAdapter = Nothing
        Me.TableAdapterManager.tblUsersTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Udp_geo_list_configureTableAdapter
        '
        Me.Udp_geo_list_configureTableAdapter.ClearBeforeFill = True
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(106, 191)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(92, 30)
        Me.btnConfig.TabIndex = 3
        Me.btnConfig.Text = "Configure"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 249)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSwaAreaID)
        Me.Controls.Add(Me.lblSwaPlace)
        Me.Controls.Add(Me.lblEngAreaID)
        Me.Controls.Add(Me.lblEngPlace)
        Me.Controls.Add(Me.cmbPlace)
        Me.Controls.Add(Me.cmbAreaID)
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuration"
        CType(Me.Udp_area_levels_configureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LGMDdataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Udp_geo_list_configureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSwaAreaID As System.Windows.Forms.Label
    Friend WithEvents lblSwaPlace As System.Windows.Forms.Label
    Friend WithEvents lblEngAreaID As System.Windows.Forms.Label
    Friend WithEvents lblEngPlace As System.Windows.Forms.Label
    Friend WithEvents cmbPlace As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAreaID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LGMDdataDataSet As LGMD.LGMDdataDataSet
    Friend WithEvents Udp_area_levels_configureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Udp_area_levels_configureTableAdapter As LGMD.LGMDdataDataSetTableAdapters.udp_area_levels_configureTableAdapter
    Friend WithEvents TableAdapterManager As LGMD.LGMDdataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Udp_geo_list_configureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Udp_geo_list_configureTableAdapter As LGMD.LGMDdataDataSetTableAdapters.udp_geo_list_configureTableAdapter
    Friend WithEvents btnConfig As System.Windows.Forms.Button
End Class
