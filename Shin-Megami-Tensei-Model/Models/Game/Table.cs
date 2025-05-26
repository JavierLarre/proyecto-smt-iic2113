namespace Shin_Megami_Tensei_Model;

public class Table: AbstractModel
{
    // Tambien puedes interpretarlo como la clase game
    private static Table Singleton;
    private Player _currentPlayer;
    private Player _enemyPlayer;
    private readonly TurnsModel _turnsModel = new();
    private LinkedList<IFighterModel> _fightOrder = [];

    public Table(Player player1, Player player2)
    {
        _currentPlayer = player1;
        _enemyPlayer = player2;
        ResetFightOrder();
        ResetTurns();
        Singleton = this;
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
        return new GameState
        {
            CurrentPlayer = GetCurrentPlayer(),
            CurrentTeam = GetCurrentPlayer().GetTeam(),
            EnemyPlayer = GetEnemyPlayer(),
            EnemyTeam = GetEnemyPlayer().GetTeam(),
            CurrentFighter = _fightOrder.First(),
            EnemyTeamAliveTargets = GetEnemyTeamAliveTargets().ToList(),
            FightersInTurnOrder = _fightOrder,
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
        _turnsModel.SaveTurns();
    }

    public void EndRound()
    {
        SwapPlayers();
        ResetFightOrder();
        ResetTurns();
    }

    private void ResetFightOrder()
    {
        var fightOrder = _currentPlayer.GetTeam().GetFightOrder(); 
        _fightOrder = new LinkedList<IFighterModel>(fightOrder);
        _turnsModel.Reset(_fightOrder.Count);
    }

    private void ResetTurns()
    {
        _turnsModel.Reset(_fightOrder.Count);
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