using Shin_Megami_Tensei.Fighters.Samurais;
using Shin_Megami_Tensei.Fighters.Skills;


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
        var monsterNames = Team.Monsters.Select(monster => monster.Name);
        return monsterNames.Distinct().Count() == Team.Monsters.Count;
    }

    private bool SamuraiHasLessThanMaxSkills()
    {
        if (Team.Samurais.Count == 0) return false;
        Samurai samurai = Team.Samurais.First();
        return samurai.Skills.Length <= Constants.MaxSkillSize;
    }

    private bool AllSkillsAreUnique()
    {
        if (Team.Samurais.Count == 0) return false;
        Skill[] skills = Team.Samurais.First().Skills;
        var skillNames = skills.Select(skill => skill.Name).ToArray();
        return skillNames.Distinct().Count() == skills.Length;
    }
}