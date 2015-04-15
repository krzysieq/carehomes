using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace HAMS.Controllers
{
    [RoutePrefix("admin/activations")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminActivationsController : ApiController
    {
        // POST: admin/activations
        [Route("")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostActivation()
        {
            HV.Methods.CheckForValidatedConnections();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
