using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Shoot: PhysAttack
{
    private readonly IFighter _attacker;
    private const int _modifier = 80;

    public Shoot(IFighter fighter)
    {
        _attacker = fighter;
    }

    public override string ActionName() => "Disparar";
    protected override int Modifier() => _modifier;
    protected override int FighterStat() => _attacker.Stats.Skl;
    protected override void PrintAttack(BattleView view, IFighter reciever)
    {
        view.WriteLines([
            $"{_attacker.Name} dispara a {reciever.Name}",
            $"{reciever.Name} recibe {CalculateDamage()} de daño",
            $"{reciever.Name} termina con HP:{reciever.Stats.HpLeft}/{reciever.Stats.MaxHp}"
        ]);
    }
}