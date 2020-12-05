using HomeMaintenance.Data.DataClasses;
using HomeMaintenance.Models.Project;
using HomeMaintenance.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMaintenanceWebAPI.Controllers.CustomControllers
{
    public class ProjectController : Controller
    {
        // GET Project
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            var model = service.GetActiveProjects();

            return View(model);
        }

        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            List<Property> Properties = (new PropertyService(userId)).GetProperties().ToList();
            List<Technician> Technicians = (new TechnicianService(userId)).GetTechnicians().ToList();
            var queryA = from o in Technicians
                        select new SelectListItem()
                        {
                            Value = o.TechnicianID.ToString(),
                            Text = o.TechnicianName
                        };
            ViewBag.TechnicianID = queryA.ToList();

            var queryB = from o in Properties
                         select new SelectListItem()
                         {
                             Value = o.PropertyID.ToString(),
                             Text = o.PropertyAddress
                         };
            ViewBag.PropertyID = queryB.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Project was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be created.");

            return View(model);
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        public ActionResult GetCompletedProject()
        {
            var svc = CreateProjectService();
            var model = svc.GetAllCompletedProjects();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);

            var userId = Guid.Parse(User.Identity.GetUserId());

            List<Property> Properties = (new PropertyService(userId)).GetProperties().ToList();
            List<Technician> Technicians = (new TechnicianService(userId)).GetTechnicians().ToList();
            var queryA = from o in Technicians
                        select new SelectListItem()
                        {
                            Value = o.TechnicianID.ToString(),
                            Text = o.TechnicianName
                        };
            ViewBag.TechnicianID = queryA.ToList();

            var queryB = from o in Properties
                         select new SelectListItem()
                         {
                             Value = o.PropertyID.ToString(),
                             Text = o.PropertyAddress
                         };
            ViewBag.PropertyID = queryB.ToList();

            var model =
                new ProjectEdit
                {
                    ProjectID = detail.ProjectID,
                    ProjectName = detail.ProjectName,
                    ProjectTask = detail.ProjectTask,
                    Description = detail.Description,
                    SuppliesNeeded = detail.SuppliesNeeded,
                    Instructions = detail.Instructions,
                    EstimatedTime = detail.EstimatedTime,
                    ProjectCompletionDate = detail.ProjectCompletionDate,
                    TechnicianNotes = detail.TechnicianNotes,
                    PropertyID = detail.PropertyID,
                    TechnicianID = detail.TechnicianID
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Project updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Project could not be updated.");
            return View(model);
        }

        public ActionResult Archive(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectCompletionDate = detail.ProjectCompletionDate,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Archive(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Project Archived.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Project could not be archived.");
            return View(model);
        }
    }
}