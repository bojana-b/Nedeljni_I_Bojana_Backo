using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Bojana_Backo.Services
{
    class ServiceEmployee
    {
        // Method that add Employee to database
        public void AddEmployee(vwWorker employee)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    tblUser newUser = new tblUser();
                    tblWorker newEmployee = new tblWorker();
                    newUser.FirstName = employee.FirstName;
                    newUser.LastName = employee.LastName;
                    newUser.JMBG = employee.JMBG;
                    newUser.Gender = employee.Gender;
                    newUser.Residence = employee.Residence;
                    newUser.MarriageStatus = employee.MarriageStatus;
                    newUser.Username = employee.Username;
                    newUser.UserPassword = SecurePasswordHasher.Hash(employee.UserPassword);

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    employee.UserID = newUser.UserID;

                    newEmployee.UserID = employee.UserID;
                    newEmployee.YearsOfService = employee.YearsOfService;
                    newEmployee.EducationDegree = employee.EducationDegree;
                    newEmployee.SectorID = 1;
                    newEmployee.PositionID = employee.PositionID;
                    newEmployee.Salary = "1200";

                    context.tblWorkers.Add(newEmployee);
                    context.SaveChanges();
                    employee.WorkerID = newEmployee.WorkerID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        // Method that reads all Employees from database
        public List<vwWorker> GetAllEmployees()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<vwWorker> list = new List<vwWorker>();
                    list = (from x in context.vwWorkers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Methot to check if Employee username exists in database
        public bool IsUser(string username)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    vwWorker employee = (from e in context.vwWorkers where e.Username == username select e).First();

                    if (employee == null)
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

        public vwWorker FindEmployee(string username)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    vwWorker employee = (from e in context.vwWorkers where e.Username == username select e).First();
                    return employee;
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
