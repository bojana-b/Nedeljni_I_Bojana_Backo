using Nedeljni_I_Bojana_Backo.Command;
using Nedeljni_I_Bojana_Backo.Services;
using Nedeljni_I_Bojana_Backo.View;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class LoginScreenViewModel : ViewModelBase
    {
        LoginScreen loginScreen;
        ManagerPassword managerPassword;
        ServiceManager serviceManager;

        public LoginScreenViewModel(LoginScreen loginScreenOpen)
        {
            loginScreen = loginScreenOpen;
            manager = new vwManager();
            serviceManager = new ServiceManager();

            managerPassword = new ManagerPassword();
            managerPassword.ApplicationStarted += WriteRandomStrToFile;
            managerPassword.WriteToFile();
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

        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }
        #endregion

        #region Commands
        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute,
                        param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;

                if (UserName.Equals("WPFMaster") && password.Equals("WPFAccess"))
                {
                    MasterWindow master = new MasterWindow();
                    loginScreen.Close();
                    master.ShowDialog();
                }
                else if (serviceManager.IsUser(UserName))
                {
                    Manager = serviceManager.FindManager(UserName);
                    if(SecurePasswordHasher.Verify(password, Manager.UserPassword) || password == Manager.ReservedPassword)
                    {
                        if(Manager.LevelOfResponsibility == null)
                        {
                            MessageBox.Show("Can't login until the Admin assigns you a level of Responsability.");
                        }
                        else
                        {
                            ManagerWindow managerWindow = new ManagerWindow();
                            loginScreen.Close();
                            managerWindow.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong usename or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            return true;
        }
        // Signup button
        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignupExecute(), param => CanCreateSigunExecute());
                }
                return signUp;
            }
        }
        private void SignupExecute()
        {
            try
            {
                Signup signup = new Signup();
                loginScreen.Close();
                signup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateSigunExecute()
        {
            return true;
        }
        #endregion
        void WriteRandomStrToFile(object source, string radnomStr)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\ManagerAccess.txt"))
            {

                sw.WriteLine(radnomStr);

            }
        }
    }
}
