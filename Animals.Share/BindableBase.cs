using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Animals.Share
{
    public class BindableBase : INotifyPropertyChanged
    {
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
        }

        protected bool SetProperty<T>(ref T storage, T value, Action action,
            [CallerMemberName] string propertyName = null)
        {
            var r = SetProperty(ref storage, value, propertyName);
            if (r) action?.Invoke();
            return r;
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}