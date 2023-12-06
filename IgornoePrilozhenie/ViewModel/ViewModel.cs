using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace IgornoePrilozhenie
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public interface IGameViewModel
        {
            UserControl CurrentControl { get; set; }
        }

        private UserControl _selectedControl;
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ICommand ShowUserControl1Command => new RelayCommand(ShowUserControl1);
        public ICommand ShowUserControl2Command => new RelayCommand(ShowUserControl2);
        public ICommand ShowUserControl3Command => new RelayCommand(ShowUserControl3);
        public ICommand ShowUserControl4Command => new RelayCommand(ShowUserControl4);
        public ICommand ShowUserControl5Command => new RelayCommand(ShowUserControl5);
        public ICommand ShowUserContro6Command => new RelayCommand(ShowUserControl6);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public UserControl SelectedControl
        {
            get { return _selectedControl; }
            set
            {
                if (_selectedControl != value)
                {
                    _selectedControl = value;
                    OnPropertyChanged(nameof(SelectedControl));
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ShowUserControl1()
        {
            SelectedControl = new Results();
        }

        private void ShowUserControl2()
        {
            SelectedControl = new ChoseRejim();
        }
        private void ShowUserControl3()
        {
            SelectedControl = new UserControl1();
        }
        private void ShowUserControl4()
        {
            SelectedControl = new BlackJack();
        }
        private void ShowUserControl5()
        {
            SelectedControl = new RussianRullet();
        }
        private void ShowUserControl6()
        {
            SelectedControl = new Defeat();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
