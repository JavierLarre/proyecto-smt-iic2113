
using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills;

public class TargetCycler
{
    private IFighterModel[] _targets;
    private int _aliveEnemyTargetsAmount;
    private int _currentIndex;
    private int _direction;

    public TargetCycler(Table table, ICollection<IFighterModel> targets)
    {
        GameState gameState = table.GetGameState();
        SetAmountOfTargets(gameState);
        SetIndex(gameState);
        SetDirection();
        _targets = targets.ToArray();
    }

    public IEnumerable<IFighterModel> GetAttackOrder(int hits)
    {
        do
        {
            yield return _targets[_currentIndex];
            _currentIndex += _direction;
            _currentIndex = int.Max(0, _currentIndex);
            _currentIndex = int.Min(_aliveEnemyTargetsAmount - 1, _currentIndex);
        } while (hits-- > 0);
    }

    private void SetIndex(GameState gameState)
    {
        int usedSkills = gameState
            .CurrentPlayerState
            .UsedSkills;
        _currentIndex = usedSkills % _aliveEnemyTargetsAmount;
    }

    private void SetAmountOfTargets(GameState gameState)
    {
        _aliveEnemyTargetsAmount = gameState
            .EnemyPlayerState
            .TeamState
            .AliveTargets
            .Count;
    }

    private void SetDirection()
    {
        if (_currentIndex % 2 == 0)
            _direction = 1;
        else
            _direction = -1;
    }
}