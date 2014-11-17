<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LuikControl
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
        Me.components = New System.ComponentModel.Container()
        Me.StopMoveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'StopMoveTimer
        '
        Me.StopMoveTimer.Interval = 5000
        '
        'SelectButton
        '
        Me.SelectButton.FlatAppearance.BorderSize = 0
        Me.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectButton.Image = Global.[Interface].My.Resources.Resources.lstate00
        Me.SelectButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.SelectButton.Location = New System.Drawing.Point(0, 0)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(104, 79)
        Me.SelectButton.TabIndex = 0
        Me.SelectButton.Text = "Test"
        Me.SelectButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.SelectButton.UseVisualStyleBackColor = False
        '
        'LuikControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SelectButton)
        Me.Name = "LuikControl"
        Me.Size = New System.Drawing.Size(102, 77)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents StopMoveTimer As System.Windows.Forms.Timer

End Class
