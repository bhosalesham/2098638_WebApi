using EmployeeManagement_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employee _empGlobal = new Employee();

        public EmployeeController() { }

        [HttpGet]
        [Route("/employee/list")]
        public ActionResult GetAllEmployee()
        {
            List<Employee> emp = _empGlobal.GetAllEmployees();
            return Ok(emp);
        }

        [HttpGet]
        [Route("/employee/id/{eno}")]
        public IActionResult GetEmpById(int eno)
        {
            try
            {
                var emp = _empGlobal.GetEmpById(eno);
                return Ok(emp);
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }

        [HttpGet]
        [Route("/employee/designation/{designation}")]
        public IActionResult GetEmpByDesignation(string designation)
        {
            try
            {
                var emp = _empGlobal.GetEmpByDesigantion(designation);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/employee/total")]
        public IActionResult GetTotalEmployees()
        {
            var total = _empGlobal.GetTotalEmployees();
            return Ok(total);
        }

        [HttpPost]
        [Route("/employee/add")]
        public IActionResult AddNewEmployee([FromBody] Employee newEmp)
        {

            try
            {
                var addResult = _empGlobal.AddNewEmployee(newEmp);
                return Created("", addResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/employee/delete/{empno}")]
        public IActionResult DeleteEmployee(int empno)
        {
            try
            {
                var deleteResult = _empGlobal.DeleteEmployee(empno);
                return Accepted(deleteResult);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("/employee/edit")]
        public IActionResult UpdateEmployee([FromBody] Employee changes)
        {
            try
            {
                var updateResult = _empGlobal.UpdateEmployee(changes);
                return Accepted(updateResult);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
