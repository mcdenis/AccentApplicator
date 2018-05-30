Namespace Views
    Public Interface IView

        ''' <summary>
        '''     Occurs when the view is loading.
        ''' </summary>
        Event Load As EventHandler

        ''' <summary>
        '''     Show the view.
        ''' </summary>
        Sub Show()

        ''' <summary>
        '''     Main text associated with the view. For example,
        '''     the text in the title bar.
        ''' </summary>
        ''' <returns></returns>
        Property Caption As String
    End Interface
End Namespace