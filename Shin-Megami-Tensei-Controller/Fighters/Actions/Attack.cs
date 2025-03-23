using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Attack(Fighter attacker): PhysAttack
{
    private readonly Fighter _attacker = attacker;
    private const int _modifier = 54;

    public override string ActionName() => "Atacar";
    protected override int Modifier() => _modifier;
    protected override int FighterStat() => _attacker.Stats.Str;
    protected override void PrintAttack(BattleFrontend frontend, Fighter reciever)
    {
        frontend.WriteLines([
            $"{_attacker.Name} ataca a {reciever.Name}",
            $"{reciever.Name} recibe {CalculateDamage()} de daño",
            $"{reciever.Name} termina con {reciever.Stats.PrintHp()}"
        ]);
    }
}