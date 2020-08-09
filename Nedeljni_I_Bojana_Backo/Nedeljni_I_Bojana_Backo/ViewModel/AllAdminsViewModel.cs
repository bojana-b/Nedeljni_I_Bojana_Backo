using Nedeljni_I_Bojana_Backo.Command;
using Nedeljni_I_Bojana_Backo.Services;
using Nedeljni_I_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class AllAdminsViewModel : ViewModelBase
    {
        AllAdmins allAdmins;
        SeerviceAdmin seerviceAdmin;

        public AllAdminsViewModel(AllAdmins allAdminsOpen)
        {
            allAdmins = allAdminsOpen;
            seerviceAdmin = new SeerviceAdmin();
            AdminList = seerviceAdmin.GetAllAdmins().ToList();
        }

        #region Properties
        private vwAdmin admin;
        public vwAdmin Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        private List<vwAdmin> adminList;
        public List<vwAdmin> AdminList
        {
            get
            {
                return adminList;
            }
            set
            {
                adminList = value;
                OnPropertyChanged("AdminList");
            }
        }
        #endregion

        #region Commands 
        private ICommand updateDate;
        public ICommand UpdateDate
        {
            get
            {
                if (updateDate == null)
                {
                    updateDate = new RelayCommand(param => UpdateDateExecute(), param => CanUpdateDateExecute());
                }
                return updateDate;
            }
        }

        private void UpdateDateExecute()
        {
            var picker = new DateTimePicker();
            Form f = new Form();
            f.Controls.Add(picker);
            try
            {
                if (Admin != null)
                {

                    MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure that you want to change expiration date?",
                       "My App",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    //int adminID = admin.AdminID;

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            var result1 = f.ShowDialog();
                            if (result1 == DialogResult.OK)
                            {
                                //get selected date
                            }
                            //service.ArchiveOrder(orderID);
                            //OrderList = service.GetAllOrders().ToList();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        private bool CanUpdateDateExecute()
        {
            if (Admin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Close Button
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            try
            {
                LoginScreen loginScreen = new LoginScreen();
                allAdmins.Close();
                loginScreen.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
