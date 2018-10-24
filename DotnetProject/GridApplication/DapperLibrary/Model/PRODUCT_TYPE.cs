using DapperLibrary.Ultils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLibrary.Model
{
    public class PRODUCT_TYPE :IDataErrorInfo
    {
        public string PRODUCT_TYPE_CD { get; set; }
        public string NAME { get; set; }

        public string Error
        {
            get
            {
                return (this as IDataErrorInfo).Error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string ValidationResult = null;
                switch (columnName)
                {
                    case "PRODUCT_TYPE_CD":
                        ValidationResult = CommonUltil.ValidateProductCD(PRODUCT_TYPE_CD);
                        break;
                    case "NAME":
                        ValidationResult = CommonUltil.ValidateName(NAME);
                        break;
                }
                return ValidationResult;

            }
        }
     
    }
}
