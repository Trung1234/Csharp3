using DapperLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GridApplication.ViewModels.Branch
{
    public class BranchListViewModel : BaseClass
    {
        private ObservableCollection<BRANCH> _branchList;
        public ICommand filterCommand { get; set; }
        public ICommand filterNameCommand { get; set; }
        public ICommand filterAddressCommand { get; set; }
        public ICommand filterCityCommand { get; set; }
        public ICommand ShowEditForm { get; set; }
        
        public ObservableCollection<BRANCH> BranchLists
        {
            get { return _branchList; }
            set { _branchList = value; OnPropertyChanged("BranchLists"); }
        }
        public BranchListViewModel()
        {
            BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
            filterCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { SearchByParameter(p); });
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

        private void SearchByParameter(FrameworkElement p)
        {
            string name="", address="", city="";
            if (p != null)
            {
                var sp = p as StackPanel;
                if (sp!=null && sp.Name.Equals("spFilter"))
                {
                    foreach(var item in sp.Children)
                    {
                        var tb = item as TextBox;
                        if (tb != null && tb.Name.Equals("txtFindName"))
                        {
                            name = tb.Text;
                        }
                        if (tb != null && tb.Name.Equals("txtFindAddress"))
                        {
                            address = tb.Text;
                        }
                        if (tb != null && tb.Name.Equals("txtFindCity"))
                        {
                            city = tb.Text;
                        }
                    }
                }
            }
            BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().SearchByParameter(name,address,city));
        }

        public void BindingSearchAll()
        {
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
        //public void BindingSearchName()
        //{
        //    filterNameCommand = new RelayCommand<string>(p => { return true; }, p => { SearchByName(p); });
        //    if (BranchItem != null)
        //        ShowEditForm = new RelayCommand<BRANCH>(
        //            p => { return p != null ? true : false; },
        //            p =>
        //            {
        //                ShowEdit(p);
        //            });
        //    else
        //    {
        //        ShowEditForm = new RelayCommand<BRANCH>(
        //            p => { return true; },
        //            p => { ShowEdit(p); }
        //            );
        //    }
        //}
        //public void BindingSearchAddress()
        //{
        //    filterNameCommand = new RelayCommand<string>(p => { return true; }, p => { SearchByAddress(p); });
        //    if (BranchItem != null)
        //        ShowEditForm = new RelayCommand<BRANCH>(
        //            p => { return p != null ? true : false; },
        //            p =>
        //            {
        //                ShowEdit(p);
        //            });
        //    else
        //    {
        //        ShowEditForm = new RelayCommand<BRANCH>(
        //            p => { return true; },
        //            p => { ShowEdit(p); }
        //            );
        //    }
        //}
        //public void BindingSearchCity()
        //{
        //    filterNameCommand = new RelayCommand<string>(p => { return true; }, p => { SearchByCity(p); });
        //    if (BranchItem != null)
        //        ShowEditForm = new RelayCommand<BRANCH>(
        //            p => { return p != null ? true : false; },
        //            p =>
        //            {
        //                ShowEdit(p);
        //            });
        //    else
        //    {
        //        ShowEditForm = new RelayCommand<BRANCH>(
        //            p => { return true; },
        //            p => { ShowEdit(p); }
        //            );
        //    }
        //}
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
        public void SearchByName(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
            }
            else
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().SearchByName(input));
            }
        }
        public void SearchByAddress(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
            }
            else
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().SearchByAddress(input));
            }
        }
        public void SearchByCity(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().GetALL());
            }
            else
            {
                BranchLists = new ObservableCollection<BRANCH>(BranchDao.Instance().SearchByCity(input));
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
