Public Class LuikControl
    Inherits System.Windows.Forms.UserControl

    Private _IsSelected As Boolean      ' selection state
    Private _Status As String           ' movement state
    Private _OpenDMXChannel As Int16    ' channel for open command
    Private _CloseDMXChannel As Int16   ' channel for close command

    Public Enum Enum_Status
        _LUnknown = 0
        _LClosed = 1
        _LOpen = 2
        _LMovingClose = 3
        _LMovingOpen = 4
    End Enum

    Public Property IsSelected() As Boolean
        Get
            Return _IsSelected
        End Get
        Set(ByVal value As Boolean)
            _IsSelected = value
            UpdateState()
        End Set
    End Property

    Public Property LuikName() As String
        Get
            Return SelectButton.Text
        End Get
        Set(ByVal value As String)
            SelectButton.Text = value
        End Set
    End Property

    Public Property DmxChannelOpen() As Int16
        Get
            Return _OpenDMXChannel
        End Get
        Set(ByVal value As Int16)
            _OpenDMXChannel = value
        End Set
    End Property
    Public Property DmxChannelClose() As Int16
        Get
            Return _CloseDMXChannel
        End Get
        Set(ByVal value As Int16)
            _CloseDMXChannel = value
        End Set
    End Property

    Public Property LuikStatus() As Enum_Status
        Get
            Return _Status
        End Get
        Set(ByVal value As Enum_Status)
            _Status = value
            UpdateState()
        End Set
    End Property

    Private ReadOnly Property IsSelectToInt As Integer
        Get
            If _IsSelected = True Then
                Return 1
            Else
                Return 0
            End If
        End Get
    End Property

    Sub UpdateState()
        Dim Objectname As String
        Dim OChan As Int16
        Dim CChan As Int16


        If _Status = Enum_Status._LMovingClose Then
            StopMoveTimer.Start()
            OChan = 0
            CChan = 255
        ElseIf _Status = Enum_Status._LMovingOpen Then
            StopMoveTimer.Start()
            OChan = 255
            CChan = 0
        Else
            StopMoveTimer.Stop()
            OChan = 0
            CChan = 0
        End If

        ' Update DMX buffer
        Try
            'clear buffer first
            FTD.buffer(DmxChannelOpen) = 0
            FTD.buffer(DmxChannelClose) = 0

            FTD.buffer(DmxChannelOpen) = OChan
            FTD.buffer(DmxChannelClose) = CChan
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

        ' change image
        Objectname = "lstate" & _Status & IsSelectToInt()
        SelectButton.Image = Global.[Interface].My.Resources.ResourceManager.GetObject(Objectname)

        Objectname = Nothing
        OChan = Nothing
        CChan = Nothing
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        If IsSelected Then
            IsSelected = False
        Else
            IsSelected = True
        End If
    End Sub

    Protected Overridable Sub StopMoveTimer_Tick(sender As Object, e As EventArgs) Handles StopMoveTimer.Tick
        ' when timer ticks stop sending dmx data and change image
        If LuikStatus = Enum_Status._LMovingClose Then
            LuikStatus = Enum_Status._LClosed
        ElseIf _Status = Enum_Status._LMovingOpen Then
            LuikStatus = Enum_Status._LOpen
        End If
    End Sub
End Class
