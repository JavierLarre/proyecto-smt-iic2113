using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class AbstractInvoke: IFighterCommand
{
    public void Execute()
    {
        Table table = Table.GetInstance();
        var reserve = table.GetCurrentPlayer().GetTeam().GetReserve()
            .Where(fighter => fighter.IsAlive());
        SummonFighterMenu summonMenu = new SummonFighterMenu(reserve);
        IFighter target = summonMenu.GetTarget();
        int atPosition = GetSummonPosition();
        table.Summon(target, atPosition);
        table.GetTurnManager().ConsumeAndGainTurn();
        BattleViewSingleton.GetBattleView()
            .WriteLine($"{target.GetName()} ha sido invocado");
    }

    protected abstract int GetSummonPosition();

}