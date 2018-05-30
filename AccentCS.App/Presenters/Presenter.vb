Namespace Presenters
    ''' <summary>
    '''     Base class for presenters.
    ''' </summary>
    ''' <typeparam name="TView">Type of the view. Ideally an interface. Ex. IMainView</typeparam>
    Public MustInherit Class Presenter(Of TView)
        ''' <summary>
        '''     View that this presenter instance is manipulating.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property View As TView

        ''' <summary>
        '''     Initialize a new Presenter for the specified view.
        ''' </summary>
        ''' <param name="view">View that the presenter should manipulate.</param>
        Public Sub New(view As TView)
            If view Is Nothing Then
                Throw New ArgumentNullException(NameOf(view))
            End If
            Me.View = view
        End Sub
    End Class
End Namespace