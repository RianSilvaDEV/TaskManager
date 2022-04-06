using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Data.Interfaces.IRepositories
{
    public interface ITasksRepository
    {
        void Add(TaskEntity task);

        void Update(string Id, TaskEntity task);

        void Delete(string Id);

        IEnumerable<TaskEntity> Get();

        TaskEntity Get(string Id);
    }
}
