using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocHomeAssignmentRestApi.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocHomeAssignmentRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = ApiKeyAuthenticationOptions.Scheme)]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;

        private readonly ICategoryRepository _categoryRepository;

        //public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger)
        //{
        //    _employeeRepository = employeeRepository;
        //    _logger = logger;
        //}

        public CategoryController(ICategoryRepository employeeRepository, ILogger<CategoryController> logger)
        {
            _categoryRepository = employeeRepository;
            _logger = logger;
        }

        // GetAllEmployees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Category> categories = await _categoryRepository.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return Ok("error");
            }
          
          
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Category employee = await _categoryRepository.GetCategory(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //[HttpPost]
        //public Task<IActionResult> AddEmployee(Category employee)
        //{
        //    //simple validations
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

           


        //    _categoryRepository.AddEmployee(employee);
        //    return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.ID }, employee.ID);
        //}

        //[HttpPut("{id}")]
        //public Task<IActionResult> UpdateEmployee(int id, Category employee)
        //{

        //    if (employee == null || !employee.IsValid())
        //    {
        //        return NoContent();
        //    }

        //    Category existingEmployee = _categoryRepository.GetEmployeeById(id);
        //    if (existingEmployee == null)
        //    {
        //        return NotFound();
        //    }
        //    employee.ID = id;
        //    _categoryRepository.UpdateEmployee(employee);
        //    return NoContent();
        //}

       

    }
}
