using IgornoePrilozhenie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IgornoePrilozhenie.DataContext
{
    public class CurrentView: PropertyC
    {
        private UserControl _userControl = new UserControl1();
        public UserControl UserControl
        {
            get
            {
                if(_userControl == null)
                {
                    _userControl = new UserControl1();
                }
                return _userControl;
            }
            set
            {
                _userControl = value;
                OnPropertyChanged("UserControl");

            }
        }
    }
}
