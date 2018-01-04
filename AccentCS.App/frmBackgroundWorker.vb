Imports System.Resources
Imports AccentCS.Controls
Imports AccentCS.Helpers

Public Class frmBackgroundWorker

    Private Const inDEFAULT_BALLOON_TIP_TIMEOUT As Integer = 5000

    Private boSafeToSync As Boolean = True
    Private boAutoSyncEnabled As Boolean = True

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        'Set the appearance of the tray icon context menu
        PrepareControls.PrepareContextMenuStripSystems({cmsNotifyIcon}, True)

        'Make the Restore command of the cmsNotifyIcon bold cause it's the main command (the one that's triggered when the icon is double-clicked.)
        tmiNotifyIcon_AppOptions.Font = New Font(tmiNotifyIcon_AppOptions.Font, FontStyle.Bold)

        'Set the appearance of the tray icon
        With NotifyIcon1
            .Icon = My.Application.Icon
            .Text = My.Application.Info.Title
        End With

        'Sync colors right when the app is launched
        If Not Debugger.IsAttached Then
            Try
                Synchronizer.Instance.RestoreLastForeColors()
                Synchronizer.Instance.SyncNow()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

        End If
    End Sub

    Private Sub tmrSpamProtection_Tick(sender As Object, e As EventArgs) Handles tmrSpamProtection.Tick
        tmrSpamProtection.Stop()
        boSafeToSync = True
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        'When DWM Colorization changed
        If m.Msg = Win32Value.WM.DWMCOLORIZATIONCOLORCHANGED And boSafeToSync And boAutoSyncEnabled Then
            boSafeToSync = False

            'Get the accent color.
            'If we use the DWM colorization color, there is no need to "retrieve" it, 
            'we can just use what's already given by the message (WParam).
            Dim colAccent As Color
            If My.Settings.General_AccentSource = AccentSources.DWMColorization Then
                colAccent = Color.FromArgb(255, Color.FromArgb(m.WParam.ToInt32)) 'Dont forget to override the alpha channel to 255.
            Else
                Threading.Thread.Sleep(1000) 'We add this if reading the accent from the registry because there is sometimes a slight delay before the registry value is actually changed.
                colAccent = AccentColor.GetAccentColor(My.Settings.General_AccentSource, pIgnoreAlpha:=True)
            End If

            Try
                Synchronizer.Instance.SyncNow(pAccent:=colAccent)
            Catch ex As Exception
                NotifyIcon1.ShowBalloonTip(inDEFAULT_BALLOON_TIP_TIMEOUT, My.Resources.LocalizedResources.ErrorIntro_LastSyncAttempFailed, ex.Message, ToolTipIcon.Error)
            End Try


            'Sets back the SafeToSync field to True after some time.
            tmrSpamProtection.Start()
        End If
    End Sub

    'Ensure the form is always hidden.
    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)

        If Visible Then
            Hide()
        End If
    End Sub

    Private Sub tmiNotifyIcon_AppOptions_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_AppOptions.Click, NotifyIcon1.DoubleClick
        frmMain.ShowSingleInstance()
    End Sub

    Private Sub tmiNotifyIcon_SyncNow_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_SyncNow.Click
        Try
            Synchronizer.Instance.SyncNow()
        Catch ex As Exception
            MsgBox(My.Resources.LocalizedResources.ErrorIntro_LastSyncAttempFailed +
                   Environment.NewLine + Environment.NewLine +
                   ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub tmiNotifyIcon_ExitApp_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_ExitApp.Click
        Application.Exit()
    End Sub

    Private Sub tmiNotifyIcon_AboutApp_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_AboutApp.Click
        frmAboutBox.ShowSingleInstance()
    End Sub
End Class