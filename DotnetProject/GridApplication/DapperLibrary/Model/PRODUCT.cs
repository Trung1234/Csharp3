using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLibrary.Model
{
    public class PRODUCT
    {
        public string PRODUCT_CD { get; set; }
        public DateTime DATE_OFFERED { get; set; }
       
        public DateTime DATE_RETIRED { get; set; }
        public string NAME { get; set; }
        public string  PRODUCT_TYPE_CD { get; set; }

    }
}
