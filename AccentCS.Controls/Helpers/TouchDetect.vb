Imports System.Runtime.InteropServices

''' <summary>
''' Allows the detection of the input device.
''' </summary>
Module TouchDetect
    ''' <summary>
    ''' The sources of the input event that is raised and is generally
    ''' recognized as mouse events.
    ''' </summary>
    Public Enum MouseEventSource
        ''' <summary>
        ''' Events raised by the mouse
        ''' </summary>
        Mouse

        ''' <summary>
        ''' Events raised by a stylus
        ''' </summary>
        Pen

        ''' <summary>
        ''' Events raised by touching the screen
        ''' </summary>
        Touch
    End Enum

    ''' <summary>
    ''' Gets the extra information for the mouse event.
    ''' </summary>
    ''' <returns>The extra information provided by Windows API</returns>
    <DllImport("user32.dll")>
    Private Function GetMessageExtraInfo() As UInteger
    End Function

    ''' <summary>
    ''' Determines what input device triggered the mouse event.
    ''' </summary>
    ''' <returns>
    ''' A result indicating whether the last mouse event was triggered
    ''' by a touch, pen or the mouse.
    ''' </returns>
    Public Function GetMouseEventSource() As MouseEventSource
        Dim extra As UInteger = GetMessageExtraInfo()
        Dim isTouchOrPen As Boolean = ((extra And &HFFFFFF00UI) = &HFF515700UI)

        If Not isTouchOrPen Then
            Return MouseEventSource.Mouse
        End If

        Dim isTouch As Boolean = ((extra And &H80) = &H80)

        Return If(isTouch, MouseEventSource.Touch, MouseEventSource.Pen)
    End Function
End Module
