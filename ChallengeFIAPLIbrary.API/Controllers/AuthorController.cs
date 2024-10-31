using ChallengeFIAPLibrary.Application.Commands.AddAuthor;
using ChallengeFIAPLibrary.Application.Commands.UpdateAuthor;
using ChallengeFIAPLibrary.Application.Queries.GetAuthorById;
using ChallengeFIAPLibrary.Application.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeFIAPLIbrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        } 

        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAll(GetAllAuthorsQuery query)
        {
            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpGet("GetById")] 
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetAuthorByIdQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        //[HttpDelete("Delete")] 
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var command = new DeleteDoctorCommand(id);
        //    var response = await _mediator.Send(command);

        //    if (!response.IsSuccess)
        //        return StatusCode(500, response.Message);

        //    return StatusCode(201, response);
        //}

        //[HttpPut("Update")] 
        //public async Task<IActionResult> Update(UpdateAuthorCommand command)
        //{
        //    var response = await _mediator.Send(command);

        //    if (!response.IsSuccess)
        //        return StatusCode(500, response.Message);

        //    return StatusCode(201, response);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAuthorCommand command)
        {
            await _mediator.Send(command);

            return Ok("Criado com sucesso");
        }
         
    }
}
