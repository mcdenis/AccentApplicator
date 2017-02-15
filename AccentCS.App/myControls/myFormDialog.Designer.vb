<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class myFormDialog
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
        Me.FormContent = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'FormContent
        '
        Me.FormContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormContent.Location = New System.Drawing.Point(0, 0)
        Me.FormContent.Name = "FormContent"
        Me.FormContent.Size = New System.Drawing.Size(284, 261)
        Me.FormContent.TabIndex = 0
        '
        'myFormDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.FormContent)
        Me.Name = "myFormDialog"
        Me.Text = "myFormDialog"
        Me.ResumeLayout(False)

    End Sub

    Protected WithEvents FormContent As Panel
End Class
