using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GridApplication.ViewModels.Employee
{
    public class EmployeeListViewModel : BaseClass
    {
        private ObservableCollection<EMPLOYEE> _productTypeList;
        public ICommand ShowEditForm { get; set; }
        public ICommand filterCommand { get; set; }


        public ObservableCollection<EMPLOYEE> EmployeeLists
        {
            get { return _productTypeList; }
            set { _productTypeList = value; OnPropertyChanged("EmployeeLists"); }
        }


        /// <summary>
        /// lay du lieu tu listview, 1 dong tuong ung voi 1 doi tuong Employee
        /// </summary>
        /// 
        //private PRODUCT_TYPE _ProductItem;
        //public PRODUCT_TYPE ProductItem
        //{
        //    get { return _ProductItem; }
        //    set { _ProductItem = value; OnPropertyChanged("ProductItem"); }
        //}
        public EmployeeListViewModel()
        {
            EmployeeLists = new ObservableCollection<EMPLOYEE>(EmployeeDao.Instance().GetALL());
            filterCommand = new RelayCommand<string>(p => { return true; }, p => { Search(p); });
            //if (ProductItem != null)
            //    ShowEditForm = new RelayCommand<EMPLOYEE>(
            //        p => { return p != null ? true : false; },
            //        p =>
            //        {
            //            //ShowEdit(p);
            //        });
            //else
            //{
            //    ShowEditForm = new RelayCommand<EMPLOYEE>(
            //        p => { return true; },
            //        p => {
            //            //ShowEdit(p); }
            //        );
            //}
        }

        //private void ShowEdit(EMPLOYEE p)
        //{

        //    //Kiem tra p neu !-null thif mo form va dien gia tri
        //    if (ProductTypeEditViewModel.ProductTypeEdit == null) ProductTypeEditViewModel.ProductTypeEdit = new PRODUCT_TYPE();
        //    ProductTypeEditViewModel.ProductTypeEdit = p;
        //    if (p == null)
        //        ProductTypeEditViewModel.isNew = true;
        //    else
        //        ProductTypeEditViewModel.isNew = false;
        //    ProductTypeEdit productEdit = new ProductTypeEdit();
        //    productEdit.ShowDialog();
        //}


        public void Search(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                EmployeeLists = new ObservableCollection<EMPLOYEE>(EmployeeDao.Instance().GetALL());
            }
            else
            {
                EmployeeLists = new ObservableCollection<EMPLOYEE>(EmployeeDao.Instance().Search(input));
            }

        }
    }
}
