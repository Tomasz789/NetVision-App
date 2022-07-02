using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.MVRelayCmds
{
    public class AsyncRelayCommand : IAsyncCommand
    {
        private readonly ObservableCollection<Task> _currentTasksList;

        public AsyncRelayCommand()
        {
            _currentTasksList = new ObservableCollection<Task>();
            _currentTasksList.CollectionChanged += OnTaskCollectionChanged;
        }

        private void OnTaskCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        private IEnumerable<Task> GetCurrentTasks
        {
            get => _currentTasksList;
        }
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public async void Execute(object parameter)
        {
            Task currentRunningTask = ExecuteAsync();
            _currentTasksList.Add(currentRunningTask);

            try
            {
                await currentRunningTask;
            }
            finally
            {
                _currentTasksList.Remove(currentRunningTask);
            }
        }

        public bool CanExecute()
        {
            return true;
        }
        public async Task ExecuteAsync()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1000));
        }

        
    }
}
