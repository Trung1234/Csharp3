using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GridApplication.ViewModels
{
    public class ProductTypeEditViewModel : BaseClass
    {
        public static bool isNew = false;
        public ICommand ExecuteCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        private static PRODUCT_TYPE _productTypeEdit;
        public static PRODUCT_TYPE ProductTypeEdit
        {
            get { return _productTypeEdit; }
            set { _productTypeEdit = value; }
        }

        public ProductTypeEditViewModel()
        {
            if (isNew)
                ExecuteCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { AddNew(p); });
            else

                ExecuteCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { Edit(p); });
            CloseCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { BaseClass.CloseForm(p); });
        }

        //}
        private void AddNew(FrameworkElement p)
        {
            GetData(p);
            ProductTypeDao.Instance().Add(ProductTypeEdit);
            //ProductTypeListViewModel.ProductTypeLists=new ObservableCollection<PRODUCT_TYPE>()
            CloseForm(p);
        }
        private void Edit(FrameworkElement p)
        {
            MessageBoxResult dlg= MessageBox.Show("Co chac chan muon sua khong?", "Xac nhan sua", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlg == MessageBoxResult.Yes)
            {
                GetData(p);
                ProductTypeDao.Instance().Update(ProductTypeEdit);
                CloseForm(p);
            }
        }
        private void GetData(FrameworkElement p)
        {
            if (ProductTypeEdit == null)
                ProductTypeEdit = new PRODUCT_TYPE();
            if (p != null)
            {
                var sp = p as StackPanel;
                if (sp != null)
                {
                    if (sp.Name.Equals("spProductType"))
                    {
                        foreach (var item in sp.Children)
                        {
                            var tb = item as TextBox;
                            if (tb != null)
                            {
                                if (tb.Name.Equals("txtTypeCD"))
                                {
                                    ProductTypeEdit.PRODUCT_TYPE_CD = tb.Text;
                                }
                                if (tb.Name.Equals("txtName"))
                                {
                                    ProductTypeEdit.NAME = tb.Text;
                                }
                            }
                        }
                    }
                        
                }
            }
        }
       
        private PRODUCT_TYPE _ProductType;

    

        public PRODUCT_TYPE ProductTypeSelected
        {
            get { return _ProductType; }
            set { _ProductType = value; OnPropertyChanged("ProductTypeSelected"); }
        }

        



    }
}