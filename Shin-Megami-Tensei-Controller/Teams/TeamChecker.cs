using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Samurais;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Teams;

public class TeamChecker(TeamParser team)
{
    private TeamParser Team = team;

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

    private bool HasSamurais() => Team.Samurais.Count > 0;
    private bool HasOneSamurai() => Team.Samurais.Count == 1;
    private bool LessThanMaxSize() => Team.Monsters.Count + 1 <= Constants.MaxTeamSize;

    private bool AllUnitsAreUnique()
    {
        return Team.Monsters.Distinct().Count() == Team.Monsters.Count;
    }

    private bool SamuraiHasLessThanMaxSkills()
    {
        Samurai samurai = Team.Samurais.First();
        return samurai.Skills.Length <= Constants.MaxSkillSize;
    }

    private bool AllSkillsAreUnique()
    {
        Skill[] skills = Team.Samurais.First().Skills;
        return skills.Distinct().Count() != skills.Length;
    }
}