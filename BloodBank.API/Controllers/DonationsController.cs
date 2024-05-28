﻿using BloodBank.Application.Commands.CreateDonation;
using BloodBank.Application.Commands.DeleteDonation;
using BloodBank.Application.Commands.UpdateDonation;
using BloodBank.Application.Querys.GetAllDonations;
using BloodBank.Application.Querys.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        var donation = await _mediator.Send(query);

        if(donation == null)
        {
            return NotFound();
        }

        return Ok(donation);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDonationCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new {id = id}, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateDonationCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDonationCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

}