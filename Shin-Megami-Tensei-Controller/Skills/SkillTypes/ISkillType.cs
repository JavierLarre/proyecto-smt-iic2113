using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public interface ISkillType
{
    public void SetTarget(IFighterModel target);
    public void ApplyEffect(Table table);
    public IAffinityController GetAffinityFrom(IFighterModel target);
    public ITypeView GetActionView();
}