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
    public class ProductTypeListViewModel : BaseClass
    {
        private ObservableCollection<PRODUCT_TYPE> _productTypeList;
        public ICommand ShowEditForm { get; set; }
        public ICommand filterCommand { get; set; }


        public ObservableCollection<PRODUCT_TYPE> ProductTypeLists
        {
            get { return _productTypeList; }
            set { _productTypeList = value; OnPropertyChanged("ProductTypeLists"); }
        }


        /// <summary>
        /// lay du lieu tu listview, 1 dong tuong ung voi 1 doi tuong Product Type
        /// </summary>
        /// 
        private PRODUCT_TYPE _ProductItem;
        public PRODUCT_TYPE ProductItem
        {
            get { return _ProductItem; }
            set { _ProductItem = value; OnPropertyChanged("ProductItem"); }
        }
        public ProductTypeListViewModel()
        {
            ProductTypeLists = new ObservableCollection<PRODUCT_TYPE>(ProductTypeDao.Instance().GetALL());
            filterCommand = new RelayCommand<string>(p => { return true; }, p => { SearchByCd(p); });
            if (ProductItem != null)
                ShowEditForm = new RelayCommand<PRODUCT_TYPE>(
                    p => { return p != null ? true : false; },
                    p =>
                    {
                        ShowEdit(p);
                    });
            else
            {
                ShowEditForm = new RelayCommand<PRODUCT_TYPE>(
                    p => { return true; },
                    p => { ShowEdit(p); }
                    );
            }
        }

        private void ShowEdit(PRODUCT_TYPE p)
        {
           
            //Kiem tra p neu !-null thif mo form va dien gia tri
            if (ProductTypeEditViewModel.ProductTypeEdit == null) ProductTypeEditViewModel.ProductTypeEdit = new PRODUCT_TYPE();
            ProductTypeEditViewModel.ProductTypeEdit = p;
            if (p == null)
                ProductTypeEditViewModel.isNew = true;
            else
                ProductTypeEditViewModel.isNew = false;
            ProductTypeEdit productEdit = new ProductTypeEdit();
            productEdit.ShowDialog();
        }

        
        public void SearchByCd(string productTypeCD)
        {
            if (string.IsNullOrEmpty(productTypeCD))
            {
                ProductTypeLists = new ObservableCollection<PRODUCT_TYPE>(ProductTypeDao.Instance().GetALL());
            }
            else
            {
                ProductTypeLists = new ObservableCollection<PRODUCT_TYPE>(ProductTypeDao.Instance().SearchByCD(productTypeCD));
            }

        }
        


    }
}
