namespace Shin_Megami_Tensei_Model;

public class Table: AbstractModel, IModelObserver
{
    // Tambien puedes interpretarlo como la clase game
    private readonly TurnsModel _turnsModel = new();
    private readonly FightOrder _fightOrder = new FightOrder();
    private Player _currentPlayer;
    private Player _enemyPlayer;

    public Table(Player player1, Player player2)
    {
        _currentPlayer = player1;
        _enemyPlayer = player2;
        ResetFightOrder();
        SubscribeToTeams();
    }
    
    public GameState GetGameState()
    {
        PlayerState currentPlayer = _currentPlayer.GetPlayerState();
        PlayerState enemyPlayer = _enemyPlayer.GetPlayerState();
        return new GameState
        {
            CurrentPlayer = _currentPlayer,
            EnemyPlayer = _enemyPlayer,
            CurrentPlayerState = currentPlayer,
            EnemyPlayerState = enemyPlayer,
            CurrentFighter = _fightOrder.GetCurrentFighter(),
            FightersInTurnOrder = _fightOrder.GetFightersInTurnOrder(),
            TurnsModel = _turnsModel,
            TurnsData = _turnsModel.GetTurnsData(),
        };
    }

    public void IncreaseCurrentPlayerUsedSkillsCount()
    {
        _currentPlayer.IncreaseUsedSkills();
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

    private void SubscribeToTeams()
    {
        SubscribeToTeam(_currentPlayer.GetPlayerState().Team);
        SubscribeToTeam(_enemyPlayer.GetPlayerState().Team);
    }

    private void SubscribeToTeam(Team team)
    {
        team.AddObserver(this);
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