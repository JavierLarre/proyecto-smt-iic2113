using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public static class BattleViewSingleton
{
    private static ConsoleBattleView? _battleViewinstance;

    public static void SetBattleView(View view)
    {
        _battleViewinstance = new ConsoleBattleView(view);
    }

    public static ConsoleBattleView GetBattleView()
    {
        if (_battleViewinstance is null)
            throw new ArgumentNullException();
        return _battleViewinstance;
    }
}