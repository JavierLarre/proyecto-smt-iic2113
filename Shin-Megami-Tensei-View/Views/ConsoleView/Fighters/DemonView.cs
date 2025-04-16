using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public class DemonView: AbstractFighterView
{
    public DemonView(IFighter fighter) : base(fighter)
    {
    }
    public override string GetInfo()
    {
        return Fighter.IsAlive() ? 
                base.GetInfo() :
                ""
                ;
    }
}