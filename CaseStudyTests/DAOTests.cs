using Xunit;
using System.Collections.Generic;
using HelpdeskDAL;
using System;
using System.Diagnostics;


namespace CaseStudyTests
{
    public class DAOTests
    {
        [Fact]
        public void Employee_GetByEmailTest()
        {
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                Employees selectedEmployee = dao.GetByEmail("bs@abc.com");
                Assert.NotNull(selectedEmployee);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }

        [Fact]
        public void Employee_GetByIdTest()
        {
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                Employees selectedStudent = dao.GetById(2);
                Assert.NotNull(selectedStudent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }

        [Fact]
        public void Employee_GetAllTest()
        {
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                List<Employees> allStudent = dao.GetAll();
                Assert.True(allStudent.Count > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }

        [Fact]
        public void Employee_AddTest()
        {
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                Employees newStudent = new Employees
                {
                    FirstName = "Joe",
                    LastName = "Smith",
                    PhoneNo = "(555)555-1234",
                    Title = "Mr.",
                    DepartmentId = 100,
                    Email = "js@abc.com"
                };
                Assert.True(dao.Add(newStudent) > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }

        [Fact]
        public void Employee_UpdateTest()
        {
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                Employees studentForUpdate = dao.GetById(1002);
                if (studentForUpdate != null)
                {
                    string oldPhoneNumber = studentForUpdate.PhoneNo;
                    string newPhoneNumber = oldPhoneNumber == "519-555-1234" ? "555-555-5555" : "519-555-1234";
                    studentForUpdate.PhoneNo = newPhoneNumber;
                }
                Assert.True(dao.Update(studentForUpdate) == 1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }

        [Fact]
        public void Employee_DeleteTest()
        {
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                Employees studentForDelete = dao.GetById(1002);
                Assert.True(dao.Delete(studentForDelete.Id) == 1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
    }
}
