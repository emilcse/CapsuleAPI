using Capsule_TaskManagerBL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Capsule_TaskManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        ProjectManagerBL ProjectManagerBL = null;
        [HttpPost]
        public object GetManager(string name)
        {
            ProjectManagerBL = new ProjectManagerBL();

            var managerList = ProjectManagerBL.GetManager(name);

            return managerList;
        }

        [HttpPost]
        public string SaveProject(Project project)
        {
            ProjectManagerBL = new ProjectManagerBL();

            string projectID = ProjectManagerBL.SaveProject(project);

            return projectID;
        }

        [HttpPost]
        public void DeleteProject(int projectId)
        {
            ProjectManagerBL = new ProjectManagerBL();

            ProjectManagerBL.DeleteProject(projectId);
        }

        [HttpGet]
        public List<ProjectModel> GetProjectList()
        {
            ProjectManagerBL = new ProjectManagerBL();

            return ProjectManagerBL.GetProject();
        }
    }
}
