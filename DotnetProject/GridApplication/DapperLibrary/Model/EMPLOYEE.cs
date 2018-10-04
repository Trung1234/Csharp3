using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLibrary.Model
{
    public class EMPLOYEE
    {
        public int EMP_ID { get; set; }
        public DateTime END_DATE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public DateTime START_DATE { get; set; }
        public string TITLE { get; set; }
        public int ASSIGNED_BRANCH_ID { get; set; }
        public int DEPT_ID { get; set; }
        public int SUPERIOR_EMP_ID { get; set; }
    }
}
