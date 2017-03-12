using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace alwfx.Devices.DTO
{
    /// <summary>
    /// Data Transfer Object for the UI implementation
    /// </summary>
    public class DeviceDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToNotification { get; set; }
        public string ToAlert { get; set; }

        #region Observable properties

        private string _mode;
        public string Mode
        {
            get { return _mode; }
            set { SetProperty(ref _mode, value); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        private int _timer;
        public int Timer
        {
            get { return _timer; }
            set { SetProperty(ref _timer, value); }
        }

        private int _remainingpercent;
        public int Remainingpercent
        {
            get { return _remainingpercent; }
            set { SetProperty(ref _remainingpercent, value); }
        }

        private Color _foreColorOfBar;
        public Color ForeColorOfBar
        {
            get { return _foreColorOfBar; }
            set { SetProperty(ref _foreColorOfBar, value); }
        }

        private Color _backColorOfBar;
        public Color BackColorOfBar
        {
            get { return _backColorOfBar; }
            set { SetProperty(ref _backColorOfBar, value); }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        ﻿protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = PropertyChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        ﻿﻿protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
