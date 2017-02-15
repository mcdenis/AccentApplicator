Imports System.Drawing
Imports System.ComponentModel

Public Enum SystemColorIDs As Integer
    ActiveCaption = 2
    ActiveCaptionText = 9
    Highlight = 13
    HighlightText = 14
    HotTrack = 26
    GradientActiveCaption = 27
    MenuHighlight = 29
End Enum

Public Module SystemColorManipulation

    '''<exception cref="Win32Exception">Occurs when SetSysColor fails.</exception>
    ''' <summary>
    ''' Restore the default colors for the desired system colors.
    ''' </summary>
    Public Sub RestoreDefaultColors(Optional pSysColorIDs() As SystemColorIDs = Nothing)
        'We are lazy, so we just hard code the default colors. Ideally, we would read the Msstyles or something like that.

        Const inDEFAULT_COLOR_ACTIVECAPTION As Integer = 13743257
        Const inDEFAULT_COLOR_ACTIVECAPTIONTEXT As Integer = 0
        Const inDEFAULT_COLOR_GRADIENTACTIVECAPTION As Integer = 15389113
        Const inDEFAULT_COLOR_HIGHLIGHT As Integer = 16750899
        Const inDEFAULT_COLOR_HIGHLIGHTTEXT As Integer = 16777215
        Const inDEFAULT_COLOR_HOTTRACK As Integer = 13395456
        Const inDEFAULT_COLOR_MENUHIGHLIGHT As Integer = 16750899

        Dim inActiveCaption As Integer
        Dim inActiveCaptionText As Integer
        Dim inGradientActiveCaption As Integer
        Dim inHighlight As Integer
        Dim inHighlightText As Integer
        Dim inHotTrack As Integer
        Dim inMenuHighlight As Integer

        If Environment.OSVersion.Version.Build < 14361 Then
            inActiveCaption = inDEFAULT_COLOR_ACTIVECAPTION
            inGradientActiveCaption = inDEFAULT_COLOR_GRADIENTACTIVECAPTION
            inHighlight = inDEFAULT_COLOR_HIGHLIGHT
            inMenuHighlight = inDEFAULT_COLOR_MENUHIGHLIGHT
            inHotTrack = inDEFAULT_COLOR_HOTTRACK

            inActiveCaptionText = inDEFAULT_COLOR_ACTIVECAPTIONTEXT
            inHighlightText = inDEFAULT_COLOR_HIGHLIGHTTEXT
        Else
            'In the Anniversary Update, the default color of Hilight and MenuHilight was changed.
            inActiveCaption = inDEFAULT_COLOR_ACTIVECAPTION
            inGradientActiveCaption = inDEFAULT_COLOR_GRADIENTACTIVECAPTION
            inHighlight = 14120960
            inMenuHighlight = 14120960
            inHotTrack = inDEFAULT_COLOR_HOTTRACK

            inActiveCaptionText = inDEFAULT_COLOR_ACTIVECAPTIONTEXT
            inHighlightText = inDEFAULT_COLOR_HIGHLIGHTTEXT
        End If

        Dim tabSysColorIDs() As SystemColorIDs

        'If the parameter contains no ID, we assume the caller wants to restore every single known system color.
        If pSysColorIDs Is Nothing Then
            tabSysColorIDs = DirectCast([Enum].GetValues(GetType(SystemColorIDs)), SystemColorIDs())
        Else
            tabSysColorIDs = pSysColorIDs
        End If

        'We create the array containing the new color associated to each System Color ID.
        Dim NewColors(tabSysColorIDs.Length - 1) As Color
        For i As Integer = 0 To tabSysColorIDs.Length - 1
            Dim id As SystemColorIDs = tabSysColorIDs(i)
            Dim inCol As Integer
            Dim col As Color
            Select Case id
                Case SystemColorIDs.ActiveCaption
                    inCol = inActiveCaption

                Case SystemColorIDs.ActiveCaptionText
                    inCol = inActiveCaptionText

                Case SystemColorIDs.GradientActiveCaption
                    inCol = inGradientActiveCaption

                Case SystemColorIDs.Highlight
                    inCol = inHighlight

                Case SystemColorIDs.HighlightText
                    inCol = inHighlightText

                Case SystemColorIDs.HotTrack
                    inCol = inHotTrack

                Case SystemColorIDs.MenuHighlight
                    inCol = inMenuHighlight

                Case Else
                    Throw New ArgumentException(My.Resources.LocalizedResources.Error_UnsupportedSysColor)
            End Select

            col = Color.FromArgb(255, Color.FromArgb(inCol)).Invert
            NewColors(i) = col
        Next



        'Apply changes
        SetSystemColors(tabSysColorIDs, NewColors)
    End Sub

    ''' <summary>
    ''' Returns a Color structure from a SystemColorIDs.
    ''' </summary>
    ''' <param name="pSysColorID"></param>
    ''' <returns></returns>
    Public Function GetSystemColor(pSysColorID As SystemColorIDs) As Color
        Select Case pSysColorID
            Case SystemColorIDs.ActiveCaption
                Return Drawing.SystemColors.ActiveCaption

            Case SystemColorIDs.ActiveCaptionText
                Return Drawing.SystemColors.ActiveCaptionText

            Case SystemColorIDs.GradientActiveCaption
                Return Drawing.SystemColors.GradientActiveCaption

            Case SystemColorIDs.Highlight
                Return Drawing.SystemColors.Highlight

            Case SystemColorIDs.HighlightText
                Return Drawing.SystemColors.HighlightText

            Case SystemColorIDs.HotTrack
                Return Drawing.SystemColors.HotTrack

            Case SystemColorIDs.MenuHighlight
                Return Drawing.SystemColors.MenuHighlight
        End Select
    End Function


    '''<exception cref="ArgumentNullException" >One or more argument is null.</exception>
    '''<exception cref="ArgumentException">Arguments dont have the same lenght or they have a lenght of 0 or at least one color is not opaque.</exception>
    '''<exception cref="Win32Exception">Occurs when SetSysColor fails.</exception>
    ''' <summary>
    ''' Changes the specified system colors for the current session and also for the next ones.
    ''' </summary>
    ''' <param name="pColorResIndexes">Array of the indexes of the system colors to change.</param>
    ''' <param name="pNewColors">Array of the new colors to apply.</param>
    Public Sub SetSystemColors(pColorResIndexes() As SystemColorIDs, pNewColors() As Color)
        'Arguments preleminary checks
        If pColorResIndexes.Length <> pNewColors.Length Then 'Throw ArgumentNullException one or more array is null.
            Throw New ArgumentException("Arguments don't have the same length.")
        End If

        If pColorResIndexes.Length < 1 Then
            Throw New ArgumentException("Arguments are empty.")
        End If


        'SETSYSCOLORS
        Dim inMaxIndex As Integer = pColorResIndexes.Length - 1

        'Converts the SystemColorIndexes array into an Integer array. 
        'We need to create a separate array (i.e. we can't cast inline) because SetSysColors re-uses the array, which is ByRef.
        Dim tabIntColorResIndexes() As Integer = DirectCast(pColorResIndexes, Integer())

        'Converts to Color array into an Integer array.
        Dim tabIntNewColors(inMaxIndex) As Integer
        For i As Integer = 0 To inMaxIndex
            'Btw, we make sure the color is opaque.
            If pNewColors(i).A <> 255 Then
                Throw New ArgumentException("The colors must be opaque.")
            End If
            tabIntNewColors(i) = RGB(pNewColors(i).R, pNewColors(i).G, pNewColors(i).B)
        Next

        If NativeMethods.SetSysColors(pColorResIndexes.Length, tabIntColorResIndexes(0), tabIntNewColors(0)) = 0 Then
            Throw New Win32Exception("Failed to apply the new colors for the session.")
        End If

    End Sub
End Module
