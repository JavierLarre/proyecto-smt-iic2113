using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_Model.Fighters;

public class EmptyFighter: AbstractModel, IFighterModel
{
    public UnitData GetUnitData() => new();
    
    public void HealDamage(double amount) { }

    public void RecieveDamage(double damage) { }

    public void DecreaseMp(int cost) { }

    public int GetCurrentHp() => 0;
    public void SetHp(int value) { }

    public int GetCurrentMp() => 0;
    public void SetMp(int value) { }
    
    public void AddToReserve(Team team) { }

    public bool IsAlive() => false;
    public bool CanBeSwapped() => true;
    public FighterState GetState() => new FighterState();
}