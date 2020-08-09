using Nedeljni_I_Bojana_Backo.Command;
using Nedeljni_I_Bojana_Backo.Services;
using Nedeljni_I_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class AddAdminViewModel : ViewModelBase
    {
        AddAdmin addAdmin;
        SeerviceAdmin seerviceAdmin;

        public AddAdminViewModel(AddAdmin addAdminOpen)
        {
            addAdmin = addAdminOpen;
            seerviceAdmin = new SeerviceAdmin();
            Admin = new vwAdmin();
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
        #endregion

        #region Commands
        // Save Button
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }
        private void SaveExecute(object obj)
        {
            try
            {
                if (!JMBGValidation.IsValid(Admin.JMBG))
                {
                    MessageBox.Show("JMBG is not valid");
                    return;
                }
                string password = (obj as PasswordBox).Password;
                Admin.UserPassword = password;
                LoginScreen login = new LoginScreen();
                seerviceAdmin.AddAdmin(Admin);
                addAdmin.Close();
                MessageBox.Show("Account created!");
                login.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (String.IsNullOrEmpty(Admin.FirstName) || String.IsNullOrEmpty(Admin.LastName)
                || String.IsNullOrEmpty(Admin.JMBG) || String.IsNullOrEmpty(Admin.Gender)
                || String.IsNullOrEmpty(Admin.Residence) || String.IsNullOrEmpty(Admin.MarriageStatus)
                || String.IsNullOrEmpty(Admin.AdminType)
                || String.IsNullOrEmpty(Admin.Username) || (obj as PasswordBox) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Cancel Button
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }
        private void CancelExecute()
        {
            try
            {
                LoginScreen login = new LoginScreen();
                addAdmin.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
