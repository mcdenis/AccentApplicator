Imports AccentCS.Helpers


Public NotInheritable Class frmMain

    Private colAccent As Color 'For now, we don't really need to make this variable a field.

    Private _syncableSystemColorIDs As ObjectModel.ReadOnlyCollection(Of SystemColorIDs)
    Private ReadOnly Property SyncableSystemColorIDs As ObjectModel.ReadOnlyCollection(Of SystemColorIDs)
        Get
            If _syncableSystemColorIDs Is Nothing Then
                _syncableSystemColorIDs = New List(Of SystemColorIDs)() From {SystemColorIDs.ActiveCaption, SystemColorIDs.GradientActiveCaption, SystemColorIDs.Highlight, SystemColorIDs.HotTrack, SystemColorIDs.MenuHighlight}.AsReadOnly
            End If
            Return _syncableSystemColorIDs
        End Get
    End Property


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = My.Application.Info.Title + " Options"

        'Set the appearance of popup menus
        PrepareControls.PrepareContextMenuStripSystems({cmsAccentColor, cmsSystemColors}, False)

        'Set the appearance of header labels
        Dim fontBold As New Font(Font, FontStyle.Bold)
        lblAccentColor.Font = fontBold
        lblSystemColors.Font = fontBold

        'Only allow a preview rectangle to be clicked if its color is checked to be synced.
        For Each chk As myCheckBox In tlpSystemColors.Controls.OfType(Of myCheckBox)
            For Each cpr As myColorPreviewRectangle In tlpSystemColors.Controls.OfType(Of myColorPreviewRectangle)
                If chk.Tag.ToString() = [Enum].GetName(GetType(CPRRepresentedColors), cpr.RepresentedColor) Then
                    cpr.DataBindings.Add("Enabled", chk, "Checked")
                    Exit For
                End If
            Next
        Next

        'Set the initial values for the colors
        colAccent = AccentColor.GetAccentColor(My.Settings.General_AccentSource, pIgnoreAlpha:=True)
        RefreshAccentColorControls()
        RefreshSystemColorControls()

        'Listen to future changes and react accordignly in the handling method
        AddHandler My.Settings.PropertyChanged, AddressOf Settings_PropertyChanged
    End Sub

    Private Sub Settings_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        Dim tabPropNameParts() As String = e.PropertyName.Split("_"c)

        'All the stuf below occurs when a setting is changes (usually thru the GUI). Do NOT hook control events like
        'CheckedChanged because those events are sometimes raised during the DataBinding, which trigers redundant and useless processing.

        'Apply changes immediately when a sync setting is changed and the Instant Option Changes setting is true.
        If My.Settings.General_InstantOptionChanges And tabPropNameParts.Length >= 3 AndAlso tabPropNameParts(0) = "SyncSetting" Then
            Dim SysColorID As SystemColorIDs
            If [Enum].TryParse(tabPropNameParts(1), SysColorID) Then
                Dim boSync As Boolean = DirectCast(My.Settings.Item(My.Settings.GetSysColorSyncSettingName(SysColorID, My.SyncColorSettings.Sync)), Boolean)
                If boSync Then
                    Try
                        Synchronizer.Instance.SyncSingleSystemColor(SysColorID)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                ElseIf tabPropNameParts(2) = "Sync" Then 'The property that was just changed is a sync bool and it is now false. We restore the default color for this sys color.
                    Try
                        SystemColorManipulation.RestoreDefaultColors({SysColorID})
                        'MsgBox(ResMan.GetString("Info_ThemeResetSuccess"), MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                End If
            End If


        ElseIf e.PropertyName = NameOf(My.Settings.General_AccentSource) Then
            'Refresh the accent color
            colAccent = AccentColor.GetAccentColor(My.Settings.General_AccentSource, pIgnoreAlpha:=True)
            RefreshAccentColorControls()

            If My.Settings.General_InstantOptionChanges Then
                'Apply changes now
                Try
                    Synchronizer.Instance.SyncNow(colAccent)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If


        ElseIf e.PropertyName = NameOf(My.Settings.General_InstantOptionChanges) And My.Settings.General_InstantOptionChanges = True Then
            SystemColorManipulation.RestoreDefaultColors(SyncableSystemColorIDs.ToArray())
            Threading.Thread.Sleep(100)
            Try
                Synchronizer.Instance.SyncNow(colAccent)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If m.Msg = Win32Value.WM.DWMCOLORIZATIONCOLORCHANGED Then
            colAccent = AccentColor.GetAccentColor(My.Settings.General_AccentSource, pIgnoreAlpha:=True)
            RefreshAccentColorControls()
        End If
    End Sub


    'CONTEXT MENU FOR SYSTEM COLORS

    Private Sub cmsSystemColors_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsSystemColors.Opening
        'We hide the Change foreground color option for the HotTrack color since it does not
        'really have an associated background color.
        Dim PreviewRect As myColorPreviewRectangle = TryCast(cmsSystemColors.SourceControl, myColorPreviewRectangle)
        If PreviewRect IsNot Nothing Then
            If PreviewRect.RepresentedColor = CPRRepresentedColors.HotTrack Then
                tmiSystemColors_ChangeForegroundColor.Visible = False
            Else
                tmiSystemColors_ChangeForegroundColor.Visible = True
            End If
        End If
    End Sub

    Private Sub tmiSystemColors_BrightnessSettings_Click(sender As Object, e As EventArgs) Handles tmiSystemColors_BrightnessSettings.Click
        Dim tmi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = DirectCast(tmi.Owner, ContextMenuStrip)
        If cms IsNot Nothing Then
            Dim cpr As myColorPreviewRectangle = DirectCast(cms.SourceControl, myColorPreviewRectangle)
            If cpr IsNot Nothing Then
                Using frm As New frmBrightnessSettings(cpr.RepresentedSystemColor)
                    frm.ShowDialog(Me)
                End Using
            End If
        End If
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


    'CONTEXT MENU FOR ACCENT COLOR

    Private Sub cmsAccentColor_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsAccentColor.Opening
        For Each item As ToolStripMenuItem In cmsAccentColor.Items
            Dim tag As AccentSources = DirectCast([Enum].Parse(GetType(AccentSources), item.Tag.ToString), AccentSources)
            If tag = My.Settings.General_AccentSource Then
                item.Checked = True
                Exit For
            End If
        Next
    End Sub

    Private Sub tmiAccentColor_AccentPalette_CheckedChanged(sender As Object, e As EventArgs) Handles tmiAccentColor_DWMColorization.CheckedChanged, tmiAccentColor_DWMAccent.CheckedChanged, tmiAccentColor_AccentPalette.CheckedChanged
        Dim item = DirectCast(sender, ToolStripMenuItem)
        If item.Checked Then
            Dim tag As AccentSources = DirectCast([Enum].Parse(GetType(AccentSources), item.Tag.ToString), AccentSources)
            My.Settings.General_AccentSource = tag
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

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        RemoveHandler My.Settings.PropertyChanged, AddressOf Settings_PropertyChanged
    End Sub
End Class
