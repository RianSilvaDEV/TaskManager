using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data.Interfaces.IRepositories;
using TaskManagerAPI.Domain.InputModels;
using TaskManagerAPI.Domain.Views;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksController(ITasksRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_taskRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if(string.IsNullOrEmpty(id))
                return NotFound();
           
            return Ok(_mapper.Map<TaskView>(_taskRepository.Get(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskInputModel newTask)
        {
            var task = _mapper.Map<TaskEntity>(newTask);

             _taskRepository.Add(task);
            return Created("", task);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TaskInputModel task, string id)
        {
            if ( _taskRepository.Get(id) == null) return NotFound();
            
            _taskRepository.Update(id, _mapper.Map<TaskEntity>(task));

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (_taskRepository.Get(id) == null) return NotFound();

           _taskRepository.Delete(id);

            return NoContent();
        }
    }
}
