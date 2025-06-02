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
    
    public FighterState GetState()
    {
        return new FighterState
        {
            Name = _unitData.Name,
            Stats = _unitData.Stats,
            Affinities = _unitData.Affinities,
            FightOptions = _unitData.FightOptions,
            CurrentHp = _hp.Get(),
            CurrentMp = _mp.Get(),
            MaxHp = _unitData.Stats.Hp,
            MaxMp = _unitData.Stats.Mp,
            Skills = _unitData.Skills,
            UsableSkills = GetUsableSkills(),
            IsAlive = IsAlive(),
            CanBeSwapped = CanBeSwapped(),
            FilePriority = _unitData.FilePriority,
        };
    }

    public void SetHp(int value)
    {
        _hp.Set(value);
        UpdateObservers();
    }
    
    public void SetMp(int value) => _mp.Set(value);
    private bool IsAlive() => _hp.Get() > 0;

    private ICollection<SkillData> GetUsableSkills()
    {
        return _unitData
            .Skills
            .Where(skill => skill.Cost <= _mp.Get())
            .ToList();
    }
    
    public abstract void AddToReserve(Team team);
    protected abstract bool CanBeSwapped();
}