Imports System.Runtime.InteropServices

Module NativeMethods

    <DllImport("user32.dll", SetLastError:=True)>
    Friend Function SetSysColors(ByVal nChanges As Integer,
           ByRef lpSysColor As Integer, ByRef lpColorValues As Integer) As Integer
    End Function

    <DllImport("dwmapi.dll", PreserveSig:=False)>
    Friend Sub DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean)
    End Sub

End Module
