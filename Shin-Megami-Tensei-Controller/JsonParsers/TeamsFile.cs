namespace Shin_Megami_Tensei.Teams;

public class TeamsFile
{
    private readonly string[] _lines;
    private readonly IEnumerable<TeamParser> _parsers;

    public TeamsFile(string filePath)
    {
        _lines = File.ReadAllLines(filePath);
        _parsers = GetParsers();
    }

    public bool IsFileValid()
    {
        var checkers = _parsers
            .Select(TeamChecker.FromParser);
        return checkers.All(checker => checker.IsValid());
    }

    public Team[] GetTeams()
    {
        return _parsers
            .Select(Team.FromParser)
            .ToArray();
    }

    private IEnumerable<TeamParser> GetParsers()
    {
        int teamOneLength = Array.IndexOf(_lines, "Player 2 Team");
        string[] teamOneLines = _lines[1..teamOneLength];
        string[] teamTwoLines = _lines[(teamOneLength + 1) .. _lines.Length];
        return [
            TeamParser.FromTextLines(teamOneLines),
            TeamParser.FromTextLines(teamTwoLines)
        ];
    }
}