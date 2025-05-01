using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TableInfoView: IView
{
    private readonly Table _table = Table.GetInstance();
    private readonly PlayerView _firstPlayer;
    private readonly PlayerView _secondPlayer;

    public TableInfoView()
    {
        Player firstPlayer = _table.GetCurrentPlayer();
        Player secondPlayer = _table.GetEnemyPlayer();
        if (firstPlayer.GetPlayerNumber() != 0)
            (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
        _firstPlayer = new PlayerView(firstPlayer);
        _secondPlayer = new PlayerView(secondPlayer);
    }

    public string GetCurrentInfo()
    {
        return $"{_firstPlayer.GetBanner()}\n{_secondPlayer.GetBanner()}";
    }

    public void Display()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        view.DisplayCard(_firstPlayer.GetBanner());
        view.WriteLine(_secondPlayer.GetBanner());
    }

    public IFighterView GetFighterInTurn()
    {
        IFighter fighterInTurn = _table.GetCurrentFighter();
        return FighterViewFactory.FromFighter(fighterInTurn);
    }
}