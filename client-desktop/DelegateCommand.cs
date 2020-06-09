using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace client_desktop
{
    class DelegateCommand : ICommand

    {
        private bool isEnabled_ = true;
        private SimpleEventHandler handler;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();

        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled_;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.IsEnabled;
        }

        public void Execute(object parameter)
        {
            this.handler();
        }

        private void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
