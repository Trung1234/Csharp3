using DapperLibrary.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GridApplication.ViewModels.Branch
{
    /// <summary>
    /// 
    /// </summary>
    public class BranchEditViewModel : BaseClass
    {
        #region Variables
        //Bien trang thai xac dinh man hinh la Them moi hay Sua
        public static bool isNew = false;
        //Dinh nghia doi tuong nhan du lieu tu ListView
        public static BRANCH _branchEdit;
        public static BRANCH BranchEdit
        {
            get { return _branchEdit; }
            set { _branchEdit = value; }
        }

        #region Command
        /// <summary>
        /// Thuc hien ghi vao DB
        /// </summary>
        public ICommand ExecuteCommand { get; set; }

        /// <summary>
        /// Dong man hinh
        /// </summary>
        public ICommand CloseCommand { get; set; }
        #endregion

        #endregion

        public BranchEditViewModel()
        {
            if (isNew)
                ExecuteCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { AddNew(p); });
            else
                ExecuteCommand = new RelayCommand<FrameworkElement>(p =>
               { return p != null ? true : false; }, p => { Edit(p); });
            CloseCommand = new RelayCommand<FrameworkElement>(p => { return true; }, p => { BaseClass.CloseForm(p); });
        }

        #region Events
        /// <summary>
        /// Sua thong tin Branch
        /// </summary>
        /// <param name="p">Doi tuong chua cac thanh phan se lay gia tri cho bran</param>
        private void Edit(FrameworkElement p)
        {
            GetData(p);
            BranchDao.Instance().Update(BranchEdit);
            CloseForm(p);
        }

        /// <summary>
        /// Lay gia tri tu cac thanh phan cua doi tuong nhan tu List ViewModel
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool GetData(FrameworkElement p)
        {
            if (BranchEdit == null)
                BranchEdit = new BRANCH();
            if (p != null)
            {
                /*
                 -  Ep kieu StackPanel
                 - Kiem tra ep thanh cong hay khong
                 - Kiem tra ten 
                 - Lap thanh phan de lay gia tri
                 */
                var sp = p as StackPanel;
                if (sp.Name.Equals("spBranchEdit"))
                {
                    foreach (var item in sp.Children)
                    {
                        var tb = item as TextBox;
                        if (tb != null)
                        {

                            if (tb.Name.Equals("txtAddress"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                BranchEdit.ADDRESS = tb.Text;

                            }
                            if (tb.Name.Equals("txtCity"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                BranchEdit.CITY = tb.Text;
                            }
                            if (tb.Name.Equals("txtName"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                BranchEdit.NAME = tb.Text;
                            }
                            if (tb.Name.Equals("txtZip"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                BranchEdit.ZIP_CODE = tb.Text;
                            }
                            if (tb.Name.Equals("txtState"))
                            {
                                if (string.IsNullOrEmpty(tb.Text))
                                    return false;
                                BranchEdit.STATE = tb.Text;
                            }
                        }
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// Them moi doi tuong Branch
        /// </summary>
        /// <param name="p">Thanh phan nhap tu man hinh User</param>
        private void AddNew(FrameworkElement p)
        {
            GetData(p);
            BranchDao.Instance().Add(BranchEdit);
            CloseForm(p);
        }

        #endregion

    }
}
