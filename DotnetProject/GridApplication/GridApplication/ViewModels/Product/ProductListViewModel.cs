using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GridApplication.ViewModels
{
    public class ListProductViewModel : BaseClass
    {
        private ObservableCollection<PRODUCT> _productList;
        public ObservableCollection<PRODUCT> ProductLists
        {
            get { return _productList; }
            set { _productList = value; OnPropertyChanged("ProductLists"); }
        }

        public ListProductViewModel()
        {
            ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().GetALL());
            filterCommand = new RelayCommand<string>(p => { return true; }, p => { SearchByCd(p); });
        }

        public ICommand filterCommand { get; set; }
        public void SearchByCd(string productTypeCD)
        {
            if (string.IsNullOrEmpty(productTypeCD))
            {
                ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().GetALL());
            }
            else
            {
                ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().SearchByCD(productTypeCD));
            }

        }
    }
}
