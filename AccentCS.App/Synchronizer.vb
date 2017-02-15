Imports AccentCS.Helpers

Public Class Synchronizer

    Private Shared ReadOnly objPadlock As New Object

    Private Shared _instance As Synchronizer
    Friend Shared ReadOnly Property Instance As Synchronizer
        Get
            SyncLock objPadlock
                If _instance Is Nothing Then
                    _instance = New Synchronizer
                End If
            End SyncLock

            Return _instance
        End Get
    End Property

    ''' <summary>
    ''' Returns the final color to apply to a system color depending of its sync settings.
    ''' </summary>
    ''' <param name="pSettings"></param>
    ''' <param name="pAccent"></param>
    ''' <returns></returns>
    Private Function GetColorToApply(pSettings As My.SystemColorSyncSettings, pAccent As Color) As Color
        If pSettings.SetBrightness Then
            Return RGBHSL.SetBrightness(pAccent, pSettings.UserBrightness)
        Else
            Return pAccent
        End If
    End Function

    '''<exception cref="Exception" >The accent color cannot be obtained. If it was supplied as a parameter, it was empty</exception>
    '''<exception cref="ComponentModel.Win32Exception">Occurs when SetSysColor fails.</exception>
    ''' <summary>
    ''' Syncs all the system colors that are configured to be synced.
    ''' </summary>
    ''' <param name="pAccent">
    ''' Color representing the accent color to use. Usefull to reduce processing 
    ''' if the accent is already known by the caller.
    ''' </param>
    Friend Sub SyncNow(Optional pAccent As Color = Nothing)
        If pAccent.IsEmpty Then
            pAccent = AccentColor.GetAccentColor(My.Settings.General_AccentSource, pIgnoreAlpha:=True)
            If pAccent.IsEmpty Then
                Throw New Exception(My.Resources.LocalizedResources.Error_InvalidAccent)
            End If
        End If

        'Declare the lists that will be extended as we check which color is configured to be synced.
        Dim lstSysColorIDs As New List(Of SystemColorIDs)
        Dim lstNewColors As New List(Of Color)

        Dim inMaxIndex As Integer = My.Settings.SystemColorsSyncSettings.Count - 1
        For i As Integer = 0 To inMaxIndex
            Dim element As KeyValuePair(Of SystemColorIDs, My.SystemColorSyncSettings) = My.Settings.SystemColorsSyncSettings.ElementAt(i)
            If element.Value.Sync Then
                lstSysColorIDs.Add(element.Key)
                Dim colNew As Color
                If element.Value.SetBrightness Then
                    colNew = RGBHSL.SetBrightness(pAccent, element.Value.UserBrightness)
                Else
                    colNew = pAccent
                End If
                lstNewColors.Add(colNew)
            End If
        Next

        'Apply changes if needed.
        If lstSysColorIDs.Count > 0 Then
            SetSystemColors(lstSysColorIDs.ToArray, lstNewColors.ToArray)
        End If
    End Sub

    '''<exception cref="Exception" >The accent color cannot be obtained. If it was supplied as a parameter, it was empty</exception>
    '''<exception cref="ComponentModel.Win32Exception">Occurs when SetSysColor fails.</exception>
    ''' <summary>
    ''' Sync the specified system color wether or not it is configured
    ''' to be synced.
    ''' </summary>
    ''' <param name="pSysColorID"></param>
    ''' <param name="pAccent">
    ''' Color representing the accent color to use. Usefull to reduce processing 
    ''' if the accent is already known by the caller.
    ''' </param>
    Friend Sub SyncSingleSystemColor(pSysColorID As SystemColorIDs, Optional pAccent As Color = Nothing)
        If pAccent.IsEmpty Then
            pAccent = AccentColor.GetAccentColor(My.Settings.General_AccentSource, pIgnoreAlpha:=True)
            If pAccent.IsEmpty Then
                Throw New Exception(My.Resources.LocalizedResources.Error_InvalidAccent)
            End If
        End If

        Dim config As My.SystemColorSyncSettings = My.Settings.SystemColorsSyncSettings.Item(pSysColorID)
        Dim colToApply As Color = GetColorToApply(config, pAccent)

        'Apply change
        SetSystemColors({pSysColorID}, {colToApply})
    End Sub

    '''<exception cref="ComponentModel.Win32Exception">Occurs when SetSysColor fails.</exception>
    ''' <summary>
    ''' Restore all the foregroud color set by the user.
    ''' </summary>
    Friend Sub RestoreLastForeColors()
        Dim lstSysColorIDs As List(Of SystemColorIDs) = New List(Of SystemColorIDs)
        Dim lstNewColors As List(Of Color) = New List(Of Color)

        Dim dicSettings = My.Settings.ForeSystemColorsUserValues
        For i As Integer = 0 To dicSettings.Count - 1
            Dim element = dicSettings.ElementAt(i)
            If element.Value.IsEmpty = False Then
                lstSysColorIDs.Add(element.Key)
                lstNewColors.Add(element.Value)
            End If
        Next

        'Apply changes
        If lstSysColorIDs.Count > 0 Then
            SetSystemColors(lstSysColorIDs.ToArray, lstNewColors.ToArray)
        End If
    End Sub
End Class
