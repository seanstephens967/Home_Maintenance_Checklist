using HomeMaintenance.Models.Technician;
using HomeMaintenance.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMaintenanceWebAPI.Controllers.CustomControllers
{
    [Authorize]
    public class TechnicianController : Controller
    {
        // GET: Technician
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TechnicianService(userId);
            var model = service.GetTechnician();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TechnicianCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTechnicianService();

            if (service.CreateTechnician(model))
            {
                TempData["SaveResult"] = "Technician has been created.";
                return RedirectToAction("Index");
            };
            return View(model);


        }

        private TechnicianService CreateTechnicianService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TechnicianService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTechnicianService();
            var model = svc.GetTechnicianById(id);

            return View(model);
        }

        public ActionResult GetTechnicianById(int id)
        {
            var svc = CreateTechnicianService();
            var model = svc.GetTechnicianById(id);

            return View(model);
        }

        public ActionResult GetProjectByTechnicianId(int id)
        {
            var svc = CreateTechnicianService();
            var model = svc.GetProjectsByTechnician(id);

            return View(model);
        }

        public ActionResult GetCompletedProjectByTechnicianId(int id)
        {
            var svc = CreateTechnicianService();
            var model = svc.GetCompletedProjectsByTechnician(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTechnicianService();
            var detail = service.GetTechnicianById(id);
            var model =
                new TechnicianEdit
                {
                   TechnicianID = detail.TechnicianID,
                   TechnicianName = detail.TechnicianName,
                   TechnicianPhoneNumber = detail.TechnicianPhoneNumber,
                   TechnicianEmail = detail.TechnicianEmail
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TechnicianEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TechnicianID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTechnicianService();

            if (service.UpdateTechnician(model))
            {
                TempData["SaveResult"] = "Technician has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Technician could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTechnicianService();
            var model = svc.GetTechnicianById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTechnicianService();

            service.DeleteTechnician(id);

            TempData["SaveResult"] = "Technician has been deleted";

            return RedirectToAction("Index");
        }
    }
}