using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace AccentApplicator.Core.Applicator
{
    public abstract class ApplicatorBase
    {
        /*
         * Note - Reason when ApplyNow() need to be called automatically :
         * -Automatic application has just been enabled;
         * -A color setting has changed;
         * -The system accent color has changed and at least one system color is configured to use it;
         */

        //Color value reserved for the accent color
        private readonly Color _accentColor = Color.Transparent;

        private UISettings _systemUISettings;
        //When this is true, we sync a set a system color that uses the accent color even though its settings are not dirty.
        private bool _pendingAccentChange;

        private bool _applySettingsAutomatically;
        /// <summary>
        ///     Gets or sets a value indicating if the color settings should be applied automatically
        ///     when needed (e.g. when the system accent color is changed).
        /// </summary>
        public bool ApplySettingsAutomatically
        {
            get => _applySettingsAutomatically;
            set
            {
                _applySettingsAutomatically = value;
                EnsureSystemSettings();
                ApplyNow();
            }
        }

        /// <summary>
        ///     Returns a dictionary of settings for the system colors that are to be supported.
        /// </summary>
        /// <returns></returns>
        protected abstract IDictionary<SystemColorId, ColorConfiguration> CreateColorSettings();

        /// <summary>
        ///     Gets a collection of settings for all system colors supported by this instance.
        /// </summary>
        public IReadOnlyDictionary<SystemColorId, ColorConfiguration> ColorSettings { get; }

        protected ApplicatorBase()
        {
            //Create the settings collection using what's provided by the base class
            var settings = CreateColorSettings();
            ColorSettings = new ReadOnlyDictionary<SystemColorId, ColorConfiguration>(settings);

            HookSettings();
        }

        /// <summary>
        ///     Ensure our <see cref="UISettings"/> object is loaded and that we are listening to its color changed event.
        /// </summary>
        private void EnsureSystemSettings()
        {
            if (_systemUISettings == null)
            {
                _systemUISettings = new UISettings();
                _systemUISettings.ColorValuesChanged += _systemUISettings_ColorValuesChanged;
                _pendingAccentChange = true;
            }
        }

        private void HookSettings()
        {
            foreach (var s in ColorSettings.Values)
            {
                s.PropertyChanged += ColorSetting_PropertyChanged;
            }
        }

        private void UnhookSettings()
        {
            foreach (var s in ColorSettings.Values)
            {
                s.PropertyChanged -= ColorSetting_PropertyChanged;
            }
        }

        private void ColorSetting_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var setting = (ColorConfiguration)sender;
            if (ApplySettingsAutomatically && setting.BaseColor == _accentColor)
            {
                ApplyNow();
            }
        }

        private void _systemUISettings_ColorValuesChanged(UISettings sender, object args)
        {
            if (ApplySettingsAutomatically && ColorSettings.Values.Any(s => s.BaseColor == _accentColor));
            {
                _pendingAccentChange = true;
                ApplyNow();
            }
        }

        public void ApplyNow()
        {
            var ids = new List<int>();
            var colors = new List<int>();
            
            foreach (var kv in ColorSettings)
            {
                if (
                        kv.Value.HasDirtyValues ||
                        //When the accent has changed, we need to apply the change even though the color config is not dirty.
                        (kv.Value.BaseColor == _accentColor && _pendingAccentChange)
                        )
                {
                    Color colColor;
                    if (kv.Value.ChangesEnabled)
                    {
                        //Get the appropriate base color
                        if (kv.Value.BaseColor == _accentColor)
                        {
                            EnsureSystemSettings();
                            colColor = _systemUISettings.GetColorValue(UIColorType.Accent).ToDrawingColor();
                        }
                        else
                        {
                            colColor = kv.Value.BaseColor;
                        }
                        //Apply the brightness
                        if (kv.Value.UseUserBrightness)
                        {
                            colColor = RGBHSL.SetBrightness(colColor, kv.Value.UserBrightness);
                        }
                    }
                    else
                    {
                        //Get the default color
                        colColor = SystemColorUtils.GetDefaultSystemColor(kv.Key);
                    }

                    ids.Add((int)kv.Key);
                    colors.Add(ColorTranslator.ToWin32(colColor));
                }

                //This config is handled
                kv.Value.ResetDirtyState();
            }

            if (ids.Count > 0)
            {
                NativeMethods.SetSysColors(ids.Count, ids.ToArray(), colors.ToArray());
            }

            //If there were any system color that used the accent color, they were refreshed.
            _pendingAccentChange = false;
        }
    }
}
