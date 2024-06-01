using BloodBank.Application.Commands.CreateDonor;
using BloodBank.Application.Commands.DeleteDonor;
using BloodBank.Application.Commands.UpdateDonor;
using BloodBank.Application.Querys.GetAllDonors;
using BloodBank.Application.Querys.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllDonorsQuery = new GetAllDonorsQuery(query);

        var donors = await _mediator.Send(getAllDonorsQuery);

        return Ok(donors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDonorByIdQuery(id);

        var result = await _mediator.Send(query);

        if(!result.Success)
        {
            return NotFound(result.Errors);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDonorCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateDonorCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDonorCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
