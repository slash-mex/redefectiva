using API.Core.PersonaAggregate;
using API.SharedKernel.Interfaces;
using API.Web.Endpoints.ProjectEndpoints;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Web.Endpoints.PersonaEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<PersonaListResponse>
{
  private readonly IReadRepository<Persona> _repository;

  public List(IReadRepository<Persona> repository)
  {
    _repository = repository;
  }

  [HttpGet("/Personas")]
  [SwaggerOperation(
      Summary = "Obtiene la lista de personas",
      Description = "Lista todas las personas almacenadas",
      OperationId = "Persona.List",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<PersonaListResponse>> HandleAsync(
    CancellationToken cancellationToken = new())
  {
    var personas = await _repository.ListAsync(cancellationToken);
    var response = new PersonaListResponse()
    {
      Personas = personas
        .Select(persona => new RegistroPersona(persona.Id, persona.nombre))
        .ToList()
    };
    //response.Personas.Add(new Persona("Marco", "Gutierrez", "Cornejo", 38, 180));

    return Ok(response);
  }
}
