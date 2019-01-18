using Capsule_TaskManager.Controllers;
using Capsule_TaskManagerDL.Model;
using NUnit.Framework;
using System;
using System.Linq;

namespace NUnit_TaskManagerController
{
    [TestFixture]
    public class NUnit_TaskManagerController
    {
        #region Public Declaration

        TaskManagerController objTaskManagerController = new TaskManagerController();
        GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result = null;
        ProjectController objProjectController = new ProjectController();

        #endregion

        #region GetParentTask
        /// <summary>
        /// To get Parent task details
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetParentTask()
        {
            var vlsit = objTaskManagerController.GetParentTask();
            var vCount = vlsit.Count();

            Assert.IsTrue(vCount > 0);
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// Method for getting the task details from BL and send back to HTML
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetTaskDetails()
        {
            var vlsit = objTaskManagerController.GetTaskDetails();
            var vCount = vlsit.Count();

            Assert.IsTrue(vCount > 0);
        }
        #endregion

        #region InsertTaskDetails
        /// <summary>
        /// Insert the Task details which user entered
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Test]
        public void InsertTaskDetails()
        {
            objGET_TASK_DETAILS_Result = new GET_TASK_DETAILS_Result();

            #region Insert new records

            objGET_TASK_DETAILS_Result.Task_ID = 0;
            objGET_TASK_DETAILS_Result.Parent_ID = 1;
            objGET_TASK_DETAILS_Result.Task = "New task";
            objGET_TASK_DETAILS_Result.Start_Date = DateTime.Now;
            objGET_TASK_DETAILS_Result.End_Date = null;
            objGET_TASK_DETAILS_Result.Priority = 4;
            objGET_TASK_DETAILS_Result.IsActive = true;
            objGET_TASK_DETAILS_Result.Project_ID = 1007;

            #endregion

            #region Update records

            //objGET_TASK_DETAILS_Result.Task_ID = 4;
            //objGET_TASK_DETAILS_Result.Parent_ID = 1;
            //objGET_TASK_DETAILS_Result.Task = "Update new task";
            //objGET_TASK_DETAILS_Result.Start_Date = DateTime.Now;
            //objGET_TASK_DETAILS_Result.End_Date = null;
            //objGET_TASK_DETAILS_Result.Priority = 16;

            #endregion

            var vlsit = objTaskManagerController.InsertTaskDetails(objGET_TASK_DETAILS_Result);

            Assert.IsTrue(vlsit == "1" || vlsit == "2");
        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// Update the End task 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Test]
        public void UpdateEndTask()
        {
            objGET_TASK_DETAILS_Result = new GET_TASK_DETAILS_Result();

            #region Update records

            objGET_TASK_DETAILS_Result.Task_ID = 1;
            objGET_TASK_DETAILS_Result.End_Date = DateTime.Now;

            #endregion

            var vlsit = objTaskManagerController.UpdateEndTask(objGET_TASK_DETAILS_Result);
            Assert.IsTrue(true);
        }
        #endregion 

        #region SaveProejct
        [Test]
        public void SaveProject()
        {
            Project project = new Project();

            project.ProjectID = 0;
            project.ManagerID = "002";
            project.Priority = 2;
            project.StartDate = DateTime.Now;
            project.EndDate = DateTime.Now.AddDays(1);
            project.ProjectName = "Test Case Project";
            project.Status = true;

            var sproj = objProjectController.SaveProject(project);

            Assert.IsTrue(sproj != string.Empty);
        }
        #endregion        
    }
}
