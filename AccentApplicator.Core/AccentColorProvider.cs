using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace AccentApplicator.Core
{
    /// <summary>
    ///     Component that provides the system accent color and to which control properties
    ///     can be data-binded.
    /// </summary>
    public sealed class AccentColorProvider : Component
    {
        private UISettings _uiSettings;
        private Color _accentColor;

        public AccentColorProvider()
        {
            _uiSettings = new UISettings();
            _accentColor = _uiSettings.GetColorValue(UIColorType.Accent).ToDrawingColor();
            _uiSettings.ColorValuesChanged += _uiSettings_ColorValuesChanged;
        }

        public AccentColorProvider(IContainer container) : this()
        {
            container.Add(this);
        }

        //Note that to support data binding, we must either implement INotifyPropertyChanged
        //or have an event whose name support the following convention : <Property name>Changed.
        //In this case, we chose the latter.
        /// <summary>
        ///     Occurs when the value of <see cref="AccentColor"/> is changed.
        /// </summary>
        public event EventHandler AccentColorChanged;

        /// <summary>
        ///     Gets the system accent color.
        /// </summary>
        public Color AccentColor => _accentColor;


        private void _uiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            //It's not clear by the documentation for the UISettings class if there
            //is a way to know which color has changed
            var colNew = _uiSettings.GetColorValue(UIColorType.Accent).ToDrawingColor();
            if (_accentColor != colNew)
            {
                OnAccentColorChanged(EventArgs.Empty);
            }
        }

        private void OnAccentColorChanged(EventArgs e)
        {
            AccentColorChanged?.Invoke(this, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uiSettings.ColorValuesChanged -= _uiSettings_ColorValuesChanged;
            }
            base.Dispose(disposing);
        }
    }
}
