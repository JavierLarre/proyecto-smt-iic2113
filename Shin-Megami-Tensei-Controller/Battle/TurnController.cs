using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Battles;

public class TurnController
{
    private Table _table = Table.GetInstance();
    private TurnManager _turnManager;

    public TurnController()
    {
        _turnManager = _table.GetTurnManager();
    }

    public void PlayTurn()
    {
        
    }
}