using System.Text.RegularExpressions;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class TeamParser
{
    public readonly List<Samurai> Samurais = [];
    public readonly List<Monster> Monsters = [];
    private readonly IEnumerable<string> _lines;

    public static TeamParser FromTextLines(IEnumerable<string> lines)
        => new (lines);
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
        Monsters.Add(MonsterFactory.FromName(name));
    }

    private void AddSamurai(string line)
    {
        string name = GetSamuraiName(line);
        string[] skills = GetSamuraiSkills(line);
        Samurai samurai = SamuraiFactory.FromName(name);
        samurai.SetSkills(skills);
        Samurais.Add(samurai);
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