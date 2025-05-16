namespace Shin_Megami_Tensei_Model;

public class Table: AbstractModel
{
    // Tambien puedes interpretarlo como la clase game
    private Player _currentPlayer = null!;
    private Player _enemyPlayer = null!;
    private TurnsModel _turnManager = new TurnsModel();
    private LinkedList<IFighterModel> _fightOrder = [];

    private Table()
    {
    }

    private static readonly Table Singleton = new Table();
    public static Table GetInstance() => Singleton;
    // Dos críticas de singleton
    // ahora el proyecto depende de este modelo
    // Y agrega una responsabilidad a Table (ergo, rompe SRP)

    //todo: solo deberia recibir players
    public void SetPlayersFromTeams(IEnumerable<Team> teams)
    {
        List<Player> players = teams
            .Select((team, i) => new Player(i, team))
            .ToList();
        _currentPlayer = players[0];
        _enemyPlayer = players[1];
        _fightOrder = new LinkedList<IFighterModel>(_currentPlayer.GetTeam().GetFightOrder());
        _turnManager.Reset(_fightOrder.Count);
    }

    public Player GetCurrentPlayer() => _currentPlayer;
    public Player GetEnemyPlayer() => _enemyPlayer;
    public TurnsModel GetTurnManager() => _turnManager;

    public void IncreaseCurrentPlayerUsedSkillsCount()
    {
        _currentPlayer.IncreaseUsedSkills();
    }

    public int GetCurrentPlayerUsedSkillsCount()
    {
        return _currentPlayer.GetUsedSkillsCount();
    }

    public IFighterModel GetCurrentFighter()
    {
        return _fightOrder.First();
    }

    public IEnumerable<IFighterModel> GetCurrentPlayerFightOrder()
    {
        return _fightOrder;
    }

    public IEnumerable<IFighterModel> GetEnemyTeamAliveTargets()
    {
        return _enemyPlayer.GetTeam().GetAliveFront();
    }

    public bool HasAnyTeamLost()
    {
        //todo: mover a su propia clase
        var currentAliveUnits = _currentPlayer.GetTeam().GetAliveFront();
        var enemyAliveUnits = _enemyPlayer.GetTeam().GetAliveFront();
        bool currentHasAliveUnits = currentAliveUnits.Any();
        bool enemyHasAliveUnits = enemyAliveUnits.Any();
        return !currentHasAliveUnits || !enemyHasAliveUnits;
    }

    public void Summon(IFighterModel fighter, int atPosition)
    {
        //todo: usar modelo para actualizar fight order
        IFighterModel previousFighter = _currentPlayer.GetTeam().GetFrontRow().ToArray()[atPosition];
        _currentPlayer.GetTeam().Summon(fighter, atPosition);
        UpdateFightOrder(previousFighter, fighter);
    }

    public void EndTurn()
    {
        IFighterModel playedFighter = _fightOrder.First();
        _fightOrder.RemoveFirst();
        _fightOrder.AddLast(playedFighter);
        _turnManager.SaveTurns();
    }

    public void EndRound()
    {
        if (HasAnyTeamLost())
            return;
        SwapPlayers();
        var fightOrder = _currentPlayer.GetTeam().GetFightOrder();
        _fightOrder = new LinkedList<IFighterModel>(fightOrder);
        _turnManager.Reset(_fightOrder.Count);
    }

    public Player GetWinner()
    {
        var enemyFighters = GetEnemyTeamAliveTargets();
        bool enemyHasUnits = enemyFighters.Any();
        return enemyHasUnits ? _enemyPlayer : _currentPlayer;
    }

    private void UpdateFightOrder(IFighterModel previousFighter, IFighterModel newFighter)
    {
        var node = _fightOrder.Find(previousFighter);
        if (node is null)
        {
            _fightOrder.AddLast(newFighter);
            return;
        }
        _fightOrder.AddAfter(node, newFighter);
        _fightOrder.Remove(previousFighter);
    }

    private void SwapPlayers()
    {
        (_currentPlayer, _enemyPlayer) = (_enemyPlayer, _currentPlayer);
    }
}