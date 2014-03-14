Imports System
Imports System.Web
Imports System.Windows.Forms.Control
Imports System.Data
Imports System.Configuration
Public Class ctrlTreeView
    Inherits TreeView
    Dim oText As Object = ""
    Dim oTag As Object = ""
    Dim oID As Object = ""
    Dim oParentID As Object = ""
    Dim oTbl As String = ""
    Dim oDs As New DataSet
    Dim tv As New TreeView
    Dim oTreeView As New TreeView
    Dim strParentColumn As String = ""
    Dim strTag As String = ""
    Dim strPreviousTag As String = ""

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles Me.Load
        Me.DataFieldID = "ShortName"
        Me.DataFieldParentID = "Category"
        Me.DataTextField = "Description"

        PerformDataBinding(oDs)
    End Sub

    'Namespace CPArticles
    'Public Class AutoBindingTree
    '  Inherits DataBoundControl

#Region "Public Properties"
    ''' <summary>
    ''' The name of the column holding the Text Value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataTextField() As String
        Get
            'Dim oText As Object = "TermID" ' = ViewState("DataTextField")
            If oText Is Nothing Then
                Return String.Empty
            Else
                Return CStr(oText)
            End If
        End Get
        Set(ByVal value As String)
            oText = value
            'ViewState("DataTextField") = value
            'If (Initialized) Then
            'OnDataPropertyChanged()
            'End If
        End Set
    End Property
    ''' <summary>
    ''' The name of the column holding the Text Value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataTagField() As String
        Get
            'Dim oText As Object = "TermID" ' = ViewState("DataTextField")
            If oTag Is Nothing Then
                Return String.Empty
            Else
                Return CStr(oTag)
            End If
        End Get
        Set(ByVal value As String)
            oTag = value
            'ViewState("DataTextField") = value
            'If (Initialized) Then
            'OnDataPropertyChanged()
            'End If
        End Set
    End Property
    ''' <summary>
    ''' The name of the Column holding the ID value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataFieldID() As String
        Get
            '= ViewState("DataFieldID")
            If oID Is Nothing Then
                Return String.Empty
            Else
                Return CStr(oID)
            End If
        End Get
        Set(ByVal value As String)
            ' ViewState("DataFieldID") = value
            oID = value
        End Set
    End Property
    ''' <summary>
    ''' The name of the Column holding the ParentID value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataFieldParentID() As String
        Get
            'Dim oParentID As Object '= ViewState("DataFieldParentID")
            If oParentID Is Nothing Then
                Return String.Empty
            Else
                Return CStr(oParentID)
            End If
        End Get
        Set(ByVal value As String)
            ' ViewState("DataFieldParentID") = value
            oParentID = value
        End Set
    End Property
    ''' <summary>
    ''' The name of the Column holding the ParentID value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TableName() As String
        Get
            'Dim oParentID As Object '= ViewState("DataFieldParentID")
            If oTbl Is Nothing Then
                Return String.Empty
            Else
                Return CStr(oTbl)
            End If
        End Get
        Set(ByVal value As String)
            ' ViewState("DataFieldParentID") = value
            oTbl = value
        End Set
    End Property
#End Region

