using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class PhysAttack: IFighterCommand
{
    private const double PhysicalDamageMultiplier = 0.0114;
    
    protected Table Table = Table.GetInstance();
    protected BattleView View = BattleViewSingleton.GetBattleView();

    public void Execute()
    {
        IFighter reciever = GetTargetFromUser();
        int damage = CalculateDamage();
        reciever.RecieveDamage(damage);
        PrintAttack(reciever);
    }

    protected abstract int Modifier();
    protected abstract int FighterStat();
    protected abstract void PrintAttack(IFighter reciever);

    protected IFighter GetAttacker() => Table.GetCurrentFighter();

    protected int CalculateDamage()
    {
        double damage = FighterStat() * Modifier() * PhysicalDamageMultiplier;
        return (int)Math.Floor(damage);
    }

    private IFighter GetTargetFromUser()
    {
        var targets = Table.GetEnemyTeamAliveTargets().ToList();
        try
        {
            IOptionMenu targetMenu = new TargetMenu(GetAttacker(), targets);
            string targetName = View.GetChoiceFromOptionMenu(targetMenu);
            return targets.First(target => target.GetName() == targetName);
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }
}