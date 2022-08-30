Imports BluePrism.AutomateProcessCore
Imports BluePrism.AutomateAppCore
Imports BluePrism.BPCoreLib
Imports BluePrism.Core.StageExecutions

''' Project  : Automate
''' Class    : clsExpressionTreeView
'''
''' <summary>
''' A TreeView subclass used to display expression operators and functions.
''' </summary>
Public Class clsExpressionTreeView
    Inherits TreeView

#Region "Properties"
    ''' <summary>
    ''' The process the tree view is for. Must be set after construction
    ''' and before attempting to populate the view.
    ''' </summary>
    Public Property Process() As BluePrismProcess
        Get
            Return mobjProcess
        End Get
        Set(ByVal Value As BluePrismProcess)
            mobjProcess = Value
        End Set
    End Property
    Private mobjProcess As BluePrismProcess

#End Region

#Region "Constructor"

    ''' <summary>
    ''' Constructor. The Process property must be set before the
    ''' tree view can be used.
    ''' </summary>
    Public Sub New()
        MyBase.New()
        Me.Indent = 20
        Me.ItemHeight = 20
        Me.Scrollable = True
        Me.Sorted = True
        mobjProcess = Nothing
    End Sub

#End Region

#Region "Populate"

    ''' <summary>
    ''' Populate the tree view with nodes representing possible
    ''' expression components.
    ''' </summary>
    ''' <remarks>
    ''' The Process property must have been set, otherwise an
    ''' ApplicationException will be thrown.
    ''' </remarks>
    Public Sub Populate()

        If mobjProcess Is Nothing Then
            Throw New InvalidOperationException("clsExpressionTreeView used without Process property being set")
        End If

        Nodes.Clear()

        Dim objFunctions As Functions

        objFunctions = mobjProcess.Functions
        For Each groupName As String In objFunctions.GroupNames
            Dim treenode As TreeNode = New TreeNode(groupName)
            treenode.Name = treenode.Text

            Dim friendlyName As String = GetLocalizedFriendlyName(treenode.Text)
            treenode.Text = CStr(IIf(friendlyName Is Nothing, treenode.Text, friendlyName))
            Nodes.Add(treenode)
        Next

        Dim nodeGroup, nodeFunction As TreeNode
        Dim objFunction As [Function]
        Dim AllFunctionKeys As List(Of String) = objFunctions.AllFunctions.Keys.ToList

        If Process.ExecutionEnvironment.HasFlag(ExecutionEnvironment.Desktop) Then
            AllFunctionKeys.Remove("IsStopRequested")
        End If

        'Add each function to the appropriate group node
        For Each s As String In AllFunctionKeys
            objFunction = objFunctions.AllFunctions.Item(s)
            For Each nodeGroup In Nodes
                If nodeGroup.Name = objFunction.GroupName Then
                    nodeFunction = New TreeNode(objFunction.Name) With {
                        .Tag = objFunction
                    }
                    nodeGroup.Nodes.Add(nodeFunction)
                    Exit For
                End If
            Next
        Next

        Dim aOperators As ProcessOperators.ProcessOperator()
        Dim objOperator As ProcessOperators.ProcessOperator

        'Add each operator to the appropriate group node
        aOperators = ProcessOperators.GetOperators
        For Each objOperator In aOperators
            For Each nodeGroup In Nodes
                If nodeGroup.Name = objOperator.GroupName Then
                    nodeFunction = New TreeNode(objOperator.Name & " (" & objOperator.Symbol & ")") With {
                        .Tag = objOperator
                    }
                    nodeGroup.Nodes.Add(nodeFunction)
                    Exit For
                End If
            Next
        Next

        'Add Exception Types
        For Each nodeGroup In Nodes
            If nodeGroup.Name = My.Resources.Exceptions Or nodeGroup.Name = "Exceptions" Then
                Dim nodExceptionTypes As New TreeNode(My.Resources.ExceptionTypes)
                nodeGroup.Nodes.Add(nodExceptionTypes)

                Try
                    Dim exceptionTypes = gSv.GetExceptionTypes()
                    For Each s As String In exceptionTypes
                        nodeFunction = NewExceptionType(s)
                        nodExceptionTypes.Nodes.Add(nodeFunction)
                    Next
                Catch ex As Exception
                    UserMessage.ShowExceptionMessage(ex)
                End Try

                nodeFunction = NewExceptionType("Internal")
                nodExceptionTypes.Nodes.Add(nodeFunction)
                Exit For
            End If
        Next

        'Add True and False 'function' nodes
        For Each nodeGroup In Nodes
            If nodeGroup.Name = My.Resources.Logic Or nodeGroup.Name = "Logic" Then
                nodeFunction = New TreeNode("True")
                Dim value As New LiteralValue With {
                    .DataType = DataType.flag,
                    .GroupName = My.Resources.Logic,
                    .HelpText = My.Resources.LiteralFlagValueOfTrue,
                    .Name = "True"
                }
                nodeFunction.Tag = value
                nodeGroup.Nodes.Add(nodeFunction)
                nodeFunction = New TreeNode("False")
                value = New LiteralValue With {
                    .DataType = DataType.flag,
                    .GroupName = My.Resources.Logic,
                    .HelpText = My.Resources.LiteralFlagValueOfFalse,
                    .Name = "False"
                }
                nodeFunction.Tag = value
                nodeGroup.Nodes.Add(nodeFunction)
                Exit For
            End If
        Next

    End Sub

    ''' <summary>
    ''' Gets the localized friendly name For this data group according To the current culture.
    ''' </summary>
    ''' <param name="type">The data group type</param>
    ''' <returns>The name of the data type for the current culture</returns>
    Public Shared Function GetLocalizedFriendlyName(type As String, Optional ByVal bPlural As Boolean = False) As String
        If (bPlural) Then
            Return My.Resources.ResourceManager.GetString($"FunctionGroups_{type.ToLower}_PluralTitle")
        Else
            Return My.Resources.ResourceManager.GetString($"FunctionGroups_{type.ToLower}_Title")
        End If
    End Function

    ''' <summary>
    ''' Little Helper function for creating an exception type node
    ''' </summary>
    Private Function NewExceptionType(ByVal name As String) As TreeNode
        Dim nodFunction As New TreeNode(name)
        Dim l As New LiteralValue
        l.DataType = DataType.text
        l.GroupName = My.Resources.ExceptionTypes
        l.HelpText = My.Resources.LiteralTextValueOfTheExceptionType
        l.Name = name
        nodFunction.Tag = l
        Return nodFunction
    End Function


