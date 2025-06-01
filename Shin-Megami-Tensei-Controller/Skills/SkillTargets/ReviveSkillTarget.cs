using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class ReviveSkillTarget: ISkillTargets
{
    private SingleFighterMenuController? _controller;
    
    public ICollection<IFighterModel> GetTargets(Table table)
    {
        if (_controller is null)
        {
            InitializeController(table);
        }
        return [_controller!.GetTarget()];
    }

    private void InitializeController(Table table)
    {
        GameState gameState = table.GetGameState();
        var deadFighters = gameState
            .CurrentPlayerState
            .TeamState
            .DeadFighters;
        ReviveMenu menu = new ReviveMenu(gameState, deadFighters);
        _controller = new SingleFighterMenuController(menu);
        _controller.SetFighters(deadFighters);
    }
}