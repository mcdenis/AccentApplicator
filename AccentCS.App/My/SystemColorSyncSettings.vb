Namespace My
    Friend Class SystemColorSyncSettings
        Friend Sub New(pSysColorID As Helpers.SystemColorIDs)
            Sync = New Setting(Of Boolean)(Settings.PropertyValues(Settings.GetSysColorSyncSettingName(pSysColorID, SyncColorSettings.Sync)))
            SetBrightness = New Setting(Of Boolean)(Settings.PropertyValues(Settings.GetSysColorSyncSettingName(pSysColorID, SyncColorSettings.SetBrit)))
            UserBrightness = New Setting(Of Double)(Settings.PropertyValues(Settings.GetSysColorSyncSettingName(pSysColorID, SyncColorSettings.UsrBrit)))
        End Sub

        Friend ReadOnly Property Sync As Setting(Of Boolean)
        Friend ReadOnly Property SetBrightness As Setting(Of Boolean)
        Friend ReadOnly Property UserBrightness As Setting(Of Double)
    End Class
End Namespace
