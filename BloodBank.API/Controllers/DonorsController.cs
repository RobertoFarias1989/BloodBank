using BloodBank.Application.Donor.Commands.CreateDonor;
using BloodBank.Application.Donor.Commands.DeleteDonor;
using BloodBank.Application.Donor.Commands.UpdateDonor;
using BloodBank.Application.Donor.Queries.GetAllDonors;
using BloodBank.Application.Donor.Queries.GetDonorById;
using BloodBank.Application.Donor.ViewModels;
using BloodBank.Application.Login.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodBank.API.Controllers;

[Route("api/donors")]
[Authorize]
[ApiController]
[Produces("application/json")]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Obtém uma lista de Donors")]
    [ProducesResponseType(typeof(List<DonorViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string? query, int page = 1)
    {
        var getAllDonorsQuery = new GetAllDonorsQuery(query!, page);

        var donors = await _mediator.Send(getAllDonorsQuery);

        return Ok(donors);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Obtém um Donor")]
    [ProducesResponseType(typeof(DonorDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [SwaggerOperation(Summary = "Adiciona um Donor")]
    [ProducesResponseType(typeof(CreateDonorCommand), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateDonorCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Atualiza um Donor")]
    [ProducesResponseType(typeof(UpdateDonorCommand), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Put(int id, UpdateDonorCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("login")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Realiza o login do Donor")]
    [ProducesResponseType(typeof(LoginCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result =  await _mediator.Send(command);

        if(!result.Success)
            return NotFound(result.Errors);

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "donor, manager")]
    [SwaggerOperation(Summary = "Deleta logicamente um Donor")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDonorCommand(id);

        var result = await _mediator.Send(command);

        if(!result.Success)
            return NotFound(result.Errors);

        return NoContent();
    }
}
