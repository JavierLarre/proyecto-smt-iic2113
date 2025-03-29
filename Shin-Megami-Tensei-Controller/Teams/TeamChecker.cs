using Shin_Megami_Tensei.Fighters.Samurais;
using Shin_Megami_Tensei.Fighters.Skills;


namespace Shin_Megami_Tensei.Teams;

public class TeamChecker
{
    private const int MaxTeamSize = 8;
    private const int MaxSkills = 8;
    private readonly TeamParser _parser;

    public static TeamChecker FromParser(TeamParser parser)
        => new TeamChecker(parser);
    private TeamChecker(TeamParser parser) => _parser = parser;

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

    private bool HasSamurais() => _parser.Samurais.Count > 0;
    private bool HasOneSamurai() => _parser.Samurais.Count == 1;
    private bool LessThanMaxSize() => _parser.Monsters.Count + 1 <= MaxTeamSize;

    private bool AllUnitsAreUnique()
    {
        var monsterNames = _parser.Monsters.Select(monster => monster.Name);
        return monsterNames.Distinct().Count() == _parser.Monsters.Count;
    }

    private bool SamuraiHasLessThanMaxSkills()
    {
        if (_parser.Samurais.Count == 0) return false;
        Samurai samurai = _parser.Samurais.First();
        return samurai.Skills.Length <= MaxSkills;
    }

    private bool AllSkillsAreUnique()
    {
        if (_parser.Samurais.Count == 0) return false;
        Skill[] skills = _parser.Samurais.First().Skills;
        var skillNames = skills.Select(skill => skill.Name).ToArray();
        return skillNames.Distinct().Count() == skills.Length;
    }
}