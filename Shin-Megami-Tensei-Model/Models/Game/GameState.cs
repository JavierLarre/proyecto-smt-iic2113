namespace Shin_Megami_Tensei_Model;

public struct GameState
{
    public Player CurrentPlayer;
    public Player EnemyPlayer;
    public TurnsModel TurnsModel;
    public IFighterModel CurrentFighter;
    public ICollection<IFighterModel> FightersInTurnOrder;
    public ICollection<IFighterModel> EnemyTeamAliveTargets;
}