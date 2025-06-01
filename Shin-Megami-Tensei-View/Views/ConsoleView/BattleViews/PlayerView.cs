using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView;

public class PlayerView: IView
{
    private readonly TeamView _team;
    private int _playerNumber;
    private string _leaderName;

    public PlayerView(Player player)
    {
        PlayerState playerState = player.GetPlayerState();
        _playerNumber = playerState.PlayerNumber + 1;
        _team = new TeamView(playerState.Team);
        _leaderName = _team.GetLeaderName();
    }

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.WriteLine($"Equipo de {GetPlayerNameAndNumber()}");
        view.WriteLine(_team.GetFightersInfo());
    }

    public string GetPlayerNameAndNumber()
    {
        return $"{_leaderName} (J{_playerNumber})";
    }
}