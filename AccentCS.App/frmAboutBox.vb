'Only open the designer at 96dpi!
Public NotInheritable Class frmAboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductNameAndVersion.Text = String.Format("{0} {1}", My.Application.Info.ProductName, My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.TextBoxDescription.Text = My.Application.Info.Description

        'Configure the picturebox with the logo
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.Image = My.Application.GetLogo


        'Configure the LinkLabels
        lbtWebsite.Links(0).LinkData = My.Resources.ExternalLink_ProjectURL
        lbtLicense.Links.Add(37, 11, Application.StartupPath + My.Resources.ExternalLink_LicenseURI)
        lbtLicense.Links.Add(79, 12, My.Resources.ExternalLink_IconAuthorPageURL)
        lbtLicense.Links.Add(97, 16, My.Resources.ExternalLink_FlatIconURL)
    End Sub

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub GenericLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbtWebsite.LinkClicked, lbtLicense.LinkClicked
        Dim link As LinkLabel.Link = e.Link
        Dim stPath As String = DirectCast(link.LinkData, String)

        'Sets the visited link as visited.
        link.Visited = True

        'Opens the URL with the default browser.
        Try
            Process.Start(stPath)
        Catch ex As Exception
            MsgBox(stPath + Environment.NewLine + Environment.NewLine + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmAboutBox_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'Really needed. According to my test, the PictureBox does not dispose its image when it is disposed, 
        'so we need to do it ourselves.
        If picLogo.Image IsNot Nothing Then
            picLogo.Image.Dispose()
        End If
    End Sub
End Class
