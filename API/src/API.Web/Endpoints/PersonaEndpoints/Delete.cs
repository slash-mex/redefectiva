using API.Core.PersonaAggregate;
using API.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Web.Endpoints.PersonaEndpoints;
public class Delete : EndpointBaseAsync
    .WithRequest<DeletePersonaRequest>
    .WithoutResult
{
  private readonly IRepository<Persona> _repository;

  public Delete(IRepository<Persona> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeletePersonaRequest.Route)]
  [SwaggerOperation(
      Summary = "Elimina una persona",
      Description = "Elimina a la persona con el ID indicado",
      OperationId = "Personas.Delete",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(
    [FromRoute] DeletePersonaRequest request,
      CancellationToken cancellationToken = new())
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.PersonaId, cancellationToken);
    if (aggregateToDelete == null)
    {
      return NotFound();
    }

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return NoContent();
  }
}
