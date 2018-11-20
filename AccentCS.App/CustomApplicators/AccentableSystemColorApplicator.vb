Imports AccentApplicator.Core
Imports AccentApplicator.Core.Applicator

Namespace CustomApplicators
    Public Class AccentableSystemColorApplicator
        Inherits ApplicatorBase

        Private Shared _instance As AccentableSystemColorApplicator

        ''' <summary>
        '''     Gets the default instance of this Applicator.
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property Instance As AccentableSystemColorApplicator
            Get
                If (_instance Is Nothing) Then
                    _instance = New AccentableSystemColorApplicator()
                End If
                Return _instance
            End Get
        End Property

        Protected Overrides Function CreateColorSettings() As IDictionary(Of SystemColorId, ColorConfiguration)
            Dim result = New Dictionary(Of SystemColorId, ColorConfiguration)()

            'Fill the dictionnary with user settings
            result.Add(SystemColorId.ActiveCaption, New ColorConfiguration() With {
                .ChangesEnabled = My.Settings.SyncSetting_ActiveCaption_Sync,
                .UserBrightness = My.Settings.SyncSetting_ActiveCaption_UsrBrit,
                .UseUserBrightness = My.Settings.SyncSetting_ActiveCaption_SetBrit
            })

            '...

            Return result

        End Function
    End Class
End Namespace
