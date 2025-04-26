using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class SpecialSkillType: ISkillType
{
    public void ApplyEffect(IFighter target, int power)
    {
        SummonPositionMenu positionMenu = new SummonPositionMenu();
        int position = positionMenu.GetPosition();
        Table.GetInstance().Summon(target, position);
    }

    public IAffinityController GetTargetAffinity(IFighter target)
    {
        return new WeakAffinity();
    }

    public string ToString(IFighter target, int power)
    {
        return $"{target} a sido invocado";
    }
}