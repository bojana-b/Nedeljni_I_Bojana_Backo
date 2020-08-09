using Nedeljni_I_Bojana_Backo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for AllAdmins.xaml
    /// </summary>
    public partial class AllAdmins : Window
    {
        public AllAdmins()
        {
            InitializeComponent();
            this.DataContext = new AllAdminsViewModel(this);
        }
    }
}
