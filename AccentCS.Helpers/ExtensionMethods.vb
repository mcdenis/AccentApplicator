Imports System.Drawing
Imports System.Runtime.CompilerServices

Module ExtensionMethods

    ''' <summary>
    ''' Invert a color while preserving the alpha value.
    ''' </summary>
    ''' <param name="aColor"></param>
    ''' <returns></returns>
    <Extension()>
    Friend Function Invert(aColor As Color) As Color
        Return Color.FromArgb(aColor.A, aColor.B, aColor.G, aColor.R)
    End Function


End Module
