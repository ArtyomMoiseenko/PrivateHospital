using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using PrivateHospital.DAL.Repositories;
using PrivateHospital.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class ClientController : Controller
    {
        private readonly PrivateHospitalContext context = new PrivateHospitalContext();
        private readonly IClientRepository clientRepository;

        public ClientController()
        {
            clientRepository = new ClientRepository(context);
        }

        public ActionResult Index()
        {
            IList<ClientModel> model = new List<ClientModel>();

            foreach (var item in clientRepository.GetAll())
            {
                model.Add(
                    new ClientModel
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        MiddleName = item.MiddleName,
                        Address = item.Address,
                        Birthday = item.Birthday,
                        Phone = item.Phone,
                        Discount = item.Discount,
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            ClientModel model = new ClientModel();

            var modelClient = clientRepository.GetById(id);
            model.Id = modelClient.Id;
            model.FirstName = modelClient.FirstName;
            model.LastName = modelClient.LastName;
            model.MiddleName = modelClient.MiddleName;
            model.Address = modelClient.Address;
            model.Birthday = modelClient.Birthday;
            model.Phone = modelClient.Phone;
            model.Discount = modelClient.Discount;
            model.SumAllMoney = clientRepository.GetSumAllMoney(modelClient.Id);

            return View("DetailsClient", model);
        }

        public ActionResult Add()
        {
            return View("AddClient");
        }

        [HttpPost]
        public ActionResult Add(ClientModel client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddClient", client);
                }
                var model = new Client();
                model.LastName = client.LastName;
                model.FirstName = client.FirstName;
                model.MiddleName = client.MiddleName;
                model.Address = client.Address;
                model.Birthday = client.Birthday;
                model.Phone = client.Phone;
                model.Discount = client.Discount;
                clientRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ClientModel model = new ClientModel();

            var modelClient = clientRepository.GetById(id);
            model.Id = modelClient.Id;
            model.FirstName = modelClient.FirstName;
            model.LastName = modelClient.LastName;
            model.MiddleName = modelClient.MiddleName;
            model.Address = modelClient.Address;
            model.Birthday = modelClient.Birthday;
            model.Phone = modelClient.Phone;
            model.Discount = modelClient.Discount;

            return View("EditClient", model);
        }

        [HttpPost]
        public ActionResult Edit(ClientModel clientUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditClient", clientUpdate);
                }
                var client = clientRepository.GetById(clientUpdate.Id);
                client.LastName = clientUpdate.LastName;
                client.FirstName = clientUpdate.FirstName;
                client.MiddleName = clientUpdate.MiddleName;
                client.Address = clientUpdate.Address;
                client.Birthday = clientUpdate.Birthday;
                client.Phone = clientUpdate.Phone;
                client.Discount = clientUpdate.Discount;
                clientRepository.Update(client);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            clientRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
