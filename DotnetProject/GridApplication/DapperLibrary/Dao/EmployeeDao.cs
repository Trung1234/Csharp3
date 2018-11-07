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
            var x = db.Query<EMPLOYEE>("SELECT EMP_ID, END_DATE, FIRST_NAME, LAST_NAME,"
                + "START_DATE, TITLE, ASSIGNED_BRANCH_ID, DEPT_ID, SUPERIOR_EMP_ID FROM EMPLOYEE").ToList();
            return x;
        }
        public List<EMPLOYEE> Search(string input)
        {
            if (input != null)
            {
                try
                {
                    var x = db.Query<EMPLOYEE>("SELECT * FROM EMPLOYEE WHERE FIRST_NAME LIKE '%"
                        + input + "%' OR " + "LAST_NAME LIKE '%"
                        + input + "%' OR END_DATE LIKE '%"
                        + input + "%' OR START_DATE LIKE '%"
                        + input + "%' OR TITLE LIKE '%"
                        + input + "%'").ToList();
                    return x;
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }
        public void Update(EMPLOYEE emp)
        {
            if (emp != null)
            {
                try
                {
                    db.Execute("UPDATE EMPLOYEE "
                        +" SET FIRST_NAME='" + emp.FIRST_NAME
                        + "',  LAST_NAME ='" + emp.LAST_NAME
                        + "',  START_DATE ='" + emp.START_DATE
                        + "',  END_DATE ='" + emp.END_DATE
                        + "',  TITLE ='" + emp.TITLE
                        + "',  ASSIGNED_BRANCH_ID ='" + emp.ASSIGNED_BRANCH_ID
                        + "',  DEPT_ID ='" + emp.DEPT_ID
                        + "',  SUPERIOR_EMP_ID ='" + emp.SUPERIOR_EMP_ID
                        + "' WHERE EMP_ID='" + emp.EMP_ID + "'");
                }
                catch { throw new Exception(); }
            }
        }
    }
}       
    
