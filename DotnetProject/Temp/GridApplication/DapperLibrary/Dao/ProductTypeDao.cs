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
    public class ProductTypeDao
    {
        private static ProductTypeDao _instance;
        public static ProductTypeDao Instance()
        {
            if (_instance == null) _instance = new ProductTypeDao();
            return _instance;
        }

        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
        public List<PRODUCT_TYPE> GetALL()
        {
            var x = db.Query<PRODUCT_TYPE>("SELECT PRODUCT_TYPE_CD, NAME FROM PRODUCT_TYPE").ToList();
            return x;
        }
        public List<PRODUCT_TYPE> SearchByCD(string typeCD)
        {
            if (typeCD != null)
            {
                try
                {
                    var x = db.Query<PRODUCT_TYPE>("SELECT * FROM PRODUCT_TYPE WHERE PRODUCT_TYPE_CD like '%" + typeCD + "%'").ToList();
                    return x;
                }
                catch {
                    return null;
                }
            }
            return null;
        }
        public void Update(PRODUCT_TYPE type)
        {
            if (type != null)
            {
                try
                {
                    db.Execute("UPDATE PRODUCT_TYPE SET NAME='" + type.NAME + "' WHERE PRODUCT_TYPE_CD='" + type.PRODUCT_TYPE_CD + "'");
                }
                catch { throw new Exception(); }
            }
        }
        public void Add(PRODUCT_TYPE type)
        {
            if(type != null)
            {
                try
                {
                    db.Execute("INSERT INTO [dbo].[PRODUCT_TYPE] ([PRODUCT_TYPE_CD],[NAME]) VALUES('" + type.PRODUCT_TYPE_CD + "','" + type.NAME + "')");
                }
                catch { throw new Exception(); }

            }
        }
    }
}
