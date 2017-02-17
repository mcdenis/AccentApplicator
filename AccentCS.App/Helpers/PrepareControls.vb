Imports AccentCS.Controls

Module PrepareControls

    ''' <summary>
    ''' Configures the given ContextMenuStrips with the correct layout and renderer.
    ''' </summary>
    ''' <param name="pContextMenuStrips"></param>
    ''' <param name="pAreTaskbarMenus"></param>
    Friend Sub PrepareContextMenuStripSystems(pContextMenuStrips As ContextMenuStripSystem(), pAreTaskbarMenus As Boolean)
        'Meaning of the UI_ContextMenuStyle values:
        '0 = no custom renderer. We just use the .net provided system renderer.
        '1 = we use the custom renderer, but only with its standard theme.
        '2 = we use the custom renderer with the Immersive theme which can be light or dark.


        If My.Settings.UI_ContextMenuStyle > 0 Then
            Dim rend As New ToolStripSystemRendererEx
            For Each cms As ContextMenuStripSystem In pContextMenuStrips
                cms.Renderer = rend
            Next
            If My.Settings.UI_ContextMenuStyle = 2 Then
                For Each cms As ContextMenuStripSystem In pContextMenuStrips
                    cms.ImmersiveMenuLayout = True
                Next
                If pAreTaskbarMenus Then
                    rend.Theme = ToolStripSystemRendererEx.Themes.ImmersiveDark
                    For Each cms As ContextMenuStripSystem In pContextMenuStrips
                        cms.IsTaskbarMenu = True
                    Next
                Else
                    rend.Theme = ToolStripSystemRendererEx.Themes.ImmersiveLight
                End If
            End If
        Else
            For Each cms As ContextMenuStripSystem In pContextMenuStrips
                cms.RenderMode = ToolStripRenderMode.System
            Next
        End If
    End Sub

End Module
