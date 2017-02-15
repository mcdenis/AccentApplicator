Imports System.ComponentModel
Imports AccentCS.Helpers

Public Enum CPRRepresentedColors
    Accent
    ActiveCaption
    GradientActiveCaption
    Highlight
    HotTrack
    MenuHighlight
End Enum

''' <summary>
''' Rectangle that shows a preview of a given system color
''' Prefix: cpr
''' </summary>
Public Class myColorPreviewRectangle
    Inherits Button

    Const flFONT_SIZE_FACTOR As Single = 0.9

    Private _glyphFont As New Lazy(Of Font)(Function() New Font("Marlett", Font.Size * 1 / flFONT_SIZE_FACTOR + 1))
    Private ReadOnly Property GlyphFont As Font
        Get
            Return _glyphFont.Value
        End Get
    End Property


    Public Property DropDownMenu As ContextMenuStrip

    <DefaultValue(FlatStyle.Popup)>
    Public Shadows Property FlatStyle As FlatStyle
        Get
            Return MyBase.FlatStyle
        End Get
        Set(value As FlatStyle)
            MyBase.FlatStyle = value
        End Set
    End Property

    <Browsable(False),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
        End Set
    End Property

    <DefaultValue("Preview")>
    Public Shadows Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Private _representedSystemColor As SystemColorIDs
    Public Property RepresentedSystemColor As SystemColorIDs
        Get
            Return _representedSystemColor
        End Get
        Private Set(value As SystemColorIDs)
            _representedSystemColor = value
        End Set
    End Property

    Private _representedColor As CPRRepresentedColors
    Public Property RepresentedColor As CPRRepresentedColors
        Get
            Return _representedColor
        End Get
        Set(value As CPRRepresentedColors)
            _representedColor = value
            OnRepresentedColorChanged()
        End Set
    End Property

    Protected Overridable Sub OnRepresentedColorChanged()
        Select Case RepresentedColor
            Case CPRRepresentedColors.Accent
                'The user sets the BackColor property
                RepresentedSystemColor = DirectCast(-1, SystemColorIDs)

            Case CPRRepresentedColors.ActiveCaption
                BackColor = SystemColors.ActiveCaption
                ForeColor = SystemColors.ActiveCaptionText
                RepresentedSystemColor = SystemColorIDs.ActiveCaption

            Case CPRRepresentedColors.GradientActiveCaption
                BackColor = SystemColors.GradientActiveCaption
                ForeColor = SystemColors.ActiveCaptionText
                RepresentedSystemColor = SystemColorIDs.GradientActiveCaption

            Case CPRRepresentedColors.Highlight
                BackColor = SystemColors.Highlight
                ForeColor = SystemColors.HighlightText
                RepresentedSystemColor = SystemColorIDs.Highlight

            Case CPRRepresentedColors.HotTrack
                BackColor = SystemColors.Control
                ForeColor = SystemColors.HotTrack
                RepresentedSystemColor = SystemColorIDs.HotTrack

            Case CPRRepresentedColors.MenuHighlight
                BackColor = SystemColors.MenuHighlight
                ForeColor = SystemColors.HighlightText
                RepresentedSystemColor = SystemColorIDs.MenuHighlight
        End Select
    End Sub

    Public Sub New()
        FlatStyle = FlatStyle.Popup
        Text = "Preview"
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        If Enabled Then
            'Draw a drop down glyph if a dropdown menu is attached to the button.
            If DropDownMenu IsNot Nothing Then
                Dim colGlyph As Color
                'We ensure that the dropdown arrow is always visible.
                'We don't use the ForeColor propty cause it would be confusing
                'for the user if using the "Change text color" option changed
                'the glyph color, which is practically more an "Image" than
                'text. Also, pure white, which is the default color for
                'highlighted text, stands out way too much in the UI.
                If BackColor.GetBrightness < 0.3 Then
                    colGlyph = Color.FromArgb(230, 230, 230)
                Else
                    colGlyph = Color.Black
                End If

                'Maybe we could use the ControlPaint.DrawMenuGlyph method to draw a menu glyph 
                'and rotate it 270 degrees instead of drawing the font character manually?
                'Read this: http://stackoverflow.com/questions/1371943/c-sharp-vertical-label-in-a-windows-forms

                TextRenderer.DrawText(pevent.Graphics, "u", GlyphFont, ClientRectangle, colGlyph,
                                      TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            End If
        Else
            'We paint over the default text, because we always want it to be the fore color, 
            'even when the button is disabled.
            TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor, BackColor)
        End If
    End Sub

    Private Sub RefreshFont()
        If Parent IsNot Nothing Then
            Dim fontParent As Font = Parent.Font
            Font = New Font(fontParent.FontFamily, fontParent.Size * flFONT_SIZE_FACTOR)
        End If
    End Sub

    Protected Overrides Sub OnParentChanged(e As EventArgs)
        MyBase.OnParentChanged(e)

        RefreshFont()
    End Sub

    Protected Overrides Sub OnParentFontChanged(e As EventArgs)
        MyBase.OnParentFontChanged(e)

        RefreshFont()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)

        If DropDownMenu IsNot Nothing Then
            Dim pt As New Point(0, Height)
            DropDownMenu.Show(Me, pt)
        End If
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso _glyphFont.IsValueCreated Then 'No need to check if _glyphFont not nothing, because that IsValueCreated property already does it for us.
            GlyphFont.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub
End Class
