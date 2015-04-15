using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace HAMS.Controllers
{
    [RoutePrefix("admin/jobs")]
    public class AdminJobsController : ApiController
    {
        // POST: admin/jobs
        [Route("")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostJobs()
        {
            // Retrieve data from NEST API
            HAMS.Devices.Nest.PushThings();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
