namespace Shin_Megami_Tensei_Model;

public struct TeamState
{
    public IFighterModel Leader;
    public ICollection<IFighterModel> FightersInOrder;
    public ICollection<IFighterModel> FrontRow;
    public ICollection<IFighterModel> AliveTargets;
    public ICollection<IFighterModel> Reserve;
    public ICollection<IFighterModel> AliveReserve;
    public ICollection<IFighterModel> DeadFighters;
    public IFighterModel LastSummonedFighter;
    public IFighterModel LastReservedFighter;
}