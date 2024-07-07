using Gladiators.Models.Fighters;

namespace Gladiators.Services;

public interface IFighterService
{
    IFighter CreateFighter();
    List<IFighter> GetFighters();
    void ReviveFighters();
}