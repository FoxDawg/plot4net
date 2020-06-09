using System.Windows.Input;

namespace plot4net.Common.Commands
{
    /// <summary>
    ///     Extension of ICommand which exposes a raise execute handler.
    /// </summary>
    public interface IDelegateCommand : ICommand
    {
        /// <summary>
        ///     Call this to raise the CanExecuteChanged event.
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}