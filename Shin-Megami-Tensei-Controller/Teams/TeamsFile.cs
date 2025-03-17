namespace Shin_Megami_Tensei.Teams;

public class TeamsFile
{
    private string[] Lines;
    private TeamParser[] Parsers;

    public TeamsFile(string filePath)
    {
        Lines = File.ReadAllLines(filePath);
        Parsers = GetParsers();
    }

    public bool IsFileValid()
    {
        TeamChecker[] checkers = Parsers
            .Select(parser => new TeamChecker(parser))
            .ToArray();
        return checkers.All(checker => checker.IsValid());
    }

    public Team[] GetTeams()
    {
        return Parsers
            .Select(parser => new Team(parser))
            .ToArray();
    }

    private TeamParser[] GetParsers()
    {
        int teamOneLength = Array.IndexOf(Lines, "Player 2 Team");
        string[] teamOneLines = Lines[1..teamOneLength];
        string[] teamTwoLines = Lines[(teamOneLength + 1) .. Lines.Length];
        return [
            new TeamParser(teamOneLines),
            new TeamParser(teamTwoLines)
        ];
    }
}