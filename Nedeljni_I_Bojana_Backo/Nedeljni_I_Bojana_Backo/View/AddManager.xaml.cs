using Nedeljni_I_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        public AddManager()
        {
            InitializeComponent();
            this.DataContext = new AddManagerViewModel(this);
        }
    }
}
