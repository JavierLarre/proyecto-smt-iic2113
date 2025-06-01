using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills;

public class Sabbatma: ISkillController
{
    private SkillData _skillData;
    private Table _table = null!;

    public Sabbatma(SkillData skill) => _skillData = skill;
    
    public void UseSkill(Table table)
    {
        _table = table;
        Summon();
        _table.GetGameState().TurnsModel.ConsumeTurn();
        ConsumeMp();
        _table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private void Summon()
    {
        var summonController = new SummonController(_table);
        var summonablePositions = new SummonablePositionsController(_table);
        summonController.AskUserForTarget();
        int atPosition = summonablePositions.GetPositionFromUser();
        summonController.SummonAt(atPosition);
    }

    private void ConsumeMp()
    {
        IFighterModel currentFighter = _table.GetCurrentFighter();
        currentFighter.SetMp(currentFighter.GetCurrentMp() - _skillData.Cost);
    }
}