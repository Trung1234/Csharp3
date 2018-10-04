using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridApplication
{
    public class BranchListViewModel
    {
        private ObservableCollection<BRANCH> _branchList;
        public ObservableCollection<BRANCH> BranchLists
        {
            get { return _branchList; }
            set { _branchList = value; }
        }

        public BranchListViewModel()
        {
            BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
        }
      
    }
}
