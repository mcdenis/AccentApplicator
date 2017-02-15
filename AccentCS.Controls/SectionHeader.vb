Imports System.ComponentModel

''' <summary>
''' Simple header for a section in a dialog. 
''' </summary>
Public Class SectionHeader

    <EditorBrowsable(EditorBrowsableState.Always),
    Browsable(True),
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
    Bindable(True)>
    Public Shadows Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Protected Shadows ReadOnly Property DefaultSize As Size
        Get
            Return New Size(200, 13)
        End Get
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Size = DefaultSize
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)

        lblText.Text = Text
    End Sub
End Class
