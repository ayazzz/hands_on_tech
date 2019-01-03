using HandsOnTech.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HandsOnTech.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var list = await _employeeRepository.GetEmployeesAsync();
                if (list == null || list.Count == 0)
                {
                    return new NotFoundObjectResult("Not found employees.");
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployees([FromRoute]int employeeId)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeAsync(employeeId);
                if (result == null)
                {
                    return new NotFoundObjectResult($"Not found employee with id {employeeId}");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}