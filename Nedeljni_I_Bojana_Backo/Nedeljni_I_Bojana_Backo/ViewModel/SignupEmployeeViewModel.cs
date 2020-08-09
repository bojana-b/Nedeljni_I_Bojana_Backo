using Nedeljni_I_Bojana_Backo.Command;
using Nedeljni_I_Bojana_Backo.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class SignupEmployeeViewModel : ViewModelBase
    {
        SignupEmployee signupEmployee;

        public SignupEmployeeViewModel(SignupEmployee signupEmployeeOpen)
        {
            signupEmployee = signupEmployeeOpen;
        }

        // Go Back Button
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
                signupEmployee.Close();
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
    }
}
