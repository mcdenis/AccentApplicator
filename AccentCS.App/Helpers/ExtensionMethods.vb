Imports System.Runtime.CompilerServices

Module ExtensionMethods

    ''' <summary>
    ''' Returns a string in the "R G B" format that can be written
    ''' in the HKCU/Control Panel/Colors registry key or shown to the user.
    ''' </summary>
    ''' <param name="aColor"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ToRGBString(aColor As Color) As String
        Dim r As Integer = aColor.R
        Dim g As Integer = aColor.G
        Dim B As Integer = aColor.B
        Return r.ToString & " " & g.ToString & " " & B.ToString
    End Function

    ''' <summary>
    ''' Converts the Metafile to to a Bitmap fiting the maximum size given while preserving the aspect ratio.
    ''' </summary>
    ''' <param name="aMetafile"></param>
    ''' <param name="pMaxSize"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ToBitmap(aMetafile As Imaging.Metafile, pMaxSize As Size) As Bitmap
        Dim tabScalings(1) As Single
        tabScalings(0) = pMaxSize.Width / CType(aMetafile.Width, Single)
        tabScalings(1) = pMaxSize.Height / CType(aMetafile.Height, Single)

        'Gets the smallest scalling factor so that the image fits in the specified max size.
        'I am not sure this would work in a situation where the Metafile and/or the Graphics have
        'a different horizontal/vertical resolution ratio.
        Dim flScalingToUse As Single = tabScalings.Min


        Dim bmp As New Bitmap(CInt(aMetafile.Width * flScalingToUse), CInt(aMetafile.Height * flScalingToUse))
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(aMetafile, 0, 0, bmp.Size.Width, bmp.Size.Height)
            'g.DrawRectangle(Pens.Red, New Rectangle(Point.Empty, bmp.Size - New Size(1, 1)))
            g.Flush()
        End Using
        Return bmp
    End Function
End Module