#Region "Data Bound Events"
    Protected Sub PerformSelect()
        '' Call OnDataBinding here if bound to a data source using the
        '' DataSource property (instead of a DataSourceID), because the
        '' databinding statement is evaluated before the call to GetData.       
        'If Not IsBoundUsingDataSourceID Then
        '    OnDataBinding(EventArgs.Empty)
        'End If

        '' The GetData method retrieves the DataSourceView object from  
        '' the IDataSource associated with the data-bound control.            
        'GetData().Select(CreateDataSourceSelectArguments(), _
        '    AddressOf OnDataSourceViewSelectCallback)

        '' The PerformDataBinding method has completed.
        'ReqHEMISresDataBinding = False
        'MarkAsDataBound()

        '' Raise the DataBound event.
        'OnDataBound(EventArgs.Empty)

    End Sub

    Private Sub OnDataSourceViewSelectCallback(ByVal retrievedData As IEnumerable)
        '' Call OnDataBinding only if it has not already been 
        '' called in the PerformSelect method.
        'If IsBoundUsingDataSourceID Then
        '    OnDataBinding(EventArgs.Empty)
        'End If
        '' The PerformDataBinding method binds the data in the  
        '' retrievedData collection to elements of the data-bound control.
        'PerformDataBinding(retrievedData)

    End Sub

    Protected Sub PerformDataBinding(ByVal oSourceData As DataSet)
        ' MyBase.PerformDataBinding(oSourceData)

        ' Verify data exists.
        If Not (oSourceData Is Nothing) Then
            'Dim oView As DataView = oSourceData
            'Dim oTable As DataTable = oView.Table
            'Dim oView As DataView = oSourceData
            Dim oTable As DataTable = oSourceData.Tables(oTbl)
            Dim oDS As DataSet = oSourceData 'New DataSet()
            'oDS.Tables.Add(oTable.Copy())

            'Create a Relation Between the ID Column and Parent Column
            Try
                If oDS.Relations.Contains("SelfRefenceRelation") = False Then
                    oDS.Relations.Add("SelfRefenceRelation", oDS.Tables(TableName).Columns(DataFieldID), oDS.Tables(TableName).Columns(DataFieldParentID))
                    ' oDS.Relations.Add("SelfRefenceRelation", oDS.Tables(0).Columns("MenuDesc"), oDS.Tables(0).Columns("MenuParent"))
                End If
            Catch ex As Exception
                '  MsgBox(ex.Message)
                '            Exit Sub
            End Try


            ' oTable.Dispose()
            ' oTable = Nothing

            'ViewState("TreeData") = oDS
            LoadTreeView(oDS)

            oDS.Dispose()
            oDS = Nothing
        End If
    End Sub
#End Region

