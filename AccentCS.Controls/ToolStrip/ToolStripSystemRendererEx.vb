Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles

''' <summary>
''' Toolstrip renderer that follows the system theme. Has improved support for visual styles, 
''' including the light and dark immersive styles.
''' </summary>
Public Class ToolStripSystemRendererEx
    Inherits ToolStripSystemRenderer

    'Différences avec myRenderer7 :
    'We re-use the same visual style renderer everywhere.

    Private Const stSTANDARD_VS_CLASS As String = "Menu"
    Private Const stIMMERSIVE_LIGHT_VS_CLASS As String = "ImmersiveStart::Menu"
    Private Const stIMMERSIVE_DARK_VS_CLASS As String = "ImmersiveStartDark::Menu"

    Private os As OperatingSystem = Environment.OSVersion
    Private vsClass As String
    Private boIsImmersive As Boolean
    Private symbolFont As Font
    Private vsRenderer As VisualStyleRenderer

    Public Sub New()
        'Set the appropriate symbol font depending of the OS.
        'Btw, it's possible that I did not pick the right characters. There are many
        'ones that look identical so I pretty much guessed. As for the font size,
        '(e.g. the minus two for Windows 8) it is a guess too.
        If os.Version.Major >= 10 Then
            symbolFont = New Font("Segoe MDL2 Assets", SystemFonts.MenuFont.Size)
        Else
            symbolFont = New Font("Segoe UI Symbol", SystemFonts.MenuFont.Size - 2)
        End If

        'Set the default value for the Theme property (we can't just assign a value to the thTheme variable cause we also want to run the code that determine the Visual Style class.
        Theme = Themes.Standard
    End Sub

    Public Enum Themes
        Standard
        ImmersiveLight
        ImmersiveDark
    End Enum
    Private thTheme As Themes
    <DefaultValue(Themes.Standard)>
    Public Property Theme As Themes 'À faire : améliorer les fallbacks pour Win7 qui n'a pas les thèmes Immersive!
        Get
            Return thTheme
        End Get
        Set(value As Themes)
            thTheme = value

            'Set the appropriate visual style class and the IsImmersive field.
            'Since some classes are not available in older versions of Windows,
            'we automatically change the vs class if the new value won't 
            'work in the current OS.
            Select Case value
                Case Themes.Standard
                    vsClass = stSTANDARD_VS_CLASS
                    boIsImmersive = False

                Case Themes.ImmersiveLight
                    'The ImmersiveLight theme is supported on Windows 8.1 Update 1 or newer. (Here, we assume that everyone using 8.1 has the update installed. In the worst case, the menu text will look weird.)
                    If os.Version.Build >= 9600 Then
                        vsClass = stIMMERSIVE_LIGHT_VS_CLASS
                        boIsImmersive = True
                    Else
                        vsClass = stSTANDARD_VS_CLASS
                        boIsImmersive = False
                    End If

                Case Themes.ImmersiveDark
                    'The ImmersiveDark theme is supported on Windows 10 TH2 or newer.
                    'If Windows 8.1, we use the ImmersiveLight theme. Otherwise, we use 
                    'the standard theme.
                    If os.Version.Build >= 10532 Then
                        vsClass = stIMMERSIVE_DARK_VS_CLASS
                        boIsImmersive = True
                    ElseIf os.Version.Build >= 9600 Then
                        vsClass = stIMMERSIVE_LIGHT_VS_CLASS
                        boIsImmersive = True
                    Else
                        vsClass = stSTANDARD_VS_CLASS
                        boIsImmersive = False
                    End If
            End Select
        End Set
    End Property

    Private Sub PrepareVisualStyleRenderer(pElement As VisualStyleElement)
        If vsRenderer Is Nothing Then
            vsRenderer = New VisualStyleRenderer(pElement)
        Else
            vsRenderer.SetParameters(pElement)
        End If
    End Sub

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        If ToolStripManager.VisualStylesEnabled = False Or (TypeOf e.ToolStrip IsNot MenuStrip And e.ToolStrip.IsDropDown = False) Then
            MyBase.OnRenderToolStripBackground(e)
            Exit Sub
        End If

        'We pick the right visual style element
        Dim vsElement As VisualStyleElement
        If e.ToolStrip.IsDropDown Then
            vsElement = VisualStyleElement.CreateElement(vsClass, 9, 0)
        Else
            vsElement = VisualStyleElement.CreateElement(vsClass, 7, 0)
        End If

        'We check if the vs element is defined. If it isn't, we just draw the classic menu and we exit.
        If VisualStyleRenderer.IsElementDefined(vsElement) = False Then
            MyBase.OnRenderToolStripBackground(e)
            Exit Sub
        End If

        PrepareVisualStyleRenderer(vsElement)
        'Do the drawing depending if a Immersive theme is used.
        If boIsImmersive = False Then
            vsRenderer.DrawBackground(e.Graphics, e.AffectedBounds)
        Else
            Dim popupBackColor As Color = vsRenderer.GetColor(ColorProperty.FillColor)
            Using b As New SolidBrush(popupBackColor)
                e.Graphics.FillRectangle(b, e.AffectedBounds)
            End Using
        End If
    End Sub

    'We would normally not need to override the border drawing method, but there is a bug in the original .Net code :
    'The border is painted 3D or flat depending if drop shadows and visual styles are enabled, which
    'is just wrong. The IsFlatMenuEnabled property should be used instead.
    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        Dim bounds As Rectangle = e.AffectedBounds

        'Principalement copié du code de .Net Reference Source.
        If TypeOf e.ToolStrip Is ToolStripDropDown Then 'Pourquoi ne pas utiliser la propriété e.Toolstrip.IsDropDown? Serait mieux pcq propriété peut être mise en cache si on la redemande.
            'Paint the border for the window depending on whether or not flat menus are enabled.
            If SystemInformation.IsFlatMenuEnabled Then
                bounds.Width -= 1
                bounds.Height -= 1
                e.Graphics.DrawRectangle(SystemPens.ControlDark, bounds)
            Else
                ControlPaint.DrawBorder3D(e.Graphics, bounds, Border3DStyle.Raised)
            End If
        Else
            MyBase.OnRenderToolStripBorder(e)
        End If
    End Sub

    ''' <summary>
    ''' Retourne le Visual Style Element d'un popup menu item avec le state approprié.
    ''' </summary>
    ''' <param name="ItemSelected"></param>
    ''' <param name="ItemEnabled"></param>
    ''' <returns></returns>
    Private Function GetPopUpItemVSElement(ItemSelected As Boolean, ItemEnabled As Boolean) As VisualStyleElement
        Dim inState As Integer

        If ItemSelected Then
            If ItemEnabled Then
                'Hot
                inState = 2
            Else
                'DisabledHot
                inState = 4
            End If
        Else
            If ItemEnabled Then
                'Normal
                inState = 1
            Else
                'Disabled
                inState = 3
            End If
        End If

        Return VisualStyleElement.CreateElement(vsClass, 14, inState)
    End Function

    Private Function GetMenuBarItemVSElement(pItemSelected As Boolean, pItemEnabled As Boolean, pItemPushed As Boolean) As VisualStyleElement
        Dim inState As Integer

        If pItemPushed Then
            If pItemEnabled Then
                'Pushed
                inState = 3
            Else
                'DisabledPushed
                inState = 6
            End If
        ElseIf pItemSelected Then
            If pItemEnabled Then
                'Hot
                inState = 2
            Else
                'DisabledHot
                inState = 5
            End If
        Else
            If pItemEnabled Then
                'Normal
                inState = 1
            Else
                'Disabled
                inState = 4
            End If
        End If

        Return VisualStyleElement.CreateElement(vsClass, 8, inState)
    End Function

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        Dim item As ToolStripMenuItem = TryCast(e.Item, ToolStripMenuItem)
        Dim g As Graphics = e.Graphics

        If ToolStripManager.VisualStylesEnabled = False Then
            MyBase.OnRenderMenuItemBackground(e)
            Exit Sub
        End If


        If item IsNot Nothing Then
            'We create and setup the rectangle where we will draw and pick the visual style element. 
            'Mainly copied & pasted from .Net Reference Source.
            Dim fillRect As New Rectangle(Point.Empty, item.Size)
            Dim vsElement As VisualStyleElement
            If item.IsOnDropDown Then
                ' VSWhidbey 518568: scoot in by 2 pixels when selected
                fillRect.X += 2
                'its already 1 away from the right edge
                fillRect.Width -= 3

                vsElement = GetPopUpItemVSElement(item.Selected, item.Enabled)
            Else
                'Menu bar item
                vsElement = GetMenuBarItemVSElement(item.Selected, item.Enabled, item.Pressed)
            End If




            'We check if the vs element is defined. If it isn't, we let MyBase do its thing.
            If VisualStyleRenderer.IsElementDefined(vsElement) = False Then
                MyBase.OnRenderMenuItemBackground(e)
                Exit Sub
            End If

            'We initialize the visual style renderer and we draw the visual style.
            PrepareVisualStyleRenderer(vsElement)
            vsRenderer.DrawBackground(g, fillRect)
        End If
    End Sub

    ''' <summary>
    ''' Vertically centers the text rectangle of a ToolstripMenuItem, which is otherwise aligned at the top.
    ''' </summary>
    ''' <param name="pPevent"></param>
    Private Sub CenterItemTextRectangle(ByRef pPevent As ToolStripItemTextRenderEventArgs)
        Dim itemRect As New Rectangle(Point.Empty, pPevent.Item.Size)
        Dim textRectNew As Rectangle = pPevent.TextRectangle

        textRectNew.Y = (itemRect.Height - textRectNew.Height) \ 2

        pPevent.TextRectangle = textRectNew
    End Sub

    Private Sub DrawClassicText(e As ToolStripItemTextRenderEventArgs)
        Dim TextColor As Color
        If e.Item.Selected Then
            If e.Item.Enabled Then
                'Hot
                TextColor = SystemColors.HighlightText
            Else
                'DisabledHot
                TextColor = SystemColors.GrayText
            End If
        Else
            If e.Item.Enabled Then
                'Normal
                TextColor = e.Item.ForeColor
            Else
                'Disabled
                TextColor = SystemColors.GrayText
            End If
        End If
        TextRenderer.DrawText(e.Graphics, e.Text, e.Item.Font, e.TextRectangle, TextColor, e.TextFormat)
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        'We only override in a situation where we know what we are doing: 
        'When drawing a menu bar item or a popup menu item and when the text is horizontal. There are probably other situations where we would do a better job than the awfully buggy base class, but that's it for now.
        If (TypeOf (e.ToolStrip) IsNot MenuStrip And Not e.Item.IsOnDropDown) Or e.TextDirection <> ToolStripTextDirection.Horizontal Then
            MyBase.OnRenderItemText(e)
            Exit Sub
        End If

        'When the text is on a popup menu, It is vertically alligned at the top,
        'which is a problem if the item is tall, so we center the text rectangle manually.
        If e.Item.IsOnDropDown Then
            CenterItemTextRectangle(e)
        End If

        'The base class already implements drawing logic for the classic theme, se we reuse it. 
        'Its main issue was the top-aligned text rectangle, which we have fixed at this point.
        If Not ToolStripManager.VisualStylesEnabled Then
            MyBase.OnRenderItemText(e)
            Exit Sub
        End If


        'Visual Styles
        'We pick the visual style element
        Dim vsElement As VisualStyleElement
        If e.Item.IsOnDropDown Then 'Popup menu item
            vsElement = GetPopUpItemVSElement(e.Item.Selected, e.Item.Enabled)
        Else 'Menu bar item
            vsElement = GetMenuBarItemVSElement(e.Item.Selected, e.Item.Enabled, e.Item.Pressed)
        End If

        'We check if the vs element is defined. If it isn't, we just draw the classic menu and we exit.
        If VisualStyleRenderer.IsElementDefined(vsElement) = False Then
            MyBase.OnRenderItemText(e)
            Exit Sub
        End If



        'We initialize the visual style renderer
        PrepareVisualStyleRenderer(vsElement)

        'We manually draw the text with the TextRenderer using the visual style color.
        'We don't use the DrawText method of the visual style renderer because while
        'it uses the correct color, it does not use the menu system font like the real
        'menus. Instead, it appears to use some generic font in the visual style file.
        'The latter does look identical to the menu system font by fortuity, but if
        'the menu font is changed in the future, it wont necesserly look the same.

        'Since the ButtonRenderer class also uses manually uses the TextRenderer with
        'the TextColor property, my guess is that the DrawText methods is only intended
        'for special text like TaskDialog header, etc. which have a dedicated visual
        'style class, not just plain text.
        Dim colTextColor As Color = vsRenderer.GetColor(ColorProperty.TextColor)
        TextRenderer.DrawText(e.Graphics, e.Text, e.Item.Font, e.TextRectangle, vsRenderer.GetColor(ColorProperty.TextColor), e.TextFormat)

        'e.Graphics.DrawRectangle(Pens.Blue, e.Item.ContentRectangle)
        'e.Graphics.DrawRectangle(Pens.Green, e.TextRectangle)
        'e.Graphics.DrawRectangle(Pens.Yellow, textRect)

    End Sub

    Private Function GetSubMenuArrowVSElement(pEnabled As Boolean) As VisualStyleElement
        If pEnabled Then
            Return VisualStyleElement.CreateElement(vsClass, 16, 1)
        Else
            Return VisualStyleElement.CreateElement(vsClass, 16, 2)
        End If
    End Function

    ''' <summary>
    ''' Returns the color for a glyph on a menu item with the immersive theme.
    ''' </summary>
    ''' <param name="pItemSelected"></param>
    ''' <param name="pItemEnabled"></param>
    ''' <returns></returns>
    Private Function GetImmersiveMenuGlyphColor(pItemSelected As Boolean, pItemEnabled As Boolean) As Color
        'We retrieve the glyph color from the item text color. If that's not possible,
        'we fallback on hardcoding the color.

        Dim vsElement As VisualStyleElement = GetPopUpItemVSElement(pItemSelected, pItemEnabled)

        Dim col As Color
        If VisualStyleRenderer.IsElementDefined(vsElement) Then
            PrepareVisualStyleRenderer(vsElement)
            col = vsRenderer.GetColor(ColorProperty.TextColor)
        ElseIf vsClass = stIMMERSIVE_DARK_VS_CLASS Then
            col = Color.White
        Else
            col = Color.Black
        End If
    End Function

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
        If ToolStripManager.VisualStylesEnabled = False Then
            MyBase.OnRenderArrow(e)
            Exit Sub
        End If

        'The standard context menu uses visual styles for its arrow. Immersive context menus use a font icon.
        If boIsImmersive = False Then
            Dim vsElement As VisualStyleElement = GetSubMenuArrowVSElement(e.Item.Enabled)
            If VisualStyleRenderer.IsElementDefined(vsElement) Then
                'Initialize the visual style renderer
                PrepareVisualStyleRenderer(vsElement)
                'Create a the appropriate rectangle for the arrow (the one that comes in the ToolStripArrowRenderEventArgs is too big!)
                Dim arrowRect As Rectangle = New Rectangle(e.ArrowRectangle.Location, vsRenderer.GetPartSize(e.Graphics, ThemeSizeType.True))
                'Center the rectangle vertically
                arrowRect.Y = e.ArrowRectangle.Y + (e.ArrowRectangle.Height - arrowRect.Height) \ 2 + 1 '+1 is just for a quick qualitative adjustement.
                'Draw the visual style
                vsRenderer.DrawBackground(e.Graphics, arrowRect)
            Else
                'Draw classic arrow
                MyBase.OnRenderArrow(e)
                Exit Sub
            End If
        Else 'Btw, Immersive arrow does not support states.
            Dim arrowColor As Color = GetImmersiveMenuGlyphColor(e.Item.Selected, e.Item.Enabled)
            'Draw the symbol font
            TextRenderer.DrawText(e.Graphics, "", symbolFont, e.ArrowRectangle, arrowColor)
        End If
    End Sub

    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)

        'Dim b As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(e.AffectedBounds.Width, 0), Color.Red, Color.Blue)
        'e.Graphics.FillRectangle(b, e.AffectedBounds)

        'Vite fait. À arranger. Surtout pour Immersive qui sont peut-être pas un cas particulier.

        'We only need to draw the gutter background for the standard visually styled menu item.
        If Not ToolStripManager.VisualStylesEnabled Or boIsImmersive Then
            MyBase.OnRenderImageMargin(e)
            Exit Sub
        End If

        Dim vsElement As VisualStyleElement = VisualStyleElement.CreateElement(vsClass, 13, 0)

        If Not VisualStyleRenderer.IsElementDefined(vsElement) Then
            MyBase.OnRenderImageMargin(e)
            Exit Sub
        End If

        'Initialize the visual style renderer
        PrepareVisualStyleRenderer(vsElement)
        'Draw the visual style
        vsRenderer.DrawBackground(e.Graphics, e.AffectedBounds)
    End Sub

    'Quickly done for the Immersive popup menu only.
    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        If Not ToolStripManager.VisualStylesEnabled Then
            MyBase.OnRenderSeparator(e)
            Exit Sub
        End If

        Const inIMMERSIVE_LATERAL_PADDING As Integer = 10 '10 on each side for a total of 20.

        Dim vsElement As VisualStyleElement = VisualStyleElement.CreateElement(vsClass, 15, 0)

        If Not VisualStyleRenderer.IsElementDefined(vsElement) Then
            MyBase.OnRenderSeparator(e)
            Exit Sub
        End If

        PrepareVisualStyleRenderer(vsElement)

        Dim inPartHeight As Integer = vsRenderer.GetPartSize(e.Graphics, ThemeSizeType.Minimum).Height
        Dim inY As Integer = (e.Item.Height - inPartHeight) \ 2 'Vertical center

        Dim bounds As New Rectangle(0, inY, e.Item.Width, inPartHeight)


        If boIsImmersive = False Then
            Dim dropDownMenu As ToolStripDropDownMenu = DirectCast(e.Item.GetCurrentParent(), ToolStripDropDownMenu)
            If dropDownMenu IsNot Nothing Then
                If dropDownMenu.RightToLeft = RightToLeft.No Then
                    bounds.X += dropDownMenu.ImageScalingSize.Width + 2
                    bounds.Width = dropDownMenu.Width - bounds.X
                Else
                    bounds.X -= 2

                    bounds.Width = dropDownMenu.Width - bounds.X - dropDownMenu.ImageScalingSize.Width
                End If
            End If
        Else
            'We slightly reduce the width of the separator to be more faitful to the real thing.
            bounds.Inflate(-inIMMERSIVE_LATERAL_PADDING, 0)
        End If

        vsRenderer.DrawBackground(e.Graphics, bounds)


        'Dim b As New System.Drawing.Drawing2D.LinearGradientBrush(bounds, Color.Red, Color.Blue, linearGradientMode:=Drawing2D.LinearGradientMode.Vertical)
        'e.Graphics.FillRectangle(b, bounds)
        'e.Graphics.DrawRectangle(Pens.Red, bounds)

    End Sub

    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
        Dim tmiEx = TryCast(e.Item, ToolStripMenuItemEx)
        'If tmiEx IsNot Nothing AndAlso tmiEx.IsRadio Then
        '    'Paint a bullet. We need to paint ourselves even if visual style are disabled
        '    'since the base renderer does not support radio button.
        '
        '    'some painting code...
        '
        '    Exit Sub
        'End If


        If Not ToolStripManager.VisualStylesEnabled Then
            MyBase.OnRenderItemCheck(e)
            Exit Sub
        End If

        'If Not boIsImmersive Then
        '    'Paint standard menu checkmark
        '
        '    'some painting code...
        '
        '    Exit Sub
        'End If

        'Immersive theme
        Dim colGlyph As Color = GetImmersiveMenuGlyphColor(e.Item.Selected, e.Item.Enabled)
        TextRenderer.DrawText(e.Graphics, "", symbolFont, e.ImageRectangle, colGlyph) 'Maybe not the right char for the glyph.
    End Sub
End Class
