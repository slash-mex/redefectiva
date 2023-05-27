using Ardalis.Specification;

namespace API.Core.PersonaAggregate.Specifications;
public class PersonaByIdWithItemsSpec : Specification<Persona>, ISingleResultSpecification
{
  public PersonaByIdWithItemsSpec(int personaId)
  {
    Query
        .Where(persona => persona.Id == personaId);
  }
}
