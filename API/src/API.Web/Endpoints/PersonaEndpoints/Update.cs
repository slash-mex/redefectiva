using API.Core.PersonaAggregate;
using API.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Web.Endpoints.PersonaEndpoints;
public class Update : EndpointBaseAsync
    .WithRequest<UpdatePersonaRequest>
    .WithActionResult<UpdatePersonaResponse>
{
  private readonly IRepository<Persona> _repository;

  public Update(IRepository<Persona> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdatePersonaRequest.Route)]
  [SwaggerOperation(
      Summary = "Actualiza una persona",
      Description = "Actualiza la informaci'on de una persona",
      OperationId = "Personas.Update",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<UpdatePersonaResponse>> HandleAsync(
    UpdatePersonaRequest request,
      CancellationToken cancellationToken = new())
  {
    if (request.Nombre == null)
    {
      return BadRequest();
    }

    var existingProject = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingProject == null)
    {
      return NotFound();
    }

    existingProject.UpdateNombre(request.Nombre);

    await _repository.UpdateAsync(existingProject, cancellationToken);

    var response = new UpdatePersonaResponse(
        persona: new RegistroPersona(existingProject.Id, existingProject.nombre)
    );

    return Ok(response);
  }
}
