namespace Shin_Megami_Tensei_Model;

public abstract class AbstractFighterFactory
{
    private readonly SkillFactory _skillFactory = new SkillFactory();

    protected Skill[] GetSkillsFromNames(IEnumerable<string> skillNames)
    {
        return skillNames
            .Where(skill => skill != "")
            .Select(_skillFactory.FromName)
            .ToArray();
    }

    protected static Stats BuildStats(StatsDataFromJson data)
    {
        return new Stats(
            data.HP,
            data.MP,
            data.Str,
            data.Skl,
            data.Mag,
            data.Spd,
            data.Lck
            );
    }

    protected static Affinities BuildAffinities(AffinityDataFromJson data)
    {
        return new Affinities
        {
            Phys = data.Phys,
            Gun = data.Gun,
            Fire = data.Fire,
            Ice = data.Ice,
            Elec = data.Elec,
            Force = data.Force,
            Light = data.Light,
            Dark = data.Dark
        };
    }
    
}