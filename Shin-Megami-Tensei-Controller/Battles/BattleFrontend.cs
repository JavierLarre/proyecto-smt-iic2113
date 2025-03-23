using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleFrontend(Table table, View view)
{
    private readonly string _indent = new('-', 40);
    private int PlayerTurnForPrinting => table.PlayerTurn + 1;

    public void WriteLines(IEnumerable<string> lines)
    {
        PrintIndent();
        foreach (var line in lines)
            view.WriteLine(line);
    }

    public void WriteLine(string line)
    {
        PrintIndent();
        view.WriteLine(line);
    }

    private void PrintIndent() => view.WriteLine(_indent);

    public void PrintWinner()
    {
        Team winner = table.GetWinner();
        int player = table.GetPlayerFromTeam(winner);
        WriteLine($"Ganador: {winner.Samurai.Name} (J{player + 1})");
    }

    public void StartRound() =>
        WriteLine($"Ronda de {table.CurrentTeam.Samurai.Name} " +
                  $"(J{PlayerTurnForPrinting})");

    public void StartTurn()
    {
        WriteLine(table.PrintInfo());
        PrintTurnsLeft();
        PrintTeamInOrder();
    }

    private void PrintTurnsLeft() =>
        WriteLines([
            $"Full Turns: {table.TurnsLeft}",
            "Blinking Turns: 0"
        ]);

    private void PrintTeamInOrder()
    {
        var fighterNames = table.GetFightOrder()
            .ToArray()
            .Select((fighter, i) => $"{i + 1}-{fighter.Name}")
            .ToList();
        fighterNames.Insert(0, "Orden:");
        WriteLines(fighterNames);
    }

    public void EndTurn() =>
        WriteLines([
            "Se han consumido 1 Full Turn(s) y 0 Blinking Turn(s)",
            "Se han obtenido 0 Blinking Turn(s)"
        ]);


    public IAction ChooseActionFromUser(Fighter fighter)
    {
        ShowActionsToUser(fighter);
        return GetActionFromUser(fighter);
    }

    private void ShowActionsToUser(Fighter fighter)
    {
        List<string> actionStrings = fighter.Actions
            .Select((action, i) => $"{i + 1}: {action}")
            .ToList();
        actionStrings.Insert(0, $"Seleccione una acción para {fighter.Name}");
        WriteLines(actionStrings);
    }

    private IAction GetActionFromUser(Fighter fighter)
    {
        int selection = 0;
        while (!(selection > 0 && selection <= fighter.Actions.Length))
            selection = ReadNumber();

        return fighter.Actions[selection - 1];
    }

    public Skill? ChooseSkillFromUser(Fighter fighter)
    {
        var skills = fighter.AvailableSkills().ToArray();
        var skillStrings = skills
            .Select(skill => skill.PrintNameAndCost())
            .ToArray();
        string choosenSkill = ChooseOptionFromUser(
            $"Seleccione una habilidad para que {fighter.Name} use", skillStrings);
        if (choosenSkill == "Cancelar")
            return null;
        return skills.First(skill => skill.PrintNameAndCost() == choosenSkill);
    }

    public Fighter? ChooseTargetFromUser(Fighter attacker)
    {
        var targets = table.EnemyTeam.ValidTargets().ToArray();
        var targetsStrings = targets
            .Select(target => target.PrintNameAndStats())
            .ToArray();
        string choosenTarget = ChooseOptionFromUser(
            $"Seleccione un objetivo para {attacker.Name}", targetsStrings
            );
        if (choosenTarget == "Cancelar") return null;
        Fighter target = targets
            .First(target => target.PrintNameAndStats() == choosenTarget);
        return target;
    }


    private string ChooseOptionFromUser(string banner, string[] options)
    {
        ShowOptions(banner, options);
        return GetOptionFromUser(options);
    }

    private void ShowOptions(string banner, string[] options)
    {
        var numberedOptions = options
            .Select((option, i) => $"{i + 1}-{option}")
            .ToList();
        numberedOptions.Insert(0, banner);
        numberedOptions.Add($"{options.Length+1}-Cancelar");
        WriteLines(numberedOptions);
    }

    private string GetOptionFromUser(string[] options)
    {
        int selectedIndex = 0;
        while (!(selectedIndex > 0 && selectedIndex <= options.Length+1))
            selectedIndex = ReadNumber();

        if (selectedIndex == options.Length + 1)
            return "Cancelar";
        return options[selectedIndex-1];
    }


    private int ReadNumber()
    {
        int readedNumber;
        
        string line = view.ReadLine();
        while (!int.TryParse(line, out readedNumber))
            line = view.ReadLine();

        return readedNumber;
    }
}