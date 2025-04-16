using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Shoot: PhysAttack
{

    public Shoot(Table table, BattleView view)
    : base(table, view)
    {
    }

    protected override int Modifier() => 80;
    protected override int FighterStat() => Attacker.Stats.Skl;
    protected override void PrintAttack()
    {
        View.WriteLines([
            $"{Attacker.Name} dispara a {Reciever.Name}",
            $"{Reciever.Name} recibe {CalculateDamage()} de daño",
            $"{Reciever.Name} termina con HP:{Reciever.Stats.HpLeft}/{Reciever.Stats.MaxHp}"
        ]);
    }
}