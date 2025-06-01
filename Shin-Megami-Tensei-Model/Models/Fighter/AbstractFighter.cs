using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_Model.Models.Fighter.Fighters;

namespace Shin_Megami_Tensei_Model;

public abstract class AbstractFighter: AbstractModel, IFighterModel
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

    public FighterState GetState()
    {
        return new FighterState
        {
            Name = _unitData.Name,
            Stats = _unitData.Stats,
            Affinities = _unitData.Affinities,
            CurrentHp = _hp.Get(),
            MaxHp = _unitData.Stats.Hp,
            CurrentMp = _mp.Get(),
            MaxMp = _unitData.Stats.Mp,
            FightOptions = _unitData.FightOptions,
            FilePriority = _unitData.FilePriority,
            IsAlive = IsAlive(),
            Skills = _unitData.Skills
        };
    }
    
}