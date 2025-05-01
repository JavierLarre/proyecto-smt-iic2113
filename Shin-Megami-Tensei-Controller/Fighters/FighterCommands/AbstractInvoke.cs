using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

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
            .DisplayCard($"{target.GetUnitData().Name} ha sido invocado");
    }

    protected abstract int GetSummonPosition();

}