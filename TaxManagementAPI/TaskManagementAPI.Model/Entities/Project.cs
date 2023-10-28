using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementAPI.Model.Entities
{
    public class Project : BaseEntity
    {
        public string? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public List<UserTask> Task { get; set; }


    }
}
