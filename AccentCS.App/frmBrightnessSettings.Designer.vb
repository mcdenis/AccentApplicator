<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrightnessSettings
    Inherits App.myFormDialog

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tbrBrightness = New AccentCS.App.myTrackBar()
        Me.chkSetBrightness = New AccentCS.App.myCheckBox()
        Me.btnOK = New AccentCS.App.myButton()
        Me.lblTbrDark = New AccentCS.App.myLabel()
        Me.lblTbrBright = New AccentCS.App.myLabel()
        Me.btnCancel = New AccentCS.App.myButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FormContent.SuspendLayout()
        CType(Me.tbrBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormContent
        '
        Me.FormContent.Controls.Add(Me.btnCancel)
        Me.FormContent.Controls.Add(Me.lblTbrBright)
        Me.FormContent.Controls.Add(Me.lblTbrDark)
        Me.FormContent.Controls.Add(Me.btnOK)
        Me.FormContent.Controls.Add(Me.chkSetBrightness)
        Me.FormContent.Controls.Add(Me.tbrBrightness)
        Me.FormContent.Size = New System.Drawing.Size(299, 118)
        '
        'tbrBrightness
        '
        Me.tbrBrightness.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbrBrightness.LargeChange = 10
        Me.tbrBrightness.Location = New System.Drawing.Point(67, 36)
        Me.tbrBrightness.Maximum = 100
        Me.tbrBrightness.Name = "tbrBrightness"
        Me.tbrBrightness.Size = New System.Drawing.Size(182, 45)
        Me.tbrBrightness.TabIndex = 0
        Me.tbrBrightness.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'chkSetBrightness
        '
        Me.chkSetBrightness.AutoSize = True
        Me.chkSetBrightness.Location = New System.Drawing.Point(13, 13)
        Me.chkSetBrightness.Name = "chkSetBrightness"
        Me.chkSetBrightness.Size = New System.Drawing.Size(141, 17)
        Me.chkSetBrightness.TabIndex = 1
        Me.chkSetBrightness.Text = "Set a custom brightness"
        Me.chkSetBrightness.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(131, 83)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblTbrDark
        '
        Me.lblTbrDark.AutoSize = True
        Me.lblTbrDark.Location = New System.Drawing.Point(35, 40)
        Me.lblTbrDark.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTbrDark.Name = "lblTbrDark"
        Me.lblTbrDark.Size = New System.Drawing.Size(29, 13)
        Me.lblTbrDark.TabIndex = 4
        Me.lblTbrDark.Text = "Dark"
        '
        'lblTbrBright
        '
        Me.lblTbrBright.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTbrBright.AutoSize = True
        Me.lblTbrBright.Location = New System.Drawing.Point(252, 40)
        Me.lblTbrBright.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblTbrBright.Name = "lblTbrBright"
        Me.lblTbrBright.Size = New System.Drawing.Size(35, 13)
        Me.lblTbrBright.TabIndex = 5
        Me.lblTbrBright.Text = "Bright"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(212, 83)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 0
        Me.ToolTip1.ReshowDelay = 0
        Me.ToolTip1.UseAnimation = False
        Me.ToolTip1.UseFading = False
        '
        'frmBrightnessSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(299, 118)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmBrightnessSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Brightness Settings"
        Me.FormContent.ResumeLayout(False)
        Me.FormContent.PerformLayout()
        CType(Me.tbrBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbrBrightness As myTrackBar
    Friend WithEvents chkSetBrightness As myCheckBox
    Friend WithEvents btnOK As myButton
    Friend WithEvents lblTbrBright As myLabel
    Friend WithEvents lblTbrDark As myLabel
    Friend WithEvents btnCancel As myButton
    Friend WithEvents ToolTip1 As ToolTip
End Class
