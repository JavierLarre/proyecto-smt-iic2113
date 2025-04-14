using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public static class OptionFactory
{
    public static IOptionMenu BuildMenu(
        string header, string name, string separator,
        IEnumerable<string> options, BattleView view, bool canCancel
        )
    {
        IOptionMenu menu = new OptionMenu(name, view);
        var builtOptions = options.Select(BuildOption).ToList();
        if (canCancel)
            builtOptions.Add(new CancelOption());
        menu.SetOptions(builtOptions, header, separator);
        return menu;
    }

    public static IOptionMenu BuildOption(string option) => new Option(option);
}