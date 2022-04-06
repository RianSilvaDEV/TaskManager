using System;

namespace TaskManagerAPI.Entities
{
    public class TaskEntity
    {
        public TaskEntity(string name, string details)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Details = details;
            DateRegister = DateTime.Now;
            CompletionDate = null;
            finished = false;

        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Details { get; private set; }

        public DateTime DateRegister { get; private set; }

        public DateTime? CompletionDate { get; private set; }

        public bool finished { get; private set; }

        public void UpdateTask(string name, string details, bool? finished)
        {
            Name = name;
            Details = details;
            //finished = finished.HasValue ? finished.Value : false;
            finished = finished ?? false;
            CompletionDate = finished == true ? DateTime.Now : null;
          

        }

    }
}
