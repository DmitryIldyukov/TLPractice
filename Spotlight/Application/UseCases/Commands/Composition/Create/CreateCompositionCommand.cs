using MediatR;

namespace Application.UseCases.Commands.Composition.Create;

public class CreateCompositionCommand : IRequest
{
    public string Name { get; init; }
    public string ShortDescription { get; init; }
    public string HeroesInformation { get; init; }
    public int AuthorId { get; init; }
}
