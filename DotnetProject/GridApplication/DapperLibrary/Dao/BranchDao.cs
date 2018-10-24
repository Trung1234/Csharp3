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
                    var x = db.Query<BRANCH>("SELECT * FROM BRANCH WHERE BRANCH_ID LIKE '%"
                        + input + "%' OR " +
                        "CITY LIKE '%" + input + "%' OR NAME LIKE '%"
                        + input + "%' OR STATE LIKE '%"
                        + input + "%' OR ZIP_CODE LIKE '%"
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
        public List<BRANCH> SearchByParameter(string name, string address, string city)
        {
            var list = db.Query<BRANCH>("SELECT * FROM BRANCH").ToList();
            if (!string.IsNullOrEmpty(name))
                list = list.Where(p => p.NAME.Contains(name)).ToList();
            if (!string.IsNullOrEmpty(address))
                list = list.Where(p => p.ADDRESS.Contains(address)).ToList();
            if (!string.IsNullOrEmpty(city))
                list = list.Where(p => p.CITY.Contains(city)).ToList();
            return list;
        }


        public List<BRANCH> SearchByName(string name)
        {
            if (name != null)
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
        public List<BRANCH> SearchByCity(string city)
        {
            if (city != null)
            {
                try
                {
                    var x = db.Query<BRANCH>("SELECT * FROM BRANCH WHERE [CITY] LIKE '%" + city + "%'").ToList();
                    return x;
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }
        public List<BRANCH> SearchByAddress(string address)
        {
            if (address != null)
            {
                try
                {
                    var x = db.Query<BRANCH>("SELECT * FROM BRANCH WHERE [ADDRESS] LIKE '%" + address + "%'").ToList();
                    return x;
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }
        public void Add(BRANCH branch)
        {
            if (branch != null)
            {
                string sql = "INSERT INTO [dbo].[BRANCH] ([ADDRESS] ,[CITY] ,[NAME] ,[STATE],[ZIP_CODE])  VALUES " +
           "('" + branch.ADDRESS + "', '" + branch.CITY + "','" + branch.NAME + "', '" + branch.STATE + "','" + branch.ZIP_CODE + "')";
                try
                {
                    db.Execute(sql);
                }
                catch
                {
                    throw new Exception();
                }

            }
        }
        public void Update(BRANCH branch)
        {
            if (branch != null)
            {
                string sql = "UPDATE [dbo].[BRANCH] SET [ADDRESS] ='" + branch.ADDRESS + "'" +
      ",[CITY] = '" + branch.CITY + "'" +
      ", NAME = '" + branch.NAME + "'" +
      ", STATE = '" + branch.STATE + "'" +
      ", ZIP_CODE = '" + branch.ZIP_CODE + "'" + " WHERE BRANCH_ID = '" + branch.BRANCH_ID + "'";
                try
                {
                    db.Execute(sql);
                }
                catch { throw new Exception(); }
            }
        }
    }
}
