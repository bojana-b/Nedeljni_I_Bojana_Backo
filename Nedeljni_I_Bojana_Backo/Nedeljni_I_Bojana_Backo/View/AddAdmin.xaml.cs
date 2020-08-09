using Nedeljni_I_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        public AddAdmin()
        {
            InitializeComponent();
            this.DataContext = new AddAdminViewModel(this);
        }
    }
}
