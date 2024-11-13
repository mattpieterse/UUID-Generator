using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Desktop.Core.Models;

public class ObservableObject
    : INotifyPropertyChanged {
    /* Superclass to notify observers of child property changes.
     */

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}