Public Class myFormDialog
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Font = SystemFonts.DialogFont
        StartPosition = FormStartPosition.CenterScreen
        MaximizeBox = False

        If My.Computer.ColoredTitleBarState <> 1 Then
            ShowIcon = False
            BackColor = SystemColors.Window
            ForeColor = SystemColors.WindowText
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        'We detect when the FormBorderStyle is changed so that we can 
        'set the icon accordingly (not all styles have an icon).
        'The message is sent two times when a change occurs: once when 
        'the "Window Style" is changed and another time when the 
        '"Extended Window Style" is changed. We only consider the
        'latter, which I *guess*, includes the former.
        If m.Msg = Win32Value.WM.STYLECHANGED And m.WParam.ToInt32 = Win32Value.GWL.EXSTYLE Then
            OnFormBorderStyleChanged()
        End If
    End Sub

    Protected Overridable Sub OnFormBorderStyleChanged()
        If FormBorderStyle <> FormBorderStyle.FixedDialog AndAlso Not Equals(Icon, My.Application.Icon) Then 'AndAlso is important here, because we don't want the property to load the icon if it isn't needed.
            Icon = My.Application.Icon
        End If
    End Sub
End Class