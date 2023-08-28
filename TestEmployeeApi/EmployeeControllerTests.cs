using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PocHomeAssignmentRestApi.Controllers;
using PocHomeAssignmentRestApi.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class EmployeesControllerTests
{
    private EmployeesController employeesController;
    private Mock<IEmployeeRepository> mockEmployeeRepository;
    private List<Category> dummyEmployees;

    [SetUp]
    public void Setup()
    {
        // Create a mock instance of IEmployeeRepository
        mockEmployeeRepository = new Mock<IEmployeeRepository>();

        dummyEmployees = new List<Category>
        {
            new Category
            {
                ID = 1,
                Name = "John1234",
                Job = "Developer",
                Title = "Senior Software Engineer",
                Age = 30,
                Company = "ABC",
                WorkstationNo = "W123",
                Site = "Tel Aviv"
            },
        };

        // Set up mock for GetAllEmployees  
        mockEmployeeRepository.Setup(repo => repo.GetAllEmployees()).Returns(dummyEmployees);

        // Set up mock for GetEmployeeById  
        mockEmployeeRepository.Setup(repo => repo.GetEmployeeById(It.IsAny<int>()))
            .Returns<int>(id => dummyEmployees.Find(employee => employee.ID == id));
         
        mockEmployeeRepository.Setup(repo => repo.AddEmployee(It.IsAny<Category>()));

        // Create instance 
        employeesController = new EmployeesController(mockEmployeeRepository.Object, Mock.Of<ILogger<EmployeesController>>());
    }

    [Test]
    public void GetAllEmployees_ReturnsListOfEmployees()
    {      
        IActionResult result = employeesController.Get();
        
        Assert.IsInstanceOf<OkObjectResult>(result);
        OkObjectResult okResult = (OkObjectResult)result;
        Assert.NotNull(okResult.Value);
        Assert.IsInstanceOf<IEnumerable<Category>>(okResult.Value);
        Assert.AreEqual(dummyEmployees.Count, ((IEnumerable<Category>)okResult.Value).Count());
    }

    [Test]
    public void GetEmployeeById_ReturnsEmployeeWithMatchingId()
    {
        int employeeId = 1;
      
        IActionResult result = employeesController.GetEmployeeById(employeeId);

        Assert.IsInstanceOf<OkObjectResult>(result);
        OkObjectResult okResult = (OkObjectResult)result;
        Assert.NotNull(okResult.Value);
        Assert.IsInstanceOf<Category>(okResult.Value);
        Assert.AreEqual(employeeId, ((Category)okResult.Value).ID);
    }

    [Test]
    public void GetEmployeeById_ReturnsNotFoundForNonExistingEmployee()
    {
        int employeeId = 10; // Assuming no employee with ID 10 exists

        //Call the GetEmployeeById method with employeeId not existing
        IActionResult result = employeesController.GetEmployeeById(employeeId);
        
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void AddEmployee_ReturnsCreatedAtAction()
    {
        Category newEmployee = new Category
        {
            ID = 6,
            Name = "New Employee",
            Job = "Tester",
            Title = "QA",
            Age = 28,
            Company = "isaac comp",
            WorkstationNo = "2d23dwed23d",
            Site = "Office"
        };
               
        IActionResult result = employeesController.AddEmployee(newEmployee);
                
        Assert.IsInstanceOf<CreatedAtActionResult>(result);
        CreatedAtActionResult createdAtResult = (CreatedAtActionResult)result;
        Assert.AreEqual(nameof(employeesController.GetEmployeeById), createdAtResult.ActionName);
        Assert.AreEqual(newEmployee.ID, createdAtResult.RouteValues["id"]);
    }
}