'Credits: http://stackoverflow.com/a/4897702

Public Class HorizontalRule
    Inherits Control
    Private Const FixedHeight As Integer = 2

    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const SS_ETCHEDHORZ As Integer = &H10
    Private Const SS_ETCHEDVERT As Integer = &H11

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassName = "STATIC"
            cp.Style = WS_CHILD Or SS_ETCHEDHORZ
            If Me.Visible Then
                cp.Style = cp.Style Or WS_VISIBLE
            End If
            Return cp
        End Get
    End Property

    Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
        height = FixedHeight
        MyBase.SetBoundsCore(x, y, width, height, specified)
    End Sub
End Class