using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_day_4.Models;
using Task_day_4.service;

namespace Task_day_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IService _service;
        private ILogger<ItemsController> _logger;
        public ItemsController(IService service,ILogger<ItemsController> ilogger)
        {
            _service = service;
            _logger = ilogger;
        }
        [HttpGet]
        public IActionResult Get_items()
        {
            var items = _service.GetItems();
            try {
                
                if(items == null)
                {
                    return NotFound();
                    throw new Exception("the item is null");
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                
                
                
            }
            return Ok(items);
            
            
        }
        [HttpGet("{id}")]
        public IActionResult Get_id([FromRoute]int id)
        {
            var item = _service.GetItem_id(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post(Items item)
        {
            var result = _service.Post(item);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Items item)
        {
            var result = _service.Put(id, item);
            try
            {
                if(result == null)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            try
            {
                if( result == null)
                {
                    return NotFound();
                    throw new Exception("item is not found");
                }

            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);

            }
            return NoContent();
        }

    }
}
