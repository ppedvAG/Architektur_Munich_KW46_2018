using Newtonsoft.Json;
using ppedv.Zeus.Logic;
using ppedv.Zeus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.Zeus.UI.Web.Controllers
{
    public class DruckerAPIController : ApiController
    {

        Core core = new Core();

        // GET: api/DruckerAPI
        public IEnumerable<Drucker> Get()
        {
            return core.Repository.GetAll<Drucker>();
        }

        // GET: api/DruckerAPI/5
        public Drucker Get(int id)
        {
            return core.Repository.GetById<Drucker>(id);
        }

        // POST: api/DruckerAPI
        public void Post([FromBody]Drucker drucker)
        {
            core.Repository.Add(drucker);
            core.Repository.Save();
        }

        // PUT: api/DruckerAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DruckerAPI/5
        public void Delete(int id)
        {
        }
    }
}
