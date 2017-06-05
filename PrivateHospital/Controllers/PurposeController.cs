using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using PrivateHospital.DAL.Repositories;
using PrivateHospital.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class PurposeController : Controller
    {
        private readonly PrivateHospitalContext context = new PrivateHospitalContext();
        private readonly IPurposeRepository purposeRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IClientRepository clientRepository;

        public PurposeController()
        {
            purposeRepository = new PurposeRepository(context);
            serviceRepository = new ServiceRepository(context);
            doctorRepository = new DoctorRepository(context);
            clientRepository = new ClientRepository(context);
        }

        public ActionResult Index()
        {
            IList<PurposeModel> model = new List<PurposeModel>();

            foreach (var item in purposeRepository.GetAll())
            {
                model.Add(
                    new PurposeModel
                    {
                        Id = item.Id,
                        DatePurposeService = item.DatePurposeService,
                        DatePerformService = item.DatePerformService,
                        PaymentState = item.PaymentState,
                        ClientId = item.ClientId,
                        DoctorPerformId = item.DoctorPerformId,
                        DoctorPurposeId = item.DoctorPurposeId,
                        ServiceId = item.ServiceId,
                        Clients = clientRepository.GetAll(),
                        Doctors = doctorRepository.GetAll(),
                        Services = serviceRepository.GetAll()
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            PurposeModel model = new PurposeModel();

            var purpose = purposeRepository.GetById(id);
            model.Id = purpose.Id;
            model.DatePurposeService = purpose.DatePurposeService;
            model.DatePerformService = purpose.DatePerformService;
            model.PaymentState = purpose.PaymentState;
            model.ClientId = purpose.ClientId;
            model.DoctorPerformId = purpose.DoctorPerformId;
            model.DoctorPurposeId = purpose.DoctorPurposeId;
            model.ServiceId = purpose.ServiceId;
            model.Clients = clientRepository.GetAll();
            model.Doctors = doctorRepository.GetAll();
            model.Services = serviceRepository.GetAll();
            model.Receipt = purposeRepository.GetReceipt(purpose.Id);

            return View("DetailsPurpose", model);
        }

        public ActionResult Add()
        {
            PurposeModel model = new PurposeModel();
            model.Clients = clientRepository.GetAll();
            model.Doctors = doctorRepository.GetAll();
            model.Services = serviceRepository.GetAll();
            return View("AddPurpose", model);
        }

        [HttpPost]
        public ActionResult Add(PurposeModel purpose)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddPurpose", purpose);
                }
                var model = new Purpose();
                model.DatePurposeService = purpose.DatePurposeService;
                model.DatePerformService = purpose.DatePerformService;
                model.PaymentState = purpose.PaymentState;
                model.ServiceId = purpose.ServiceId;
                model.DoctorPurposeId = purpose.DoctorPurposeId;
                model.DoctorPerformId = purpose.DoctorPerformId;
                model.Client = clientRepository.GetById(purpose.ClientId);
                model.DoctorPurpose = doctorRepository.GetById(purpose.DoctorPurposeId);
                model.DoctorAssign = doctorRepository.GetById(purpose.DoctorPerformId);
                model.Service = serviceRepository.GetById(purpose.ServiceId);
                purposeRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            PurposeModel model = new PurposeModel();
            var purpose = purposeRepository.GetById(id);
            model.Id = purpose.Id;
            model.DatePurposeService = purpose.DatePurposeService;
            model.DatePerformService = purpose.DatePerformService;
            model.PaymentState = purpose.PaymentState;
            model.ServiceId = purpose.ServiceId;
            model.DoctorPurposeId = purpose.DoctorPurposeId;
            model.DoctorPerformId = purpose.DoctorPerformId;
            model.Clients = clientRepository.GetAll();
            model.Doctors = doctorRepository.GetAll();
            model.Services = serviceRepository.GetAll();

            return View("EditPurpose", model);
        }

        [HttpPost]
        public ActionResult Edit(PurposeModel purpose)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditPurpose", purpose);
                }
                var model = purposeRepository.GetById(purpose.Id);
                model.Id = purpose.Id;
                model.DatePurposeService = purpose.DatePurposeService;
                model.DatePerformService = purpose.DatePerformService;
                model.PaymentState = purpose.PaymentState;
                model.ClientId = purpose.ClientId;
                model.ServiceId = purpose.ServiceId;
                model.DoctorPurposeId = purpose.DoctorPurposeId;
                model.DoctorPerformId = purpose.DoctorPerformId;
                model.Client = clientRepository.GetById(purpose.ClientId);
                model.DoctorPurpose = doctorRepository.GetById(purpose.DoctorPurposeId);
                model.DoctorAssign = doctorRepository.GetById(purpose.DoctorPerformId);
                model.Service = serviceRepository.GetById(purpose.ServiceId);
                purposeRepository.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            purposeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}