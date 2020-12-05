using HomeMaintenance.Data;
using HomeMaintenance.Data.DataClasses;
using HomeMaintenance.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Services.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }
        // Create Project
        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    ProjectName = model.ProjectName,
                    ProjectTask = model.ProjectTask,
                    Description = model.Description,
                    SuppliesNeeded = model.SuppliesNeeded,
                    Instructions = model.Instructions,
                    EstimatedTime = model.EstimatedTime,
                    ProjectionCreateationDate = DateTimeOffset.Now,
                    ProjectCompletionDate = model.ProjectCompletionDate,
                    TechnicianNotes = model.TechnicianNotes,
                    PropertyID = model.PropertyID,
                    TechnicianID = model.TechnicianID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Project.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All Projects
        public IEnumerable<ProjectListItem> GetProject()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Project
                    .Select(
                    e =>
                    new ProjectListItem
                    {
                        ProjectID = e.ProjectID,
                        ProjectName = e.ProjectName,
                        ProjectTask = e.ProjectTask,
                        Description = e.Description,
                        SuppliesNeeded = e.SuppliesNeeded,
                        Instructions = e.Instructions,
                        EstimatedTime = e.EstimatedTime,
                        ProjectionCreateationDate = e.ProjectionCreateationDate,
                        ProjectCompletionDate = e.ProjectCompletionDate,
                        TechnicianNotes = e.TechnicianNotes,
                        PropertyID = e.PropertyID,
                        TechnicianID = e.TechnicianID
                    });
                return query.ToArray();
            }
        }

        //Get Project By ID
        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Project
                        .Single(e => e.ProjectID == id);
                return
                    new ProjectDetail
                    {
                        ProjectID = entity.ProjectID,
                        ProjectName = entity.ProjectName,
                        ProjectTask = entity.ProjectTask,
                        Description = entity.Description,
                        SuppliesNeeded = entity.SuppliesNeeded,
                        Instructions = entity.Instructions,
                        EstimatedTime = entity.EstimatedTime,
                        ProjectionCreateationDate = entity.ProjectionCreateationDate,
                        ProjectCompletionDate = entity.ProjectCompletionDate,
                        TechnicianNotes = entity.TechnicianNotes,
                        PropertyID = entity.PropertyID,
                        TechnicianID = entity.TechnicianID
                    };
            }
        }

        //Edit Project
        public bool UpdateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Project
                    .Single(e => e.ProjectID == model.ProjectID);

                entity.ProjectName = model.ProjectName;
                entity.ProjectTask = model.ProjectTask;
                entity.Description = model.Description;
                entity.SuppliesNeeded = model.SuppliesNeeded;
                entity.Instructions = model.Instructions;
                entity.EstimatedTime = model.EstimatedTime;
                entity.ProjectCompletionDate = model.ProjectCompletionDate;
                entity.TechnicianNotes = model.TechnicianNotes;
                entity.PropertyID = model.PropertyID;
                entity.TechnicianID = model.TechnicianID;

                return ctx.SaveChanges() == 1;
            }
        }

        //Archive Projects
        public bool ArchiveProject(ProjectArchive model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Project
                    .Single(e => e.ProjectID == model.ProjectID);

                entity.ProjectCompletionDate = model.ProjectCompletionDate;

                return ctx.SaveChanges() == 1;
            }
        }

        //Get All Active Projects
        public IEnumerable<ProjectListItem> GetActiveProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Project
                    .Where(e => e.ProjectCompletionDate == null)
                    .Select(
                       e =>
                       new ProjectListItem
                       {
                           ProjectID = e.ProjectID,
                           ProjectName = e.ProjectName,
                           ProjectTask = e.ProjectTask,
                           Description = e.Description,
                           SuppliesNeeded = e.SuppliesNeeded,
                           Instructions = e.Instructions,
                           EstimatedTime = e.EstimatedTime,
                           ProjectionCreateationDate = e.ProjectionCreateationDate,
                           ProjectCompletionDate = e.ProjectCompletionDate,
                           TechnicianNotes = e.TechnicianNotes,
                           PropertyID = e.PropertyID,
                           TechnicianID = e.TechnicianID
                       }
                    );
                return query.ToArray();
            }
        }

        //Get All Completed Projects
        public IEnumerable<ProjectListItem> GetAllCompletedProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Project
                    .Where(e => e.ProjectCompletionDate != null)
                    .Select(
                       e =>
                       new ProjectListItem
                       {
                           ProjectID = e.ProjectID,
                           ProjectName = e.ProjectName,
                           ProjectTask = e.ProjectTask,
                           Description = e.Description,
                           SuppliesNeeded = e.SuppliesNeeded,
                           Instructions = e.Instructions,
                           EstimatedTime = e.EstimatedTime,
                           ProjectionCreateationDate = e.ProjectionCreateationDate,
                           ProjectCompletionDate = e.ProjectCompletionDate,
                           TechnicianNotes = e.TechnicianNotes,
                           PropertyID = e.PropertyID,
                           TechnicianID = e.TechnicianID
                       }
                    );
                return query.ToArray();
            }
        }

        

        
    }
}
