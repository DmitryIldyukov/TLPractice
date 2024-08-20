using Gladiators.GameMaster;
using Gladiators.Services;

namespace Gladiators;

internal class Program
{
    static void Main( string[] args )
    {
        IGameManager gameManager = new GameManager( new FighterService() );
        gameManager.Play();
    }
}