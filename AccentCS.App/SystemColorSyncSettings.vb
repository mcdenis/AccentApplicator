Namespace My
    Friend Class SystemColorSyncSettings
        Friend Sub New(pSysColorID As Helpers.SystemColorIDs)
            Sync = DirectCast(Settings.Item(Settings.GetSysColorSyncSettingName(pSysColorID, SyncColorSettings.Sync)), Boolean)
            SetBrightness = DirectCast(Settings.Item(Settings.GetSysColorSyncSettingName(pSysColorID, SyncColorSettings.SetBrit)), Boolean)
            UserBrightness = DirectCast(Settings.Item(Settings.GetSysColorSyncSettingName(pSysColorID, SyncColorSettings.UsrBrit)), Double)
        End Sub

        Friend ReadOnly Property Sync As Boolean
        Friend ReadOnly Property SetBrightness As Boolean
        Friend ReadOnly Property UserBrightness As Double
    End Class
End Namespace
