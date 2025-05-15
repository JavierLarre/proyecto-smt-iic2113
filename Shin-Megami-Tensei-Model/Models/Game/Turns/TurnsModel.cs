using System.IO.Pipes;

namespace Shin_Megami_Tensei_Model;

public class TurnsModel: AbstractModel
{
    private TurnsData _turns;

    public void Reset(int initialFullTurns)
    {
        _turns = new TurnsData();
        if (initialFullTurns == 0)
            throw new ArgumentException("Initial Full Turns can't be zero");
        _turns.FullTurns = initialFullTurns;
    }

    public TurnsData GetTurns() => _turns;
    

    public void ConsumeTurn()
    {
        if (HasBlinking())
            _turns.ConsumedBlinking++;
        else
            if (HasFull())
                _turns.ConsumedFull++;
    }

    public void ConsumeFullAndGain()
    {
        if (HasFull())
        {
            _turns.ConsumedFull++;
            _turns.GainedBlinking++;
        }
        else
        {
            _turns.ConsumedBlinking++;
        }
    }

    private bool HasFull()
    {
        return _turns.FullTurns - _turns.ConsumedFull > 0;
    }

    public void ConsumeAndGainTurn()
    {
        bool didNotHadBlinking = !HasBlinking();
        ConsumeTurn();
        if (didNotHadBlinking)
            GainTurn();
    }

    public void ConsumeAll()
    {
        while(HasTurnsLeft())
            ConsumeTurn();
    }

    private bool HasTurnsLeft()
    {
        int fullLeft = _turns.FullTurns - _turns.ConsumedFull;
        int blinkingLeft = _turns.BlinkingTurns + _turns.GainedBlinking - _turns.ConsumedBlinking;
        return fullLeft + blinkingLeft > 0;
    }

    private bool HasBlinking()
    {
        return _turns.BlinkingTurns + _turns.GainedBlinking - _turns.ConsumedBlinking > 0;
    }

    private void GainTurn() => _turns.GainedBlinking++;
    
    public void SaveTurns()
    {
        int fullTurnsLeft = _turns.FullTurns - _turns.ConsumedFull;
        int blinkingTurnsLeft = _turns.BlinkingTurns - _turns.ConsumedBlinking;
        blinkingTurnsLeft += _turns.GainedBlinking;
        _turns.FullTurns = int.Max(0, fullTurnsLeft);
        _turns.BlinkingTurns = int.Max(0, blinkingTurnsLeft);
        _turns.GainedBlinking = 0;
        _turns.ConsumedFull = 0;
        _turns.ConsumedBlinking = 0;
    }
}