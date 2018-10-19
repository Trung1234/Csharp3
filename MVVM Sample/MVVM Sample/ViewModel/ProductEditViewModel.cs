using SaleLibrary;
using SaleLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TESTEntitiesLibrary;
using System.Collections;

namespace MVVM_Sample.ViewModel
{
    public class ProductEditViewModel : BaseClass
    {
        private static PRODUCT _product;
        public static PRODUCT ProductEdit
        {
            get { return _product; }
            set { _product = value; }
        }

        private ObservableCollection<PRODUCT_TYPE> _productType;
        public ObservableCollection<PRODUCT_TYPE> ProductTypeList
        {
            get { return _productType; }
            set { _productType = value; OnPropertyChanged(); }
        }

        private PRODUCT_TYPE _ProductType;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public PRODUCT_TYPE ProductTypeSelected
        {
            get { return _ProductType; }
            set { _ProductType = value; OnPropertyChanged(); }
        }

        public ICommand ExecuteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ProductEditViewModel()
        {
            ProductTypeList = new ObservableCollection<PRODUCT_TYPE>(ProductTypeDao.Instance().GetAll());
            if (ProductEdit != null)
                ExecuteCommand = new RelayCommand<FrameworkElement>((p) => { return p != null ? true : false; }, (p) => { EditExecute(p); });
            else
                ExecuteCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { AddExecute(p); });
        }

        private void GetData(FrameworkElement p)
        {
            if (p != null)
            {
                var sp = p as StackPanel;
                if (sp != null)
                {
                    //If Name=spProductCD
                    if (sp.Name.Equals("spProduct"))
                    {
                        foreach (var item in sp.Children)
                        {

                            var tb = item as TextBox;
                            if (tb != null)
                            {
                                if (tb.Name == "txtProductCD")
                                    ProductEdit.PRODUCT_CD = tb.Text;
                                if (tb != null && tb.Name == "txtName")
                                    ProductEdit.NAME = tb.Text;
                            }
                            else
                            {
                                var dp = item as DatePicker;
                                if (dp != null)
                                {
                                    if (dp.Name == "dpDateOffer")
                                        ProductEdit.DATE_OFFERED = dp.SelectedDate;
                                    if (dp.Name == "dpRetied")
                                        ProductEdit.DATE_RETIRED = dp.SelectedDate;
                                }
                                else
                                {
                                    var cb = item as ComboBox;
                                    if (cb != null && cb.Name == "cbType")
                                    {
                                        ProductEdit.PRODUCT_TYPE_CD = cb.SelectedValue.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void EditExecute(FrameworkElement p)
        {
            GetData(p);
            ProductDao.Instance().Edit(ProductEdit);
        }

        private void AddExecute(FrameworkElement p)
        {
            GetData(p);
            ProductDao.Instance().Add(ProductEdit);
        }
    }
}
