using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using PrivateHospital.DAL.Repositories;
using PrivateHospital.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class ServiceController : Controller
    {
        private readonly PrivateHospitalContext context = new PrivateHospitalContext();
        private readonly IServiceRepository serviceRepository;

        public ServiceController()
        {
            serviceRepository = new ServiceRepository(context);
        }

        public ActionResult Index()
        {
            IList<ServiceModel> model = new List<ServiceModel>();

            foreach (var item in serviceRepository.GetAll())
            {
                model.Add(
                    new ServiceModel
                    {
                        Id = item.Id,
                        NameService = item.NameService,
                        Description = item.Description,
                        Cost = item.Cost,
                        Discount = item.Discount
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            ServiceModel model = new ServiceModel();

            var service = serviceRepository.GetById(id);
            model.Id = service.Id;
            model.NameService = service.NameService;
            model.Description = service.Description;
            model.Cost = service.Cost;
            model.Discount = service.Discount;

            return View("DetailsService", model);
        }

        public ActionResult Add()
        {
            return View("AddService");
        }

        [HttpPost]
        public ActionResult Add(ServiceModel service)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddService", service);
                }
                var model = new Service();
                model.NameService = service.NameService;
                model.Description = service.Description;
                model.Cost = service.Cost;
                model.Discount = service.Discount;
                serviceRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ServiceModel model = new ServiceModel();

            var service = serviceRepository.GetById(id);
            model.Id = service.Id;
            model.NameService = service.NameService;
            model.Description = service.Description;
            model.Cost = service.Cost;
            model.Discount = service.Discount;

            return View("EditService", model);
        }

        [HttpPost]
        public ActionResult Edit(ServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditService", model);
                }
                var service = serviceRepository.GetById(model.Id);
                service.Id = model.Id;
                service.NameService = model.NameService;
                service.Description = model.Description;
                service.Cost = model.Cost;
                service.Discount = model.Discount;
                serviceRepository.Update(service);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            serviceRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}