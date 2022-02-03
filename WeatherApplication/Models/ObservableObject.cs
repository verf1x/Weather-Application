using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Verf1xWeatherApp.Models
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected virtual bool SetValue<T0>(ref T0 field, T0 value, [CallerMemberName] string propName = "")
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propName);
            return true;
        }
    }
}
