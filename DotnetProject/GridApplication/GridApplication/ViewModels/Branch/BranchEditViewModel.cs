using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridApplication.ViewModels.Branch
{
    public class BranchEditViewModel
    {
        public static bool isNew = false;
        public static BRANCH _branchEdit;
        public static BRANCH BranchEdit
        {
            get { return _branchEdit; }
            set { _branchEdit = value; }
        }
    }
}
