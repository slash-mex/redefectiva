using System.ComponentModel.DataAnnotations;

namespace API.Web.Endpoints.ProjectEndpoints;
public class CreatePersonaRequest
{

  [Required]
  public string? Nombre { get; set; }

  [Required]
  public string? apellidoPaterno { get; set; }
  
  [Required]
  public string? apellidoMaterno { get; set; }
  public int edad { get; set; }
  public int estatura { get; set; }
}
