using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementAPI.Model.EntityEnums
{
    public enum Priority
    {
        Low,
        Medium,
        High

    }

    public enum Status
    {
        Pending,
        InProgress,
        Completed
    }


    public enum NotificationType
    {
        DueDateReminder,
        StatusUpdate,
        Others
    }

}
