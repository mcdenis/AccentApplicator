Namespace Events
    Public Class ControlEventArgs(Of TControl As Control)
        Public ReadOnly Property Control As TControl

        Public Sub New(control As TControl)
            Me.Control = control
        End Sub
    End Class
End Namespace