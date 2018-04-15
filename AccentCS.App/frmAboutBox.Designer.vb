<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAboutBox
    Inherits AccentCS.App.myFormDialog

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelProductNameAndVersion As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAboutBox))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelProductNameAndVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.lbtWebsite = New System.Windows.Forms.LinkLabel()
        Me.lbtLicense = New System.Windows.Forms.LinkLabel()
        Me.pnlBranding = New System.Windows.Forms.Panel()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.FormContent.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.pnlBranding.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormContent
        '
        Me.FormContent.Controls.Add(Me.TableLayoutPanel)
        Me.FormContent.Location = New System.Drawing.Point(9, 9)
        Me.FormContent.Size = New System.Drawing.Size(329, 206)
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 3
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.54567!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.5927!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.1307!))
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductNameAndVersion, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 2, 4)
        Me.TableLayoutPanel.Controls.Add(Me.lbtWebsite, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.lbtLicense, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.pnlBranding, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 5
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(329, 206)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'LabelProductNameAndVersion
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.LabelProductNameAndVersion, 2)
        Me.LabelProductNameAndVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductNameAndVersion.Location = New System.Drawing.Point(76, 2)
        Me.LabelProductNameAndVersion.Margin = New System.Windows.Forms.Padding(6, 2, 3, 2)
        Me.LabelProductNameAndVersion.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelProductNameAndVersion.Name = "LabelProductNameAndVersion"
        Me.LabelProductNameAndVersion.Size = New System.Drawing.Size(250, 17)
        Me.LabelProductNameAndVersion.TabIndex = 0
        Me.LabelProductNameAndVersion.Text = "Product Name + Version"
        Me.LabelProductNameAndVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.LabelCopyright, 2)
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Location = New System.Drawing.Point(76, 23)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 2, 3, 2)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(250, 17)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.TextBoxDescription, 2)
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Location = New System.Drawing.Point(76, 44)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 2, 3, 2)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(251, 180)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'lbtWebsite
        '
        Me.lbtWebsite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbtWebsite.AutoSize = True
        Me.lbtWebsite.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.lbtWebsite.Location = New System.Drawing.Point(76, 190)
        Me.lbtWebsite.Margin = New System.Windows.Forms.Padding(6, 2, 3, 3)
        Me.lbtWebsite.Name = "lbtWebsite"
        Me.lbtWebsite.Size = New System.Drawing.Size(116, 13)
        Me.lbtWebsite.TabIndex = 1
        Me.lbtWebsite.TabStop = True
        Me.lbtWebsite.Text = "Visit project homepage"
        Me.lbtWebsite.Visible = False
        '
        'lbtLicense
        '
        Me.lbtLicense.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbtLicense.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.lbtLicense, 2)
        Me.lbtLicense.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.lbtLicense.Location = New System.Drawing.Point(76, 80)
        Me.lbtLicense.Margin = New System.Windows.Forms.Padding(6, 8, 3, 0)
        Me.lbtLicense.Name = "lbtLicense"
        Me.lbtLicense.Size = New System.Drawing.Size(240, 78)
        Me.lbtLicense.TabIndex = 2
        Me.lbtLicense.TabStop = True
        Me.lbtLicense.Text = "This software is published under the MIT license." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The icon is a creation of Pi" &
    "xel Buddha from www.flaticon.com." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Portions of this code provided by Bob Powel" &
    "l."
        '
        'pnlBranding
        '
        Me.pnlBranding.Controls.Add(Me.picLogo)
        Me.pnlBranding.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBranding.Location = New System.Drawing.Point(3, 3)
        Me.pnlBranding.Name = "pnlBranding"
        Me.TableLayoutPanel.SetRowSpan(Me.pnlBranding, 5)
        Me.pnlBranding.Size = New System.Drawing.Size(64, 200)
        Me.pnlBranding.TabIndex = 3
        '
        'picLogo
        '
        Me.picLogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picLogo.Location = New System.Drawing.Point(0, 3)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(61, 50)
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'frmAboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(347, 224)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmAboutBox"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.Text = "AboutBox1"
        Me.FormContent.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.pnlBranding.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbtWebsite As LinkLabel
    Friend WithEvents lbtLicense As LinkLabel
    Friend WithEvents pnlBranding As Panel
    Friend WithEvents picLogo As PictureBox
End Class
