using BloodBank.Application.Donation.Commands.CreateDonation;
using BloodBank.Application.Donation.Commands.DeleteDonation;
using BloodBank.Application.Donation.Commands.UpdateDonation;
using BloodBank.Application.Donation.Queries.GetAllDonations;
using BloodBank.Application.Donation.Queries.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers;

[Route("api/donations")]
[Authorize]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllDonationsQuery = new GetAllDonationsQuery(query);

        var donations = await _mediator.Send(getAllDonationsQuery);

        return Ok(donations);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDonationByIdQuery(id);

        var result = await _mediator.Send(query);

        if(!result.Success)
            return NotFound(result.Errors);

        return Ok(result.Value);
    }

    [HttpPost]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Post(CreateDonationCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return CreatedAtAction(nameof(GetById), new {id = result.Value}, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Put(int id, UpdateDonationCommand command)
    {
        var result =  await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDonationCommand(id);

        var result =  await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return NoContent();
    }

}
