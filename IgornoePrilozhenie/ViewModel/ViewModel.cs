using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using IgornoePrilozhenie.DataContext;

namespace IgornoePrilozhenie
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public interface IGameViewModel
        {
            
        }

        private UserControl _selectedControl;
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ICommand ShowUserControl1Command => new RelayCommand(ShowUserControl1);
        public ICommand ShowUserControl2Command => new RelayCommand(ShowUserControl2);
        public ICommand ShowUserControl3Command => new RelayCommand(ShowUserControl3);
        public ICommand ShowUserControl4Command => new RelayCommand(ShowUserControl4);
        public ICommand ShowUserControl5Command => new RelayCommand(ShowUserControl5);
        

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ShowUserControl1()
        {
            LocatorView.CurrentView.UserControl.Content = new Results();
        }

        private void ShowUserControl2()
        {
            LocatorView.CurrentView.UserControl.Content = new ChoseRejim();
        }
        private void ShowUserControl3()
        {
            LocatorView.CurrentView.UserControl.Content = new UserControl1();
        }
        private void ShowUserControl4()
        {
            LocatorView.CurrentView.UserControl.Content = new BlackJack();
        }
        private void ShowUserControl5()
        {
            LocatorView.CurrentView.UserControl.Content = new RussianRullet();
        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
