using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Patients.Api.Models;
using System.Collections.Generic;

namespace Patients.Api.App_Start
{
    public class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientsDbContext.Open();
            var exists = patients.AsQueryable().Where(p => p.Name == "Scott").Any();

            if (!exists)
            {
                var newPatients = new List<Patient>()
                {
                    new Patient
                    {
                        Name = "Allan",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Crazy Ailment 1 "} },
                        Medications = new List<Medication> { new Medication { Name = "Crazy Medicament 1", Doses = 1 } }
                    },
                    new Patient
                    {
                        Name = "Scott",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Crazy Ailment 2"} },
                        Medications = new List<Medication> { new Medication { Name = "Crazy Medicament 2", Doses = 1 } }
                    },
                    new Patient
                    {
                        Name = "Allen",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Crazy Ailment 3"} },
                        Medications = new List<Medication> { new Medication { Name = "Crazy Medicament 3", Doses = 1 } }
                    }
                };

                patients.InsertMany(newPatients);
            }
        }
    }
}