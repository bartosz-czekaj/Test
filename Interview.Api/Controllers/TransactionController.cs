using Interview.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private iTransaction dataAccess;

        public TransactionController(iTransaction transactionService)
        {
            dataAccess = transactionService;
        }

        // GET api/<controller>
        [HttpGet(Name = "GetTransaction")]
        public Interview.DataModel.Transaction Get(string id)
        {
            var guid = new Guid(id);
            return dataAccess.Retrieve(guid);
        }

        // POST api/<controller>
        [HttpPost(Name = "PostTransaction")]
        public void Post([FromBody] Interview.DataModel.Transaction record)
        {
            dataAccess.Create(record);
        }

        // PUT api/<controller>
        [HttpPut(Name = "PutTransaction")]
        public void Put([FromBody] Interview.DataModel.Transaction record)
        {
            dataAccess.Update(record);
        }

        // DELETE api/<controller>
        [HttpDelete(Name = "DeleteTransaction")]
        public void Delete(string id)
        {
            var guid = new Guid(id);
            dataAccess.Delete(guid);
        }
    }
}
