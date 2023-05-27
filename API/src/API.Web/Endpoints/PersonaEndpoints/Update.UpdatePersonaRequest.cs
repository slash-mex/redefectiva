using System.ComponentModel.DataAnnotations;

namespace API.Web.Endpoints.PersonaEndpoints;
public class UpdatePersonaRequest
{
  public const string Route = "/Personas";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? Nombre { get; set; }
}
