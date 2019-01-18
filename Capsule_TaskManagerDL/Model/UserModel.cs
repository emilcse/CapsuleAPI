using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerDL.Model
{
    public class UserModel
    {
        public int User_ID { get; set; }
        public string Employee_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
    }
}
