using Capsule_TaskManager.Controllers;
using Capsule_TaskManagerDL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Capsule_TaskManager.Tests
{
    [TestClass]
    public class UnitTestCase
    {
        TaskManagerController objTaskManagerController = new TaskManagerController();
        GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result = null;

        #region GetParentTask
        /// <summary>
        /// To get Parent task details
        /// </summary>
        /// <returns></returns>
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
        public void UpdateEndTask()
        {
            objGET_TASK_DETAILS_Result = new GET_TASK_DETAILS_Result();

            #region Update records

            objGET_TASK_DETAILS_Result.Task_ID = 1;           
            objGET_TASK_DETAILS_Result.End_Date = DateTime.Now;            

            #endregion

            var vlsit = objTaskManagerController.UpdateEndTask(objGET_TASK_DETAILS_Result);
            Assert.IsTrue(vlsit=="1");
        }
        #endregion
    }
}
