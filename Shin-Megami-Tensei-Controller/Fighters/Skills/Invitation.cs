using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.Skills;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class Invitation: ISkillController
{
    private SkillData _skillData;

    public Invitation(SkillData skill) => _skillData = skill;
    
    public void UseSkill(Table table)
    {
        GameState gameState = table.GetGameState();
        IFighterModel caster = gameState.CurrentFighter;

        IFighterModel target = GetTarget();
        bool wasDead = !target.GetState().IsAlive;
        int atPosition = GetPositionFromUser(table);
        new SummonController(table).SummonAt(target, atPosition);
        
        SupportiveSkillType type = new ReviveSkillType();
        type.ApplyEffect(target, _skillData.Power);
        if (wasDead)
            type.Display(caster, target);

        ConsumeTurn(gameState.TurnsModel);
        ConsumeMpFromCaster(caster);
        table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private void ConsumeMpFromCaster(IFighterModel currentFighter)
    {
        int newMp = currentFighter.GetState().CurrentMp - _skillData.Cost;
        currentFighter.SetMp(newMp);
    }

    private void ConsumeTurn(TurnsModel turnsModel)
    {
        turnsModel.ConsumeTurn();
    }

    private int GetPositionFromUser(Table table)
    {
        return new SummonablePositionsController(table).GetPositionFromUser();
    }

    private IFighterModel GetTarget()
    {
        return new ReserveTarget().GetTargets().First();
    }
}