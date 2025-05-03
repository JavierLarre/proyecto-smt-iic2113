using Shin_Megami_Tensei_Model.Models.Fighter.Fighters;

namespace Shin_Megami_Tensei_Model;

public abstract class AbstractFighter: AbstractModel, IFighter
{
    private UnitData _unitData;
    private StatComponent _hp;
    private StatComponent _mp;

    protected AbstractFighter(UnitData unitData)
    {
        _unitData = unitData;
        _hp = new StatComponent(_unitData.Stats.Hp);
        _mp = new StatComponent(_unitData.Stats.Mp);
    }
    public int GetCurrentHp() => _hp.Get();

    public void SetHp(int value)
    {
        _hp.Set(value);
        UpdateObservers();
    }

    public int GetCurrentMp() => _mp.Get();

    public void SetMp(int value) => _mp.Set(value);

    public abstract void AddToReserve(Team team);
    public abstract bool CanBeSwapped();

    public bool IsAlive() => _hp.Get() > 0;

    public UnitData GetUnitData() => _unitData;
    
}