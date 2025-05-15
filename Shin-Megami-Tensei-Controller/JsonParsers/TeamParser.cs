using System.Text.RegularExpressions;
using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Teams;

public class TeamParser
{
    private readonly List<IFighterModel> _fighters = [];
    private readonly IEnumerable<string> _lines;
    private readonly SamuraiFactory _samuraiFactory = new ();
    private readonly DemonFactory _demonFactory = new DemonFactory();

    public static TeamParser FromTextLines(IEnumerable<string> lines)
        => new (lines);

    public IEnumerable<IFighterModel> GetFighters()
    {
        return _fighters;
    }

    public Team GetTeam()
    {
        TeamBuilder teamBuilder = new TeamBuilder();
        return teamBuilder.FromFighters(_fighters);
    }
    private TeamParser(IEnumerable<string> lines)
    {
        _lines = lines;
        DeserializeTeam();
    }
    
    private void DeserializeTeam()
    {
        foreach (string line in _lines)
            AddEntity(line);
    }

    private void AddEntity(string line)
    {
        if (line.Contains("[Samurai]"))
            AddSamurai(line);
        else
        {
            AddMonster(line);
        }
    }

    private void AddMonster(string name)
    {
        _fighters.Add(_demonFactory.BuildFromName(name));
    }

    private void AddSamurai(string line)
    {
        string name = GetSamuraiName(line);
        string[] skills = GetSamuraiSkills(line);
        IFighterModel samurai = _samuraiFactory.BuildFromNameAndSkills(name, skills);
        _fighters.Add(samurai);
    }

    private static string GetSamuraiName(string line)
    {
        Regex pattern = new Regex(@"^\[Samurai\] (?<name>[A-Za-z\-]+)");
        Match match = pattern.Match(line);
        return match.Groups["name"].Value;
    }

    private static string[] GetSamuraiSkills(string line)
    {
        Regex skillPattern = new Regex(@"^\[Samurai\] [A-Za-z\-]+ \((?<skills>[A-Za-z\-,\s]+)\)");
        Match match = skillPattern.Match(line);
        return match.Groups["skills"].Value.Split(",");
    }
}