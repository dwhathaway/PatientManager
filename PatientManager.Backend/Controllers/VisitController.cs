using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PatientManager.Backend.DataObjects;
using PatientManager.Backend.Models;

namespace PatientManager.Backend.Controllers
{
    public class VisitController : TableController<Visit>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Visit>(context, Request);
        }

        // GET tables/Visit
        public IQueryable<Visit> GetAllVisit()
        {
            return Query(); 
        }

        // GET tables/Visit/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Visit> GetVisit(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Visit/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Visit> PatchVisit(string id, Delta<Visit> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Visit
        public async Task<IHttpActionResult> PostVisit(Visit item)
        {
            Visit current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Visit/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteVisit(string id)
        {
             return DeleteAsync(id);
        }
    }
}