#End Region

#Region "Event Handlers"

    Private Sub TreeView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        SelectedNode = GetNodeAt(New Point(e.X, e.Y))
    End Sub

    Private Sub TreeView_MouseLeave(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles MyBase.ItemDrag
        If Not e.Item Is Nothing Then
            DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyBase.AfterSelect
        If Not SelectedNode Is Nothing AndAlso Not SelectedNode.Tag Is Nothing Then
            RaiseEvent SelectExpression(SelectedNode.Tag)
        End If
    End Sub

    ''' <summary>
    ''' An event raise when a node is selected.
    ''' </summary>
    ''' <param name="e">The tag object of the selected node</param>
    Public Event SelectExpression(ByVal e As Object)

#End Region

#Region "Class LiteralValue"

    ''' Project  : Automate
    ''' Class    : clsExpressionTreeView.LiteralValue
    '''
    ''' <summary>
    ''' Dummy class knocked together to provide ability to add literal values such
    ''' as True and False to the 'functions' treeview. This class was modelled on
    ''' clsFunctions.clsFunction
    '''
    ''' Corresponding changes to recognise this reference type were required in the
    ''' ctlFunction help box and in the drag drop functionality for the calculation
    ''' stage properties form.
    ''' </summary>
    Public Class LiteralValue

        ''' <summary>
        ''' Private member to store corresponding public property.
        ''' </summary>
        Private mDataType As DataType
        ''' <summary>
        ''' THe data type of this literal value
        ''' </summary>
        ''' <value></value>
        Public Property DataType() As DataType
            Get
                Return mDataType
            End Get
            Set(ByVal Value As DataType)
                mDataType = Value
            End Set
        End Property

        ''' <summary>
        ''' Private member to store corresponding public property.
        ''' </summary>
        Private msGroupName As String
        ''' <summary>
        ''' The name of the group under which this literal value falls.
        ''' </summary>
        ''' <value></value>
        Public Property GroupName() As String
            Get
                Return msGroupName
            End Get
            Set(ByVal Value As String)
                msGroupName = Value
            End Set
        End Property

        ''' <summary>
        ''' Private member to store corresponding public property.
        ''' </summary>
        Private msHelpText As String
        ''' <summary>
        ''' The helptext associated with this literal value
        ''' </summary>
        ''' <value></value>
        Public Property HelpText() As String
            Get
                Return msHelpText
            End Get
            Set(ByVal Value As String)
                msHelpText = Value
            End Set
        End Property

        ''' <summary>
        ''' Private member to store corresponding public property.
        ''' </summary>
        Private msName As String
        ''' <summary>
        ''' The literal text representing this value. eg "True"
        ''' </summary>
        ''' <value></value>
        Public Property Name() As String
            Get
                Return msName
            End Get
            Set(ByVal Value As String)
                msName = Value
            End Set
        End Property

        ''' <summary>
        ''' Private member to store corresponding public property.
        ''' </summary>
        Private msShortDesc As String
        ''' <summary>
        ''' The short description of this value.
        ''' </summary>
        ''' <value></value>
        Public Property ShortDesc() As String
            Get
                Return msShortDesc
            End Get
            Set(ByVal Value As String)
                msShortDesc = Value
            End Set
        End Property
    End Class

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
