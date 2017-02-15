Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles

''' <summary>
''' Standard toolstrip menu item that can also be used as a radio button.
''' </summary>
Public Class ToolStripMenuItemEx
    Inherits ToolStripMenuItem

    Private boIsRadioPropty As Boolean
    <DefaultValue(False)>
    Public Property IsRadio As Boolean
        Get
            Return boIsRadioPropty
        End Get
        Set(value As Boolean)
            boIsRadioPropty = value
            If value = True Then
                CheckOnClick = True
            End If
        End Set
    End Property

    Private Sub Initialize()
        If Me.IsRadio Then
            CheckOnClick = True
        End If
    End Sub

    Protected Overrides Sub OnCheckedChanged(ByVal e As EventArgs)

        MyBase.OnCheckedChanged(e)

        '------
        If Me.IsRadio = False Then
            Return
        End If
        '------

        ' If this item is no longer in the checked state or if its 
        ' parent has not yet been initialized, do nothing.
        If Not Checked OrElse Me.Parent Is Nothing Then Return

        ' Clear the checked state for all siblings. 
        For Each item As ToolStripItem In Parent.Items

            Dim radioItem As ToolStripMenuItemEx =
                    TryCast(item, ToolStripMenuItemEx)
            If radioItem IsNot Nothing AndAlso
                    radioItem IsNot Me AndAlso
                    radioItem.Checked Then

                radioItem.Checked = False

                ' Only one item can be selected at a time, 
                ' so there is no need to continue.
                Return

            End If
        Next

    End Sub

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        If Me.IsRadio = False Then
            MyBase.OnClick(e)
            Return
        End If
        '------

        ' If the item is already in the checked state, do not call 
        ' the base method, which would toggle the value. 
        If Checked Then Return

        MyBase.OnClick(e)
    End Sub

    '' Let the item paint itself, and then paint the RadioButton
    '' where the check mark is normally displayed.
    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    '    If Me.IsRadio = False Then
    '        MyBase.OnPaint(e)
    '        Return
    '    End If
    '    '------
    '
    '    If Image IsNot Nothing Then
    '        ' If the client sets the Image property, the selection behavior
    '        ' remains unchanged, but the RadioButton is not displayed and the
    '        ' selection is indicated only by the selection rectangle. 
    '        MyBase.OnPaint(e)
    '        Return
    '    Else
    '        ' If the Image property is not set, call the base OnPaint method 
    '        ' with the CheckState property temporarily cleared to prevent
    '        ' the check mark from being painted.
    '        Dim currentState As CheckState = Me.CheckState
    '        Me.CheckState = CheckState.Unchecked
    '        MyBase.OnPaint(e)
    '        Me.CheckState = currentState
    '    End If
    '
    '    ' Determine the correct state of the RadioButton.
    '    Dim buttonState As RadioButtonState = RadioButtonState.UncheckedNormal
    '    If Enabled Then
    '        If mouseDownState Then
    '            If Checked Then
    '                buttonState = RadioButtonState.CheckedPressed
    '            Else
    '                buttonState = RadioButtonState.UncheckedPressed
    '            End If
    '        ElseIf mouseHoverState Then
    '            If Checked Then
    '                buttonState = RadioButtonState.CheckedHot
    '            Else
    '                buttonState = RadioButtonState.UncheckedHot
    '            End If
    '        Else
    '            If Checked Then buttonState = RadioButtonState.CheckedNormal
    '        End If
    '    Else
    '        If Checked Then
    '            buttonState = RadioButtonState.CheckedDisabled
    '        Else
    '            buttonState = RadioButtonState.UncheckedDisabled
    '        End If
    '    End If
    '
    '    ' Calculate the position at which to display the RadioButton.
    '    Dim offset As Int32 = CInt((ContentRectangle.Height -
    '            RadioButtonRenderer.GetGlyphSize(
    '            e.Graphics, buttonState).Height) / 2)
    '    Dim imageLocation As Point = New Point(
    '            ContentRectangle.Location.X + 4,
    '            ContentRectangle.Location.Y + offset)
    '
    '    ' Paint the RadioButton. 
    '    RadioButtonRenderer.DrawRadioButton(
    '            e.Graphics, imageLocation, buttonState)
    '
    'End Sub

    Private mouseHoverState As Boolean = False

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        If Me.IsRadio = False Then
            MyBase.OnMouseEnter(e)
            Return
        End If
        '------

        mouseHoverState = True

        ' Force the item to repaint with the new RadioButton state.
        Invalidate()

        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        If Me.IsRadio = False Then
            MyBase.OnMouseLeave(e)
        End If
        '------

        mouseHoverState = False
        MyBase.OnMouseLeave(e)
    End Sub

    Private mouseDownState As Boolean = False

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If Me.IsRadio = False Then
            MyBase.OnMouseDown(e)
            Return
        End If
        '------

        mouseDownState = True

        ' Force the item to repaint with the new RadioButton state.
        Invalidate()

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        If Me.IsRadio = False Then
            MyBase.OnMouseUp(e)
        End If

        mouseDownState = False
        MyBase.OnMouseUp(e)
    End Sub

End Class
