Imports System.ComponentModel

Public Class ComboBoxEx
    Inherits ComboBox

    Private Const inNORMAL_ADDITIONAL_HEIGHT = 1
    Private Const inTOUCH_ADDITIONAL_HEIGHT = 20
    Private Const TEXT_FLAG As TextFormatFlags = TextFormatFlags.Default Or TextFormatFlags.VerticalCenter

    Private inNormalHeight As Integer
    Private inTouchHeight As Integer

    Public Sub New()
        RefreshHeightVars()
        ItemHeight = inNormalHeight
    End Sub

#Region "Lil makeup for some existing properties."
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property ItemHeight As Integer
        Get
            Return MyBase.ItemHeight
        End Get
        Set(value As Integer)
            MyBase.ItemHeight = value
        End Set
    End Property

    <Description("Whether or not enable user-implemented enhancements.")>
    Public Shadows Property DrawMode As DrawMode
        Get
            Return MyBase.DrawMode
        End Get
        Set(value As DrawMode)
            MyBase.DrawMode = value
        End Set
    End Property
#End Region

    Private Sub RefreshHeightVars()
        inNormalHeight = TextRenderer.MeasureText("Abcq", Font).Height + inNORMAL_ADDITIONAL_HEIGHT
        inTouchHeight = inNormalHeight + inTOUCH_ADDITIONAL_HEIGHT
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        RefreshHeightVars()
        MyBase.OnFontChanged(e)
    End Sub

    Protected Overrides Sub OnDropDown(e As EventArgs)
        If TouchDetect.GetMouseEventSource <> MouseEventSource.Mouse Then
            ItemHeight = inTouchHeight
        Else
            ItemHeight = inNormalHeight
        End If
        MyBase.OnDropDown(e)
    End Sub

    Protected Overrides Sub OnDropDownClosed(e As EventArgs)
        ItemHeight = inNormalHeight
        MyBase.OnDropDownClosed(e)
    End Sub

    Protected Overrides Sub OnMeasureItem(e As MeasureItemEventArgs)
        e.ItemHeight = ItemHeight
        MyBase.OnMeasureItem(e)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.DrawBackground()

        Dim inIndex As Integer = e.Index
        If inIndex >= 0 And inIndex < Items.Count Then
            Dim stItemText As String = GetItemText(Items.Item(inIndex))
            Dim colTextColor As Color
            If e.State.HasFlag(DrawItemState.Selected) Then
                colTextColor = SystemColors.HighlightText
            Else
                colTextColor = ForeColor
            End If
            TextRenderer.DrawText(e.Graphics, stItemText, Font, e.Bounds, colTextColor, TEXT_FLAG)
        End If
        MyBase.OnDrawItem(e)
    End Sub
End Class
