using DapperLibrary.Model;
using GridApplication.ViewModels.Product;
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
        public ICommand filterCommand { get; set; }
        public ICommand ShowEditForm { get; set; }

        private ObservableCollection<PRODUCT> _productList;
        public ObservableCollection<PRODUCT> ProductLists
        {
            get { return _productList; }
            set { _productList = value; OnPropertyChanged("ProductLists"); }
        }

        public ListProductViewModel()
        {
            ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().GetALL());
            filterCommand = new RelayCommand<string>(p => { return true; },
                p => { Search(p); });
            if (ProductItem != null)
                ShowEditForm = new RelayCommand<PRODUCT>(
                    p => { return p != null ? true : false; },
                    p =>
                    {
                        ShowEdit(p);
                    });
            else
            {
                ShowEditForm = new RelayCommand<PRODUCT>(
                    p => { return true; },
                    p => { ShowEdit(p); }
                    );
            }
        }

        private PRODUCT _ProductItem;
        public PRODUCT ProductItem
        {
            get { return _ProductItem; }
            set { _ProductItem = value; OnPropertyChanged("ProductItem"); }

        }
        private void ShowEdit(PRODUCT p)
        {

            //Kiem tra p neu !-null thif mo form va dien gia tri
            if (ProductEditViewModel.ProductEdit == null) ProductEditViewModel.ProductEdit = new PRODUCT();
            ProductEditViewModel.ProductEdit = p;
            if (p == null)
                ProductEditViewModel.isNew = true;
            else
                ProductEditViewModel.isNew = false;
            ProductEdit productEdit = new ProductEdit();
            productEdit.ShowDialog();
        }
        public void Search(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().GetALL());
            }
            else
            {
                ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().Search(input));
            }

        }
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
