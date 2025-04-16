using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

namespace Shin_Megami_Tensei_View.Views.ConsoleView;

public class PlayerView
{
    private readonly Player _player;
    private readonly TeamView _team;

    public PlayerView(Player player)
    {
        _player = player;
        _team = new TeamView(player.Team);
    }

    public int GetPlayerNumber() => _player.PlayerNumber + 1;
    public string GetPlayerName() => _team.GetLeaderName();

    public string GetBanner()
    {
        return $"Equipo de {GetPlayerName()} (J{GetPlayerNumber()})"
               + '\n' + _team.GetFightersInfo();
    }

}