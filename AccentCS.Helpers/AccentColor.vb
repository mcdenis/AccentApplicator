Imports System.Drawing

''' <summary>
''' Enumeration of possible methods to abtain the accent color.
''' </summary>
Public Enum AccentSources As Integer
    AccentPalette
    DWMAccent
    DWMColorization
End Enum

Public Module AccentColor
    ''' <summary>
    ''' Returns a color representing the system accent color.
    ''' </summary>
    ''' <param name="pSource">The prefered method to use to get the accent color.</param>
    ''' <param name="pFallback">Wether or not a fallback should be used if the prefered method fails.</param>
    ''' <returns></returns>
    Public Function GetAccentColor(pSource As AccentSources, Optional pFallback As Boolean = True, Optional pIgnoreAlpha As Boolean = False) As Color
        Dim c As Color

        'We get the accent using the desired source.
        Select Case pSource
            Case AccentSources.AccentPalette
                c = GetAccentPaletteMainColor()
            Case AccentSources.DWMAccent
                c = GetDWMAccentColor()
            Case AccentSources.DWMColorization
                c = GetDWMColorizationColor()
        End Select

        'If the accent could not be obtained, we fallback on the Immersive accent.
        'Todo: Find a better fallback! I believe the Immersive accent does not even exist on W10!
        If Not c.IsEmpty Or Not pFallback Then
            If pIgnoreAlpha Then
                Return Color.FromArgb(255, c)
            Else
                Return c
            End If
        Else
            Return GetImmersiveAccentColor()
        End If
    End Function

    Private Function GetAccentPaletteMainColor() As Color
        'Reads from the registry
        Dim obRegValue As Object
        Try
            obRegValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentPalette", Nothing)
        Catch ex As Exception
            Return Color.Empty
        End Try
        If obRegValue Is Nothing Then
            Return Color.Empty
        End If

        'Converts the value into a usable color
        Dim byteArray As Byte() = CType(obRegValue, Byte())
        Dim hexString = String.Join("", byteArray.Select(Function(b) b.ToString("X2")))
        Dim SingleHexString As String = "#" & hexString.Substring(24, 6)
        Dim c As Color = ColorTranslator.FromHtml(SingleHexString)

        Return c

    End Function

    Private Function GetDWMAccentColor() As Color
        Dim inDWMAccentColor As Integer
        Try
            inDWMAccentColor = DirectCast(My.Computer.Registry.GetValue _
("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\DWM", "AccentColor", Nothing), Integer)
        Catch ex As Exception
            Return Color.Empty
        End Try

        Return Color.FromArgb(inDWMAccentColor).Invert
    End Function

    Private Function GetDWMColorizationColor() As Color
        Dim inDwmColor As Integer
        Dim colDWMColor As Color

        'We try to get the DWM colorization color as an integer from the DWM API.
        Try
            NativeMethods.DwmGetColorizationColor(inDwmColor, New Boolean)
        Catch ex As Exception
            Return Color.Empty
        End Try

        'We convert the integer into an opaque color
        colDWMColor = Color.FromArgb(inDwmColor)
        Return colDWMColor
    End Function

    Private Function GetImmersiveAccentColor() As Color
        Dim inImmersiveAccentColor As Integer
        Try
            inImmersiveAccentColor = DirectCast(My.Computer.Registry.GetValue _
("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentColor", Nothing), Integer)
        Catch ex As Exception
            Return Color.Empty
        End Try

        Return Color.FromArgb(inImmersiveAccentColor).Invert
    End Function
End Module
