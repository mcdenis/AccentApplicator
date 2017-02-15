Namespace My

    Partial Friend Class MyComputer
        ''' <summary>
        ''' Gets a value indicating if colored title bars are enabled in Windows.
        ''' </summary>
        ''' <returns></returns>
        Friend ReadOnly Property ColoredTitleBarState As Integer
            Get
                Return GetWindowsColoredTitleBar()
            End Get
        End Property

        Private Function GetWindowsColoredTitleBar() As Integer
            Dim inRegValue As Integer
            Try
                inRegValue = DirectCast(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\DWM\", "ColorPrevalence", Nothing), Integer)
            Catch ex As Exception
                Return 1
            End Try
            Return inRegValue
        End Function
    End Class
End Namespace
