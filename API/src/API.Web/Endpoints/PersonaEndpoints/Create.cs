using API.Core.PersonaAggregate;
using API.SharedKernel.Interfaces;
using API.Web.Endpoints.ProjectEndpoints;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Web.Endpoints.PersonaEndpoints;
public class Create : EndpointBaseAsync
  .WithRequest<CreatePersonaRequest>
  .WithActionResult<CreatePersonaResponse>
{
  private readonly IRepository<Persona> _repository;

  public Create(IRepository<Persona> repository)
  {
    _repository = repository;
  }

  [HttpPost("/Personas")]
  [SwaggerOperation(
    Summary = "Crea una nueva persona",
    Description = "Crea una nueva persona",
    OperationId = "Persona.Create",
    Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<CreatePersonaResponse>> HandleAsync(
    CreatePersonaRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request.Nombre == null || request.apellidoPaterno == null || request.apellidoMaterno == null)
    {
      return BadRequest();
    }

    var nuevaPersona = new Persona(request.Nombre, request.apellidoPaterno, request.apellidoMaterno, request.edad, request.estatura);
    var createdItem = await _repository.AddAsync(nuevaPersona, cancellationToken);
    var response = new CreatePersonaResponse
    (
      id: createdItem.Id,
      nombre: createdItem.nombre
    );

    return Ok(response);
  }
}
