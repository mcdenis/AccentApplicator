Imports System.Runtime.InteropServices

Module NativeMethods

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function SetSysColors(ByVal nChanges As Integer,
           ByRef lpSysColor As Integer, ByRef lpColorValues As Integer) As Integer
    End Function

    <DllImport("uxtheme.dll", ExactSpelling:=True)>
    Public Function GetThemeSysColor(hTheme As IntPtr, iColorId As Integer) As Integer
    End Function

    <DllImport("dwmapi.dll", PreserveSig:=False)>
    Public Sub DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean)
    End Sub

End Module
