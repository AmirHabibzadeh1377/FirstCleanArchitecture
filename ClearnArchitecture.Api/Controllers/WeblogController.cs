using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Features.Requests.Weblog.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClearnArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeblogController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public WeblogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        // GET: api/<WeblogController>
        [HttpGet]
        public async Task<ActionResult<List<WeblogListDTOs>>> Get()
        {
            var weblogListDTOs = await _mediator.Send(new GetWeblogListRequest());
            return Ok(weblogListDTOs);
        }

        // GET api/<WeblogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeblogListDTOs>> Get(int id)
        {
            var weblogListDtos = await _mediator.Send(new GetWeblogRequest { WeblogId  = id});
            return Ok(weblogListDtos);
        }

        // POST api/<WeblogController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateWeblogDTOs model)
        {
            var createCommand = new CreateWeblogRequest { CreateWeblogDTOs = model };
            var response = await _mediator.Send(new CreateWeblogRequest { CreateWeblogDTOs = model });
            return Ok(response);
        }

        // PUT api/<WeblogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateWeblogDTOs model)
        {
            var updateCommand = new UpdateWeblogRequest { UpdateWeblogDTOs = model };
            var response = await _mediator.Send(updateCommand);
            return NoContent();
        }

        // DELETE api/<WeblogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteWeblogCommandRequest { WeblogId= id };
            var response = await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}