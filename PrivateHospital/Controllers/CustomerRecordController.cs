using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using PrivateHospital.DAL.Repositories;
using PrivateHospital.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class CustomerRecordController : Controller
    {
        private readonly PrivateHospitalContext context = new PrivateHospitalContext();
        private readonly ICustomerRecordRepository customerRecordRepository;
        private readonly IClientRepository clientRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly ISpecializationRepository specializationRepository;

        public CustomerRecordController()
        {
            customerRecordRepository = new CustomerRecordRepository(context);
            doctorRepository = new DoctorRepository(context);
            clientRepository = new ClientRepository(context);
            specializationRepository = new SpecializationRepository(context);
        }

        public ActionResult Index()
        {
            IList<CustomerRecordModel> model = new List<CustomerRecordModel>();

            foreach (var item in customerRecordRepository.GetAll())
            {
                model.Add(
                    new CustomerRecordModel
                    {
                        Id = item.Id,
                        DateAndTimeOfRecord = item.DateAndTimeOfRecord,
                        Status = item.Status,
                        PaymentState = item.PaymentState,
                        ClientId = item.ClientId,
                        DoctorId = item.DoctorId,
                        Type = item.Type,
                        Cost = item.Cost,
                        Clients = clientRepository.GetAll(),
                        Doctors = doctorRepository.GetAll()
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            CustomerRecordModel model = new CustomerRecordModel();

            var customerRecord = customerRecordRepository.GetById(id);
            model.Id = customerRecord.Id;
            model.DateAndTimeOfRecord = customerRecord.DateAndTimeOfRecord;
            model.Status = customerRecord.Status;
            model.PaymentState = customerRecord.PaymentState;
            model.ClientId = customerRecord.ClientId;
            model.DoctorId = customerRecord.DoctorId;
            model.Type = customerRecord.Type;
            model.Cost = customerRecord.Cost;
            model.Clients = clientRepository.GetAll();
            model.Doctors = doctorRepository.GetAll();
            model.Consultation = customerRecordRepository.GetReceipt(customerRecord.Id);

            return View("DetailsCustomerRecord", model);
        }

        public ActionResult Add()
        {
            CustomerRecordModel model = new CustomerRecordModel();
            model.Clients = clientRepository.GetAll();
            model.Doctors = doctorRepository.GetAll();

            return View("AddCustomerRecord", model);
        }

        [HttpPost]
        public ActionResult Add(CustomerRecordModel customerRecord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddCustomerRecord", customerRecord);
                }
                var model = new CustomerRecord();
                model.Id = customerRecord.Id;
                model.DateAndTimeOfRecord = customerRecord.DateAndTimeOfRecord;
                model.Status = customerRecord.Status;
                model.PaymentState = customerRecord.PaymentState;
                model.ClientId = customerRecord.ClientId;
                model.DoctorId = customerRecord.DoctorId;
                model.Type = customerRecord.Type;
                if(customerRecord.Type == customerRecord.VisitType[0])
                {
                    model.Cost = specializationRepository.GetById(doctorRepository.GetById(customerRecord.DoctorId).SpecializationId).PrimaryCost;
                }
                else
                {
                    model.Cost = specializationRepository.GetById(doctorRepository.GetById(customerRecord.DoctorId).SpecializationId).SecondaryCost;
                }
                model.Client = clientRepository.GetById(customerRecord.ClientId);
                model.Doctor = doctorRepository.GetById(customerRecord.DoctorId);
                customerRecordRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            CustomerRecordModel model = new CustomerRecordModel();
            var customerRecord = customerRecordRepository.GetById(id);
            model.Id = customerRecord.Id;
            model.DateAndTimeOfRecord = customerRecord.DateAndTimeOfRecord;
            model.Status = customerRecord.Status;
            model.PaymentState = customerRecord.PaymentState;
            model.ClientId = customerRecord.ClientId;
            model.DoctorId = customerRecord.DoctorId;
            model.Type = customerRecord.Type;
            model.Clients = clientRepository.GetAll();
            model.Doctors = doctorRepository.GetAll();

            return View("EditCustomerRecord", model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerRecordModel customerRecord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditCustomerRecord", customerRecord);
                }
                var model = customerRecordRepository.GetById(customerRecord.Id);
                model.Id = customerRecord.Id;
                model.DateAndTimeOfRecord = customerRecord.DateAndTimeOfRecord;
                model.Status = customerRecord.Status;
                model.PaymentState = customerRecord.PaymentState;
                model.ClientId = customerRecord.ClientId;
                model.DoctorId = customerRecord.DoctorId;
                model.Type = customerRecord.Type;
                if (customerRecord.Type == customerRecord.VisitType[0])
                {
                    model.Cost = specializationRepository.GetById(doctorRepository.GetById(customerRecord.DoctorId).SpecializationId).PrimaryCost;
                }
                else
                {
                    model.Cost = specializationRepository.GetById(doctorRepository.GetById(customerRecord.DoctorId).SpecializationId).SecondaryCost;
                }
                model.Client = clientRepository.GetById(customerRecord.ClientId);
                model.Doctor = doctorRepository.GetById(customerRecord.DoctorId);
                customerRecordRepository.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            customerRecordRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}