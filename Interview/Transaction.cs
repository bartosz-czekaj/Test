using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Interview
{
    public class Transaction : ApiController
    {
        private Interview.DAL.Retrieve.DataFile dataAccess => new Interview.DAL.Retrieve.DataFile();

        // GET api/<controller>
        public IEnumerable<Interview.DataModel.Transaction> Get()
        {
            return dataAccess.RetrieveAll();
        }

        // GET api/<controller>
        public Interview.DataModel.Transaction Get(string id)
        {
            var guid = new Guid(id);
            return dataAccess.Retrieve(guid);
        }

        // POST api/<controller>
        public void Post([FromBody] Interview.DataModel.Transaction record)
        {
            dataAccess.Create(record);
        }

        // PUT api/<controller>
        public void Put([FromBody] Interview.DataModel.Transaction record)
        {
            dataAccess.Update(record);
        }

        // DELETE api/<controller>
        public void Delete(string id)
        {
            var guid = new Guid(id);
            dataAccess.Delete(guid);
        }
    }
}