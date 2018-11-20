Namespace Views
    Public Interface IView

        ''' <summary>
        '''     Occurs when the view is loading.
        ''' </summary>
        Event Load As EventHandler

        ''' <summary>
        '''     Shows the view.
        ''' </summary>
        Sub Show(owner As IWin32Window)

        ''' <summary>
        '''     Main text associated with the view. For example,
        '''     the text in the title bar.
        ''' </summary>
        ''' <returns></returns>
        Property Caption As String
    End Interface
End Namespace