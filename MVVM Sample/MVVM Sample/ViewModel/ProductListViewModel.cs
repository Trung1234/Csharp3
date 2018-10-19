
using MVVM_Sample.Screen;
using SaleLibrary.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TESTEntitiesLibrary;

namespace MVVM_Sample.ViewModel
{
    public class ProductListViewModel : BaseClass
    {
        private ObservableCollection<PRODUCT> _productList;
        public ObservableCollection<PRODUCT> ProductList
        {
            get { return _productList; }
            set { _productList = value; OnPropertyChanged(); }
        }

        private PRODUCT _productItem;
        public PRODUCT ProductItem
        {
            get { return _productItem; }
            set { _productItem = value; OnPropertyChanged(); }
        }
        ProductDao dao = new ProductDao();
        public ProductListViewModel()
        {
            List<PRODUCT> rs = dao.GetALl();
            ProductList = new ObservableCollection<PRODUCT>(ProductDao.Instance().GetALl().ToList());
            if (ProductItem != null)
                ShowEditWindow = new RelayCommand<PRODUCT>((p) => { return p != null ? true : false; }, (p) => { ShowWindow(ProductItem); });
            else
                ShowEditWindow = new RelayCommand<PRODUCT>((p) => { return true; }, (p) => { ShowWindow(ProductItem); });
        }

        public ICommand ShowEditWindow { get; set; }

        private void ShowWindow(PRODUCT p)
        {
            if (ProductEditViewModel.ProductEdit == null) ProductEditViewModel.ProductEdit = new PRODUCT();
            ProductEditViewModel.ProductEdit = p;
            ProductEdit productEdit = new ProductEdit();
            productEdit.ShowDialog();
        }
    }
}
