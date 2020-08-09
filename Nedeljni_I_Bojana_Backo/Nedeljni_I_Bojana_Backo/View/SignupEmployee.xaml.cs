using Nedeljni_I_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for SignupEmployee.xaml
    /// </summary>
    public partial class SignupEmployee : Window
    {
        public SignupEmployee()
        {
            InitializeComponent();
            this.DataContext = new SignupEmployeeViewModel(this);
        }
    }
}
