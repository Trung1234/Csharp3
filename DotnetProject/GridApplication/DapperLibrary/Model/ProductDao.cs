using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLibrary.Model
{
    public class ProductDao
    {
        private static ProductDao _instance;
        public static ProductDao Instance()
        {
            if (_instance == null) _instance = new ProductDao();
            return _instance;
        }

        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
        public List<PRODUCT> GetALL()
        {
            var x = db.Query<PRODUCT>("SELECT PRODUCT_CD,[DATE_OFFERED] ,[DATE_RETIRED] ,[NAME],[PRODUCT_TYPE_CD] FROM PRODUCT").ToList();
            return x;
        }

        public void Update(PRODUCT product)
        {
            if (product != null)
            {
                try
                {
                    db.Execute("UPDATE PRODUCT SET NAME='" + product.NAME + "' WHERE PRODUCT_TYPE_CD='" + product.PRODUCT_CD + "'");
                }
                catch { throw new Exception(); }
            }
        }
    }
}
