using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Bojana_Backo.Services
{
    class ServiceManager
    {
        public void AddManager(vwManager manager)
        {
            try
            {
                using(CompanyDBEntities context = new CompanyDBEntities())
                {
                    tblUser newUser = new tblUser();
                    tblManager newManager = new tblManager();
                    newUser.FirstName = manager.FirstName;
                    newUser.LastName = manager.LastName;
                    newUser.JMBG = manager.JMBG;
                    newUser.Gender = manager.Gender;
                    newUser.Residence = manager.Residence;
                    newUser.MarriageStatus = manager.MarriageStatus;
                    newUser.Username = manager.Username;
                    newUser.UserPassword = manager.UserPassword;

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    manager.UserID = newUser.UserID;

                    newManager.UserID = manager.UserID;
                    newManager.Email = manager.Email;
                    newManager.ReservedPassword = manager.ReservedPassword + "WPF";
                    newManager.LevelOfResponsibility = "2";// manager.LevelOfResponsibility;
                    newManager.SuccessfulProjects = manager.SuccessfulProjects;
                    newManager.Salary = "1200";
                    newManager.OfficeNumber = manager.OfficeNumber;

                    context.tblManagers.Add(newManager);
                    context.SaveChanges();
                    manager.ManagerID = newManager.ManagerID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
