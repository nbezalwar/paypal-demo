<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlAuditObjectLogs
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlAuditObjectLogs))
        Me.logsObj = New AutomateUI.ctlLogList()
        Me.SuspendLayout()
        '
        'logsObj
        '
        resources.ApplyResources(Me.logsObj, "logsObj")
        Me.logsObj.Name = "logsObj"
        Me.logsObj.ProcessType = BluePrism.AutomateProcessCore.Processes.DiagramType.[Object]
        '
        'ctlAuditObjectLogs
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.logsObj)
        Me.Name = "ctlAuditObjectLogs"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents logsObj As AutomateUI.ctlLogList

End Class
