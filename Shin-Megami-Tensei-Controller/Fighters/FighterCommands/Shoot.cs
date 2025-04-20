using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Shoot: PhysAttack
{

    public Shoot(IFighter fighter)
    : base(fighter)
    {
    }

    protected override int Modifier() => 80;
    protected override int FighterStat() => Attacker.Stats.Skl;
    protected override void PrintAttack(IFighter reciever, BattleView view)
    {
        view.WriteLines([
            $"{Attacker.Name} dispara a {reciever.Name}",
            $"{reciever.Name} recibe {CalculateDamage()} de daño",
            $"{reciever.Name} termina con HP:{reciever.Stats.HpLeft}/{reciever.Stats.MaxHp}"
        ]);
    }
}