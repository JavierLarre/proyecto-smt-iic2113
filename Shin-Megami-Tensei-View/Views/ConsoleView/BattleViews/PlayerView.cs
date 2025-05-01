using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView;

public class PlayerView: IView
{
    private readonly Player _player;
    private readonly TeamView _team;

    public PlayerView(Player player)
    {
        _player = player;
        _team = new TeamView(player.GetTeam());
    }

    public int GetPlayerNumber() => _player.GetPlayerNumber() + 1;
    public string GetPlayerName() => _team.GetLeaderName();

    public string GetPlayerNameAndNumber()
    {
        return $"{GetPlayerName()} (J{GetPlayerNumber()})";
    }

    public string GetBanner()
    {
        return $"Equipo de {GetPlayerName()} (J{GetPlayerNumber()})"
               + '\n' + _team.GetFightersInfo();
    }

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.DisplayCard($"Equipo de {GetPlayerNameAndNumber()}");
        view.WriteLine(_team.GetFightersInfo());
    }

}