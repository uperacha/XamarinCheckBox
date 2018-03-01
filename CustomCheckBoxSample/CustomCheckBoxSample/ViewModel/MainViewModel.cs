using System.ComponentModel;
using Xamarin.Forms;

namespace CustomCheckBoxSample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Commands      
        public Command CheckedCommand { get; private set; }
        #endregion

        #region Properties
        public bool Checked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public MainViewModel()

        {
            CheckedCommand = new Command(this.Check, this.CheckCanExecute);
        }

        #region Private
        private void Check()
        {
            this.Checked = !this.Checked;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Checked"));
        }

        private bool CheckCanExecute()
        {
            return true;
        }
        #endregion
    }
}
