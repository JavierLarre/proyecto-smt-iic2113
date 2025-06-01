using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class Invitation: ISkillController
{
    private SkillData _skillData;
    private Table _table = null!;
    private GameState _gameState;
    private IFighterModel _target = new EmptyFighter();
    private bool _targetWasDead;

    public Invitation(SkillData skill) => _skillData = skill;
    
    public void UseSkill(Table table)
    {
        _table = table;
        _gameState = _table.GetGameState();

        SelectTarget(table);
        _targetWasDead = !_target.GetState().IsAlive;

        Summon();
        HealTarget();
        ConsumeTurn(_gameState.TurnsModel);
        ConsumeMpFromCaster(_gameState.CurrentFighter);
        table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private void HealTarget()
    {
        HealSkillType type = new HealSkillType(_skillData);
        type.SetTarget(_target);
        type.ApplyEffect(_table);
        type.SetCaster(_gameState.CurrentFighter);
        if (!_targetWasDead) return;
        ITypeView actionView = type.GetActionView();
        actionView.Display();
        actionView.DisplayEnding();
    }

    private void Summon()
    {
        int atPosition = GetPositionFromUser(_table);
        new SummonController(_table).SummonAt(_target, atPosition);
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
        var summonPositions = new SummonablePositionsController(table);
        return summonPositions.GetPositionFromUser();
    }

    private void SelectTarget(Table table)
    {
        var reserveTarget = new ReserveTarget();
        _target = reserveTarget.GetTargets(table).First();
    }
}