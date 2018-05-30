Imports AccentCS.Helpers
Imports AccentCS.Controls
Imports AccentCS.App.Views.Interfaces
Imports AccentCS.App.Events
Imports AccentApplicator.Core

Namespace Views
    Public NotInheritable Class frmMain
        Implements IMainView

        Private ContextMenuRend As ToolStripSystemRendererEx

#Region "IMainView members"
        Public Event BrightnessSettingsClicked As EventHandler(Of SystemColorEventArgs) Implements IMainView.BrightnessSettingsClicked
        Public Event SetForeColorClicked As EventHandler(Of SystemColorEventArgs) Implements IMainView.SetForeColorClicked
        Public Event SystemColorConfigMenuShowing As EventHandler(Of ControlEventArgs(Of ContextMenuStrip)) Implements IMainView.SystemColorConfigMenuShowing

        'Make this implementation explicit because the Form class already has the Text property that does the same thing
        Private Property Caption As String Implements IMainView.Caption
            Get
                Return Text
            End Get
            Set(value As String)
                Text = value
            End Set
        End Property

        'This events is already implemented in the base class, but VB is dumb and forces us to reimplement it.
        Private Event IView_Load As EventHandler Implements IView.Load


        Public Sub SetAccentPreviewTooltipText(text As String) Implements IMainView.SetAccentPreviewTooltipText
            Throw New NotImplementedException()
        End Sub

        Public Sub SetSystemColorPreviewTooltipText(systemColorId As SystemColorId, systemColortext As String) Implements IMainView.SetSystemColorPreviewTooltipText
            Throw New NotImplementedException()
        End Sub
#End Region

#Region "Custom Event Methods"
        Private Sub OnSystemColorConfigMenuShowing(e As ControlEventArgs(Of ContextMenuStrip))
            RaiseEvent SystemColorConfigMenuShowing(Me, e)
        End Sub

        Private Sub OnBrightnessSettingsClicked(e As SystemColorEventArgs)
            RaiseEvent BrightnessSettingsClicked(Me, e)
        End Sub
#End Region


        Protected Overrides Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)
            RaiseEvent IView_Load(Me, e)
        End Sub

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
            OnSystemColorConfigMenuShowing(New ControlEventArgs(Of ContextMenuStrip)(cmsSystemColors))
        End Sub

        Private Sub tmiSystemColors_BrightnessSettings_Click(sender As Object, e As EventArgs) Handles tmiSystemColors_BrightnessSettings.Click
            Dim ctrlSender = DirectCast(sender, Control)
            Dim sysColorId As SystemColorId = DirectCast([Enum].Parse(GetType(SystemColorId), ctrlSender.Tag.ToString()), SystemColorId)

            OnBrightnessSettingsClicked(New SystemColorEventArgs(sysColorId))
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
        ''' Refresh the UI elements representing the accent color.
        ''' </summary>
        Private Sub RefreshAccentColorControls()
            If colAccent.IsEmpty = False Then
                cprAccent.BackColor = colAccent
                ToolTip1.SetToolTip(cprAccent, My.Resources.LocalizedResources.Caption_CurrentRGBValue +
                                Environment.NewLine + colAccent.ToRGBString() +
                                Environment.NewLine + Environment.NewLine +
                                My.Resources.LocalizedResources.Caption_ClickToChangeAccentSource)
            Else
                cprAccent.BackColor = Color.White
                ToolTip1.SetToolTip(cprAccent, My.Resources.LocalizedResources.Error_InvalidColor)
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

        Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If Not My.Settings.General_InstantOptionChanges Then
                Try
                    'We need to restore all the system colors to their defaults (exept the fore colors) before applying their new values 
                    'because we don't know which color was initially configured to be synced then configured not
                    'to be (there is surely a way but that's it for now.)

                    SystemColorManipulation.RestoreDefaultColors(SyncableSystemColorIDs.ToArray)
                    Threading.Thread.Sleep(200) 'just to give some time to the SetSysColor Win32 function to do its stuff.
                    Synchronizer.Instance.SyncNow(colAccent)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    e.Cancel = True
                End Try
            End If
        End Sub

        Private Sub IView_Show() Implements IView.Show
            Throw New NotImplementedException()
        End Sub
    End Class

End Namespace