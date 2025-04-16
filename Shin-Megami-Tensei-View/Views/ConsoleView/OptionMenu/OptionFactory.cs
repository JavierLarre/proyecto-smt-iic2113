using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public static class OptionFactory
{
    public static IOptionMenu BuildActionMenu(IFighterView fighter, BattleView view)
    {
        IOptionMenu actionMenu = new OptionMenu(view);
        var options = fighter.GetOptions().Select(ToOption);
        actionMenu.SetOptions(options);
        actionMenu.SetMenuView($"Seleccione una acción para {fighter.GetName()}", ": ");
        return actionMenu;
    }

    public static IOptionMenu BuildTargetMenu(IFighterView attacker, BattleView battleView,
        IEnumerable<IFighterView> targets)
    {
        IOptionMenu targetMenu = new OptionMenu(battleView);
        var options = targets
            .Select(target => target.GetInfo())
            .Select(ToOption)
            .ToList();
        options.Add(new CancelOption());
        targetMenu.SetOptions(options);
        targetMenu.SetMenuView($"Seleccione un objetivo para {attacker.GetName()}", "-");
        return targetMenu;
    }

    public static IOptionMenu BuildSkillMenu(IFighter attacker, BattleView view)
    {
        IOptionMenu skillMenu = new OptionMenu(view);
        var options = attacker.GetAvailableSkills()
            .Select(skill => skill.ToString())
            .Select(ToOption).ToList();
        options.Add(new CancelOption());
        skillMenu.SetOptions(options);
        skillMenu.SetMenuView(
            $"Seleccione una habilidad para que {attacker.Name} use",
            "-"
            );
        return skillMenu;
    }

    private static IOptionMenu ToOption(string option) => new Option(option);
}