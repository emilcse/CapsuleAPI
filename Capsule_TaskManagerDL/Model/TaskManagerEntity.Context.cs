﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capsule_TaskManagerDL.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TaskManagerEntities : DbContext
    {
        public TaskManagerEntities()
            : base("name=TaskManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Parent_Task> Parent_Task { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<GET_PARENT_TASK_Result> GET_PARENT_TASK()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GET_PARENT_TASK_Result>("GET_PARENT_TASK");
        }
    
        public virtual int UPDATE_END_TASK(Nullable<int> task_ID, Nullable<System.DateTime> end_Date)
        {
            var task_IDParameter = task_ID.HasValue ?
                new ObjectParameter("Task_ID", task_ID) :
                new ObjectParameter("Task_ID", typeof(int));
    
            var end_DateParameter = end_Date.HasValue ?
                new ObjectParameter("End_Date", end_Date) :
                new ObjectParameter("End_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UPDATE_END_TASK", task_IDParameter, end_DateParameter);
        }
    
        public virtual ObjectResult<GET_TASK_DETAILS_Result> GET_TASK_DETAILS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GET_TASK_DETAILS_Result>("GET_TASK_DETAILS");
        }
    
        public virtual int INSERT_TASK_DETAILS(Nullable<int> task_ID, Nullable<int> parent_ID, string task, Nullable<System.DateTime> start_Date, Nullable<System.DateTime> end_Date, Nullable<int> priority, Nullable<int> project_ID)
        {
            var task_IDParameter = task_ID.HasValue ?
                new ObjectParameter("Task_ID", task_ID) :
                new ObjectParameter("Task_ID", typeof(int));
    
            var parent_IDParameter = parent_ID.HasValue ?
                new ObjectParameter("Parent_ID", parent_ID) :
                new ObjectParameter("Parent_ID", typeof(int));
    
            var taskParameter = task != null ?
                new ObjectParameter("Task", task) :
                new ObjectParameter("Task", typeof(string));
    
            var start_DateParameter = start_Date.HasValue ?
                new ObjectParameter("Start_Date", start_Date) :
                new ObjectParameter("Start_Date", typeof(System.DateTime));
    
            var end_DateParameter = end_Date.HasValue ?
                new ObjectParameter("End_Date", end_Date) :
                new ObjectParameter("End_Date", typeof(System.DateTime));
    
            var priorityParameter = priority.HasValue ?
                new ObjectParameter("Priority", priority) :
                new ObjectParameter("Priority", typeof(int));
    
            var project_IDParameter = project_ID.HasValue ?
                new ObjectParameter("Project_ID", project_ID) :
                new ObjectParameter("Project_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERT_TASK_DETAILS", task_IDParameter, parent_IDParameter, taskParameter, start_DateParameter, end_DateParameter, priorityParameter, project_IDParameter);
        }
    }
}
