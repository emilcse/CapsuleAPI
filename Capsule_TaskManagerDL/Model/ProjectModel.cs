using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerDL.Model
{
    public class ProjectModel:Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int NoOfTasks { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<int> Priority { get; set; }
        public int CompletedTasks { get; set; }
        public bool? Status { get; set; }
        public string ManagerID { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
    }
}
