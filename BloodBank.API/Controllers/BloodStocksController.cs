using BloodBank.Application.BloodStock.Commands.ConsumeBloodStock;
using BloodBank.Application.BloodStock.Commands.CreateBloodStock;
using BloodBank.Application.BloodStock.Commands.DeleteBloodStock;
using BloodBank.Application.BloodStock.Commands.UpdateBloodStock;
using BloodBank.Application.BloodStock.Queries.GetAllBloodStocks;
using BloodBank.Application.BloodStock.Queries.GetBloodStockById;
using BloodBank.Application.BloodStock.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodBank.API.Controllers;

[Route("api/bloodstocks")]
[Authorize]
[ApiController]
[Produces("application/json")]
public class BloodStocksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodStocksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Obtém uma lista de BloodStock")]
    [ProducesResponseType(typeof(List<BloodStockViewModel>),StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string? query, int page = 1)
    {
        var getAllBloodStocksQuery = new GetAllBloodStocksQuery(query!, page);

        var bloodStock = await _mediator.Send(getAllBloodStocksQuery);

        return Ok(bloodStock);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Obtém um BloodStock")]
    [ProducesResponseType(typeof(List<BloodStockDetailsViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [SwaggerOperation(Summary = "Adiciona um BloodStock")]
    [ProducesResponseType(typeof(CreateBloodStockCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Atualiza os dados de um BloodStock")]
    [ProducesResponseType(typeof(UpdateBloodStockCommand),StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, UpdateBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}/consume")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Atualiza a quantidade em estoque do BloodStock")]
    [ProducesResponseType(typeof(UpdateBloodStockCommand), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ConsumeAmount(int id, ConsumeBloodStockCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Deleta logicamente um BloodStock")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBloodStockCommand(id);

        var result =  await _mediator.Send(command);

        if (!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }
}
