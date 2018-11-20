Imports AccentCS.App.Views.Interfaces

Namespace Views
    Public Class frmBrightnessSettings
        Implements IBrightnessSettingsView

        Protected Overrides Sub OnLoad(e As EventArgs)

            'Bind the Enabled property of brightness controls to the Set brightness checkbox.
            Dim tabBriControls() As Control = {tbrBrightness, lblTbrDark, lblTbrBright}
            For Each c In tabBriControls
                c.DataBindings.Add("Enabled", chkSetBrightness, "Checked")
            Next

            MyBase.OnLoad(e)
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

#Region "IBrightnessSettingsView members"
        Public Property SetBrightness As Boolean Implements IBrightnessSettingsView.SetBrightness
            Get
                Return chkSetBrightness.Checked
            End Get
            Set(value As Boolean)
                chkSetBrightness.Checked = value
            End Set
        End Property

        ''' <summary>
        '''     Gets or sets a value between 0 and 1 indicating the desired brightness.
        ''' </summary>
        ''' <returns></returns>
        Public Property Brightness As Double Implements IBrightnessSettingsView.Brightness
            Get
                Return tbrBrightness.Value / 100
            End Get
            Set(value As Double)
                tbrBrightness.Value = CInt(Math.Round(value * 100))
            End Set
        End Property

        Private Property Caption As String Implements IView.Caption
            Get
                Return Text
            End Get
            Set(value As String)
                Text = value
            End Set
        End Property

        Private Event IView_Load As EventHandler Implements IView.Load
        Public Event Submitted As EventHandler Implements IDialogView.Submitted

        Private Sub IView_Show(owner As IWin32Window) Implements IView.Show
            Show(owner)
        End Sub

        Private Sub IView_ShowDialog(owner As IWin32Window) Implements IDialogView.ShowDialog
            ShowDialog(owner)
        End Sub
#End Region
    End Class

End Namespace