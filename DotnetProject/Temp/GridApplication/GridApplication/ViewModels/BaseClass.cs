using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GridApplication.ViewModels
{
    public class BaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public static void CloseForm(FrameworkElement p)
        {
            if (p != null)
            {
                var sp = p as FrameworkElement;
                if (sp != null)
                {
                    var curParent = sp.Parent;
                    if (curParent != null)
                        CloseForm(curParent as FrameworkElement);
                    else
                        (sp as Window).Close();
                }
            }
        }
    }
   
    
}
