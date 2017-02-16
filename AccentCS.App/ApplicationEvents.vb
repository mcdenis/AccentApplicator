Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            'Show error message if the current software configuration is innapropriate
            If Debugger.IsAttached = False Then
                Dim stMsgDetails As String = ""

                Dim os As OperatingSystem = Environment.OSVersion
                Dim major = os.Version.Major
                If major < 10 Then
                    stMsgDetails += Environment.NewLine + Resources.LocalizedResources.WarningPart_UnsupportedOS
                End If

                If SystemInformation.HighContrast Then
                    stMsgDetails += Environment.NewLine + Resources.LocalizedResources.WarningPart_HighContrast
                End If

                If stMsgDetails <> "" Then
                    'Removes the ponctuation of the last item and replaces it with a period.
                    stMsgDetails = stMsgDetails.Substring(0, stMsgDetails.Length - 1)
                    stMsgDetails += "."
                    'Shows the message.
                    MsgBox(String.Format(Resources.LocalizedResources.WarningPart_Startup, Application.Info.Title) +
                           stMsgDetails, MsgBoxStyle.Exclamation)
                End If
            End If
        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            e.BringToForeground = False 'We disable this because the app has not visible window most of the time anyway.
            MsgBox(String.Format(Resources.LocalizedResources.Info_ExistingAppInstance, Application.Info.Title), MsgBoxStyle.Information)
        End Sub

    End Class
End Namespace
