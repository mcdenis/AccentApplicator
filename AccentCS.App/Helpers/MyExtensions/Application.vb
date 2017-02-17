Namespace My
    Partial Friend Class MyApplication

        ''' <summary>
        ''' Returns a new image representing the application logo.
        ''' </summary>
        ''' <returns></returns>
        Friend Function GetLogo() As Imaging.Metafile
            Using stream As New IO.MemoryStream(My.Resources.Logo)
                Return New Imaging.Metafile(stream)
            End Using
        End Function


        'Btw, we use a method for the logo, but a property for the icon
        'because it is resonable to cache the icon, a reference of which
        'is always used by the tray icon. On the other hand, the logo is 
        'rarely needed and takes quite a lot of memory.
        Private _icon As Icon
        ''' <summary>
        ''' An icon representing the application.
        ''' </summary>
        ''' <returns></returns>
        Friend ReadOnly Property Icon As Icon
            Get
                If _icon Is Nothing Then
                    _icon = GetIcon()
                End If
                Return _icon
            End Get
        End Property

        Private Function GetIcon() As Icon
            Using mtf As Imaging.Metafile = GetLogo()
                Using bmp As Bitmap = mtf.ToBitmap(New Size(256, 256))
                    Return Icon.FromHandle(bmp.GetHicon)
                End Using
            End Using
        End Function

    End Class
End Namespace
