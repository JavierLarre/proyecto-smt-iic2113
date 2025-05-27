namespace Shin_Megami_Tensei_Model;

public class Table: AbstractModel, IModelObserver
{
    // Tambien puedes interpretarlo como la clase game
    private static Table Singleton;
    private Player _currentPlayer;
    private Player _enemyPlayer;
    private readonly TurnsModel _turnsModel = new();
    private readonly FightOrder _fightOrder = new FightOrder();

    public Table(Player player1, Player player2)
    {
        _currentPlayer = player1;
        _enemyPlayer = player2;
        ResetFightOrder();
        Singleton = this;
        SubscribeToTeams();
    }

    private void SubscribeToTeams()
    {
        SubscribeToTeam(_currentPlayer.GetPlayerState().Team);
        SubscribeToTeam(_enemyPlayer.GetPlayerState().Team);
    }

    private void SubscribeToTeam(Team team)
    {
        team.AddObserver(this);
    }

    public static Table GetInstance() => Singleton;
    // Dos críticas de singleton
    // ahora el proyecto depende de este modelo
    // Y agrega una responsabilidad a Table (ergo, rompe SRP)

    public Player GetCurrentPlayer() => _currentPlayer;
    public Player GetEnemyPlayer() => _enemyPlayer;
    public TurnsModel GetTurnManager() => _turnsModel;

    public GameState GetGameState()
    {
        PlayerState currentPlayer = _currentPlayer.GetPlayerState();
        PlayerState enemyPlayer = _enemyPlayer.GetPlayerState();
        // todo: agregar campos a esta edd
        return new GameState
        {
            CurrentPlayer = GetCurrentPlayer(),
            CurrentTeam = currentPlayer.Team,
            EnemyPlayer = GetEnemyPlayer(),
            EnemyTeam = enemyPlayer.Team,
            CurrentFighter = _fightOrder.GetCurrentFighter(),
            EnemyTeamAliveTargets = GetEnemyTeamAliveTargets().ToList(),
            FightersInTurnOrder = _fightOrder.GetFightersInTurnOrder(),
            TurnsModel = _turnsModel,
            TurnsData = _turnsModel.GetTurnsData()
        };
    }

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
        return _fightOrder.GetCurrentFighter();
    }

    public IEnumerable<IFighterModel> GetCurrentPlayerFightOrder()
    {
        return _fightOrder.GetFightersInTurnOrder();
    }

    public IEnumerable<IFighterModel> GetEnemyTeamAliveTargets()
    {
        return _enemyPlayer.GetTeam().GetAliveFront();
    }

    public void Summon(IFighterModel fighter, int atPosition)
    {
        PlayerState currentPlayer = _currentPlayer.GetPlayerState();
        currentPlayer.Team.Summon(fighter, atPosition);
    }

    public void EndTurn()
    {
        _fightOrder.CycleFighters();
        _turnsModel.SaveTurns();
    }

    public void EndRound()
    {
        SwapPlayers();
        ResetFightOrder();
        ResetTurns();
    }

    public void Update()
    {
        PlayerState currentPlayer = _currentPlayer.GetPlayerState();
        _fightOrder.UpdateFightOrderFrom(currentPlayer.Team);
    }

    private void ResetFightOrder()
    {
        Team currentTeam = _currentPlayer.GetPlayerState().Team;
        _fightOrder.SetFightOrderFrom(currentTeam);
        ResetTurns();
    }

    private void ResetTurns()
    {
        _turnsModel.Reset(_fightOrder.Count);
    }

    private void SwapPlayers()
    {
        (_currentPlayer, _enemyPlayer) = (_enemyPlayer, _currentPlayer);
    }
}