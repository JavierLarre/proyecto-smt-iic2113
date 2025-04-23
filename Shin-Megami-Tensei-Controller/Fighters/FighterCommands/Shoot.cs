using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Shoot: PhysAttack
{

    protected override int Modifier() => 80;
    protected override int FighterStat() => GetAttacker().GetStats().Skl;
    protected override void PrintAttack(IFighter reciever)
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        view.WriteLines([
            $"{GetAttacker().GetName()} dispara a {reciever.GetName()}",
            $"{reciever.GetName()} recibe {CalculateDamage()} de daño",
            $"{reciever.GetName()} termina con HP:{reciever.GetStats().HpLeft}/{reciever.GetStats().MaxHp}"
        ]);
    }
}