<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackgroundWorker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrSpamProtection = New System.Windows.Forms.Timer(Me.components)
        Me.cmsNotifyIcon = New AccentCS.App.myContextMenuStripSystem()
        Me.tmiNotifyIcon_AppOptions = New AccentCS.App.myToolStripMenuItem()
        Me.tmiNotifyIcon_SyncNow = New AccentCS.App.myToolStripMenuItem()
        Me.tmiNotifyIcon_AboutApp = New AccentCS.App.myToolStripMenuItem()
        Me.sepNotifyIcon_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tmiNotifyIcon_ExitApp = New AccentCS.App.myToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsNotifyIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrSpamProtection
        '
        Me.tmrSpamProtection.Interval = 200
        '
        'cmsNotifyIcon
        '
        Me.cmsNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmiNotifyIcon_AppOptions, Me.tmiNotifyIcon_SyncNow, Me.tmiNotifyIcon_AboutApp, Me.sepNotifyIcon_1, Me.tmiNotifyIcon_ExitApp})
        Me.cmsNotifyIcon.Name = "MyContextMenuStripSystem2"
        Me.cmsNotifyIcon.Size = New System.Drawing.Size(235, 98)
        '
        'tmiNotifyIcon_AppOptions
        '
        Me.tmiNotifyIcon_AppOptions.Name = "tmiNotifyIcon_AppOptions"
        Me.tmiNotifyIcon_AppOptions.Size = New System.Drawing.Size(234, 22)
        Me.tmiNotifyIcon_AppOptions.Text = "Configure Accent Applicator…"
        '
        'tmiNotifyIcon_SyncNow
        '
        Me.tmiNotifyIcon_SyncNow.Name = "tmiNotifyIcon_SyncNow"
        Me.tmiNotifyIcon_SyncNow.Size = New System.Drawing.Size(234, 22)
        Me.tmiNotifyIcon_SyncNow.Text = "Apply accent now"
        Me.tmiNotifyIcon_SyncNow.Visible = False
        '
        'tmiNotifyIcon_AboutApp
        '
        Me.tmiNotifyIcon_AboutApp.Name = "tmiNotifyIcon_AboutApp"
        Me.tmiNotifyIcon_AboutApp.Size = New System.Drawing.Size(234, 22)
        Me.tmiNotifyIcon_AboutApp.Text = "About"
        '
        'sepNotifyIcon_1
        '
        Me.sepNotifyIcon_1.Name = "sepNotifyIcon_1"
        Me.sepNotifyIcon_1.Padding = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.sepNotifyIcon_1.Size = New System.Drawing.Size(231, 6)
        '
        'tmiNotifyIcon_ExitApp
        '
        Me.tmiNotifyIcon_ExitApp.Name = "tmiNotifyIcon_ExitApp"
        Me.tmiNotifyIcon_ExitApp.Size = New System.Drawing.Size(234, 22)
        Me.tmiNotifyIcon_ExitApp.Text = "Exit"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.cmsNotifyIcon
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'frmBackgroundWorker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(40, 33)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBackgroundWorker"
        Me.ShowInTaskbar = False
        Me.Text = "frmBackgroundWorker"
        Me.cmsNotifyIcon.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsNotifyIcon As myContextMenuStripSystem
    Friend WithEvents sepNotifyIcon_1 As ToolStripSeparator
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents tmrSpamProtection As Timer
    Friend WithEvents tmiNotifyIcon_AppOptions As myToolStripMenuItem
    Friend WithEvents tmiNotifyIcon_SyncNow As myToolStripMenuItem
    Friend WithEvents tmiNotifyIcon_AboutApp As myToolStripMenuItem
    Friend WithEvents tmiNotifyIcon_ExitApp As myToolStripMenuItem
End Class
