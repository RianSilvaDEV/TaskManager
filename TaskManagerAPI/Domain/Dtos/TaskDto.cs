using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Domain.Dtos
{
    public class TaskDto
    {
        public string Name { get; set; }

        public string Details { get; set; }

        public bool? Status { get; set; }

    }
}
