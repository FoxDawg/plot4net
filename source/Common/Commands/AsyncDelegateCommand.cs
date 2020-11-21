using System;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace plot4net.Common.Commands
{
    /// <summary>
    /// A base ICommand implementation that supports async/await.
    /// </summary>
    public class AsyncDelegateCommand : IAsyncDelegateCommand
    {
        /// <summary>
        /// </summary>
        protected readonly Predicate<object> canExecute;

        /// <summary>
        /// </summary>
        protected Func<object, Task> asyncExecute;

        /// <summary>
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new async delegate command.
        /// </summary>
        /// <param name="execute">Method to call when command is executed.</param>
        public AsyncDelegateCommand(Func<Task> execute)
            : this(_ => execute(), null)
        {
        }

        /// <summary>
        /// Creates a new async delegate command.
        /// </summary>
        /// <param name="execute">Method to call when command is executed.</param>
        public AsyncDelegateCommand(Func<object, Task> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new async delegate command.
        /// </summary>
        /// <param name="execute">Method to call when command is executed.</param>
        /// <param name="canExecute">Method to call to determine whether command is valid.</param>
        public AsyncDelegateCommand(Func<Task> execute, Func<bool> canExecute)
            : this(_ => execute(), _ => canExecute())
        {
        }

        /// <summary>
        /// Creates a new async delegate command.
        /// </summary>
        /// <param name="asyncExecute">Method to call when command is executed.</param>
        /// <param name="canExecute">Method to call to determine whether command is valid.</param>
        public AsyncDelegateCommand(Func<object, Task> asyncExecute,
                                    Predicate<object> canExecute)
        {
            this.asyncExecute = asyncExecute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Raise the CanExecuteChanged handler.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns whether the command is possible right now.
        /// </summary>
        /// <returns><c>true</c>, if execute was caned, <c>false</c> otherwise.</returns>
        /// <param name="parameter">Parameter.</param>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public async void Execute(object parameter)
        {
            await this.ExecuteAsync(parameter);
        }

        /// <summary>
        /// Executes the command and returns an awaitable task.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="parameter">Parameter.</param>
        public async Task ExecuteAsync(object parameter)
        {
            await this.asyncExecute(parameter);
        }
    }

    /// <summary>
    /// A generic ICommand implementation that supports async/await.
    /// </summary>
    public class AsyncDelegateCommand<T> : IAsyncDelegateCommand<T>
    {
        /// <summary>
        /// </summary>
        protected readonly Predicate<T> canExecute;

        /// <summary>
        /// </summary>
        protected Func<T, Task> asyncExecute;

        /// <summary>
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new async delegate command.
        /// </summary>
        /// <param name="execute">Method to call when command is executed.</param>
        public AsyncDelegateCommand(Func<T, Task> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new async delegate command.
        /// </summary>
        /// <param name="asyncExecute">Method to call when command is executed.</param>
        /// <param name="canExecute">Method to determine whether command is valid.</param>
        public AsyncDelegateCommand(Func<T, Task> asyncExecute,
                                    Predicate<T> canExecute)
        {
            this.asyncExecute = asyncExecute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Raises the CanExecuteChanged event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns whether the command is valid at this moment.
        /// </summary>
        /// <returns><c>true</c>, if execute was caned, <c>false</c> otherwise.</returns>
        /// <param name="parameter">Parameter.</param>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute((T)parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns><c>true</c>, if execute was caned, <c>false</c> otherwise.</returns>
        /// <param name="parameter">Parameter.</param>
        public async void Execute(object parameter)
        {
            await this.ExecuteAsync((T)parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns><c>true</c>, if execute was caned, <c>false</c> otherwise.</returns>
        /// <param name="parameter">Parameter.</param>
        public async Task ExecuteAsync(T parameter)
        {
            await this.asyncExecute(parameter);
        }
    }
}