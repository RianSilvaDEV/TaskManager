using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Domain.InputModels
{
    public class TaskInputModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public bool? Status { get; set; }

    }
}
