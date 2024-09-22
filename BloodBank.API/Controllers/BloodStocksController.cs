using BloodBank.Application.BloodStock.Commands.ConsumeBloodStock;
using BloodBank.Application.BloodStock.Commands.CreateBloodStock;
using BloodBank.Application.BloodStock.Commands.DeleteBloodStock;
using BloodBank.Application.BloodStock.Commands.UpdateBloodStock;
using BloodBank.Application.BloodStock.Queries.GetAllBloodStocks;
using BloodBank.Application.BloodStock.Queries.GetBloodStockById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers;

[Route("api/bloodstocks")]
[Authorize]
[ApiController]
public class BloodStocksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodStocksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllBloodStocksQuery = new GetAllBloodStocksQuery(query);

        var bloodStock = await _mediator.Send(getAllBloodStocksQuery);

        return Ok(bloodStock);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetBloodStockByIdQuery(id);

        var result = await _mediator.Send(query);

        if(!result.Success)
            return NotFound(result.Errors);


        return Ok(result.Value);
    }

    [HttpPost]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Post(CreateBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Put(int id, UpdateBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}/consume")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> ConsumeAmount(int id, ConsumeBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "donor, manager")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBloodStockCommand(id);

        var result =  await _mediator.Send(command);

        if (!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }
}
