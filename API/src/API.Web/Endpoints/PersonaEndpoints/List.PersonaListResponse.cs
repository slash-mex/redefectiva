using API.Core.PersonaAggregate;
using API.Web.Endpoints.ProjectEndpoints;

namespace API.Web.Endpoints.PersonaEndpoints;

public class PersonaListResponse
{
  public List<RegistroPersona> Personas { get; set; } = new();
}
