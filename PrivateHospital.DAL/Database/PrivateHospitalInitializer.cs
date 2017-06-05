using PrivateHospital.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrivateHospital
{
    public class PrivateHospitalInitializer : System.Data.Entity.CreateDatabaseIfNotExists<PrivateHospitalContext>
    {
        protected override void Seed(PrivateHospitalContext context)
        {
            var clientList = new List<Client>()
            {
                new Client(){ LastName = "Бардамид", FirstName = "Влад", MiddleName = "Юрьевич", Address = "Харьков", Birthday = DateTime.Today, Phone = 0993459595, Discount = 0 }
            };
            clientList.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var specializationList = new List<Specialization>()
            {
                new Specialization(){ NameSpecialization = "Хирургия", Description = "Описание хирургии", PrimaryCost = 200, SecondaryCost = 100 }
            };
            specializationList.ForEach(e => context.Specializations.Add(e));
            context.SaveChanges();

            var doctorList = new List<Doctor>()
            {
                new Doctor(){ LastName = "Селезнёв", FirstName = "Дмитрий", MiddleName = "Никифорович", Birthday = DateTime.Today, Phone = 0993459595, StartDateOfWork = DateTime.Now, SpecializationId = context.Specializations.FirstOrDefault().Id }
            };
            doctorList.ForEach(e => context.Doctors.Add(e));
            context.SaveChanges();

            var customerRecordList = new List<CustomerRecord>()
            {
                new CustomerRecord(){ PaymentState = "Оплачено", Status = "Выполнено", DateAndTimeOfRecord = DateTime.Now, ClientId = context.Clients.FirstOrDefault().Id,
                    DoctorId = context.Doctors.FirstOrDefault().Id,
                    Cost = context.Specializations.FirstOrDefault(item => item.Id == context.Doctors.FirstOrDefault().SpecializationId).PrimaryCost }
            };
            customerRecordList.ForEach(c => context.CustomerRecords.Add(c));
            context.SaveChanges();

            var serviceList = new List<Service>()
            {
                new Service(){ NameService = "УЗИ", Description = "Описание УЗИ", Cost = 500, Discount = 0 }
            };
            serviceList.ForEach(e => context.Services.Add(e));
            context.SaveChanges();

            var purposeList = new List<Purpose>()
            {
                new Purpose(){ DatePurposeService = DateTime.Now, DatePerformService = DateTime.Now, PaymentState = "Оплачено", ClientId = context.Clients.FirstOrDefault().Id,
                    DoctorPerformId = context.Doctors.FirstOrDefault().Id, DoctorPurposeId = context.Doctors.FirstOrDefault().Id, ServiceId = context.Services.FirstOrDefault().Id}
            };
            purposeList.ForEach(e => context.Purposes.Add(e));
            context.SaveChanges();
        }
    }
}