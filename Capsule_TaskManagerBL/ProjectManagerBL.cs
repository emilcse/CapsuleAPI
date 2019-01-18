using Capsule_TaskManagerDL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerBL
{
    public class ProjectManagerBL
    {
        ProjectManagerDL ProjectManagerDL = null;

        public List<ProjectModel> GetManager(string name)
        {
            ProjectManagerDL = new ProjectManagerDL();

            return ProjectManagerDL.GetManager(name);
        }

        public string SaveProject(Project ProjectModel)
        {
            ProjectManagerDL = new ProjectManagerDL();

            string projectID = ProjectManagerDL.SaveProject(ProjectModel);

            return projectID;
        }

        public void DeleteProject(int ProjectId)
        {
            ProjectManagerDL = new ProjectManagerDL();

            ProjectManagerDL.DeleteProject(ProjectId);
        }

        public List<ProjectModel> GetProject()
        {
            ProjectManagerDL = new ProjectManagerDL();

            return ProjectManagerDL.GetProject();
        }
    }
}
