Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles

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
    '''<exception cref="InvalidOperationException">Occurs when visual styles are disabled.</exception>
    ''' <summary>
    ''' Restore the default colors for the desired system colors using the current system theme.
    ''' </summary>
    ''' <param name="pSysColorIDs">
    ''' The system colors that sould be restored. If null is specified, all the system colors are restored.
    ''' </param>
    Public Sub RestoreDefaultColors(Optional pSysColorIDs() As SystemColorIDs = Nothing)
        'Note that GetThemeSysColor still works even when it is passed a null theme handle.
        'In that case, however, it will just return the value of GetSysColor, which is obviously
        'not what we want, since that means that we'll just apply the same colors that are
        'are already in effect, hence why we throw an exception if visual styles are not enabled.
        If VisualStyleRenderer.IsSupported = False Then
            Throw New InvalidOperationException("Cannot restore default colors from the theme, because visual styles are not currently enabled for the application.")
        End If

        Dim tabSysColorIDs() As SystemColorIDs
        'If the parameter contains no ID, we assume the caller wants to restore every single known system color.
        If pSysColorIDs Is Nothing Then
            tabSysColorIDs = DirectCast([Enum].GetValues(GetType(SystemColorIDs)), SystemColorIDs())
        ElseIf pSysColorIDs.Length < 1 Then
            'Ids array is empty, so nothing to do.
            Return
        Else
            tabSysColorIDs = pSysColorIDs
        End If

        'We create the array containing the new color associated to each System Color ID.
        'Here, the Button element is an arbitrary choice. We just need a theme handle.
        Dim renderer = New VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal)
        Dim newColors(tabSysColorIDs.Length - 1) As Color
        For i As Integer = 0 To tabSysColorIDs.Length - 1
            newColors(i) = ColorTranslator.FromWin32(NativeMethods.GetThemeSysColor(renderer.Handle, tabSysColorIDs(i)))
        Next

        'Apply changes
        SetSystemColors(tabSysColorIDs, newColors)
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
