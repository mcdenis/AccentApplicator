using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AccentApplicator.Core.Applicator
{
    public class ColorConfiguration : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Color _baseColor;
        public Color BaseColor
        {
            get => _baseColor;
            set
            {
                if (_baseColor != value)
                {
                    _baseColor = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _changedEnabled;
        public bool ChangesEnabled
        {
            get => _changedEnabled;
            set
            {
                if (_changedEnabled != value)
                {
                    _changedEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _useUserBrightness;
        public bool UseUserBrightness
        {
            get => _useUserBrightness;
            set
            {
                if (_useUserBrightness != value)
                {
                    _useUserBrightness = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double _userBrightness;
        public double UserBrightness
        {
            get => _userBrightness;
            set
            {
                if (_userBrightness != value)
                {
                    _userBrightness = value;
                    RaisePropertyChanged();
                }
            }
        }

        //Initially, we are dirty because we have not been applied yet
        public bool HasDirtyValues { get; protected set; } = true;

        internal void ResetDirtyState()
        {
            HasDirtyValues = false;
        }

        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            HasDirtyValues = true;
            PropertyChanged?.Invoke(this, e);
        }
    }
}
