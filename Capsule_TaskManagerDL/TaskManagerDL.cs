using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capsule_TaskManagerDL
{
    public class TaskManagerDL
    {

        #region GetParentTask
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GET_PARENT_TASK_Result> GetParentTask()
        {
            using (Entities db = new Entities())
            {
                var VParentTask = db.GET_PARENT_TASK().ToList();
                return VParentTask;
            }

        }
        #endregion 
        
        #region GetTaskDetails
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public IEnumerable<GET_TASK_DETAILS_Result> GetTaskDetails()
        {
            using (Entities db = new Entities())
            {
                var VTaskDetails = db.GET_TASK_DETAILS().ToList();
                return VTaskDetails;
            }

        }
        #endregion 
        
        #region InsertTaskDetails
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>

        public string InsertTaskDetails(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        {
            using (Entities db = new Entities())
            {
                objGET_TASK_DETAILS_Result.Task_ID = objGET_TASK_DETAILS_Result.Task_ID == null ? 0 : objGET_TASK_DETAILS_Result.Task_ID;
               var vInsertTaskDetails = db.INSERT_TASK_DETAILS(objGET_TASK_DETAILS_Result.Task_ID, objGET_TASK_DETAILS_Result.Parent_ID, objGET_TASK_DETAILS_Result.Task, objGET_TASK_DETAILS_Result.Start_Date, objGET_TASK_DETAILS_Result.End_Date, objGET_TASK_DETAILS_Result.Priority);
                
                db.SaveChanges();
                return Convert.ToString(vInsertTaskDetails);
            }

        }
        #endregion 
        
        #region UpdateEndTask
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>

        public string UpdateEndTask(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        {
            using (Entities db = new Entities())
            {
                var vUpdateEndTask = db.UPDATE_END_TASK(objGET_TASK_DETAILS_Result.Task_ID,objGET_TASK_DETAILS_Result.End_Date);
                db.SaveChanges();
                return Convert.ToString(vUpdateEndTask);
            }

        }
        #endregion 
    }
}
