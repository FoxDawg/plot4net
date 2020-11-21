using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace plot4net.Common.ViewModel
{
    /// <summary>
    /// Base class for viewmodels
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised on property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to set properties and auto-invoke property changed events on value changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(property, value))
            {
                property = value;
                this.NotifyPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to manually invoke property change events
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}