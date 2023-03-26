using Microsoft.AspNetCore.Mvc;
using Scheduler.Services;
using Scheduler.Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IPlansManagementService plansManagementService;

        public PlansController(IPlansManagementService plansManagementService)
        {
            this.plansManagementService = plansManagementService;
        }

        // GET: api/<PlansController>
        [HttpGet]
        public IEnumerable<Plan> Get()
        {
            return this.plansManagementService.GetPlans(0, int.MaxValue);
        }

        // GET api/<PlansController>/5
        [HttpGet("{id}")]
        public Plan Get(int id)
        {
            return this.plansManagementService.GetPlan(id);
        }

        // POST api/<PlansController>
        [HttpPost]
        public void Post([FromBody] Plan plan)
        {
            this.plansManagementService.AddPlan(plan);
        }

        // PUT api/<PlansController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Plan plan)
        {
            this.plansManagementService.UpdatePlan(id, plan);
        }

        // DELETE api/<PlansController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.plansManagementService.DeletePlan(id);
        }
    }
}
