using DapperLibrary.Ultils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLibrary.Model
{
    public class BRANCH : IDataErrorInfo
    {
        public int BRANCH_ID { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string NAME { get; set; }
        public string STATE { get; set; }
        public string ZIP_CODE { get; set; }

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
                    case "BRANCH_ID":
                        ValidationResult = CommonUltil.ValidateID(BRANCH_ID);
                        break;
                    case "ADDRESS":
                        ValidationResult = CommonUltil.ValidateName(ADDRESS);
                        break;
                    case "CITY":
                        ValidationResult = CommonUltil.ValidateName(CITY);
                        break;
                    case "NAME":
                        ValidationResult = CommonUltil.ValidateName(NAME);
                        break;
                    case "STATE":
                        ValidationResult = CommonUltil.ValidateName(STATE); ;
                        break;
                    case "ZIP_CODE":
                        ValidationResult = CommonUltil.ValidateCode(ZIP_CODE);
                        break;

                }
                return ValidationResult;
            }
        }
    }
}
