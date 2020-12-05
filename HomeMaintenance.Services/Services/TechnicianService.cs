using HomeMaintenance.Data;
using HomeMaintenance.Data.DataClasses;
using HomeMaintenance.Models.Project;
using HomeMaintenance.Models.Technician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Services.Services
{
    public class TechnicianService
    {
        private readonly Guid _userId;

        public TechnicianService(Guid userId)
        {
            _userId = userId;
        }

        // Create Technician
        public bool CreateTechnician(TechnicianCreate model)
        {
            var entity =
                new Technician()
                {
                    TechnicianName = model.TechnicianName,
                    TechnicianPhoneNumber = model.TechnicianPhoneNumber,
                    TechnicianEmail = model.TechnicianEmail
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Technician.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All Technicians
        public IEnumerable<TechnicianListItem> GetTechnician()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Technician
                    .Select(
                    e =>
                    new TechnicianListItem
                    {
                        TechnicianID = e.TechnicianID,
                        TechnicianName = e.TechnicianName,
                        TechnicianPhoneNumber = e.TechnicianPhoneNumber,
                        TechnicianEmail = e.TechnicianEmail
                    });
                return query.ToArray();
            }
        }

        public IEnumerable<Technician> GetTechnicians()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Technician.ToList();
            }
        }

        public TechnicianDetail GetTechnicianById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Technician
                        .Single(e => e.TechnicianID == id);
                return
                    new TechnicianDetail
                    {
                        TechnicianID = entity.TechnicianID,
                        TechnicianName = entity.TechnicianName,
                        TechnicianPhoneNumber = entity.TechnicianPhoneNumber,
                        TechnicianEmail = entity.TechnicianEmail
                    };
            }
        }

        public bool UpdateTechnician(TechnicianEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Technician
                    .Single(e => e.TechnicianID == model.TechnicianID);

                entity.TechnicianID = model.TechnicianID;
                entity.TechnicianName = model.TechnicianName;
                entity.TechnicianPhoneNumber = model.TechnicianPhoneNumber;
                entity.TechnicianEmail = model.TechnicianEmail;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Technician
        public bool DeleteTechnician(int technicianId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Technician
                        .Single(e => e.TechnicianID == technicianId);

                ctx.Technician.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        // Get Active Projects By Technician
        public IEnumerable<ProjectListItem> GetProjectsByTechnician(int technicianId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Project
                    .Where(e => e.TechnicianID == technicianId && e.ProjectCompletionDate == null)
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

        // Get Completed Projects By Technician
        public IEnumerable<ProjectListItem> GetCompletedProjectsByTechnician(int technicianId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Project
                    .Where(e => e.TechnicianID == technicianId && e.ProjectCompletionDate != null)
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
    }
}
