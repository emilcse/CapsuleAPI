using Capsule_TaskManager.Controllers;
using Capsule_TaskManagerDL.Model;
using NBench;
using System;
using System.Linq;

namespace NBench_Capsule.Tests
{
    public class NBenchTestCase : PerformanceTestStuite<NBenchTestCase>
    {
        #region Variables
        TaskManagerController objTaskManagerController = null;
        GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result = null;

        private const int AcceptableMinAddThroughput = 500;
        #endregion

        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            objTaskManagerController = new TaskManagerController();
            objGET_TASK_DETAILS_Result = new GET_TASK_DETAILS_Result();
        }

        #region GetParentTask
        /// <summary>
        /// To get Parent task details
        /// </summary>
        /// <returns></returns>
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void GetParentTask()
        {
            var vlsit = objTaskManagerController.GetParentTask();
            var vCount = vlsit.Count();

        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// Method for getting the task details from BL and send back to HTML
        /// </summary>
        /// <returns></returns>
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void GetTaskDetails()
        {
            var vlsit = objTaskManagerController.GetTaskDetails();
            var vCount = vlsit.Count();

        }
        #endregion

        #region InsertTaskDetails
        /// <summary>
        /// Insert the Task details which user entered
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
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

        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// Update the End task 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void UpdateEndTask()
        {
            objGET_TASK_DETAILS_Result = new GET_TASK_DETAILS_Result();

            #region Update records

            objGET_TASK_DETAILS_Result.Task_ID = 4;
            objGET_TASK_DETAILS_Result.End_Date = DateTime.Now;

            #endregion

            var vlsit = objTaskManagerController.UpdateEndTask(objGET_TASK_DETAILS_Result);
        }
        #endregion 

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
             objTaskManagerController = null;
             objGET_TASK_DETAILS_Result = null;

        }
    }
}
