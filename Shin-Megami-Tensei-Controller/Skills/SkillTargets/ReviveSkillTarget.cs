using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class ReviveSkillTarget: ISkillTargets
{
    private IFighterModel? _target;
    
    public ICollection<IFighterModel> GetTargets()
    {
        if (_target is null)
            InitializeTarget();
        return [_target!];
    }

    private void InitializeTarget()
    {
        Table table = Table.GetInstance();
        Team team = table.GetCurrentPlayer().GetTeam();
        var deadUnits = team.GetReserve().
            Where(fighter => !fighter.IsAlive()).ToList();
        if (!team.GetLeader().IsAlive())
            deadUnits.Insert(0, team.GetLeader());
        ReviveMenu menu = new ReviveMenu(deadUnits);
        _target = menu.GetTarget();
    }
}