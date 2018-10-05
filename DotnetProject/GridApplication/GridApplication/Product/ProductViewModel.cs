using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridApplication.Product
{
    public class ProductViewModel
    {
        private ObservableCollection<PRODUCT> _productList;
        public ObservableCollection<PRODUCT> ProductLists
        {
            get { return _productList; }
            set { _productList = value; }
        }

        public ProductViewModel()
        {
            ProductLists = new ObservableCollection<PRODUCT>(ProductDao.Instance().GetALL());
        }
    }
}
