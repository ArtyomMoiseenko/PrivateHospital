using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using PrivateHospital.DAL.Repositories;
using PrivateHospital.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly PrivateHospitalContext context = new PrivateHospitalContext();
        private readonly IDoctorRepository doctorRepository;
        private readonly ISpecializationRepository specializationRepository;

        public DoctorController()
        {
            doctorRepository = new DoctorRepository(context);
            specializationRepository = new SpecializationRepository(context);
        }

        public ActionResult Index()
        {
            IList<DoctorModel> model = new List<DoctorModel>();

            foreach (var item in doctorRepository.GetAll())
            {
                model.Add(
                    new DoctorModel
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        MiddleName = item.MiddleName,
                        Birthday = item.Birthday,
                        Phone = item.Phone,
                        StartDateOfWork = item.StartDateOfWork,
                        SpecializationId = item.SpecializationId,
                        Specializations = specializationRepository.GetAll()
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            DoctorModel model = new DoctorModel();

            var doctor = doctorRepository.GetById(id);
            model.Id = doctor.Id;
            model.FirstName = doctor.FirstName;
            model.LastName = doctor.LastName;
            model.MiddleName = doctor.MiddleName;
            model.Birthday = doctor.Birthday;
            model.Phone = doctor.Phone;
            model.StartDateOfWork = doctor.StartDateOfWork;
            model.SpecializationId = doctor.SpecializationId;
            model.Specializations = specializationRepository.GetAll();

            return View("DetailsDoctor", model);
        }

        public ActionResult Add()
        {
            DoctorModel model = new DoctorModel();
            model.Specializations = specializationRepository.GetAll();
            return View("AddDoctor", model);
        }

        [HttpPost]
        public ActionResult Add(DoctorModel doctor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddDoctor", doctor);
                }
                var model = new Doctor();
                model.FirstName = doctor.FirstName;
                model.LastName = doctor.LastName;
                model.MiddleName = doctor.MiddleName;
                model.Birthday = doctor.Birthday;
                model.Phone = doctor.Phone;
                model.StartDateOfWork = doctor.StartDateOfWork;
                model.SpecializationId = doctor.SpecializationId;
                doctorRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            DoctorModel model = new DoctorModel();
            var doctor = doctorRepository.GetById(id);
            model.Id = doctor.Id;
            model.FirstName = doctor.FirstName;
            model.LastName = doctor.LastName;
            model.MiddleName = doctor.MiddleName;
            model.Birthday = doctor.Birthday;
            model.Phone = doctor.Phone;
            model.StartDateOfWork = doctor.StartDateOfWork;
            model.SpecializationId = doctor.SpecializationId;
            model.Specializations = specializationRepository.GetAll();

            return View("EditDoctor", model);
        }

        [HttpPost]
        public ActionResult Edit(DoctorModel doctor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditDoctor", doctor);
                }
                var model = doctorRepository.GetById(doctor.Id);
                model.Id = doctor.Id;
                model.FirstName = doctor.FirstName;
                model.LastName = doctor.LastName;
                model.MiddleName = doctor.MiddleName;
                model.Birthday = doctor.Birthday;
                model.Phone = doctor.Phone;
                model.StartDateOfWork = doctor.StartDateOfWork;
                model.SpecializationId = doctor.SpecializationId;
                doctorRepository.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            doctorRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}