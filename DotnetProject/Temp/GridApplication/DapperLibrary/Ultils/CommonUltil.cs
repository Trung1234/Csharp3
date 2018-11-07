using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DapperLibrary.Ultils
{
    public static class CommonUltil
    {
        public static string ValidateProductCD(string product_cd)
        {
            string r = "";
            if (string.IsNullOrEmpty(product_cd))
                r = "Nhap vao C";
            else if (product_cd.Length > 255 || product_cd.Length <= 2)
                r = "Chi duoc tu 255 ky tu tro xuong va phai tren 2 ky tu";
            return r;
        }
        public static string ValidateName(string name)
        {
            string r = "";
            if (string.IsNullOrEmpty(name))
                r = "Nhap vao C";
            else if (name.Length > 255 || name.Length <= 2)
                r = "Chi duoc tu 255 ky tu tro xuong va phai tren 2 ky tu";
            return r;
        }
        public static string ValidateID(int numb)
        {
            string result = null;
            int Num;
            bool isNum = int.TryParse(numb.ToString(), out numb);
            if (isNum)
                result = "Đây không phải số";
            return result;
        }

        internal static string ValidateCode(string zIP_CODE)
        {
            string r = "";
            if (string.IsNullOrEmpty(zIP_CODE))
                r = "Nhap vao C";
            else if (zIP_CODE.Length > 5 || zIP_CODE.Length <= 2)
                r = "Chi duoc tu 5 ky tu tro xuong va phai tren 2 ky tu";
            return r;
        }
        //public static string ValidateCode(string code)
        //{
        //    string pattern = @"^[a-zA-Z0-9\]+$";
        //    Regex regex = new Regex(pattern);
        //    string result = null;
        //    // Compare a string against the regular expression
        //    if (regex.IsMatch(code))
        //    {
        //        result = "mã không hợp lệ";
        //    };
        //    return result;
        //}

    }
}
