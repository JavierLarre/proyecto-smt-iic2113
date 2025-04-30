using System.IO.Pipes;

namespace Shin_Megami_Tensei_Model;

public class TurnManager: AbstractModel
{
    private int _fullTurns;
    private int _blinkingTurns;
    private int _gainedBlinking;
    private int _consumedFull;
    private int _consumedBlinking;

    public TurnManager()
    {
    }

    public TurnManager(int initialTurns)
    {
        _fullTurns = initialTurns;
    }

    public void Reset(int initialFullTurns)
    {
        if (initialFullTurns == 0)
            throw new ArgumentException("Initial Full Turns can't be zero");
        _fullTurns = initialFullTurns;
        _blinkingTurns = 0;
        _consumedFull = 0;
        _consumedBlinking = 0;
        _gainedBlinking = 0;
    }

    public void ConsumeTurn()
    {
        if (HasBlinking())
            _consumedBlinking++;
        else
            if (HasFull())
                _consumedFull++;
    }

    public void ConsumeFullAndGain()
    {
        if (HasFull())
        {
            _consumedFull++;
            _gainedBlinking++;
        }
        else
        {
            _consumedBlinking++;
        }
    }

    private bool HasFull()
    {
        return _fullTurns - _consumedFull > 0;
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
        int fullLeft = _fullTurns - _consumedFull;
        int blinkingLeft = _blinkingTurns + _gainedBlinking - _consumedBlinking;
        return fullLeft + blinkingLeft > 0;
    }

    private bool HasBlinking()
    {
        return _blinkingTurns + _gainedBlinking - _consumedBlinking > 0;
    }

    private void GainTurn() => _gainedBlinking++;


    public void SaveTurns()
    {
        _fullTurns = int.Max(0, _fullTurns - _consumedFull);
        _blinkingTurns += _gainedBlinking;
        _blinkingTurns = int.Max(0, _blinkingTurns - _consumedBlinking);
        _gainedBlinking = 0;
        _consumedFull = 0;
        _consumedBlinking = 0;
    }
    
    public int GetFullTurns() => _fullTurns;
    public int GetBlinkingTurns() => _blinkingTurns;

    public override string ToString()
    {
        string consumedFull = $"Se han consumido {_consumedFull} Full Turn(s)";
        string consumedBlinking = $" y {_consumedBlinking} Blinking Turn(s)";
        string gainedTurns = $"Se han obtenido {_gainedBlinking} Blinking Turn(s)";
        return consumedFull + consumedBlinking + '\n' + gainedTurns;
    }
}