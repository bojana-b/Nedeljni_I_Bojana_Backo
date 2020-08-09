using Nedeljni_I_Bojana_Backo.Command;
using Nedeljni_I_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class MasterWindowViewModel : ViewModelBase
    {
        MasterWindow masterWindow;

        public MasterWindowViewModel(MasterWindow masterWindowOpen)
        {
            masterWindow = masterWindowOpen;
        }

        #region Commands
        // CreateManager Button
        private ICommand createManager;
        public ICommand CreateManager
        {
            get
            {
                if(createManager == null)
                {
                    createManager = new RelayCommand(param => CreateManagerExecute(), param => CanCreateManagerExecute());
                }
                return createManager;
            }
        }
        private void CreateManagerExecute()
        {
            try
            {
                AddManager addManager = new AddManager();
                masterWindow.Close();
                addManager.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateManagerExecute()
        {
            return true;
        }
        // CreateEmployee Button
        private ICommand createEmployee;
        public ICommand CreateEmployee
        {
            get
            {
                if (createEmployee == null)
                {
                    createEmployee = new RelayCommand(param => createEmployeeExecute(), param => CancreateEmployeeExecute());
                }
                return createEmployee;
            }
        }
        private void createEmployeeExecute()
        {
            try
            {
                SignupEmployee signupEmployee = new SignupEmployee();
                masterWindow.Close();
                signupEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CancreateEmployeeExecute()
        {
            return true;
        }
        // CreateAdmin Button
        private ICommand createAdmin;
        public ICommand CreateAdmin
        {
            get
            {
                if (createAdmin == null)
                {
                    createAdmin = new RelayCommand(param => createAdminExecute(), param => CanCreateAdminExecute());
                }
                return createAdmin;
            }
        }
        private void createAdminExecute()
        {
            try
            {
                AddAdmin addAdmin = new AddAdmin();
                masterWindow.Close();
                addAdmin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateAdminExecute()
        {
            return true;
        }
        // Logout Button
        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            try
            {
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
                masterWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
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
                masterWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
