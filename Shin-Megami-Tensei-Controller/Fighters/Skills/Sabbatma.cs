using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills;

public class Sabbatma: ISkillController
{
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private SkillData _skillData;
    private Table _table = Table.GetInstance();

    public Sabbatma(SkillData skill) => _skillData = skill;
    
    public void UseSkill()
    {
        //todo: esto deberia ocupar invoke
        var reserve = GetReserve();
        SummonFighterMenu summonMenu = new SummonFighterMenu(reserve);
        IFighterModel target = summonMenu.GetTarget();
        int atPosition = new SummonPositionsMenu(new SummonablePositionsController().GetPositions()).GetPosition();
        _table.Summon(target, atPosition);
        _table.GetTurnManager().ConsumeTurn();
        IFighterModel currentFighter = _table.GetCurrentFighter();
        currentFighter.SetMp(currentFighter.GetCurrentMp() - _skillData.Cost);
        _table.IncreaseCurrentPlayerUsedSkillsCount();
        _view.DisplayCard($"{target.GetUnitData().Name} ha sido invocado");
    }

    //todo: esto deberia ser compartido por abstract invoke
    private IEnumerable<IFighterModel> GetReserve()
    {
        return _table.GetCurrentPlayer().GetTeam().GetReserve()
            .Where(fighter => fighter.IsAlive());
    }
}