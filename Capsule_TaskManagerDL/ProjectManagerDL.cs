using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerDL
{
    public class ProjectManagerDL
    {
        public List<ProjectModel> GetManager(string ProjectName)
        {
            //.Select(x => new { ProjectID = x.ProjectId, Name = x.Name })
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var projectList = (from project in db.Projects
                                   join task in db.Tasks on project.ProjectID equals task.Project_ID into allPro
                                   from temp in allPro.DefaultIfEmpty()
                                   where project.Status == true
                                   //orderby project.Project_ID descending
                                   select new ProjectModel()
                                   {
                                       ProjectID = project.ProjectID,
                                       ProjectName = project.ProjectName,
                                       Priority = project.Priority,
                                       StartDate = project.StartDate,
                                       EndDate = project.EndDate,
                                       Status = project.Status,
                                       NoOfTasks = project.Tasks.Count(),
                                       ManagerID = project.ManagerID.ToString(),
                                       CompletedTasks = project.Tasks.Where(x => x.IsActive == false).Count()
                                   }).Distinct().ToList();

                return projectList.OrderByDescending(x => x.ProjectID).ToList();
            }
        }

        public string SaveProject(Project projectModel)
        {
            if (projectModel != null)
            {
                Project Project = GetProject(projectModel.ProjectID);
                using (TaskManagerEntities db = new TaskManagerEntities())
                {
                    if (Project == null)
                    {
                        projectModel.Status = true;
                        db.Projects.Add(projectModel);
                    }
                    else
                    {
                        Project.ProjectName = projectModel.ProjectName;
                        Project.Priority = projectModel.Priority;
                        Project.EndDate = projectModel.EndDate;
                        Project.StartDate = projectModel.StartDate;
                        Project.Status = projectModel.Status;
                        db.Entry(Project).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    
                }
            }

            return projectModel.ProjectID.ToString();
        }

        public void DeleteProject(int projectId)
        {
            Project Project = GetProject(projectId);
            if (Project != null)
                using (TaskManagerEntities db = new TaskManagerEntities())
                {
                    db.Projects.Remove(Project);
                    db.SaveChanges();
                }
        }
        
        public Project GetProject(int ProjectID)
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var Project = db.Projects.Where(i => i.ProjectID == ProjectID).FirstOrDefault();

                return Project;
            }
        }

        public List<ProjectModel> GetProject()
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var projectList = (from project in db.Projects
                                   join task in db.Tasks on project.ProjectID equals task.Project_ID into allPro
                                   from temp in allPro.DefaultIfEmpty()
                                   where project.Status == true
                                   //orderby project.Project_ID descending
                                   select new ProjectModel()
                                   {
                                       ProjectID = project.ProjectID,
                                       ProjectName = project.ProjectName,
                                       Priority = project.Priority,
                                       StartDate = project.StartDate,
                                       EndDate = project.EndDate,
                                       Status = project.Status,
                                       NoOfTasks = project.Tasks.Count(),
                                       ManagerID = project.ManagerID.ToString(),
                                       CompletedTasks = project.Tasks.Where(x => x.IsActive == false).Count()
                                   }).Distinct().ToList();

                return projectList.OrderByDescending(x => x.ProjectID).ToList();
            }
        }

    }
}
