using Capsule_TaskManagerBL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Capsule_TaskManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        UserManagerBL userManagerBL = null;
        [HttpPost]
        public object GetManager(string name)
        {
            userManagerBL = new UserManagerBL();

            var managerList = userManagerBL.GetManager(name);

            return managerList;
        }

        [HttpPost]
        public string  SaveUser(User user)
        {
            userManagerBL = new UserManagerBL();

            string userID = userManagerBL.SaveUser(user);

            return userID;
        }

        [HttpPost]
        public void DeleteUser(string Employee_ID)
        {
            userManagerBL = new UserManagerBL();

            userManagerBL.DeleteUser(Employee_ID);
        }

        [HttpGet]
        public List<UserModel> GetUserList()
        {
            userManagerBL = new UserManagerBL();

            var userList = userManagerBL.GetUser();

            return userList;
        }
    }
}
