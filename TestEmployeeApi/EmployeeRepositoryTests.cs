using DataAccess;
using NUnit.Framework;
using PocHomeAssignmentRestApi.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace TestEmployeeApi
{
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository employeeRepository;

        [SetUp]
        public void Setup()
        {
            employeeRepository = new EmployeeRepository();
        }

        [Test]
        public void GetAllEmployees_ReturnsListOfEmployees()
        {           
            IEnumerable<Category> employees = employeeRepository.GetAllEmployees();
           
            Assert.NotNull(employees);
            Assert.AreEqual(5, employees.Count());
        }

        [Test]
        public void GetAllEmployees_ReturnsCorrectEmployeeDetails()
        {
           
            IEnumerable<Category> employees = employeeRepository.GetAllEmployees();

            // Check if the first employee in the list has the expected details
            Category firstEmployee = employees.FirstOrDefault();
            Assert.NotNull(firstEmployee);
            Assert.AreEqual(1, firstEmployee.ID);
            Assert.AreEqual("John Doe", firstEmployee.Name);
            Assert.AreEqual("Developer", firstEmployee.Job);
            Assert.AreEqual("Senior Software Engineer", firstEmployee.Title);
            Assert.AreEqual(30, firstEmployee.Age);
            Assert.AreEqual("ABC Corporation", firstEmployee.Company);
            Assert.AreEqual("W123", firstEmployee.WorkstationNo);
            Assert.AreEqual("Headquarters", firstEmployee.Site);
        }
    }
}