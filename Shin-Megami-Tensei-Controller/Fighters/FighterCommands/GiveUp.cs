using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IFighterCommand
{
    private Table _table;
    private BattleView _view;
    public GiveUp(Table table, BattleView view)
    {
        _table = table;
        _view = view;
    }
    
    public string GetActionName() => "Rendirse";
    public void Execute()
    {
        PlayerView loser = new PlayerView(_table.GetCurrentPlayer());
        throw new GameException($"{loser.GetPlayerName()} (J{loser.GetPlayerNumber()}) se rinde");
    }

    public void Reset()
    {
    }
}