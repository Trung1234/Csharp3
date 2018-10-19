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
    public class BranchDao
    {
        private static BranchDao _instance;
        public static BranchDao Instance()
        {
            if (_instance == null) _instance = new BranchDao();
            return _instance;
        }

        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
        public List<BRANCH> GetALL()
        {
            var x = db.Query<BRANCH>("SELECT * FROM BRANCH").ToList();
            return x;
        }
        public List<BRANCH> Search(string input)
        {
            if (input != null)
            {
                try
                {
                    var x = db.Query<BRANCH>("SELECT * FROM BRANCH WHERE BRANCH_ID LIKE '%" + input + "%' OR " + 
                        "CITY LIKE '%" + input + "%' OR NAME LIKE '%" + input + "%' OR STATE LIKE '%" + input + "%' OR ZIP_CODE LIKE '%" + input+ "%'").ToList();
                    return x;
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }
        public List<BRANCH> SearchByName(string name)
        {
            if(name != null)
            {
                try
                {
                    var x = db.Query<BRANCH>("SELECT * FROM BRANCH WHERE NAME LIKE '%" + name + "%'").ToList();
                    return x;
                }
                catch
                {
                    return null;
                }
                
            }
            return null;
        }
        public void Update(BRANCH branch)
        {
            if (branch != null)
            {
                try
                {
                    db.Execute("UPDATE BRANCH SET NAME='" + branch.NAME + "' WHERE EMP_ID='" + branch.BRANCH_ID + "'");
                }
                catch { throw new Exception(); }
            }
        }
    }
}
