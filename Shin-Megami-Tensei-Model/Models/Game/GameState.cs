
namespace Shin_Megami_Tensei_Model;

public struct GameState
{
    public Player CurrentPlayer;
    public Player EnemyPlayer;
    public PlayerState CurrentPlayerState;
    public PlayerState EnemyPlayerState;
    public TurnsModel TurnsModel;
    public TurnsData TurnsData;
    public IFighterModel CurrentFighter;
    public ICollection<IFighterModel> FightersInTurnOrder;
}