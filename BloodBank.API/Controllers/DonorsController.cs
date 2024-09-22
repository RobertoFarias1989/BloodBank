using BloodBank.Application.Donor.Commands.CreateDonor;
using BloodBank.Application.Donor.Commands.DeleteDonor;
using BloodBank.Application.Donor.Commands.UpdateDonor;
using BloodBank.Application.Donor.Queries.GetAllDonors;
using BloodBank.Application.Donor.Queries.GetDonorById;
using BloodBank.Application.Login.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers;

[Route("api/donors")]
[Authorize]
[ApiController]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllDonorsQuery = new GetAllDonorsQuery(query);

        var donors = await _mediator.Send(getAllDonorsQuery);

        return Ok(donors);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDonorByIdQuery(id);

        var result = await _mediator.Send(query);

        if(!result.Success)
        {
            return NotFound(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(CreateDonorCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Put(int id, UpdateDonorCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result =  await _mediator.Send(command);

        if(!result.Success)
            return NotFound(result.Errors);

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDonorCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
