namespace API.Web.Endpoints.ProjectEndpoints;

public class CreatePersonaResponse
{
  public CreatePersonaResponse(int id, string nombre)
  {
    Id = id;
    Nombre = nombre;
  }
  public int Id { get; set; }
  public string Nombre { get; set; }
}
