using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GridApplication.ViewModels.Branch
{
    public class BranchListViewModel : BaseClass
    {
        private ObservableCollection<BRANCH> _branchList;
        public ICommand filterCommand { get; set; }
        public ICommand ShowEditForm { get; set; }
        
        public ObservableCollection<BRANCH> BranchLists
        {
            get { return _branchList; }
            set { _branchList = value; OnPropertyChanged("BranchLists"); }
        }
        public BranchListViewModel()
        {
            BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
            filterCommand = new RelayCommand<string>(p => { return true; }, p => { Search(p); });
            if (BranchItem != null)
                ShowEditForm = new RelayCommand<BRANCH>(
                    p => { return p != null ? true : false; },
                    p =>
                    {
                        ShowEdit(p);
                    });
            else
            {
                ShowEditForm = new RelayCommand<BRANCH>(
                    p => { return true; },
                    p => { ShowEdit(p); }
                    );
            }
        }
        private BRANCH _BranchItem;
        public BRANCH BranchItem
        {
            get { return _BranchItem; }
            set { _BranchItem = value; OnPropertyChanged("BranchItem"); }

        }
        private void ShowEdit(BRANCH p)
        {

            //Kiem tra p neu !-null thif mo form va dien gia tri
            if (BranchEditViewModel.BranchEdit== null) BranchEditViewModel.BranchEdit = new BRANCH();
            BranchEditViewModel.BranchEdit = p;
            if (p == null)
                BranchEditViewModel.isNew = true;
            else
                BranchEditViewModel.isNew = false;
            BranchEdit productEdit = new BranchEdit();
            productEdit.ShowDialog();
        }
        public void Search(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
            }
            else
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().Search(input));
            }
        }
        //public void SearchByName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
        //    }
        //    else
        //    {
        //        BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().SearchByName(name));
        //    }
        //}

    }
}
