using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Attack: PhysAttack
{
    public Attack(IFighter fighter)
    : base(fighter)
    {
    }
    protected override int Modifier() => 54;
    protected override int FighterStat() => Attacker.Stats.Str;
    protected override void PrintAttack(IFighter reciever, BattleView view)
    {
        view.WriteLines([
            $"{Attacker.Name} ataca a {reciever.Name}",
            $"{reciever.Name} recibe {CalculateDamage()} de daño",
            $"{reciever.Name} termina con HP:{reciever.Stats.HpLeft}/{reciever.Stats.MaxHp}"
        ]);
    }
}