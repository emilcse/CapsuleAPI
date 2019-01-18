using Capsule_TaskManagerDL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;

namespace Capsule_TaskManagerBL
{
    public class TaskManagerBL
    {
        #region Public Declaration

        TaskManagerDL objTaskManagerDL = null;

        #endregion

        #region GetParentTask
        /// <summary>
        /// To get Parent task details from DL using EF
        /// </summary>
        /// <returns></returns>

        public IEnumerable<GET_PARENT_TASK_Result> GetParentTask()
        {
            objTaskManagerDL = new TaskManagerDL();
            var vGetparentTaskDetails = objTaskManagerDL.GetParentTask();

            return vGetparentTaskDetails;
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// To get task details from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<TaskModel> GetTaskDetails()
        {
            objTaskManagerDL = new TaskManagerDL();
            var vGetTaskDetails = objTaskManagerDL.GetTaskDetails();

            return vGetTaskDetails;
        }
        #endregion 

        #region InsertTaskDetails
        /// <summary>
        /// Insert the task values which user entered to DB from DL using EF
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        public string InsertTaskDetails(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        {
            objTaskManagerDL = new TaskManagerDL();
            var vInsertTaskDetails = objTaskManagerDL.InsertTaskDetails(objGET_TASK_DETAILS_Result);

            if (objGET_TASK_DETAILS_Result.Task_ID != 0)
                if (vInsertTaskDetails == "1")
                {
                    vInsertTaskDetails = "2";
                }

            return vInsertTaskDetails;
        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// Update the end task which user entered ,DL using EF
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        public string UpdateEndTask(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        {
            objTaskManagerDL = new TaskManagerDL();
            var vUpdateEndTask = objTaskManagerDL.UpdateEndTask(objGET_TASK_DETAILS_Result);

            return Convert.ToString(vUpdateEndTask);
        }
        #endregion 

    }
}
