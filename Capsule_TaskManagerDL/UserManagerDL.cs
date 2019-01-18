using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerDL
{
    public class UserManagerDL
    {
        public List<User> GetManager(string name)
        {
            //.Select(x => new { UserID = x.UserId, Name = x.Name })
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var manager = db.Users.Where(x => x.FirstName.Contains(name)).ToList();
                return manager;
            }
        }

        public string SaveUser(User userModel)
        { 
            if (userModel != null)
            {
                User user = GetUser(userModel.Employee_ID);
                using (TaskManagerEntities db = new TaskManagerEntities())
                {
                    if (user == null)
                    {
                        db.Users.Add(userModel);
                    }
                    else
                    {
                        user.FirstName = userModel.FirstName;
                        user.LastName = userModel.LastName;
                        user.IsActive = userModel.IsActive;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }

            return userModel.User_ID.ToString();
        }

        public void DeleteUser(string employeeId)
        {
            User user = GetUser(employeeId);
            if(user != null)
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                    db.Users.Remove(user);
                    db.SaveChanges();
            }
        }

        public User GetUser(string employeeId)
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var user = db.Users.Where(i => i.Employee_ID == employeeId).FirstOrDefault();

                return user;
            }
        }

        public List<UserModel> GetUser()
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var userList = (from user in db.Users
                                where user.IsActive == true
                                orderby user.User_ID descending
                                select new UserModel()
                                {
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    Employee_ID = user.Employee_ID,
                                    User_ID = user.User_ID,
                                    IsActive = user.IsActive
                                }).ToList();

                return userList;
            }
        }
    }
}
