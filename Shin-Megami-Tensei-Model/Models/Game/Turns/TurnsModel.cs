
namespace Shin_Megami_Tensei_Model;

public class TurnsModel: AbstractModel
{
    private TurnsData _turnsData;

    public void Reset(int initialFullTurns)
    {
        _turnsData = new TurnsData();
        if (initialFullTurns == 0)
            throw new ArgumentException("Initial Full Turns can't be zero");
        _turnsData.FullTurns = initialFullTurns;
    }

    public TurnsData GetTurnsData() => _turnsData;
    
    public void SaveTurns()
    {
        int fullTurnsLeft = _turnsData.FullTurns - _turnsData.ConsumedFull;
        int blinkingTurnsLeft = _turnsData.BlinkingTurns - _turnsData.ConsumedBlinking;
        blinkingTurnsLeft += _turnsData.GainedBlinking;
        _turnsData.FullTurns = int.Max(0, fullTurnsLeft);
        _turnsData.BlinkingTurns = int.Max(0, blinkingTurnsLeft);
        _turnsData.GainedBlinking = 0;
        _turnsData.ConsumedFull = 0;
        _turnsData.ConsumedBlinking = 0;
    }
    

    public void ConsumeTurn()
    {
        if (HasBlinking())
            _turnsData.ConsumedBlinking++;
        else
            if (HasFull())
                _turnsData.ConsumedFull++;
    }

    public void ConsumeFullAndGain()
    {
        if (HasFull())
        {
            _turnsData.ConsumedFull++;
            _turnsData.GainedBlinking++;
        }
        else
        {
            _turnsData.ConsumedBlinking++;
        }
    }

    public void ConsumeAndGainTurn()
    {
        bool didNotHadBlinking = !HasBlinking();
        ConsumeTurn();
        if (didNotHadBlinking)
            GainTurn();
    }

    public void GainTurns(int turns)
    {
        for (int i = 0; i < turns; i++)
        {
            GainTurn();
        }
    }

    public void ConsumeAll()
    {
        while(HasTurnsLeft())
            ConsumeTurn();
    }

    private bool HasTurnsLeft()
    {
        int fullLeft = _turnsData.FullTurns - _turnsData.ConsumedFull;
        int blinkingLeft = _turnsData.BlinkingTurns + _turnsData.GainedBlinking - _turnsData.ConsumedBlinking;
        return fullLeft + blinkingLeft > 0;
    }

    private bool HasFull()
    {
        return _turnsData.FullTurns - _turnsData.ConsumedFull > 0;
    }

    private bool HasBlinking()
    {
        return _turnsData.BlinkingTurns + _turnsData.GainedBlinking - _turnsData.ConsumedBlinking > 0;
    }

    private void GainTurn() => _turnsData.GainedBlinking++;
}