using System;
using System.Windows;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var hash = SecurePasswordHasher.Hash("WPFAccess");
            try
            {
                if (txtUsername.Text.Equals("WPFMaster") && SecurePasswordHasher.Verify(txtPassword.Password, hash))
                {
                    MasterWindow dashboard = new MasterWindow();
                    dashboard.Show();
                    this.Close();
                }
                //else if (JMBGValidation.IsValid(txtUsername.Text) && txtPassword.Password.Equals("Gost"))
                //{
                //    Service service = new Service();

                //    if (!service.IsUser(txtUsername.Text))
                //    {
                //        Service.userGuest = service.AddUser(txtUsername.Text);
                //        MainWindow dashboard = new MainWindow();
                //        dashboard.Show();
                //        this.Close();
                //    }
                //    else
                //    {
                //        Service.userGuest = service.FindUser(txtUsername.Text);
                //        UserWindow userWindow = new UserWindow();
                //        MainWindow dashboard = new MainWindow();
                //        userWindow.ShowDialog();
                //        dashboard.Show();
                //        this.Close();
                //    }
                //}
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }
    }
}
