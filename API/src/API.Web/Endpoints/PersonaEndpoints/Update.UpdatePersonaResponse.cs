namespace API.Web.Endpoints.PersonaEndpoints;

public class UpdatePersonaResponse
{
  public UpdatePersonaResponse(RegistroPersona persona)
  {
    Persona = persona;
  }
  public RegistroPersona Persona { get; set; }
}
