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
        // Method that add Manager to database
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
                    newUser.UserPassword = SecurePasswordHasher.Hash(manager.UserPassword);

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
        // Method that reads all Managers from database
        public List<vwManager> GetAllManagers()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Methot to check if Manager username exists in database
        public bool IsUser(string username)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    vwManager manager = (from e in context.vwManagers where e.Username == username select e).First();

                    if (manager == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public vwManager FindManager(string username)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    vwManager manager = (from e in context.vwManagers where e.Username == username select e).First();
                    return manager;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
