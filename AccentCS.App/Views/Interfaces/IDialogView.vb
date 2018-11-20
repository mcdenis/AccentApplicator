Namespace Views.Interfaces

    ''' <summary>
    '''     A dialog that the user can submit or dismiss. It should have an OK
    '''     button and optionaly a Cancel and an Apply button.
    ''' </summary>
    ''' <remarks>
    '''     This is not appropriate for a message box since such a dialog may have
    '''     several other results (eg. Yes, No, Retry, etc.)
    ''' </remarks>
    Public Interface IDialogView
        Inherits IView

        ''' <summary>
        '''     Occurs when the user has requested the current state of the view to
        '''     be applied.
        ''' </summary>
        ''' <remarks>
        '''     Usually called when OK or Applied is clicked.
        ''' </remarks>
        Event Submitted As EventHandler

        ''' <summary>
        '''     Shows the view as a modal dialog.
        ''' </summary>
        Sub ShowDialog(owner As IWin32Window)

    End Interface
End Namespace