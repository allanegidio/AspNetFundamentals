using MongoDB.Driver;

namespace Patients.Api.Models
{
    public class PatientsDbContext
    {
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("PatientsDb");
            return db.GetCollection<Patient>("Patients");
        }
    }
}