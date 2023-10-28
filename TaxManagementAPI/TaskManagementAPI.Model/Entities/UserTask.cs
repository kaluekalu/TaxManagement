using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Model.EntityEnums;

namespace TaskManagementAPI.Model.Entities
{
    public class UserTask : BaseEntity
    {
        public string UserTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string? ProjectId { get; set; }
        public Project Project { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
