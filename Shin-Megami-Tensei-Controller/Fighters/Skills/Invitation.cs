using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class Invitation: ISkillController
{
    private Skill _skill;
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private Table _table = Table.GetInstance();

    public Invitation(Skill skill) => _skill = skill;
    
    public void UseSkill()
    {
        IFighter target = new ReserveTargets().GetTargets().First();
        int atPosition = new SummonPositionMenu().GetPosition();
        ISkillType type = new ReviveSkillType();
        string effectMade = $"{target.GetUnitData().Name} ha sido invocado";
        bool targetWasDead = !target.IsAlive();
        type.ApplyEffect(target, _skill.Power);
        if (targetWasDead)
        {
            effectMade += '\n' + type.ToString(target, _skill.Power);
            effectMade += '\n' + FighterViewFactory.FromFighter(target).GetHpEndedWith();
        }

        _view.DisplayCard(effectMade);
        _table.GetTurnManager().ConsumeTurn();
        IFighter currentFighter = _table.GetCurrentFighter();
        currentFighter.SetMp(currentFighter.GetCurrentMp() - _skill.Cost);
        _table.Summon(target, atPosition);
        _table.IncreaseCurrentPlayerUsedSkillsCount();
    }
}