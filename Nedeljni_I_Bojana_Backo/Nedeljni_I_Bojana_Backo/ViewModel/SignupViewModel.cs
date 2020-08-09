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
    class SignupViewModel : ViewModelBase
    {
        Signup signup;

        public SignupViewModel(Signup signupOpen)
        {
            signup = signupOpen;
        }
        #region Command
        // Signup Manager button
        private ICommand signupManager;
        public ICommand SignupManager
        {
            get
            {
                if (signupManager == null)
                {
                    signupManager = new RelayCommand(param => SignupManagerExecute(), param => CanSignupManagerExecute());
                }
                return signupManager;
            }
        }
        private void SignupManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure that you want to signup as Manager?",
                       "My App", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        PasswordFromFile addManager = new PasswordFromFile();
                        signup.Close();
                        addManager.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSignupManagerExecute()
        {
            return true;
        }
        // Signup Employee button
        private ICommand signupEmployee;
        public ICommand SignupEmployee
        {
            get
            {
                if (signupEmployee == null)
                {
                    signupEmployee = new RelayCommand(param => SignupEmployeeExecute(), param => CanSignupEmployeeExecute());
                }
                return signupEmployee;
            }
        }
        private void SignupEmployeeExecute()
        {
            try
            {
                SignupEmployee employee = new SignupEmployee();
                signup.Close();
                employee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSignupEmployeeExecute()
        {
            return true;
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
                signup.Close();
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
