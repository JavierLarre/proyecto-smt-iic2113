using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Skills.SpecialCases;

public class BadCompany: ISkillController
{
    private SkillData _skillData;
    private ICollection<IFighterModel> _reserve = [];
    private IFighterModel _strongestFighter = new EmptyFighter();
    private int _summonPosition;

    public BadCompany(SkillData skillData) => _skillData = skillData;
    public void UseSkill(Table table)
    {
        GameState gameState = table.GetGameState();
        _reserve = gameState.CurrentPlayerState.TeamState.AliveReserve;

        GetStrongestFighterFromReserve();
        GetSummonPositionFromUser(table);
        ConsumeMp(gameState);
        SummonStrongestFighter(table);
        ConsumeTurns(gameState.TurnsModel);
        table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private void SummonStrongestFighter(Table table)
    {
        var summonController = new SummonController(table);
        summonController.SummonAt(_strongestFighter, _summonPosition);
    }

    private void ConsumeMp(GameState gameState)
    {
        IFighterModel currentFighter = gameState.CurrentFighter;
        currentFighter.SetMp(currentFighter.GetState().CurrentMp - _skillData.Cost);
    }

    private static void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeTurn();
    }

    private void GetStrongestFighterFromReserve()
    {
        try
        {
            TrySaveStrongestFighter();
        }
        catch (InvalidOperationException e)
        {
            throw new OptionException(e.Message);
        }
    }

    private void TrySaveStrongestFighter()
    {
        foreach (IFighterModel model in _reserve)
        {
            Console.WriteLine(model.GetState().Name);
            Console.WriteLine(model.GetState().FilePriority);
            Console.WriteLine(model.GetState().Stats.Str);
        }

        IFighterModel? strongestFighter = _reserve.MaxBy(fighter => fighter.GetState().Stats.Str);
        if (strongestFighter is null) 
            throw new InvalidOperationException();
        _strongestFighter = strongestFighter;
    }

    private void GetSummonPositionFromUser(Table table)
    {
        var positionsController = new SummonablePositionsController(table);
        _summonPosition = positionsController.GetPositionFromUser();
    }
}