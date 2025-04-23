using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Attack: PhysAttack
{
    protected override int Modifier() => 54;
    protected override int FighterStat() => GetAttacker().GetStats().Str;
    protected override void PrintAttack(IFighter reciever)
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        view.WriteLines([
            $"{GetAttacker().GetName()} ataca a {reciever.GetName()}",
            $"{reciever.GetName()} recibe {CalculateDamage()} de daño",
            $"{reciever.GetName()} termina con HP:{reciever.GetStats().HpLeft}/{reciever.GetStats().MaxHp}"
        ]);
    }
}