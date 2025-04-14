using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Attack: PhysAttack
{
    private const int _modifier = 54;
    private readonly IFighter _attacker;

    public Attack(IFighter attacker) => _attacker = attacker;

    public override string ActionName() => "Atacar";
    protected override int Modifier() => _modifier;
    protected override int FighterStat() => _attacker.Stats.Str;
    protected override void PrintAttack(BattleView view, IFighter reciever)
    {
        view.WriteLines([
            $"{_attacker.Name} ataca a {reciever.Name}",
            $"{reciever.Name} recibe {CalculateDamage()} de daño",
            $"{reciever.Name} termina con HP:{reciever.Stats.HpLeft}/{reciever.Stats.MaxHp}"
        ]);
    }
}