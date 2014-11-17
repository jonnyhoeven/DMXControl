
' Copyright (C) Jonny van der Hoeven

' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.

' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.

' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>

Public Class MainForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Starts the open DMX node
        FTD.initOpenDMX()
        FTD.start()
    End Sub


    Private Sub UpdateLuikStatus(LState As LuikControl.Enum_Status)
        'change state of Luik
        Dim MyControl As Control
        Dim MyLuikControl As LuikControl

        For Each MyControl In Controls
            If TypeOf MyControl Is LuikControl Then
                MyLuikControl = MyControl

                If MyLuikControl.IsSelected Then
                    MyLuikControl.LuikStatus = LState
                End If

            End If
        Next
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        UpdateLuikStatus(LuikControl.Enum_Status._LMovingOpen)
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        UpdateLuikStatus(LuikControl.Enum_Status._LUnknown)
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        UpdateLuikStatus(LuikControl.Enum_Status._LMovingClose)
    End Sub


    Private Sub UpdateLuikSel(LSel As Boolean)
        ' update selection state
        Dim MyControl As Control
        Dim MyLuikControl As LuikControl

        For Each MyControl In Controls
            If TypeOf MyControl Is LuikControl Then
                MyLuikControl = MyControl
                MyLuikControl.IsSelected = LSel
            End If
        Next
    End Sub

    Private Sub AllSelButton_Click(sender As Object, e As EventArgs) Handles AllSelButton.Click

        UpdateLuikSel(True)
    End Sub
    Private Sub NoSelButton_Click(sender As Object, e As EventArgs) Handles NoSelButton.Click
        UpdateLuikSel(False)
    End Sub
End Class