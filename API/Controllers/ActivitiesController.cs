using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domains;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ActivitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List()
        {
            return await this.mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Get(Guid id)
        {
            return await this.mediator.Send(new Details.Query{ ActivityId = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await this.mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.ActivityId = id;
            return await this.mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await this.mediator.Send(new Delete.Command{ ActivityId = id});
        }
    }
}