using Capsule_TaskManagerBL;
using Capsule_TaskManagerDL.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Capsule_TaskManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskManagerController : ApiController
    {
        #region Public Declaration

        TaskManagerBL objTaskManagerBL = null;

        #endregion

        #region GetParentTask
        /// <summary>
        /// To get Parent task details
        /// </summary>
        /// <returns></returns>
        [Route("api/TaskManager/GetParentTask")]
        [HttpGet]       
        public IEnumerable<GET_PARENT_TASK_Result> GetParentTask()
        {
            objTaskManagerBL = new TaskManagerBL();
            var vGetparentTaskDetails = objTaskManagerBL.GetParentTask();

            return vGetparentTaskDetails;
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// Method for getting the task details from BL and send back to HTML
        /// </summary>
        /// <returns></returns>
        [Route("api/TaskManager/GetTaskDetails")]
        [HttpGet]       
        public List<TaskModel> GetTaskDetails()
        {
            objTaskManagerBL = new TaskManagerBL();
            var vGetTaskDetails = objTaskManagerBL.GetTaskDetails();

            return vGetTaskDetails;
        }
        #endregion

        #region InsertTaskDetails
        /// <summary>
        /// Insert the Task details which user entered
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/TaskManager/InsertTaskDetails")]
        [HttpPost]
        public string InsertTaskDetails(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        {
            objTaskManagerBL = new TaskManagerBL();
            var vInsertTaskDetails = objTaskManagerBL.InsertTaskDetails(objGET_TASK_DETAILS_Result);
            return vInsertTaskDetails;
        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// Update the End task 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/TaskManager/UpdateEndTask")]
        [HttpPost]
        public string UpdateEndTask(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        {
            objTaskManagerBL = new TaskManagerBL();
            var vUpdateEndTask = objTaskManagerBL.UpdateEndTask(objGET_TASK_DETAILS_Result);

            return vUpdateEndTask;
        }
        #endregion 
    }
}
