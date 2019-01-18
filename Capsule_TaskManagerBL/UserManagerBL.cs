using Capsule_TaskManagerDL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerBL
{
    
    public class UserManagerBL
    {
        UserManagerDL userManagerDL = null;

        public List<User> GetManager(string name)
        {
            userManagerDL = new UserManagerDL();

            return userManagerDL.GetManager(name);
        }

        public string SaveUser(User userModel)
        {
            userManagerDL = new UserManagerDL();

            return userManagerDL.SaveUser(userModel);
        }

        public void DeleteUser(string employeeeId)
        {
            userManagerDL = new UserManagerDL();

            userManagerDL.DeleteUser(employeeeId);
        }

        public List<UserModel> GetUser()
        {
            userManagerDL = new UserManagerDL();

            return userManagerDL.GetUser();
        }

    }
}
