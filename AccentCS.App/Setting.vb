Imports System.Configuration

Namespace My
    ''' <summary>
    ''' Wraps a strongly typed setting from MySettings.
    ''' </summary>
    ''' <typeparam name="T">Type of the setting value.</typeparam>
    Friend Class Setting(Of T)
        Private ReadOnly rawSetting As SettingsPropertyValue

        Friend Sub New(pSetting As SettingsPropertyValue)
            rawSetting = pSetting
        End Sub

        'Getting or setting the setting value thru the SettingsPropertyValue object
        'seems to bypass MySettings, which causes it the PropertyChanged event
        'not to be raised. As a workaround, we use just get the name from the
        'SettingPropertyValue and get or set the value from Settings, as we usually do.
        Friend Property Value As T
            Get
                Dim objValue = Settings.Item(Name)
                If objValue IsNot Nothing Then
                    Return DirectCast(objValue, T)
                Else
                    Return Nothing
                End If
            End Get
            Set(value As T)
                Settings.Item(Name) = value
            End Set
        End Property

        Friend ReadOnly Property DefaultValue As String
            Get
                Dim objValue = rawSetting.Property.DefaultValue
                If objValue IsNot Nothing Then
                    Return DirectCast(objValue, String)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Friend ReadOnly Property Name As String
            Get
                Return rawSetting.Name
            End Get
        End Property

    End Class
End Namespace
