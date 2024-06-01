using BloodBank.Application.Commands.CreateBloodStock;
using BloodBank.Application.Commands.DeleteBloodStock;
using BloodBank.Application.Commands.UpdateBloodStock;
using BloodBank.Application.Querys.GetAllBloodStocks;
using BloodBank.Application.Querys.GetBloodStockByIdQuery;
using BloodBank.Core.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BloodStocksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodStocksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllBloodStocksQuery = new GetAllBloodStocksQuery(query);

        var bloodStock = await _mediator.Send(getAllBloodStocksQuery);

        return Ok(bloodStock);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetBloodStockByIdQuery(id);

        var result = await _mediator.Send(query);

        if(!result.Success)
            return NotFound(result.Errors);


        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBloodStockCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBloodStockCommand(id);

        var result =  await _mediator.Send(command);

        if (!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }
}
