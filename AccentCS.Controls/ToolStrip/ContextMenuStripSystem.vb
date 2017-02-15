Imports System.ComponentModel

''' <summary>
''' Standard context menu with improved touch support.
''' Note: Don't change the menu item padding and margin. It may be overriden.
''' </summary>
Public Class ContextMenuStripSystem
    Inherits ContextMenuStrip

    'TO DO: Use recursive loops so that sub-menu items also get the margin & padding treatment.

    Private Const inTOUCH_ADDITIONNAL_PADDING As Integer = 10
    Private Const inNORMAL_BASE_PADDING As Integer = 1
    Private Const inTASKBAR_BASE_PADDING As Integer = 6
    Private Const inIMMERSIVE_TOP_BOTTOM_MARGIN As Integer = 3 '4
    Private Const inIMMERSIVE_TASKBAR_TOP_BOTTOM_MARGIN As Integer = 7 '8
    Private Const inIMMERSIVE_SEPARATOR_TOP_BOTTOM_MARGIN As Integer = 0 '3
    Private Const inIMMERSIVE_TASKBAR_SEPARATOR_TOP_BOTTOM_MARGIN As Integer = 1 '4

    Private inBasePadding As Integer = inNORMAL_BASE_PADDING
    Private inImmersiveTopBottomMargin As Integer = inIMMERSIVE_TOP_BOTTOM_MARGIN
    Private inImmersiveTopBottomSeparatorMargin As Integer = inIMMERSIVE_SEPARATOR_TOP_BOTTOM_MARGIN
    Private boCurrentViewIsTouch As Boolean
    Private boBasePaddingApplied As Boolean = False
    Private boMarginApplied As Boolean = False

    Private _isTaskbarMenu As Boolean = False
    ''' <summary>
    ''' Set to true if the menu is attached to a control on the Windows desktop Taskbar.
    ''' In practice, this causes the menu items to be taller on Windows TH2 and above.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(False)>
    Public Property IsTaskbarMenu As Boolean
        Get
            Return _isTaskbarMenu
        End Get
        Set(value As Boolean)
            If value <> _isTaskbarMenu Then
                Dim os As OperatingSystem = Environment.OSVersion
                If os.Version.Build > 10532 And value = True Then
                    inBasePadding = inTASKBAR_BASE_PADDING
                    inImmersiveTopBottomMargin = inIMMERSIVE_TASKBAR_TOP_BOTTOM_MARGIN
                    inImmersiveTopBottomSeparatorMargin = inIMMERSIVE_TASKBAR_SEPARATOR_TOP_BOTTOM_MARGIN
                Else
                    inBasePadding = inNORMAL_BASE_PADDING
                    inImmersiveTopBottomMargin = inIMMERSIVE_TOP_BOTTOM_MARGIN
                    inImmersiveTopBottomSeparatorMargin = inIMMERSIVE_SEPARATOR_TOP_BOTTOM_MARGIN
                End If

                _isTaskbarMenu = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Adds additional margin to the first and last items.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(False)>
    Public Property ImmersiveMenuLayout As Boolean = False



    Protected Overrides Sub OnOpened(e As EventArgs)
        If boMarginApplied = False AndAlso ImmersiveMenuLayout Then
            ApplyImmersiveMenuMargin()
        End If
        If TouchDetect.GetMouseEventSource() <> TouchDetect.MouseEventSource.Mouse Then
            'Calculates and creates the padding to apply
            Dim inPad As Integer = inBasePadding + inTOUCH_ADDITIONNAL_PADDING
            Dim pad As New Padding(0)
            pad.Top = inPad
            pad.Bottom = inPad

            'Applies the padding to all menu items
            For Each mi As ToolStripItem In Items
                mi.Padding = pad
            Next
            '
            boCurrentViewIsTouch = True

        ElseIf boBasePaddingApplied = False Then
            ApplyBasePadding()
        End If

        MyBase.OnOpened(e)
    End Sub

    Protected Overrides Sub OnClosed(e As ToolStripDropDownClosedEventArgs)
        MyBase.OnClosed(e)

        If boCurrentViewIsTouch Then
            'Indeed, when the menu is closed, it always gets its base size.
            'That way, we always know its size when it is opened and we can
            'potentially avoid changing the padding each time the menu 
            'is opened.
            ApplyBasePadding()

            boCurrentViewIsTouch = False
        End If
    End Sub

    ''' <summary>
    ''' Applie the appropriate padding for a normal (not touch-sized) menu item.
    ''' </summary>
    Private Sub ApplyBasePadding()
        'Creates the padding to apply
        Dim pad As New Padding(0, inBasePadding, 0, inBasePadding)

        'Applies the padding to all menu items
        For Each mi As ToolStripItem In Items
            mi.Padding = pad
        Next
        '
        boBasePaddingApplied = True
    End Sub

    ''' <summary>
    ''' Applies the appropriate margin to menu items.
    ''' </summary>
    Private Sub ApplyImmersiveMenuMargin()
        For i As Integer = 0 To Items.Count - 1
            If i = 0 Then 'First item
                Dim margin As Padding = Items(i).Margin
                margin.Top = inImmersiveTopBottomMargin
                Items(i).Margin = margin
            End If
            If i = Items.Count - 1 Then 'Last item
                Dim margin As Padding = Items(i).Margin
                margin.Bottom = inImmersiveTopBottomMargin
                Items(i).Margin = margin
            End If
            If TypeOf (Items(i)) Is ToolStripSeparator Then 'Separator
                Items(i).Margin = New Padding(0, inImmersiveTopBottomSeparatorMargin, 0, inImmersiveTopBottomSeparatorMargin + 1)
            End If
        Next
    End Sub

    'Note : ce ContextMenuSystemStrip ne fonctionnera pas comme faut si des items sont 
    'ajoutés après la première ouverture du menu pcq on applique seulement le 
    'layout à ce moment là. On pourrait régler ça, si jamais ça devient un 
    'problème, en appliquant le layout chaque fois que le menu est ouvert.
    '(ou si on pouvait détecter quand des items sont ajoutés, on pourrait juste
    'le faire à ce moment là...)
End Class
