using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridApplication.ProductType
{
    class ProductTypeViewModel
    {
        private ObservableCollection<PRODUCT_TYPE> _productTypeList;
        public ObservableCollection<PRODUCT_TYPE> ProductTypeLists
        {
            get { return _productTypeList; }
            set { _productTypeList = value; }
        }

        public ProductTypeViewModel()
        {
            ProductTypeLists = new ObservableCollection<PRODUCT_TYPE>(ProductTypeDao.Instance().GetALL());
        }
    }
}
