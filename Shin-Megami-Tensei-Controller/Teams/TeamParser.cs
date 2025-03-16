using System.Text.RegularExpressions;
using Shin_Megami_Tensei.Monsters;
using Shin_Megami_Tensei.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class TeamParser
{
    public List<Samurai> Samurais;
    public List<Monster> Monsters;
    private string[] Lines;

    public TeamParser(string[] lines)
    {
        Lines = lines;
        DeserializeTeam();
    }
    
    private void DeserializeTeam()
    {
        foreach (string line in Lines)
        {
            AddEntity(line);
        }
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

    private void AddMonster(string line)
    {
        Monsters.Add(new Monster(line));
    }

    private void AddSamurai(string line)
    {
        Samurai samurai = new Samurai(GetSamuraiName(line));
        Samurais.Add(samurai);
        string[] skills = GetSkills(line);
        samurai.AddSkills(skills);
    }

    private string GetSamuraiName(string line)
    {
        Regex pattern = new Regex(@"^\[Samurai\] (?<name>\w+)$");
        Match match = pattern.Match(line);
        return match.Groups["name"].Value;
    }

    private string[] GetSkills(string line)
    {
        Regex pattern = new Regex(@"^\[Samurai\] \w+ \(([^)]+)\)$");
        Match match = pattern.Match(line);
        return match.Groups["name"].Value.Split(",");
    }
}