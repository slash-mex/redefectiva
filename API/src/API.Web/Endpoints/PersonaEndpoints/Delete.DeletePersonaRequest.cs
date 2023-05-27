namespace API.Web.Endpoints.PersonaEndpoints;

public class DeletePersonaRequest
{
  public const string Route = "/Personas/{PersonaId:int}";
  public static string BuildRoute(int personaId) => Route.Replace("{PersonaId:int}", personaId.ToString());

  public int PersonaId { get; set; }
}
