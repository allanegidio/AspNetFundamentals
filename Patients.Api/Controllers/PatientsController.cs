using MongoDB.Bson;
using MongoDB.Driver;
using Patients.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Patients.Api.Controllers
{
    [Authorize]
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientsDbContext.Open();
        }

        public IEnumerable<Patient> Get()
        {
            var filter = new BsonDocument();
            return _patients.Find(filter).ToEnumerable();
        }

        //public async Task<HttpResponseMessage> Get(string id)
        public async Task<IHttpActionResult> Get(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("Id", id);
            var patient = await _patients.FindSync(filter).FirstAsync();

            if (patient == null)
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found.");
                return NotFound();

            return Ok(patient); //Request.CreateResponse(patient);
        }

        [Route("api/patients/{id}/medications")] 
        public async Task<IHttpActionResult> GetMedications(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("Id", id);
            var patient = await _patients.FindSync(filter).FirstAsync();

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }
    }
}
