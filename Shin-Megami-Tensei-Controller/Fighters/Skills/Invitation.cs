using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class Invitation: ISkillController
{
    private SkillData _skillData;
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private Table _table = null!;

    public Invitation(SkillData skill) => _skillData = skill;
    
    public void UseSkill(Table table)
    {
        _table = table;
        IFighterModel target = new ReserveTarget().GetTargets().First();
        FighterState targetState = target.GetState();
        var summonablePositions = new SummonablePositionsController(_table);
        int atPosition = summonablePositions.GetPositionFromUser();
        ISkillType type = new ReviveSkillType();
        string effectMade = $"{targetState.Name} ha sido invocado";
        bool targetWasDead = !targetState.IsAlive;
        type.ApplyEffect(target, _skillData.Power);
        if (targetWasDead)
        {
            effectMade += '\n' + type.ToString(target, _skillData.Power);
            effectMade += '\n' + new FighterView(target).GetHpEndedWith();
        }

        _view.DisplayCard(effectMade);
        _table.GetTurnManager().ConsumeTurn();
        IFighterModel currentFighter = _table.GetCurrentFighter();
        currentFighter.SetMp(currentFighter.GetCurrentMp() - _skillData.Cost);
        _table.Summon(target, atPosition);
        _table.IncreaseCurrentPlayerUsedSkillsCount();
    }
}