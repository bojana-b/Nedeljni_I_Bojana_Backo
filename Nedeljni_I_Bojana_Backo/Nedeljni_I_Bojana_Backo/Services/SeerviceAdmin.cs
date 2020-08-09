using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Bojana_Backo.Services
{
    class SeerviceAdmin
    {
        // Method that add Admin to database
        public void AddAdmin(vwAdmin admin)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    tblUser newUser = new tblUser();
                    tblAdmin newAdmin = new tblAdmin();
                    newUser.FirstName = admin.FirstName;
                    newUser.LastName = admin.LastName;
                    newUser.JMBG = admin.JMBG;
                    newUser.Gender = admin.Gender;
                    newUser.Residence = admin.Residence;
                    newUser.MarriageStatus = admin.MarriageStatus;
                    newUser.Username = admin.Username;
                    newUser.UserPassword = SecurePasswordHasher.Hash(admin.UserPassword);

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    admin.UserID = newUser.UserID;

                    newAdmin.UserID = admin.UserID;
                    newAdmin.ExpirationDate = DateTime.Now.AddDays(7);
                    newAdmin.AdminType = admin.AdminType;

                    context.tblAdmins.Add(newAdmin);
                    context.SaveChanges();
                    admin.AdminID = newAdmin.AdminID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        // Method that reads all Admins from database
        public List<vwAdmin> GetAllAdmins()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<vwAdmin> list = new List<vwAdmin>();
                    list = (from x in context.vwAdmins select x).ToList();
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
                    vwAdmin admin = (from e in context.vwAdmins where e.Username == username select e).First();

                    if (admin == null)
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

        public vwAdmin FindAdmin(string username)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    vwAdmin admin = (from e in context.vwAdmins where e.Username == username select e).First();
                    return admin;
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
