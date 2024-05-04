using ApiToDoList.Dto;
using ApiToDoList.Models.Errors;
using ApiToDoList.ModelViews;
using ApiToDoList.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDoList.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TaskToDoController : ControllerBase{

        private ITaskToDoService _service;

        public TaskToDoController(ITaskToDoService service) {

            _service = service;

        }

        [HttpGet]
        public IActionResult GetAll(int page = 1) {
            var task = _service.TaskList(page); ;

            return Ok(task);

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {

            try {
                var tarefa = _service.SearchById(id);
                return Ok(tarefa);
            } catch (TaskToDoError error) {
                return StatusCode(404, new ErrorView { Message = error.Message });
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskToDoDto taskDto) {

            try {
                var tarefa = _service.Include(taskDto);
                return Ok(tarefa);
            } catch (TaskToDoError error) {
                return StatusCode(400, new ErrorView { Message = error.Message });
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TaskToDoDto taskDto) {

            try {
                var tarefa = _service.Update(id, taskDto);
                return Ok(tarefa);
            } catch (TaskToDoError error) {
                return StatusCode(400, new ErrorView { Message = error.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) {

            try {
                _service.Remove(id);                   
                return Ok();
            } catch (TaskToDoError error) {
                return StatusCode(400, new ErrorView { Message = error.Message });
            }

        }
    }
}
