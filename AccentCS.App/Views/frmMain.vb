Imports AccentCS.Helpers
Imports AccentCS.Controls
Imports AccentCS.App.Views.Interfaces
Imports AccentCS.App.Events
Imports AccentApplicator.Core

Namespace Views
    Public NotInheritable Class frmMain

        Private ContextMenuRend As ToolStripSystemRendererEx

        Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


            'Set the ToolstripRenderer for context menus

            'Meaning of the UI_ContextMenuStyle values:
            '0 = no custom renderer. We just use the .net provided system renderer.
            '1 = we use the custom renderer, but only with its standard theme.
            '2 = we use the custom renderer with the Immersive theme which can be light or dark.
            If My.Settings.UI_ContextMenuStyle > 0 Then
                ContextMenuRend = New ToolStripSystemRendererEx
                If My.Settings.UI_ContextMenuStyle = 2 Then
                    ContextMenuRend.Theme = ToolStripSystemRendererEx.Themes.ImmersiveLight
                    cmsSystemColors.ImmersiveMenuLayout = True
                End If
                cmsSystemColors.Renderer = ContextMenuRend
            Else
                cmsSystemColors.RenderMode = ToolStripRenderMode.System
            End If


            Dim fontBold As New Font(Font, FontStyle.Bold)
            lblAccentColor.Font = fontBold
            lblSystemColors.Font = fontBold

            'Enable the color preview button only if the corresponding checkbox is checked.
            cprActiveCaption.DataBindings.Add(NameOf(cprActiveCaption.Enabled), chkActiveCaption, NameOf(chkActiveCaption.Checked))
            cprGradientActiveCaption.DataBindings.Add(NameOf(cprGradientActiveCaption.Enabled), chkGradientActiveCaption, NameOf(chkGradientActiveCaption.Checked))
            cprHighlight.DataBindings.Add(NameOf(cprHighlight.Enabled), chkHighlight, NameOf(chkHighlight.Checked))
            cprMenuHighlight.DataBindings.Add(NameOf(cprMenuHighlight.Enabled), chkMenuHighlight, NameOf(chkMenuHighlight.Checked))
            cprHotTrack.DataBindings.Add(NameOf(cprHotTrack.Enabled), chkHotTrack, NameOf(chkHotTrack.Checked))
        End Sub




        'CONTEXT MENU FOR SYSTEM COLORS

        Private Sub cmsSystemColors_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsSystemColors.Opening

        End Sub

        Private Sub tmiSystemColors_BrightnessSettings_Click(sender As Object, e As EventArgs) Handles tmiSystemColors_BrightnessSettings.Click
            Dim ctrlSender = DirectCast(sender, Control)
            Dim sysColorId As SystemColorId = DirectCast([Enum].Parse(GetType(SystemColorId), ctrlSender.Tag.ToString()), SystemColorId)


        End Sub

        Private Sub tmiSystemColors_ChangeForegroundColor_Click(sender As Object, e As EventArgs) Handles tmiSystemColors_ChangeForegroundColor.Click
            Dim tmi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
            Dim cms As ContextMenuStrip = DirectCast(tmi.Owner, ContextMenuStrip)
            Dim previewRect As myColorPreviewRectangle = DirectCast(cms.SourceControl, myColorPreviewRectangle)

            Dim SysColorID As SystemColorIDs
            Dim colSysColor As Color

            'We identify the foreground system color
            Select Case previewRect.RepresentedColor
                Case CPRRepresentedColors.ActiveCaption, CPRRepresentedColors.GradientActiveCaption
                    SysColorID = SystemColorIDs.ActiveCaptionText
                    colSysColor = SystemColors.ActiveCaptionText

                Case CPRRepresentedColors.Highlight, CPRRepresentedColors.MenuHighlight
                    SysColorID = SystemColorIDs.HighlightText
                    colSysColor = SystemColors.HighlightText

                Case Else
                    Exit Sub
            End Select

            ColorDialog1.Color = colSysColor

            If ColorDialog1.ShowDialog(Me) = DialogResult.OK Then
                'Apply change
                SystemColorManipulation.SetSystemColors({SysColorID}, {ColorDialog1.Color})

                'Backup change
                Dim stSettingName As String = "ForeSysColorUsrValue_" + [Enum].GetName(GetType(SystemColorIDs), SysColorID)
                My.Settings.Item(stSettingName) = ColorDialog1.Color
            End If

        End Sub

        ''' <summary>
        ''' Refresh the UI elements representing a specific to a system color.
        ''' </summary>
        Private Sub RefreshSystemColorControls()
            'We only need to refresh the tooltip value, because the background color is automatically
            'refreshed by the system.
            For Each cpr As Control In tlpSystemColors.Controls.OfType(Of myColorPreviewRectangle)
                If TypeOf (cpr) Is myColorPreviewRectangle Then
                    Dim stRGB As String
                    If cpr.Name = NameOf(cprHotTrack) Then
                        stRGB = cpr.ForeColor.ToRGBString
                    Else
                        stRGB = cpr.BackColor.ToRGBString
                    End If
                    ToolTip1.SetToolTip(cpr, My.Resources.LocalizedResources.Caption_CurrentRGBValue +
                                    Environment.NewLine + stRGB +
                                    Environment.NewLine + Environment.NewLine +
                                    My.Resources.LocalizedResources.Caption_ClickForMoreOptions)
                End If
            Next
        End Sub

        Private Sub frmMain_SystemColorsChanged(sender As Object, e As EventArgs) Handles MyBase.SystemColorsChanged
            RefreshSystemColorControls()
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            Close()
        End Sub
    End Class

End Namespace