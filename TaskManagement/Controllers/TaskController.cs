using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public ITaskService _taskService;
        public TaskController(ITaskService taskservice)
        {
            _taskService = taskservice;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_taskService.GetAllTasks());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get_id(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult post(Todo task)
        {
            try
            {
                var added = _taskService.Create_Task(task);
                return CreatedAtAction(nameof(Get_id), new { id = added.Id }, added);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult update(int id,Todo task)
        {
            try
            {
                var updated = _taskService.Update_Task(id,task);
                return Ok(updated);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskService.Delete_Task(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
