Public Class frmBrightnessSettings

    Private CurrentSystemColor As Helpers.SystemColorIDs

    ''' <summary>
    ''' Constructor without argument for the designer. DON'T USE IN CODE!
    ''' </summary>
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' Initialize an instance of the dialog to configure the brightness of a given system color.
    ''' </summary>
    ''' <param name="pSysColorID">Color that the settings should affect.</param>
    Public Sub New(pSysColorID As Helpers.SystemColorIDs)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CurrentSystemColor = pSysColorID

        'Bind the Enabled property of brightness controls to the Set brightness checkbox.
        Dim tabBriControls() As Control = {tbrBrightness, lblTbrDark, lblTbrBright}
        For Each c As Control In tabBriControls
            c.DataBindings.Add("Enabled", chkSetBrightness, "Checked")
        Next

        'Sets the initial values for the controls that directly depend on My.Settings
        Dim objSetBrit = My.Settings.Item(My.Settings.GetSysColorSyncSettingName(CurrentSystemColor, My.SyncColorSettings.SetBrit))
        chkSetBrightness.Checked = DirectCast(objSetBrit, Boolean)

        Dim objUsrBrit = My.Settings.Item(My.Settings.GetSysColorSyncSettingName(CurrentSystemColor, My.SyncColorSettings.UsrBrit))
        tbrBrightness.Value = CInt(DirectCast(objUsrBrit, Double) * 100)
    End Sub

    Private Sub frmBrightnessSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Apply change if OK clicked
        If DialogResult = DialogResult.OK Then
            'SetBrit
            Dim stSetBritSettingName As String = My.Settings.GetSysColorSyncSettingName(CurrentSystemColor, My.SyncColorSettings.SetBrit)
            My.Settings.Item(stSetBritSettingName) = chkSetBrightness.Checked

            'UsrBrit
            Dim stUsrBritSettingName As String = My.Settings.GetSysColorSyncSettingName(CurrentSystemColor, My.SyncColorSettings.UsrBrit)
            My.Settings.Item(stUsrBritSettingName) = tbrBrightness.Value / 100 'Indeed, we store the value as a double between 0 and 1. Maybe it would be better to store it as is and only convert it when it's time to sync...
        End If
    End Sub

    Private Sub tbrBrightness_MouseDown(sender As Object, e As MouseEventArgs) Handles tbrBrightness.MouseDown
        ToolTip1.Active = True
        ToolTip1.SetToolTip(tbrBrightness, tbrBrightness.Value.ToString())
    End Sub

    Private Sub tbrBrightness_Scroll(sender As Object, e As EventArgs) Handles tbrBrightness.Scroll
        ToolTip1.SetToolTip(tbrBrightness, tbrBrightness.Value.ToString())
    End Sub

    Private Sub tbrBrightness_MouseUp(sender As Object, e As MouseEventArgs) Handles tbrBrightness.MouseUp
        ToolTip1.Active = False
    End Sub
End Class
