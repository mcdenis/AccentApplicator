Imports AccentApplicator.Core

Namespace Events
    Public Class SystemColorEventArgs
        Inherits EventArgs
        Public ReadOnly Property SystemColor As SystemColorId

        Public Sub New(systemColor As SystemColorId)
            Me.SystemColor = systemColor
        End Sub
    End Class
End Namespace