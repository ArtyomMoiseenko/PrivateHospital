using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using PrivateHospital.DAL.Repositories;
using PrivateHospital.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly PrivateHospitalContext context = new PrivateHospitalContext();
        private readonly ISpecializationRepository specializationRepository;

        public SpecializationController()
        {
            specializationRepository = new SpecializationRepository(context);
        }

        public ActionResult Index()
        {
            IList<SpecializationModel> model = new List<SpecializationModel>();

            foreach (var item in specializationRepository.GetAll())
            {
                model.Add(
                    new SpecializationModel
                    {
                        Id = item.Id,
                        NameSpecialization = item.NameSpecialization,
                        Description = item.Description,
                        PrimaryCost = item.PrimaryCost,
                        SecondaryCost = item.SecondaryCost
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            SpecializationModel model = new SpecializationModel();

            var specialization = specializationRepository.GetById(id);
            model.Id = specialization.Id;
            model.NameSpecialization = specialization.NameSpecialization;
            model.Description = specialization.Description;
            model.PrimaryCost = specialization.PrimaryCost;
            model.SecondaryCost = specialization.SecondaryCost;

            return View("DetailsSpecialization", model);
        }

        public ActionResult Add()
        {
            return View("AddSpecialization");
        }

        [HttpPost]
        public ActionResult Add(SpecializationModel specialization)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddSpecialization", specialization);
                }
                var model = new Specialization();
                model.Id = specialization.Id;
                model.NameSpecialization = specialization.NameSpecialization;
                model.Description = specialization.Description;
                model.PrimaryCost = specialization.PrimaryCost;
                model.SecondaryCost = specialization.SecondaryCost;
                specializationRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            SpecializationModel model = new SpecializationModel();

            var specialization = specializationRepository.GetById(id);
            model.Id = specialization.Id;
            model.NameSpecialization = specialization.NameSpecialization;
            model.Description = specialization.Description;
            model.PrimaryCost = specialization.PrimaryCost;
            model.SecondaryCost = specialization.SecondaryCost;

            return View("EditSpecialization", model);
        }

        [HttpPost]
        public ActionResult Edit(SpecializationModel specialization)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditSpecialization", specialization);
                }
                var model = specializationRepository.GetById(specialization.Id);
                model.Id = specialization.Id;
                model.NameSpecialization = specialization.NameSpecialization;
                model.Description = specialization.Description;
                model.PrimaryCost = specialization.PrimaryCost;
                model.SecondaryCost = specialization.SecondaryCost;
                specializationRepository.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            specializationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}