using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektGuitarWPF.ViewModels.Commands
{
    /// <summary>
    /// Helper class for creating commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action action;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
