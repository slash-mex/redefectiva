using API.Core.PersonaAggregate;
using API.Core.PersonaAggregate.Specifications;
using API.SharedKernel.Interfaces;
using API.Web.ApiModels;
using API.Web.Endpoints.PersonaEndpoints;
using API.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace API.Web.Api;
/// <summary>
/// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
/// https://github.com/ardalis/ApiEndpoints
/// </summary>
public class PersonaController : BaseApiController
{
  private readonly IRepository<Persona> _repository;

  public PersonaController(IRepository<Persona> repository)
  {
    _repository = repository;
  }

  // GET: api/Personas
  [HttpGet]
  public async Task<IActionResult> List()
  {
    var personaDTOs = (await _repository.ListAsync())
        .Select(persona => new PersonaDTO
        (
            id: persona.Id,
            nombre: persona.nombre
        ))
        .ToList();

    return Ok(personaDTOs);
  }

  // GET: api/Personas
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var personaSpec = new PersonaByIdWithItemsSpec(id);
    var persona = await _repository.FirstOrDefaultAsync(personaSpec);
    if (persona == null)
    {
      return NotFound();
    }

    var result = new PersonaDTO
    (
        id: persona.Id,
        nombre: persona.nombre
    );

    return Ok(result);
  }

  // POST: api/Personas
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreatePersonaRequest request)
  {

    if (request.Nombre == null || request.apellidoPaterno == null || request.apellidoMaterno == null)
    {
      return BadRequest();
    }

    var nuevaPersona = new Persona(request.Nombre, request.apellidoPaterno, request.apellidoMaterno, request.edad, request.estatura);

    var createdPersona = await _repository.AddAsync(nuevaPersona);

    var result = new CreatePersonaResponse
    (
        id: createdPersona.Id,
        nombre: createdPersona.nombre
    );
    return Ok(result);
  }

}
