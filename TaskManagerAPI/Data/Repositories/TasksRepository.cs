
using MongoDB.Driver;
using System.Collections.Generic;

using System.Threading.Tasks;
using TaskManagerAPI.Data.Interfaces.IConfigurations;
using TaskManagerAPI.Data.Interfaces.IRepositories;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IMongoCollection<TaskEntity> _tasks;

        public TasksRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _tasks = database.GetCollection<TaskEntity>("tasks");

        }
        public void Add(TaskEntity task)
        {
            _tasks.InsertOne(task);
        }

        public TaskEntity Update(TaskEntity taskUpdate)
        {
            return _tasks.FindOneAndReplace(task => task.Id == taskUpdate.Id, taskUpdate);
        }

        public void Delete(string Id)
        {
            _tasks.DeleteOne(task => task.Id == Id);
        }
      
        public IEnumerable<TaskEntity> Get()
        {
            return _tasks.Find(task => true).ToList();
        }

        public TaskEntity Get(string Id)
        {
            return _tasks.Find(task => task.Id == Id).FirstOrDefault();
        }

      
    }
}
