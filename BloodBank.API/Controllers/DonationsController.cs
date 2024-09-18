using BloodBank.Application.Donation.Commands.CreateDonation;
using BloodBank.Application.Donation.Commands.DeleteDonation;
using BloodBank.Application.Donation.Commands.UpdateDonation;
using BloodBank.Application.Donation.Queries.GetAllDonations;
using BloodBank.Application.Donation.Queries.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllDonationsQuery = new GetAllDonationsQuery(query);

        var donations = await _mediator.Send(getAllDonationsQuery);

        return Ok(donations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDonationByIdQuery(id);

        var result = await _mediator.Send(query);

        if(!result.Success)
            return NotFound(result.Errors);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDonationCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return CreatedAtAction(nameof(GetById), new {id = result.Value}, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateDonationCommand command)
    {
        var result =  await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDonationCommand(id);

        var result =  await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return NoContent();
    }

}
