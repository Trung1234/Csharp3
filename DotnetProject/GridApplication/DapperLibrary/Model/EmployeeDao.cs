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
    public class EmployeeDao
    {
        private static EmployeeDao _instance;
        public static EmployeeDao Instance()
        {
            if (_instance == null) _instance = new EmployeeDao();
            return _instance;
        }

        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
        public List<EMPLOYEE> GetALL()
        {
            var x = db.Query<EMPLOYEE>("SELECT EMP_ID, END_DATE, FIRST_NAME, LAST_NAME, START_DATE, TITLE, ASSIGNED_BRANCH_ID, DEPT_ID, SUPERIOR_EMP_ID FROM EMPLOYEE").ToList();
            return x;
        }
       
        public void Update(EMPLOYEE emp)
        {
            if (emp != null)
            {
                try
                {
                    db.Execute("UPDATE EMPLOYEE SET FIRST_NAME='" + emp.FIRST_NAME + "' WHERE EMP_ID='" + emp.EMP_ID + "'");
                }
                catch { throw new Exception(); }
            }
        }
    }
}       
    
