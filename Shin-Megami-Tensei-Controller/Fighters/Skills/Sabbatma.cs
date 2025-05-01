using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills;

public class Sabbatma: ISkillController
{
    private BattleView _view = BattleViewSingleton.GetBattleView();
    private Skill _skill;
    private Table _table = Table.GetInstance();

    public Sabbatma(Skill skill) => _skill = skill;
    
    public void UseSkill()
    {
        var reserve = _table.GetCurrentPlayer().GetTeam().GetReserve()
            .Where(fighter => fighter.IsAlive());
        SummonFighterMenu summonMenu = new SummonFighterMenu(reserve);
        IFighter target = summonMenu.GetTarget();
        int atPosition = new SummonPositionMenu().GetPosition();
        _table.Summon(target, atPosition);
        _table.GetTurnManager().ConsumeTurn();
        IFighter currentFighter = _table.GetCurrentFighter();
        currentFighter.SetMp(currentFighter.GetCurrentMp() - _skill.Cost);
        _table.IncreaseCurrentPlayerUsedSkillsCount();
        _view.DisplayCard($"{target.GetUnitData().Name} ha sido invocado");
    }
}