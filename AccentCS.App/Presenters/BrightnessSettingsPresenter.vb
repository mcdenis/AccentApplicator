Imports AccentApplicator.Core
Imports AccentCS.App.CustomApplicators
Imports AccentCS.App.Views.Interfaces

Namespace Presenters
    Public Class BrightnessSettingsPresenter
        Inherits Presenter(Of IBrightnessSettingsView)

        Public ReadOnly Property AffectedSystemColor As SystemColorId

        Public Sub New(systemColor As SystemColorId, view As IBrightnessSettingsView)
            MyBase.New(view)

            AffectedSystemColor = systemColor

            AddHandler view.Load, AddressOf View_Load
            AddHandler view.Submitted, AddressOf View_Submitted
        End Sub

        Private Sub View_Load(sender As Object, e As EventArgs)
            'Sets the initial values of the view
            View.SetBrightness = AccentableSystemColorApplicator.Instance.ColorSettings(AffectedSystemColor).UseUserBrightness
            View.Brightness = AccentableSystemColorApplicator.Instance.ColorSettings(AffectedSystemColor).UserBrightness
        End Sub

        Private Sub View_Submitted(sender As Object, e As EventArgs)
            'Apply the settings to the applicator.
            AccentableSystemColorApplicator.Instance.ColorSettings(AffectedSystemColor).UseUserBrightness = View.SetBrightness
            AccentableSystemColorApplicator.Instance.ColorSettings(AffectedSystemColor).UserBrightness = View.Brightness
        End Sub

    End Class
End Namespace
