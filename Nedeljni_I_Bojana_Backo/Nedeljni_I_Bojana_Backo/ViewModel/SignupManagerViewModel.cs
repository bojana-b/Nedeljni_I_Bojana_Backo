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
    class SignupManagerViewModel : ViewModelBase
    {
        SignupManager signupManager;
        ServiceManager serviceManager;
        HintPasswordValidation hintPasswordValidation;

        public SignupManagerViewModel(SignupManager signupManagerOpen)
        {
            signupManager = signupManagerOpen;
            serviceManager = new ServiceManager();
            Manager = new vwManager();
            hintPasswordValidation = new HintPasswordValidation();
        }

        #region Properties
        private vwManager manager;
        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
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
                if (!JMBGValidation.IsValid(Manager.JMBG))
                {
                    MessageBox.Show("JMBG is not valid");
                    return;
                }
                else if (!hintPasswordValidation.PasswordOk(Manager.ReservedPassword))
                {
                    MessageBox.Show("Password Hint must contain at least 5 caracters!");
                    return;
                }
                string password = (obj as PasswordBox).Password;
                Manager.UserPassword = password;
                LoginScreen login = new LoginScreen();
                serviceManager.AddManager(Manager);
                signupManager.Close();
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
            if (String.IsNullOrEmpty(Manager.FirstName) || String.IsNullOrEmpty(Manager.LastName)
                || String.IsNullOrEmpty(Manager.JMBG) || String.IsNullOrEmpty(Manager.Gender)
                || String.IsNullOrEmpty(Manager.Residence) || String.IsNullOrEmpty(Manager.MarriageStatus)
                || String.IsNullOrEmpty(Manager.Email) || String.IsNullOrEmpty(Manager.ReservedPassword)
                || String.IsNullOrEmpty(Manager.OfficeNumber)
                || String.IsNullOrEmpty(Manager.Username) || (obj as PasswordBox) == null)
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
                signupManager.Close();
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
