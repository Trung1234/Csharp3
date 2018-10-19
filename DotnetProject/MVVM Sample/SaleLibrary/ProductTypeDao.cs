using SaleLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLibrary
{
    public class ProductTypeDao
    {
        //SigleTon
        private static ProductTypeDao _instance;
        public static ProductTypeDao Instance()
        {
            if (_instance == null) _instance = new ProductTypeDao();
            return _instance;
        }
        public ProductTypeDao() { }
        public List<PRODUCT_TYPE> GetAll()
        {
            using (TESTEntities entity = new TESTEntities())
            {
                return entity.PRODUCT_TYPE.ToList();
            }
        }
    }
}
