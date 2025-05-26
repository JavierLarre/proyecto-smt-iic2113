namespace Shin_Megami_Tensei_Model;

public struct TeamState
{
    public IFighterModel Leader;
    public ICollection<IFighterModel> FightersInOrder;
    public ICollection<IFighterModel> FrontRow;
    public ICollection<IFighterModel> AliveFrontRow;
    public ICollection<IFighterModel> Reserve;
    
}