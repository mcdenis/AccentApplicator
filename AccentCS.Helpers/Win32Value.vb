Public Module Win32Value
    Public Enum WM
        DWMCOMPOSITIONCHANGED = &H31E
        DWMNCRENDERINGCHANGED = &H31F
        DWMCOLORIZATIONCOLORCHANGED = &H320
        DWMWINDOWMAXIMIZEDCHANGE = &H321

        STYLECHANGED = &H7D
    End Enum

    Public Enum GWL
        EXSTYLE = -20
        STYLE = -16
    End Enum
End Module
