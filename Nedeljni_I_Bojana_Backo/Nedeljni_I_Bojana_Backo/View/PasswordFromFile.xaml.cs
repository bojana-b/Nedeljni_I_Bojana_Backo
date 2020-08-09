using Nedeljni_I_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for PasswordFromFile.xaml
    /// </summary>
    public partial class PasswordFromFile : Window
    {
        public PasswordFromFile()
        {
            InitializeComponent();
            this.DataContext = new PasswordFromFileViewModel(this);
        }
    }
}
