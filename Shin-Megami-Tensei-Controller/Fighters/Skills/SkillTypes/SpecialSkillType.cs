using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class SpecialSkillType: ISkillType
{
    Table _table = Table.GetInstance();
    
    public void ApplyEffect(IFighterModel target, int power)
    {
        throw new ArgumentException("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        // TODO: oportunidad de refactorizar aquí
        // new SamuraiInvoke().Execute();
        Summon(target);
    }

    private void Summon(IFighterModel target)
    {
        int atPosition = GetSummonPosition();
        _table.Summon(target, atPosition);
    }
    
    private int GetSummonPosition()
    {
        var targets = new SummonablePositionsController().GetPositions();
        SummonPositionsMenu positionsMenu = new SummonPositionsMenu(targets);
        return positionsMenu.GetPosition();
    }

    public IAffinityController GetTargetAffinity(IFighterModel target)
    {
        return new WeakAffinity();
        // Invocar da 
    }

    public string ToString(IFighterModel target, int power)
    {
        return $"{target} a sido invocado";
    }
}