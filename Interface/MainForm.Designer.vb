<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.AllSelButton = New System.Windows.Forms.Button()
        Me.NoSelButton = New System.Windows.Forms.Button()
        Me.LuikControl3 = New [Interface].LuikControl()
        Me.LuikControl2 = New [Interface].LuikControl()
        Me.LuikControl1 = New [Interface].LuikControl()
        Me.FaderControl1 = New [Interface].FaderControl()
        Me.SuspendLayout()
        '
        'OpenButton
        '
        Me.OpenButton.Location = New System.Drawing.Point(12, 179)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(75, 23)
        Me.OpenButton.TabIndex = 3
        Me.OpenButton.Text = "&Open"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(93, 179)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(75, 23)
        Me.StopButton.TabIndex = 4
        Me.StopButton.Text = "&Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(174, 179)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 5
        Me.CloseButton.Text = "&Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'AllSelButton
        '
        Me.AllSelButton.Location = New System.Drawing.Point(12, 208)
        Me.AllSelButton.Name = "AllSelButton"
        Me.AllSelButton.Size = New System.Drawing.Size(103, 23)
        Me.AllSelButton.TabIndex = 6
        Me.AllSelButton.Text = "Alles Selecteren"
        Me.AllSelButton.UseVisualStyleBackColor = True
        '
        'NoSelButton
        '
        Me.NoSelButton.Location = New System.Drawing.Point(146, 208)
        Me.NoSelButton.Name = "NoSelButton"
        Me.NoSelButton.Size = New System.Drawing.Size(103, 23)
        Me.NoSelButton.TabIndex = 7
        Me.NoSelButton.Text = "Geen Selectie"
        Me.NoSelButton.UseVisualStyleBackColor = True
        '
        'LuikControl3
        '
        Me.LuikControl3.DmxChannelClose = CType(0, Short)
        Me.LuikControl3.DmxChannelOpen = CType(0, Short)
        Me.LuikControl3.IsSelected = False
        Me.LuikControl3.Location = New System.Drawing.Point(228, 12)
        Me.LuikControl3.LuikName = "Test"
        Me.LuikControl3.LuikStatus = [Interface].LuikControl.Enum_Status._LUnknown
        Me.LuikControl3.Name = "LuikControl3"
        Me.LuikControl3.Size = New System.Drawing.Size(102, 77)
        Me.LuikControl3.TabIndex = 2
        '
        'LuikControl2
        '
        Me.LuikControl2.DmxChannelClose = CType(0, Short)
        Me.LuikControl2.DmxChannelOpen = CType(0, Short)
        Me.LuikControl2.IsSelected = False
        Me.LuikControl2.Location = New System.Drawing.Point(120, 12)
        Me.LuikControl2.LuikName = "Test"
        Me.LuikControl2.LuikStatus = [Interface].LuikControl.Enum_Status._LUnknown
        Me.LuikControl2.Name = "LuikControl2"
        Me.LuikControl2.Size = New System.Drawing.Size(102, 77)
        Me.LuikControl2.TabIndex = 1
        '
        'LuikControl1
        '
        Me.LuikControl1.DmxChannelClose = CType(0, Short)
        Me.LuikControl1.DmxChannelOpen = CType(0, Short)
        Me.LuikControl1.IsSelected = False
        Me.LuikControl1.Location = New System.Drawing.Point(12, 12)
        Me.LuikControl1.LuikName = "Test"
        Me.LuikControl1.LuikStatus = [Interface].LuikControl.Enum_Status._LUnknown
        Me.LuikControl1.Name = "LuikControl1"
        Me.LuikControl1.Size = New System.Drawing.Size(102, 77)
        Me.LuikControl1.TabIndex = 0
        '
        'FaderControl1
        '
        Me.FaderControl1.Location = New System.Drawing.Point(12, 112)
        Me.FaderControl1.Name = "FaderControl1"
        Me.FaderControl1.Size = New System.Drawing.Size(131, 52)
        Me.FaderControl1.TabIndex = 8
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 247)
        Me.Controls.Add(Me.FaderControl1)
        Me.Controls.Add(Me.NoSelButton)
        Me.Controls.Add(Me.AllSelButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.LuikControl3)
        Me.Controls.Add(Me.LuikControl2)
        Me.Controls.Add(Me.LuikControl1)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LuikControl1 As LuikControl
    Friend WithEvents LuikControl2 As LuikControl
    Friend WithEvents LuikControl3 As LuikControl
    Friend WithEvents OpenButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents AllSelButton As System.Windows.Forms.Button
    Friend WithEvents NoSelButton As System.Windows.Forms.Button
    Friend WithEvents FaderControl1 As FaderControl
End Class
