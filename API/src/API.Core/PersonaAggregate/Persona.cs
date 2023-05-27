using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using API.SharedKernel;
using API.SharedKernel.Interfaces;
using Ardalis.GuardClauses;

namespace API.Core.PersonaAggregate;
public class Persona : EntityBase, IAggregateRoot
{

  public Persona(string nombre, string apellidoPaterno, string apellidoMaterno, int edad, int estatura)
  {
    this.nombre = nombre;
    this.apellidoPaterno = apellidoPaterno;
    this.apellidoMaterno = apellidoMaterno;
    this.edad = edad;
    this.estatura = estatura;
  }
  public string nombre { get; set; }
  public string apellidoPaterno { get; set; }
  public string apellidoMaterno { get; set; }
  public int edad { get; set; }
  public int estatura { get; set; }

  public void UpdateNombre(string nuevoNombre)
  {
    nombre = Guard.Against.NullOrEmpty(nuevoNombre, nameof(nuevoNombre));
  }
}
