using Nedeljni_I_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Bojana_Backo.ViewModel
{
    class SignupEmployeeViewModel : ViewModelBase
    {
        SignupEmployee signupEmployee;

        public SignupEmployeeViewModel(SignupEmployee signupEmployeeOpen)
        {
            signupEmployee = signupEmployeeOpen;
        }
    }
}
