using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SummonPositionMenu: AbstractOptionsMenu
{
    //TODO: limpiar esta porquería, urgentemente
    private class FighterPosition
    {
        public int Position;
        public IFighter Fighter;
        public string PositionInfo;

        public FighterPosition(IFighter fighter, int position)
        {
            Fighter = fighter;
            Position = position;
        }

        public void SetFighterInfo()
        {
            IFighterView fighter = FighterViewFactory.FromFighter(Fighter);
            PositionInfo = $"{fighter.GetInfo()}";
            if (PositionInfo == "")
                PositionInfo = "Vacío";
            if (PositionInfo == " ")
                PositionInfo = "Vacío";
            PositionInfo += $" (Puesto {Position + 1})";
        }
    }
    
    
    public SummonPositionMenu()
    {
        Table table = Table.GetInstance();
        var fighters = table.GetCurrentPlayer().GetTeam().GetFrontRow();
        SetPositions(fighters);
        SetHeader("Seleccione una posición para invocar");
    }

    private void SetPositions(IEnumerable<IFighter> fighters)
    {
        var positions = fighters.Select((fighter, i) => new FighterPosition(fighter, i));
        positions = positions.Where(position => position.Fighter is not Samurai).ToList();
        foreach (var position in positions)
        {
            position.SetFighterInfo();
            AddOption(position.Position.ToString(), position.PositionInfo);
        }
        AddCancelOption();
    }

    public int GetPosition()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        string choice = GetChoice();
        return int.Parse(choice);
    }

    
    public override string GetSeparator() => "-";
}