using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Day_2.Models;
using Task_Day_2.Services;

namespace Task_Day_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployees _emplyee;
        public EmployeeController(IEmployees emplyee ) {

            _emplyee = emplyee;
        
        }
        [HttpGet("api/employees")]
        public IActionResult Get()
        {
            
            return Ok(_emplyee.Get());
        }
        [HttpGet("api/employees/{id}")]
        public IActionResult Get_id(int id)
        {
            return Ok(_emplyee.Get_id(id));
            
        }
        [HttpPost]
        public IActionResult post([FromBody]Employ_data employee)
        {
            if (employee == null)
            {
                return BadRequest("employee cannot be empty");
            }
            var created = _emplyee.Post(employee);
            return CreatedAtAction(nameof(Get_id), new {created.Id}, created);
            
        }
        [HttpPut("{id}")]
        public IActionResult put(int id, Employ_data employ)
        {
            var updated = _emplyee.Put(id, employ);
            return Ok(updated);
        }
        [HttpDelete]
        public IActionResult delete([FromBody]int id) {
            _emplyee.Delete(id);
            return Ok();
        }
    }
}
