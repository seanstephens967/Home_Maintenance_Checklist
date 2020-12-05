using HomeMaintenance.Data;
using HomeMaintenance.Data.DataClasses;
using HomeMaintenance.Models.Property;
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
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            var model = service.GetProperty();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            PropertyService service = CreatePropertyService();

            if (service.CreateProperty(model))
            {
                TempData["SaveResult"] = "Property has been created.";
                return RedirectToAction("Index");
            };
            return View(model);


        }

        private PropertyService CreatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        public ActionResult GetPropertyById(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        public ActionResult GetActiveProjectByPropertyById(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetActiveProjectsByPropertyId(id);

            return View(model);
        }

        public ActionResult GetCompletedProjectByPropertyById(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetCompletedProjectsByPropertyId(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePropertyService();
            var detail = service.GetPropertyById(id);
            var model =
                new PropertyEdit
                {
                    PropertyID = detail.PropertyID,
                    PropertyOwnerFirstName = detail.PropertyOwnerFirstName,
                    PropertyOwnerLastName = detail.PropertyOwnerLastName,
                    PropertyAddress = detail.PropertyAddress,
                    PropertyPhone = detail.PropertyPhone,
                    PropertyOwnerEmail = detail.PropertyOwnerEmail
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePropertyService();

            if (service.UpdateProperty(model))
            {
                TempData["SaveResult"] = "Property has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Property could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePropertyService();

            service.DeleteProperty(id);

            TempData["SaveResult"] = "Property has been deleted";

            return RedirectToAction("Index");
        }
    }
}