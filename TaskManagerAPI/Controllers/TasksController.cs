using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagerAPI.Data.Interfaces.IRepositories;
using TaskManagerAPI.Domain.Dtos;
using TaskManagerAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        ITasksRepository _taskRepository;

        public TasksController(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
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
           
            return Ok(_taskRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskDto newTask)
        {
            var task = new TaskEntity(newTask.Name,newTask.Details);

             _taskRepository.Add(task);
            return Created("", task);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TaskEntity Task, string id)
        {
            var existingTask = _taskRepository.Get(id);

            if (existingTask == null) return NotFound();

             existingTask.UpdateTask(Task.Name, Task.Details, Task.finished);
            
            _taskRepository.Update(id, existingTask);

            return Ok(existingTask);
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
