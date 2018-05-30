Imports AccentApplicator.Core
Imports AccentCS.App.Events

Namespace Views.Interfaces
    Public Interface IMainView
        Inherits IView

        ''' <summary>
        '''     Occurs when the user requests the to see the option to set the 
        '''     brightness for a system color.
        ''' </summary>
        Event BrightnessSettingsClicked As EventHandler(Of SystemColorEventArgs)

        ''' <summary>
        '''     Occurs when the user requests the ability to set the foreground
        '''     color associated with the specified system color.
        ''' </summary>
        Event SetForeColorClicked As EventHandler(Of SystemColorEventArgs)

        ''' <summary>
        '''     Occurs when the menu that offers options to the user related to a
        '''     specific system color is shown.
        ''' </summary>
        Event SystemColorConfigMenuShowing As EventHandler(Of ControlEventArgs(Of ContextMenuStrip))

        ''' <summary>
        '''     Sets the tooltip text for the preview of the accent color.
        ''' </summary>
        ''' <param name="text"></param>
        Sub SetAccentPreviewTooltipText(text As String)

        ''' <summary>
        '''     Sets the tooltip text for the preview of the specified system color.
        ''' </summary>
        ''' <param name="systemColorId">Specifies for which preview the message should be applied.</param>
        ''' <param name="systemColortext">Specifies the content of the message.</param>
        Sub SetSystemColorPreviewTooltipText(systemColorId As SystemColorId, systemColortext As String)
    End Interface
End Namespace