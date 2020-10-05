using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;


namespace HelpdeskDAL
{
    public class EmployeeDAO
    {
        public Employees GetByEmail(string email)
        {
            Employees selectedEmployee = null;
            try
            {
                HelpdeskContext _db = new HelpdeskContext();
                selectedEmployee = _db.Employees.FirstOrDefault(emp => emp.Email == email);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Problem in " + " " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + ex.Message);
            }
            return selectedEmployee;
        }

        public Employees GetById(int id)
        {
            Employees selectedempdent = null;

            try
            {
                HelpdeskContext _db = new HelpdeskContext();
                selectedempdent = _db.Employees.FirstOrDefault(emp => emp.Id == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in" + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return selectedempdent;
        }

        public List<Employees> GetAll()
        {
            List<Employees> allEmployees = new List<Employees>();

            try
            {
                HelpdeskContext _db = new HelpdeskContext();
                allEmployees = _db.Employees.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + "" + ex.Message);
                throw ex;
            }

            return allEmployees;
        }

        public int Add(Employees newempdent)
        {

            try
            {
                HelpdeskContext _db = new HelpdeskContext();
                _db.Employees.Add(newempdent);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod().Name + "" + ex.Message);
                throw ex;
            }

            return newempdent.Id;
        }

        public int Update(Employees updatedempdent)
        {
            int EmployeesUpdated = -1;

            try
            {
                HelpdeskContext _db = new HelpdeskContext();
                Employees currentempdent = _db.Employees.FirstOrDefault(emp => emp.Id == updatedempdent.Id);
                _db.Entry(currentempdent).CurrentValues.SetValues(updatedempdent);
                EmployeesUpdated = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod().Name + " " + ex.Message);
            }

            return EmployeesUpdated;
        }

        public int Delete(int id)
        {
            int empdentDeleted = -1;
            try
            {
                HelpdeskContext _db = new HelpdeskContext();
                Employees selectedempdent = _db.Employees.FirstOrDefault(emp => emp.Id == id);
                _db.Employees.Remove(selectedempdent);
                empdentDeleted = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod().Name + "" + ex.Message);
                throw ex;
            }
            return empdentDeleted;
        }
    }
}
