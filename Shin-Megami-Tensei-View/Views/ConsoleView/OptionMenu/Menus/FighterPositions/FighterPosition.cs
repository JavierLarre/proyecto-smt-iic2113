using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public struct FighterPosition
{
    public int Position;
    public IFighterModel Fighter;

    public override string ToString()
    {
        IFighterModel fighter = Fighter;
        FighterView fighterView = new FighterView(fighter);
        string positionInfo = fighterView.GetInfo();
        if (positionInfo == "")
            positionInfo = "Vacío";
        positionInfo += $" (Puesto {Position + 1})";
        return positionInfo;
    }
}