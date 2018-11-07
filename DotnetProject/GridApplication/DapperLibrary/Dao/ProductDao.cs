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
        public List<PRODUCT> SearchByCD(string CD)
        {
            if (CD != null)
            {
                try
                {
                    var x = db.Query<PRODUCT>("SELECT * FROM PRODUCT WHERE PRODUCT_CD like '%" + CD + "%'").ToList();
                    return x;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        public void Update(PRODUCT product)
        {
            if (product != null)
            {
                try
                {
                    db.Execute("UPDATE PRODUCT SET NAME='" + product.NAME + 
                        "' WHERE PRODUCT_TYPE_CD='" + product.PRODUCT_CD + "'");
                }
                catch { throw new Exception(); }
            }
        }
        public List<PRODUCT> Search(string input)
        {
            if (input != null)
            {
                try
                {
                    string search = "SELECT * FROM PRODUCT WHERE [PRODUCT_CD] LIKE '%"
                        + input + "%' OR " +
                        "[DATE_OFFERED] LIKE '%" + input + "%' OR [DATE_RETIRED] LIKE '%"
                        + input + "%' OR [NAME] LIKE '%"
                        + input + "%' OR [PRODUCT_TYPE_CD] LIKE '%"
                        + input + "%'";
                    var x = db.Query<PRODUCT>(search).ToList();
                    return x;
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }
        public void Add(PRODUCT product)
        {
            if (product != null)
            {
                try
                {
                    string sql = "INSERT INTO [dbo].[PRODUCT]([PRODUCT_CD],[DATE_OFFERED],[DATE_RETIRED],[NAME],[PRODUCT_TYPE_CD])"
                        + " VALUES('" + product.PRODUCT_CD + "','"
                        + product.DATE_OFFERED + "','"
                        + product.DATE_RETIRED + "','"
                        + product.NAME + "','"
                        + product.PRODUCT_TYPE_CD + "')";
                    db.Execute(sql);
                }
                catch
                { throw new Exception(); }
            }
        }
    }
}
