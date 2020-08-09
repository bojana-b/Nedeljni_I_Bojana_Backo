using Nedeljni_I_Bojana_Backo.Command;
using Nedeljni_I_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class PasswordFromFileViewModel : ViewModelBase
    {
        PasswordFromFile passwordFromFile;
        static int counter = 3;

        public PasswordFromFileViewModel(PasswordFromFile passwordFromFileOpen)
        {
            passwordFromFile = passwordFromFileOpen;
        }

        #region Properties
       
        //public string Error
        //{
        //    get { return null; }
        //}

        //public string this[string someProperty]
        //{
        //    get
        //    {

        //        return string.Empty;
        //    }
        //}
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
                string passwordFile = ReadPasswordFromFile();
                string password = (obj as PasswordBox).Password;
                

                if (password.Equals(passwordFile))
                {
                    SignupManager manager = new SignupManager();
                    passwordFromFile.Close();
                    manager.ShowDialog();
                }
                else
                {
                    counter--;
                    if(counter != 0)
                    {
                        MessageBox.Show("Wrong password. You have " + counter + " more attempts!");
                    }
                    if(counter == 0)
                    {
                        MessageBox.Show("You have no more attemps! Signup as Employee...");
                        SignupEmployee employee = new SignupEmployee();
                        passwordFromFile.Close();
                        employee.ShowDialog();
                    }
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
                passwordFromFile.Close();
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

        string ReadPasswordFromFile()
        {
            try
            {

                using (StreamReader sr = new StreamReader(@"..\..\ManagerAccess.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        return line;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