#Region "Tree Functions"
    ''' <summary>
    ''' Populate Tree View
    ''' </summary>
    ''' <param name="oDS">Data Set</param>
    ''' <remarks></remarks>
    Private Sub LoadTreeView(ByVal oDS As DataSet)
        'Dim oTreeView As TreeView = tv 'New TreeView() = tv
        Dim oDataRow As DataRow
        For Each oDataRow In oDS.Tables(0).Rows
            'Find Root Node,A root node has ParentID NULL
            If oDataRow.IsNull(DataFieldParentID) Then
                'Create Parent Node and add to tree
                Dim oNode As New TreeNode()
                If DataTextField.Contains("-") Then
                    oNode.Text = oDataRow(DataTextField.Split("-")(0)).ToString() & " " & oDataRow(DataTextField.Split("-")(1)).ToString()
                Else
                    oNode.Text = oDataRow(DataTextField).ToString()
                End If
                oNode.Tag = "" 'DataFieldParentID 'oDataRow(DataFieldID).ToString()

                ' strParentColumn = oNode.Tag
                'oNode.NavigateUrl = oDataRow("NavigateURL").ToString()
                oTreeView.Nodes.Add(oNode)

                'Recurively Populate From root
                RecursivelyLoadTree(oDataRow, oNode)
            End If
        Next oDataRow
        'Me.TestCtrl = oTreeView
        ' tv = oTreeView
        oTreeView.Name = "TreeView"
        oTreeView.Text = "TreeView"
        ' Controls.Add(oTreeView)
        oDS.Dispose()
        oDS = Nothing
    End Sub 'LoadTreeView
    ''' <summary>
    ''' Recursively Load ChildNodes for each Node using the Dataset relation
    ''' </summary>
    ''' <param name="oDataRow">Data Row</param>
    ''' <param name="oNode">Parent Node</param>
    ''' <remarks></remarks>
    Private Sub RecursivelyLoadTree(ByVal oDataRow As DataRow, ByRef oNode As TreeNode)
        Dim oChildRow As DataRow

        'returns an array of DataRow objects representing the child view 
        For Each oChildRow In oDataRow.GetChildRows("SelfRefenceRelation")
            'Create child node and add to Parent
            Dim oChildNode As New TreeNode()

            If DataTextField.Contains("-") Then
                oChildNode.Text = oChildRow(DataTextField.Split("-")(0)).ToString() & " " & oChildRow(DataTextField.Split("-")(1)).ToString()
                'oChildNode.Tag = DataTextField.Split("-")(0).ToString()
                ' oChildNode.Tag = DataTextField.ToString 'DataFieldID.ToString & "= '" & DataTextField.Split("-")(0).ToString & "'"
            Else
                oChildNode.Text = oChildRow(DataTextField).ToString()
                'oChildNode.Tag = DataTextField.ToString()
                'oChildNode.Tag = DataTextField.ToString '& "= '" & DataTextField.ToString & "'"

            End If
            ' strParentColumn = DataFieldID.ToString


            'oChildNode.Value = oChildRow(DataFieldID).ToString()
            'oChildNode.NavigateUrl = oChildRow("NavigateURL").ToString()
            'oNode.ChildNodes.Add(oChildNode)
            oNode.Nodes.Add(oChildNode)
            ' If strTag = oChildRow(DataFieldParentID).ToString() Then
            ' oChildNode.Tag = strPreviousTag
            ' strTag = oChildRow(DataFieldParentID).ToString()
            ' Else
            If oChildNode.Parent.Tag.contains(DataFieldParentID) Then
                'If oChildNode.Parent.Tag.split(".")(1).split("=")(0).ToString = DataFieldParentID Then
                strPreviousTag = DataFieldID
            Else
                strPreviousTag = DataFieldParentID
            End If
            '   If strPreviousTag = DataFieldID Then
            If Len(oChildNode.Parent.Tag) > 0 Then
                If UCase(strPreviousTag) = "YEAR" Or UCase(strPreviousTag) = "ID" Then
                    'oChildNode.Tag = oTbl & "." & strPreviousTag & "='" & oChildRow(strPreviousTag).ToString() & "' and  " & oChildNode.Parent.Tag & ""
                    oChildNode.Tag = strPreviousTag & "='" & oChildRow(strPreviousTag).ToString() & "' and  " & oChildNode.Parent.Tag & ""
                Else
                    'oChildNode.Tag = oTbl & "." & strPreviousTag & "='" & oChildRow(strPreviousTag).ToString() & "' and  " & oChildNode.Parent.Tag & ""
                    oChildNode.Tag = strPreviousTag & "='" & oChildRow(strPreviousTag).ToString() & "' and  " & oChildNode.Parent.Tag & ""
                End If
            Else
                If UCase(strPreviousTag) = "YEAR" Or UCase(strPreviousTag) = "ID" Then
                    'oChildNode.Tag = oTbl & "." & strPreviousTag & "='" & oChildRow(DataFieldID).ToString() & "'"
                    oChildNode.Tag = strPreviousTag & "='" & oChildRow(DataFieldID).ToString() & "'"
                Else
                    'oChildNode.Tag = oTbl & "." & strPreviousTag & "='" & oChildRow(DataFieldID).ToString() & "'"
                    oChildNode.Tag = strPreviousTag & "='" & oChildRow(DataFieldID).ToString() & "'"
                End If

            End If
            'Else
            'oChildNode.Tag = strPreviousTag 'DataFieldID
            'End If
            strTag = oChildRow(DataFieldParentID).ToString()
            'End If
            'Repeat for each child
            RecursivelyLoadTree(oChildRow, oChildNode)
        Next oChildRow
    End Sub 'RecursivelyLoadTree
#End Region

#Region "View State"
    Protected Function SaveViewState() As Object
        'Dim baseState As Object = MyBase.SaveViewState()
        Dim allStates() As Object = New Object(2) {}
        ' allStates(0) = baseState
        ' allStates(1) = ViewState("TreeData")
        Return allStates
    End Function
    Protected Sub LoadViewState(ByVal savedState As Object)
        If Not savedState Is Nothing Then
            Dim myState() As Object = CType(savedState, Object())
            If Not myState(0) Is Nothing Then
                'MyBase.LoadViewState(myState(0))
            End If
            If Not myState(1) Is Nothing Then
                '  ViewState("TreeData") = CType(myState(1), DataSet)
            End If
            'If Not ViewState("TreeData") Is Nothing Then
            '    '   LoadTreeView(CType(ViewState("TreeData"), DataSet))
            'End If
        End If
    End Sub
#End Region
    '    End Class
    '
    Public Sub New(ByRef c As TreeView, ByVal oDs As DataSet, ByVal otbl As String, Optional ByVal oID As String = "", Optional ByVal oParentID As String = "", Optional ByVal oText As String = "", Optional ByRef oParentColumn As String = "")

        ' This call is reqHEMISred by the Windows Form Designer.
        InitializeComponent()
        oDs = oDs
        Me.DataFieldID = oID
        Me.DataFieldParentID = oParentID
        Me.DataTextField = oText
        'Me.DataTagField = oTag
        Me.TableName = otbl
        'oDs.Load( = "select " & oID & " , " & oParentID & "," & oText & " from " & otbl & " group by " & oID & " , " & oParentID & "," & oText & "" 'otbl"
        oTreeView = c

        PerformDataBinding(oDs)
        oParentColumn = oParentID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class