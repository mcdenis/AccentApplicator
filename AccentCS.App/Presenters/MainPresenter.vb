Imports AccentCS.App.Events
Imports AccentCS.App.Views.Interfaces

Namespace Presenters
    Public Class MainPresenter
        Inherits Presenter(Of IMainView)

        Public Sub New(mainView As IMainView)
            MyBase.New(mainView)

            'Hook the events
            AddHandler mainView.Load, AddressOf MainView_Load
            AddHandler mainView.BrightnessSettingsClicked, AddressOf MainView_SetBrightnessClicked
            AddHandler mainView.SetForeColorClicked, AddressOf MainView_SetForeColorClicked
            AddHandler mainView.SystemColorConfigMenuShowing, AddressOf MainView_SystemColorConfigMenuShowing
        End Sub

        Private Sub MainView_Load(sender As Object, e As EventArgs)
            With View
                .Caption = My.Application.Info.Title + " Options"
            End With

        End Sub

        Private Sub MainView_SetBrightnessClicked(sender As Object, e As SystemColorEventArgs)
            Throw New NotImplementedException()
        End Sub

        Private Sub MainView_SetForeColorClicked(sender As Object, e As SystemColorEventArgs)
            Throw New NotImplementedException()
        End Sub

        Private Sub MainView_SystemColorConfigMenuShowing(sender As Object, e As ControlEventArgs(Of ContextMenuStrip))
            'We hide the Change foreground color option for the HotTrack color since it does not
            'really have an associated background color.
            Dim PreviewRect As myColorPreviewRectangle = TryCast(e.Control.SourceControl, myColorPreviewRectangle)
            e.Control.Items("tmiSystemColors_ChangeForegroundColor").Visible = PreviewRect.Name <> "cprHotTrack"
        End Sub
    End Class
End Namespace