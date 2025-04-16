using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Battles;

public class BattleView
{
    private readonly View _view;
    private readonly TableView _tableView;

    public BattleView(Table table, View view)
    {
        _tableView = new TableView(table);
        _view = view;
    }

    public void WriteLines(IEnumerable<string> lines)
    {
        PrintIndent();
        foreach (var line in lines)
            _view.WriteLine(line);
    }

    public void WriteLine(string line)
    {
        PrintIndent();
        _view.WriteLine(line);
    }

    public void PrintWinner()
    {
        WriteLine(_tableView.GetWinner());
    }

    public void StartRound() =>
        WriteLine($"Ronda de {_tableView.GetCurrentPlayerName()} " +
                  $"(J{_tableView.GetCurrentPlayerNumber()})");

    public void StartTurn()
    {
        WriteLine(_tableView.GetCurrentInfo());
        WriteLine(_tableView.GetCurrentPlayerTurns());
        WriteLine("Orden:\n" + _tableView.GetCurrentPlayerFightOrder());
    }

    public void PrintConsumedAndObtainedTurns()
    {
        string consumed = $"Se han consumido 1 Full Turn(s)"
                          + $" y 0 Blinking Turn(s)";
        string gained = $"Se han obtenido 0 Blinking Turn(s)";
        WriteLine(consumed + '\n' + gained);
    }

    public string GetInputFromUser() => _view.ReadLine();
    
    //TODO: separar cada menú en su propia clase

    public string GetActionFromUser()
    {
        IFighterView currentFighter = _tableView.GetFighterInTurn();
        IOptionMenu actionMenu = OptionFactory.BuildActionMenu(currentFighter, this);
        IOptionMenu choosenAction = actionMenu.GetOption();
        return choosenAction.ToString();
    }

    public string GetTargetFromUser()
    {
        IFighterView currentFighter = _tableView.GetFighterInTurn();
        List<IFighterView> targets = _tableView.GetEnemyTeamTargets().ToList();
        IOptionMenu targetMenu = OptionFactory.BuildTargetMenu(currentFighter, this, targets);
        IOptionMenu choosenTarget = targetMenu.GetOption();
        int optionIndex = targetMenu.GetOptionIndex(choosenTarget);
        if (choosenTarget.ToString() == "Cancelar")
            throw new OptionException("Cancelado");
        return targets[optionIndex].GetName();
    }

    public string GetSkillFromUser()
    {
        IFighterView currentFighter = _tableView.GetFighterInTurn();
        IOptionMenu skillMenu = OptionFactory.BuildSkillMenu(currentFighter.GetFighter(), this);
        IOptionMenu choosenSkill = skillMenu.GetOption();
        if (choosenSkill.ToString() == "Cancelar")
            throw new OptionException("Cancelado");
        return currentFighter.GetSkills().Skills
            .First(skill => SkillsView.GetSkillInfo(skill) == choosenSkill.ToString()).Name;
    }

    private void PrintIndent()
    {
        string indent = new('-', 40);
        _view.WriteLine(indent);
    }
}