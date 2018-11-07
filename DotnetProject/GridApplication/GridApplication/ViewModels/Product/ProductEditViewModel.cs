using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GridApplication.ViewModels.Product
{
    public class ProductEditViewModel : BaseClass
    {
        public static bool isNew = false;
        public ICommand ExecuteCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private PRODUCT_TYPE _ProductType;

       

        public PRODUCT_TYPE ProductTypeSelected
        {
            get { return _ProductType; }
            set { _ProductType = value; OnPropertyChanged("ProductTypeSelected"); }
        }

        private ObservableCollection<PRODUCT_TYPE> _productType;
        public ObservableCollection<PRODUCT_TYPE> ProductTypeList
        {
            get { return _productType; }
            set { _productType = value; OnPropertyChanged(); }
        }
        private static PRODUCT _productEdit;
        public static PRODUCT ProductEdit
        {
            get { return _productEdit; }
            set { _productEdit = value; }
        }
        public ProductEditViewModel()
        {
            ProductTypeList = new ObservableCollection<PRODUCT_TYPE>(ProductTypeDao.Instance().GetALL());
            if (isNew)
                ExecuteCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { AddNew(p); });
            else
                ExecuteCommand = new RelayCommand<FrameworkElement>(p =>
                { return p != null ? true : false; }, p => { Edit(p); });
            CloseCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { CloseForm(p); });
        }

        private void Edit(FrameworkElement p)
        {
            GetData(p);
            ProductDao.Instance().Update(ProductEdit);
            CloseForm(p);
        }

        private void AddNew(FrameworkElement p)
        {
            GetData(p);
            ProductDao.Instance().Add(ProductEdit);
            CloseForm(p);
        }

        private bool GetData(FrameworkElement p)
        {
            if (ProductEdit == null)
                ProductEdit = new PRODUCT();
            if (p != null)
            {
                /*
                 -  Ep kieu StackPanel
                 - Kiem tra ep thanh cong hay khong
                 - Kiem tra ten 
                 - Lap thanh phan de lay gia tri
                 */
                var sp = p as StackPanel;
                if (sp.Name.Equals("spProductEdit"))
                {
                    foreach (var item in sp.Children)
                    {
                        var tb = item as TextBox;
                        if (tb != null)
                        {

                            if (tb.Name.Equals("txtProductCD"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                ProductEdit.PRODUCT_CD = tb.Text;

                            }

                            if (tb.Name.Equals("txtName"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                ProductEdit.NAME = tb.Text;
                            }
                            //if (tb.Name.Equals("txtTypeCD"))
                            //{
                            //    if (string.IsNullOrEmpty(tb.Text))
                            //        return false;
                            //    ProductEdit.PRODUCT_TYPE_CD = tb.Text;
                            //}
                        }
                        var dp = item as DatePicker;
                        if (dp != null && dp.Name.Equals("txtDateOffered"))
                        {
                            ProductEdit.DATE_OFFERED = Convert.ToDateTime(dp.SelectedDate);
                        }
                        if (dp != null && dp.Name.Equals("txtDateRetired"))
                        {
                            ProductEdit.DATE_RETIRED = Convert.ToDateTime(dp.SelectedDate);
                        }
                        var cb = item as ComboBox;
                        if (cb != null && cb.Name == "cbType")
                        {
                            ProductEdit.PRODUCT_TYPE_CD = ProductTypeSelected.PRODUCT_TYPE_CD;
                        }
                    }
                }

            }
            return true;
        }
    }
}
