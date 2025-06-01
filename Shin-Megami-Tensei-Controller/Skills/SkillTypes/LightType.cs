using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class LightType: ISkillType
{
    public void SetTarget(IFighterModel target)
    {
        throw new NotImplementedException();
    }

    public void ApplyEffect(Table table)
    {
        throw new NotImplementedException();
    }

    public IAffinityController GetAffinityFrom(IFighterModel target)
    {
        throw new NotImplementedException();
    }

    public ITypeView GetActionView()
    {
        throw new NotImplementedException();
    }
}