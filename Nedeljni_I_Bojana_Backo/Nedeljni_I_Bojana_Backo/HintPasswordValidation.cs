using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Bojana_Backo
{
    // Class for Hint Password validation
    public class HintPasswordValidation
    {
        int minLength = 5;
        public bool PasswordOk(string password)
        {
            // get individual characters
            char[] characters = password.ToCharArray();

            // checking variables
            int length = password.Length;

            // check the entered password
            if (length < minLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
