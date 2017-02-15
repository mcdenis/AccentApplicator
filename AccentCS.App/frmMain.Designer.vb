<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits AccentCS.App.myFormDialog

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cprAccent = New AccentCS.App.myColorPreviewRectangle()
        Me.cmsAccentColor = New AccentCS.App.myContextMenuStripSystem()
        Me.tmiAccentColor_AccentPalette = New AccentCS.App.myToolStripMenuItem()
        Me.tmiAccentColor_DWMAccent = New AccentCS.App.myToolStripMenuItem()
        Me.tmiAccentColor_DWMColorization = New AccentCS.App.myToolStripMenuItem()
        Me.cmsSystemColors = New AccentCS.App.myContextMenuStripSystem()
        Me.tmiSystemColors_BrightnessSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmiSystemColors_ChangeForegroundColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlpSystemColors = New System.Windows.Forms.TableLayoutPanel()
        Me.chkActiveCaption = New AccentCS.App.myCheckBox()
        Me.chkGradientActiveCaption = New AccentCS.App.myCheckBox()
        Me.chkHighlight = New AccentCS.App.myCheckBox()
        Me.chkMenuHighlight = New AccentCS.App.myCheckBox()
        Me.chkHotTrack = New AccentCS.App.myCheckBox()
        Me.cprActiveCaption = New AccentCS.App.myColorPreviewRectangle()
        Me.cprGradientActiveCaption = New AccentCS.App.myColorPreviewRectangle()
        Me.cprHighlight = New AccentCS.App.myColorPreviewRectangle()
        Me.cprMenuHighlight = New AccentCS.App.myColorPreviewRectangle()
        Me.cprHotTrack = New AccentCS.App.myColorPreviewRectangle()
        Me.btnOK = New AccentCS.App.myButton()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblAccentColor = New AccentCS.App.myLabel()
        Me.lblSystemColors = New AccentCS.App.myLabel()
        Me.chkInstantOptionChanges = New AccentCS.App.myCheckBox()
        Me.FormContent.SuspendLayout()
        Me.cmsAccentColor.SuspendLayout()
        Me.cmsSystemColors.SuspendLayout()
        Me.tlpSystemColors.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContent
        '
        Me.FormContent.Controls.Add(Me.chkInstantOptionChanges)
        Me.FormContent.Controls.Add(Me.lblSystemColors)
        Me.FormContent.Controls.Add(Me.lblAccentColor)
        Me.FormContent.Controls.Add(Me.btnOK)
        Me.FormContent.Controls.Add(Me.tlpSystemColors)
        Me.FormContent.Controls.Add(Me.cprAccent)
        Me.FormContent.Size = New System.Drawing.Size(296, 285)
        '
        'cprAccent
        '
        Me.cprAccent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cprAccent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cprAccent.DropDownMenu = Me.cmsAccentColor
        Me.cprAccent.Location = New System.Drawing.Point(12, 29)
        Me.cprAccent.Name = "cprAccent"
        Me.cprAccent.RepresentedColor = AccentCS.App.CPRRepresentedColors.Accent
        Me.cprAccent.Size = New System.Drawing.Size(272, 33)
        Me.cprAccent.TabIndex = 1
        Me.cprAccent.Text = " "
        Me.cprAccent.UseVisualStyleBackColor = False
        '
        'cmsAccentColor
        '
        Me.cmsAccentColor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmiAccentColor_AccentPalette, Me.tmiAccentColor_DWMAccent, Me.tmiAccentColor_DWMColorization})
        Me.cmsAccentColor.Name = "cmsAccentColor"
        Me.cmsAccentColor.Size = New System.Drawing.Size(170, 70)
        '
        'tmiAccentColor_AccentPalette
        '
        Me.tmiAccentColor_AccentPalette.CheckOnClick = True
        Me.tmiAccentColor_AccentPalette.IsRadio = True
        Me.tmiAccentColor_AccentPalette.Name = "tmiAccentColor_AccentPalette"
        Me.tmiAccentColor_AccentPalette.Size = New System.Drawing.Size(169, 22)
        Me.tmiAccentColor_AccentPalette.Tag = "AccentPalette"
        Me.tmiAccentColor_AccentPalette.Text = "Accent palette"
        '
        'tmiAccentColor_DWMAccent
        '
        Me.tmiAccentColor_DWMAccent.CheckOnClick = True
        Me.tmiAccentColor_DWMAccent.IsRadio = True
        Me.tmiAccentColor_DWMAccent.Name = "tmiAccentColor_DWMAccent"
        Me.tmiAccentColor_DWMAccent.Size = New System.Drawing.Size(169, 22)
        Me.tmiAccentColor_DWMAccent.Tag = "DWMAccent"
        Me.tmiAccentColor_DWMAccent.Text = "DWM accent"
        '
        'tmiAccentColor_DWMColorization
        '
        Me.tmiAccentColor_DWMColorization.CheckOnClick = True
        Me.tmiAccentColor_DWMColorization.IsRadio = True
        Me.tmiAccentColor_DWMColorization.Name = "tmiAccentColor_DWMColorization"
        Me.tmiAccentColor_DWMColorization.Size = New System.Drawing.Size(169, 22)
        Me.tmiAccentColor_DWMColorization.Tag = "DWMColorization"
        Me.tmiAccentColor_DWMColorization.Text = "DWM colorization"
        '
        'cmsSystemColors
        '
        Me.cmsSystemColors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmiSystemColors_BrightnessSettings, Me.tmiSystemColors_ChangeForegroundColor})
        Me.cmsSystemColors.Name = "cmsColor"
        Me.cmsSystemColors.Size = New System.Drawing.Size(177, 48)
        '
        'tmiSystemColors_BrightnessSettings
        '
        Me.tmiSystemColors_BrightnessSettings.Name = "tmiSystemColors_BrightnessSettings"
        Me.tmiSystemColors_BrightnessSettings.Size = New System.Drawing.Size(176, 22)
        Me.tmiSystemColors_BrightnessSettings.Text = "Brightness settings"
        '
        'tmiSystemColors_ChangeForegroundColor
        '
        Me.tmiSystemColors_ChangeForegroundColor.Name = "tmiSystemColors_ChangeForegroundColor"
        Me.tmiSystemColors_ChangeForegroundColor.Size = New System.Drawing.Size(176, 22)
        Me.tmiSystemColors_ChangeForegroundColor.Text = "Change text color..."
        '
        'tlpSystemColors
        '
        Me.tlpSystemColors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpSystemColors.ColumnCount = 2
        Me.tlpSystemColors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSystemColors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSystemColors.Controls.Add(Me.chkActiveCaption, 0, 0)
        Me.tlpSystemColors.Controls.Add(Me.chkGradientActiveCaption, 0, 1)
        Me.tlpSystemColors.Controls.Add(Me.chkHighlight, 0, 2)
        Me.tlpSystemColors.Controls.Add(Me.chkMenuHighlight, 0, 3)
        Me.tlpSystemColors.Controls.Add(Me.chkHotTrack, 0, 4)
        Me.tlpSystemColors.Controls.Add(Me.cprActiveCaption, 1, 0)
        Me.tlpSystemColors.Controls.Add(Me.cprGradientActiveCaption, 1, 1)
        Me.tlpSystemColors.Controls.Add(Me.cprHighlight, 1, 2)
        Me.tlpSystemColors.Controls.Add(Me.cprMenuHighlight, 1, 3)
        Me.tlpSystemColors.Controls.Add(Me.cprHotTrack, 1, 4)
        Me.tlpSystemColors.Location = New System.Drawing.Point(12, 97)
        Me.tlpSystemColors.Name = "tlpSystemColors"
        Me.tlpSystemColors.RowCount = 5
        Me.tlpSystemColors.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpSystemColors.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpSystemColors.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpSystemColors.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpSystemColors.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpSystemColors.Size = New System.Drawing.Size(272, 136)
        Me.tlpSystemColors.TabIndex = 4
        '
        'chkActiveCaption
        '
        Me.chkActiveCaption.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkActiveCaption.AutoSize = True
        Me.chkActiveCaption.Checked = Global.AccentCS.App.My.MySettings.Default.SyncSetting_ActiveCaption_Sync
        Me.chkActiveCaption.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AccentCS.App.My.MySettings.Default, "SyncSetting_ActiveCaption_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkActiveCaption.Location = New System.Drawing.Point(0, 5)
        Me.chkActiveCaption.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.chkActiveCaption.Name = "chkActiveCaption"
        Me.chkActiveCaption.Size = New System.Drawing.Size(99, 17)
        Me.chkActiveCaption.TabIndex = 0
        Me.chkActiveCaption.Tag = "ActiveCaption"
        Me.chkActiveCaption.Text = "Active captions"
        Me.chkActiveCaption.UseVisualStyleBackColor = True
        '
        'chkGradientActiveCaption
        '
        Me.chkGradientActiveCaption.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkGradientActiveCaption.AutoSize = True
        Me.chkGradientActiveCaption.Checked = Global.AccentCS.App.My.MySettings.Default.SyncSetting_GradientActiveCaption_Sync
        Me.chkGradientActiveCaption.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AccentCS.App.My.MySettings.Default, "SyncSetting_GradientActiveCaption_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkGradientActiveCaption.Location = New System.Drawing.Point(0, 32)
        Me.chkGradientActiveCaption.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.chkGradientActiveCaption.Name = "chkGradientActiveCaption"
        Me.chkGradientActiveCaption.Size = New System.Drawing.Size(150, 17)
        Me.chkGradientActiveCaption.TabIndex = 1
        Me.chkGradientActiveCaption.Tag = "GradientActiveCaption"
        Me.chkGradientActiveCaption.Text = "Active captions (gradient)"
        Me.chkGradientActiveCaption.UseVisualStyleBackColor = True
        '
        'chkHighlight
        '
        Me.chkHighlight.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkHighlight.AutoSize = True
        Me.chkHighlight.Checked = Global.AccentCS.App.My.MySettings.Default.SyncSetting_Highlight_Sync
        Me.chkHighlight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHighlight.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AccentCS.App.My.MySettings.Default, "SyncSetting_Highlight_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkHighlight.Location = New System.Drawing.Point(0, 59)
        Me.chkHighlight.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.chkHighlight.Name = "chkHighlight"
        Me.chkHighlight.Size = New System.Drawing.Size(95, 17)
        Me.chkHighlight.TabIndex = 2
        Me.chkHighlight.Tag = "Highlight"
        Me.chkHighlight.Text = "Selected items"
        Me.chkHighlight.UseVisualStyleBackColor = True
        '
        'chkMenuHighlight
        '
        Me.chkMenuHighlight.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMenuHighlight.AutoSize = True
        Me.chkMenuHighlight.Checked = Global.AccentCS.App.My.MySettings.Default.SyncSetting_MenuHighlight_Sync
        Me.chkMenuHighlight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMenuHighlight.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AccentCS.App.My.MySettings.Default, "SyncSetting_MenuHighlight_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkMenuHighlight.Location = New System.Drawing.Point(0, 86)
        Me.chkMenuHighlight.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.chkMenuHighlight.Name = "chkMenuHighlight"
        Me.chkMenuHighlight.Size = New System.Drawing.Size(124, 17)
        Me.chkMenuHighlight.TabIndex = 3
        Me.chkMenuHighlight.Tag = "MenuHighlight"
        Me.chkMenuHighlight.Text = "Selected menu items"
        Me.chkMenuHighlight.UseVisualStyleBackColor = True
        '
        'chkHotTrack
        '
        Me.chkHotTrack.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkHotTrack.AutoSize = True
        Me.chkHotTrack.Checked = Global.AccentCS.App.My.MySettings.Default.SyncSetting_HotTrack_Sync
        Me.chkHotTrack.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHotTrack.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AccentCS.App.My.MySettings.Default, "SyncSetting_HotTrack_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkHotTrack.Location = New System.Drawing.Point(0, 113)
        Me.chkHotTrack.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.chkHotTrack.Name = "chkHotTrack"
        Me.chkHotTrack.Size = New System.Drawing.Size(75, 17)
        Me.chkHotTrack.TabIndex = 4
        Me.chkHotTrack.Tag = "HotTrack"
        Me.chkHotTrack.Text = "Hyperlinks"
        Me.chkHotTrack.UseVisualStyleBackColor = True
        '
        'cprActiveCaption
        '
        Me.cprActiveCaption.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cprActiveCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cprActiveCaption.DropDownMenu = Me.cmsSystemColors
        Me.cprActiveCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cprActiveCaption.Location = New System.Drawing.Point(156, 3)
        Me.cprActiveCaption.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.cprActiveCaption.Name = "cprActiveCaption"
        Me.cprActiveCaption.RepresentedColor = AccentCS.App.CPRRepresentedColors.ActiveCaption
        Me.cprActiveCaption.Size = New System.Drawing.Size(116, 21)
        Me.cprActiveCaption.TabIndex = 5
        Me.cprActiveCaption.UseVisualStyleBackColor = False
        '
        'cprGradientActiveCaption
        '
        Me.cprGradientActiveCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cprGradientActiveCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cprGradientActiveCaption.DropDownMenu = Me.cmsSystemColors
        Me.cprGradientActiveCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cprGradientActiveCaption.Location = New System.Drawing.Point(156, 30)
        Me.cprGradientActiveCaption.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.cprGradientActiveCaption.Name = "cprGradientActiveCaption"
        Me.cprGradientActiveCaption.RepresentedColor = AccentCS.App.CPRRepresentedColors.GradientActiveCaption
        Me.cprGradientActiveCaption.Size = New System.Drawing.Size(116, 21)
        Me.cprGradientActiveCaption.TabIndex = 6
        Me.cprGradientActiveCaption.UseVisualStyleBackColor = False
        '
        'cprHighlight
        '
        Me.cprHighlight.BackColor = System.Drawing.SystemColors.Highlight
        Me.cprHighlight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cprHighlight.DropDownMenu = Me.cmsSystemColors
        Me.cprHighlight.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cprHighlight.Location = New System.Drawing.Point(156, 57)
        Me.cprHighlight.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.cprHighlight.Name = "cprHighlight"
        Me.cprHighlight.RepresentedColor = AccentCS.App.CPRRepresentedColors.Highlight
        Me.cprHighlight.Size = New System.Drawing.Size(116, 21)
        Me.cprHighlight.TabIndex = 7
        Me.cprHighlight.UseVisualStyleBackColor = False
        '
        'cprMenuHighlight
        '
        Me.cprMenuHighlight.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.cprMenuHighlight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cprMenuHighlight.DropDownMenu = Me.cmsSystemColors
        Me.cprMenuHighlight.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cprMenuHighlight.Location = New System.Drawing.Point(156, 84)
        Me.cprMenuHighlight.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.cprMenuHighlight.Name = "cprMenuHighlight"
        Me.cprMenuHighlight.RepresentedColor = AccentCS.App.CPRRepresentedColors.MenuHighlight
        Me.cprMenuHighlight.Size = New System.Drawing.Size(116, 21)
        Me.cprMenuHighlight.TabIndex = 8
        Me.cprMenuHighlight.UseVisualStyleBackColor = False
        '
        'cprHotTrack
        '
        Me.cprHotTrack.BackColor = System.Drawing.SystemColors.Control
        Me.cprHotTrack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cprHotTrack.DropDownMenu = Me.cmsSystemColors
        Me.cprHotTrack.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cprHotTrack.Location = New System.Drawing.Point(156, 111)
        Me.cprHotTrack.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.cprHotTrack.Name = "cprHotTrack"
        Me.cprHotTrack.RepresentedColor = AccentCS.App.CPRRepresentedColors.HotTrack
        Me.cprHotTrack.Size = New System.Drawing.Size(116, 22)
        Me.cprHotTrack.TabIndex = 9
        Me.cprHotTrack.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(209, 250)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblAccentColor
        '
        Me.lblAccentColor.AutoSize = True
        Me.lblAccentColor.Location = New System.Drawing.Point(9, 13)
        Me.lblAccentColor.Name = "lblAccentColor"
        Me.lblAccentColor.Size = New System.Drawing.Size(109, 13)
        Me.lblAccentColor.TabIndex = 7
        Me.lblAccentColor.Text = "Current accent color:"
        '
        'lblSystemColors
        '
        Me.lblSystemColors.AutoSize = True
        Me.lblSystemColors.Location = New System.Drawing.Point(9, 81)
        Me.lblSystemColors.Name = "lblSystemColors"
        Me.lblSystemColors.Size = New System.Drawing.Size(165, 13)
        Me.lblSystemColors.TabIndex = 8
        Me.lblSystemColors.Text = "Apply the accent on these items:"
        '
        'chkInstantOptionChanges
        '
        Me.chkInstantOptionChanges.AutoSize = True
        Me.chkInstantOptionChanges.Checked = Global.AccentCS.App.My.MySettings.Default.General_InstantOptionChanges
        Me.chkInstantOptionChanges.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInstantOptionChanges.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AccentCS.App.My.MySettings.Default, "General_InstantOptionChanges", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkInstantOptionChanges.Location = New System.Drawing.Point(12, 254)
        Me.chkInstantOptionChanges.Name = "chkInstantOptionChanges"
        Me.chkInstantOptionChanges.Size = New System.Drawing.Size(184, 17)
        Me.chkInstantOptionChanges.TabIndex = 9
        Me.chkInstantOptionChanges.Text = "Apply option changes in real time"
        Me.chkInstantOptionChanges.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(296, 285)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.Text = "App Name"
        Me.Controls.SetChildIndex(Me.FormContent, 0)
        Me.FormContent.ResumeLayout(False)
        Me.FormContent.PerformLayout()
        Me.cmsAccentColor.ResumeLayout(False)
        Me.cmsSystemColors.ResumeLayout(False)
        Me.tlpSystemColors.ResumeLayout(False)
        Me.tlpSystemColors.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cprAccent As myColorPreviewRectangle
    Friend WithEvents tlpSystemColors As TableLayoutPanel
    Friend WithEvents chkActiveCaption As myCheckBox
    Friend WithEvents chkGradientActiveCaption As myCheckBox
    Friend WithEvents chkHighlight As myCheckBox
    Friend WithEvents chkMenuHighlight As myCheckBox
    Friend WithEvents chkHotTrack As myCheckBox
    Friend WithEvents cprActiveCaption As myColorPreviewRectangle
    Friend WithEvents cprGradientActiveCaption As myColorPreviewRectangle
    Friend WithEvents cprHighlight As myColorPreviewRectangle
    Friend WithEvents cprMenuHighlight As myColorPreviewRectangle
    Friend WithEvents cprHotTrack As myColorPreviewRectangle
    Friend WithEvents cmsSystemColors As myContextMenuStripSystem
    Friend WithEvents tmiSystemColors_BrightnessSettings As ToolStripMenuItem
    Friend WithEvents tmiSystemColors_ChangeForegroundColor As ToolStripMenuItem
    Friend WithEvents cmsAccentColor As myContextMenuStripSystem
    Friend WithEvents btnOK As myButton
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents tmiAccentColor_AccentPalette As myToolStripMenuItem
    Friend WithEvents tmiAccentColor_DWMAccent As myToolStripMenuItem
    Friend WithEvents tmiAccentColor_DWMColorization As myToolStripMenuItem
    Friend WithEvents lblSystemColors As myLabel
    Friend WithEvents lblAccentColor As myLabel
    Friend WithEvents chkInstantOptionChanges As myCheckBox
End Class
