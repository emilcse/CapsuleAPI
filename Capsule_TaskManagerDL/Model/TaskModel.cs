using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerDL.Model
{
    public class TaskModel
    {
        public int Task_ID { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public int Project_ID { get; set; }
        public string Parent_Task { get; set; }
        public string Task { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Priority { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public bool IsParent { get; set; }
        public int User_ID { get; set; }
        public string Project { get; set; }
        public string ManagerId { get; set; }
    }
}
