namespace Shin_Megami_Tensei_Model;

public static class TableSingleton
{
    private static Table? _tableInstance;
    
    public static Table GetInstance()
    {
        if (_tableInstance is null)
            throw new NullReferenceException();
        return _tableInstance;
    }

    public static void SetTable(IEnumerable<Team> teams)
    {
        _tableInstance = Table.FromTeams(teams);
    }
}