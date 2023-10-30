using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkLogic.Common.InputOutput;
using ThinkLogic.Common.Models;
using ThinkLogic.Domain.Interfaces.Business;

namespace ThinkLogic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledEventController : ControllerBase
    {
        private readonly IBusiness<ScheduledEvent> _business;

        public ScheduledEventController(IBusiness<ScheduledEvent> business)
        {
            _business = business;
        }

        [HttpPost]
        [Produces(typeof(TLResponse<int>))]
        public IActionResult Insert(ScheduledEvent model)
        {
            /// Since we are encapsulating everything in a response class, we don't need to follow the Http Stand, but we can, in this demo i'll not follow.
            return Ok(_business.Insert(model));
        }

        [HttpPut]
        [Produces(typeof(TLResponse<int>))]
        public IActionResult Update(ScheduledEvent model)
        {
            return Ok(_business.Update(model));
        }

        [HttpDelete]
        [Produces(typeof(TLResponse<int>))]
        public IActionResult Delete(int id)
        {
            return Ok(_business.Delete(id));
        }

        [HttpGet("id")]
        [Produces(typeof(TLResponse<ScheduledEvent>))]
        public IActionResult Get(int id)
        {
            return Ok(_business.GetById(id));
        }

        [HttpPost("ByRequest")]
        [Produces(typeof(TLListResponse<ScheduledEvent>))]
        public IActionResult GetByRequest(TLRequest<ScheduledEvent> request) 
        {
           return Ok(_business.GetByRequest(request));
        }
    }
}
