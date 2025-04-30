using Shin_Megami_Tensei_Model;


namespace Shin_Megami_Tensei.Teams;

public class TeamChecker
{
    private const int MaxTeamSize = 8;
    private const int MaxSkills = 8;
    private readonly List<IFighter> _fighters;

    public static TeamChecker FromParser(TeamParser parser)
        => new TeamChecker(parser);
    private TeamChecker(TeamParser parser) => _fighters = parser.GetFighters().ToList();

    public bool IsValid()
    {
        bool[] conditions = [
            HasSamurais(),
            HasOneSamurai(),
            LessThanMaxSize(),
            AllUnitsAreUnique(),
            SamuraiHasLessThanMaxSkills(),
            AllSkillsAreUnique()
        ];
        return conditions.All(c => c);
    }

    private bool HasSamurais() => _fighters.Any(fighter => fighter is Samurai);
    private bool HasOneSamurai() => _fighters.Count(fighter => fighter is Samurai) == 1;
    private bool LessThanMaxSize() => _fighters.Count <= MaxTeamSize;
    private bool AllUnitsAreUnique()
    {
        var fightersNames = _fighters.Select(fighter => fighter.GetUnitData().Name);
        return fightersNames.Distinct().Count() == _fighters.Count;
    }

    private bool SamuraiHasLessThanMaxSkills()
    {
        if (!HasSamurais()) return false;
        IFighter samurai = _fighters.First(fighter => fighter is Samurai);
        return samurai.GetUnitData().Skills.Count <= MaxSkills;
    }

    private bool AllSkillsAreUnique()
    {
        if (!HasSamurais()) return false;
        var skills = _fighters.First(fighter => fighter is Samurai).GetUnitData().Skills;
        var skillNames = skills.Select(skill => skill.Name);
        return skillNames.Distinct().Count() == skills.Count;
    }
}