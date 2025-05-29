namespace Shin_Megami_Tensei_Model;

public struct GameState
{
    public Player CurrentPlayer;
    public Team CurrentTeam;
    public Player EnemyPlayer;
    public Team EnemyTeam;
    public TurnsModel TurnsModel;
    public TurnsData TurnsData;
    public IFighterModel CurrentFighter;
    public ICollection<IFighterModel> FrontRow;
    public ICollection<IFighterModel> FightersInTurnOrder;
    public ICollection<IFighterModel> EnemyTeamAliveTargets;
    public ICollection<IFighterModel> Reserve;
    public ICollection<IFighterModel> AliveReserve;
}