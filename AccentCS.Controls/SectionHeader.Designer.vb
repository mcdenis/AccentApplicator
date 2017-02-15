<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SectionHeader
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblText = New System.Windows.Forms.Label()
        Me.hrLine = New AccentCS.Controls.HorizontalRule()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.hrLine, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblText, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(150, 150)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblText
        '
        Me.lblText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblText.AutoSize = True
        Me.lblText.Location = New System.Drawing.Point(0, 68)
        Me.lblText.Margin = New System.Windows.Forms.Padding(0)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(28, 13)
        Me.lblText.TabIndex = 1
        Me.lblText.Text = "Text"
        '
        'hrLine
        '
        Me.hrLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hrLine.Location = New System.Drawing.Point(31, 74)
        Me.hrLine.Name = "hrLine"
        Me.hrLine.Size = New System.Drawing.Size(116, 2)
        Me.hrLine.TabIndex = 0
        Me.hrLine.Text = "HorizontalRule1"
        '
        'SectionHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "SectionHeader"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents hrLine As HorizontalRule
    Friend WithEvents lblText As Label
End Class
