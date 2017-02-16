Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports AccentCS.Helpers

Namespace My
    Friend Enum SyncColorSettings
        Sync
        SetBrit
        UsrBrit
    End Enum
    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings
        Private Const stSYNC_SETTING_NAME_FORMAT As String = "SyncSetting_{0}_{1}"

        Private _writableSysColorsSyncSettings As Dictionary(Of SystemColorIDs, SystemColorSyncSettings)
        Private _writableForeSysColorsUsrValues As Dictionary(Of SystemColorIDs, Color)

        Private _systemColorsSyncSettings As ReadOnlyDictionary(Of SystemColorIDs, SystemColorSyncSettings)
        ''' <summary>
        ''' Dictionary containing groupped settings related to the synchronization process.
        ''' </summary>
        ''' <returns></returns>
        Friend ReadOnly Property SystemColorsSyncSettings As ReadOnlyDictionary(Of SystemColorIDs, SystemColorSyncSettings)
            Get
                If _systemColorsSyncSettings Is Nothing Then
                    CreateSysColorsSyncSettingsLists()
                End If
                Return _systemColorsSyncSettings
            End Get
        End Property

        Private _foreSystemColorsUserValues As ReadOnlyDictionary(Of SystemColorIDs, Color)
        ''' <summary>
        ''' Dictionnaries containing the user-defined foreground colors. If a color is empty,
        ''' it means that the user has not set a custom color.
        ''' </summary>
        ''' <returns></returns>
        Friend ReadOnly Property ForeSystemColorsUserValues As ReadOnlyDictionary(Of SystemColorIDs, Color)
            Get
                If _foreSystemColorsUserValues Is Nothing Then
                    CreateForeSysColorSettingsList()
                End If
                Return _foreSystemColorsUserValues
            End Get
        End Property

        Private Sub MySettings_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Me.PropertyChanged
            Dim tabPropNameParts() As String = e.PropertyName.Split("_"c)

            'We refresh the dictionary that contain a value.
            If tabPropNameParts.Length >= 3 AndAlso tabPropNameParts(0) = "SyncSetting" And _writableSysColorsSyncSettings IsNot Nothing Then
                Dim SysColorID As SystemColorIDs
                If [Enum].TryParse(tabPropNameParts(1), SysColorID) Then
                    _writableSysColorsSyncSettings.Item(SysColorID) = New SystemColorSyncSettings(SysColorID)
                End If
            ElseIf tabPropNameParts.Length >= 2 AndAlso tabPropNameParts(0) = "ForeSysColorUsrValue" And _foreSystemColorsUserValues IsNot Nothing Then
                Dim SysColorID As SystemColorIDs
                If [Enum].TryParse(tabPropNameParts(1), SysColorID) Then
                    _writableForeSysColorsUsrValues(SysColorID) = DirectCast(Item(e.PropertyName), Color)
                End If
            End If

            'We really need to save the settings all the time because when the Windows session ends, Windows kills
            'the process without giving it time to save its settings. I have tried cleanly exiting the app and even just saving the settings
            'when the SessionEnded system event is raised, but the results were too inconsistent.
            If General_SaveSettings Then
                Save()
            End If
        End Sub


        ''' <summary>
        ''' Returns the name of a setting related to the system color sync process.
        ''' </summary>
        ''' <param name="pSysColorID"></param>
        ''' <param name="pSetting"></param>
        ''' <returns></returns>
        Friend Function GetSysColorSyncSettingName(pSysColorID As String, pSetting As SyncColorSettings) As String
            Dim stSetting As String = [Enum].GetName(GetType(SyncColorSettings), pSetting)

            Dim stProptyName As String = String.Format(stSYNC_SETTING_NAME_FORMAT, pSysColorID, stSetting)

            Return stProptyName
        End Function

        ''' <summary>
        ''' Returns the name of a setting related to the system color sync process.
        ''' </summary>
        ''' <param name="pSysColorID"></param>
        ''' <param name="pSetting"></param>
        ''' <returns></returns>
        Friend Function GetSysColorSyncSettingName(pSysColorID As SystemColorIDs, pSetting As SyncColorSettings) As String
            Dim stColor As String = [Enum].GetName(GetType(SystemColorIDs), pSysColorID)
            Dim stSetting As String = [Enum].GetName(GetType(SyncColorSettings), pSetting)

            Dim stProptyName As String = String.Format(stSYNC_SETTING_NAME_FORMAT, stColor, stSetting)

            Return stProptyName
        End Function



        ''' <summary>
        ''' Creates a new SyncSettingDictionary of settings related to the synchronization 
        ''' of system colors for the SystemColorsSyncSettings property.
        ''' </summary>
        Private Sub CreateSysColorsSyncSettingsLists()
            _writableSysColorsSyncSettings = New Dictionary(Of SystemColorIDs, SystemColorSyncSettings)

            For Each value As Configuration.SettingsPropertyValue In PropertyValues
                Dim tabPropNameParts() As String = value.Name.Split("_"c)
                If tabPropNameParts.Length >= 3 AndAlso tabPropNameParts(0) = "SyncSetting" AndAlso tabPropNameParts(2) = "Sync" Then
                    Dim SysColorId As SystemColorIDs

                    If [Enum].TryParse(tabPropNameParts(1), SysColorId) Then
                        _writableSysColorsSyncSettings.Add(SysColorId, New SystemColorSyncSettings(SysColorId))
                    End If
                End If
            Next

            _systemColorsSyncSettings = New ReadOnlyDictionary(Of SystemColorIDs, SystemColorSyncSettings)(_writableSysColorsSyncSettings)
        End Sub

        Private Sub CreateForeSysColorSettingsList()
            _writableForeSysColorsUsrValues = New Dictionary(Of SystemColorIDs, Color)

            For Each value As Configuration.SettingsPropertyValue In PropertyValues
                Dim tabPropNameParts() As String = value.Name.Split("_"c)
                If tabPropNameParts.Length >= 2 AndAlso tabPropNameParts(0) = "ForeSysColorUsrValue" Then
                    Dim SysColorId As SystemColorIDs

                    If [Enum].TryParse(tabPropNameParts(1), SysColorId) Then
                        Dim colNew As Color
                        'Normally, a Color Structure is never null, but since the property
                        'that returns it is an Object, it can exceptionnaly be null and causes
                        'an exception when casting it. This check fixes a strange bug that occured before:
                        'When a fore color was not modified by the user and the app.config file
                        'was missing from the application directory, the PropertyValue here was null,
                        'which caused an exception. Strangely, when the config file was there, no
                        'problem occured.
                        If value.PropertyValue IsNot Nothing Then
                            colNew = DirectCast(value.PropertyValue, Color)
                        Else
                            colNew = Color.Empty
                        End If
                        _writableForeSysColorsUsrValues.Add(SysColorId, colNew)
                    End If
                End If
            Next

            _foreSystemColorsUserValues = New ReadOnlyDictionary(Of SystemColorIDs, Color)(_writableForeSysColorsUsrValues)
        End Sub
    End Class
End Namespace
