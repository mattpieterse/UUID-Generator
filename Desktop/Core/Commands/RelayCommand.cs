using System.Windows.Input;

namespace Desktop.Core.Commands;

public class RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
    : ICommand {
    /* Command that takes a delegate method and passes an object parameter to it
     * if the delegate predicate (bool) method returns true or is null
     */

    public event EventHandler? CanExecuteChanged
    {
        remove => CommandManager.RequerySuggested -= value;
        add => CommandManager.RequerySuggested += value;
    }

    // - Command

    public bool CanExecute(object? parameter) {
        if (canExecute is null) return true;
        return parameter is not null && canExecute(parameter);
    }

    public void Execute(object? parameter) {
        if (parameter is not null) execute.Invoke((parameter));
    }
}