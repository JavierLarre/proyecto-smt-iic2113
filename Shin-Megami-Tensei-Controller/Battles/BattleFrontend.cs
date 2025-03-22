using System.Globalization;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Samurais;
using Shin_Megami_Tensei.Fighters.Skills;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleFrontend
{
    private readonly View _view;
    private readonly Table _table;
    private Team _currentTeam; //TODO: logica que no deberia estar acá
    private int _round;
    private int _turnsPlayed = 0;
    private readonly string _indent = new ('-', 40);
    private Fighter[] _inOrder = [];

    public BattleFrontend(Table table, View view)
    {
        _table = table;
        _currentTeam = table.Teams.First();
        _view = view;
    }
    
    public void PrintRound()
    {
        //TODO: no queda claro qué es todo esto
        var infoStringsWithIndents = PrintOrder().
            Select(info => $"{_indent}\n{info}");
        string joinedStringsWithNewlines = string.
            Join('\n', infoStringsWithIndents);
        _view.WriteLine(joinedStringsWithNewlines);
    }

    public void FighterTurn(Fighter fighter)
    {
        IAction? selectedAction = null;
        bool isDone = false;
        //TODO: mover a método de acción
        while (!isDone)
        {
            //TODO: mover a método de elegir action
            _view.WriteLine(_indent);
            _view.WriteLine($"Seleccione una acción para {fighter.Name}");
            //TODO: definir lambda para select
            _view.WriteLine(string.Join('\n', fighter.Actions.Select((action, i) => $"{i+1}: {action}")));
            
            int selection = 0;
            while (!(selection > 0 && selection <= fighter.Actions.Length))
            {
                string result = _view.ReadLine();
                while (!int.TryParse(result, out selection))
                    result = _view.ReadLine();
            }
            selectedAction = fighter.Actions[selection-1];
            selectedAction.Act(_table, fighter, this);
            isDone = selectedAction.IsDone();
            
        }

        selectedAction?.End();
        //TODO: algo hacer aquí
        if(selectedAction?.GetType() != new GiveUp().GetType())
            EndTurn();
        //TODO: esto es solo para el print del orden de turnos
        _turnsPlayed++;
        
    }

    public void PrintAttack(Fighter attacker, Fighter reciever, int dmg)
    {
        _view.WriteLine(_indent);
        _view.WriteLine($"{attacker.Name} ataca a {reciever.Name}");
        _view.WriteLine($"{reciever.Name} recibe {dmg} de daño");
        _view.WriteLine($"{reciever.Name} termina con {reciever.Stats.PrintHp()}");
    }
    //TODO: seguramente puedo refactorizar esto
    
    public void PrintShoot(Fighter attacker, Fighter reciever, int dmg)
    {
        _view.WriteLine(_indent);
        _view.WriteLine($"{attacker.Name} dispara a {reciever.Name}");
        _view.WriteLine($"{reciever.Name} recibe {dmg} de daño");
        _view.WriteLine($"{reciever.Name} termina con {reciever.Stats.PrintHp()}");
    }

    //TODO: mover esto a la clase GiveUp
    public void PrintGiveUp(Fighter loser)
    {
        PrintIndent();
        Team losers = _table.GetTeamFromFighter(loser);
        int player = _table.GetPlayerFromTeam(losers);
        _view.WriteLine($"{loser.Name} (J{player}) se rinde");
    }

    public void EndTurn()
    {
        _view.WriteLine(_indent);
        _view.WriteLine("Se han consumido 1 Full Turn(s) y 0 Blinking Turn(s)");
        _view.WriteLine("Se han obtenido 0 Blinking Turn(s)");
    }

    public Skill? ChooseSkillFromUser(Fighter fighter)
    {
        string response = "";
        do
        {
            PrintIndent();
            ShowSkillsToUser(fighter);
            response = _view.ReadLine();
        } while (!SkillResponseIsValid(response, fighter));

        return GetSkillFromSelection(fighter, response);
    }

    private Skill? GetSkillFromSelection(Fighter fighter, string response)
    {
        int result = int.Parse(response);
        if (result == fighter.Skills.Length+1)
            return null;
        return fighter.Skills[result-1];
    }
    private bool SkillResponseIsValid(string response, Fighter fighter)
    {
        int result;
        try
        {
            result = int.Parse(response);
        }
        catch (FormatException e)
        {
            return false;
        }
        //TODO: is in range
        return (0 < result) && (result <= fighter.Skills.Length+1);
    }

    private void ShowSkillsToUser(Fighter fighter)
    {
        _view.WriteLine($"Seleccione una habilidad para que {fighter.Name} use");
        //TODO: la lógica para obtener las skills usables debe estar en otro lugar
        var skillStrings = fighter.Skills
            .Where(skill => skill.Cost <= fighter.Stats.MpLeft)
            //TODO: lambda
            .Select((skill, i) => $"{i+1}-{skill}")
            .ToArray();
        foreach(var skill in skillStrings) 
            _view.WriteLine(skill);
        _view.WriteLine($"{fighter.Skills.Count(skill => skill.Cost <= fighter.Stats.MpLeft)+1}-Cancelar");
    }

    public void ChangeStatus(Team team, int round)
    {
        _currentTeam = team;
        _round = round;
        _turnsPlayed = 0;
    }

    public void PrintFighterActions(Fighter fighter)
    {
        _view.WriteLine($"Seleccione una acción para {fighter.Name}");
        _view.WriteLine("");
    }

    public Fighter? ChooseTargetFromUser(Fighter attacker)
    {
        
        _view.WriteLine(_indent);
        //TODO: esto no deberia estar aqui
        Team enemyTeam = _table.GetEnemyTeam(_currentTeam);
        //TODO: logica para las unidades validas no deberia estar aqui
        var targets = enemyTeam.Units()
            .Where(fighter => fighter is not null)
            .Where(fighter => fighter.Stats.HpLeft > 0)
            .ToArray();
        _view.WriteLine($"Seleccione un objetivo para {attacker.Name}");
        //TODO: hay una mejor manera de hacer esto
        int i = 1;
        foreach (var target in targets)
        { 
            _view.WriteLine($"{i++}-{target}");
        }
        _view.WriteLine($"{i}-Cancelar");
        //TODO: metodo elegir opcion
        string result = _view.ReadLine();
        int index = -1;
        while (!(index > 0 && index <= targets.Length + 1))
        {
            while (!int.TryParse(result, out index))
                result = _view.ReadLine();
        }
        //TODO: target vacio
        if (index == targets.Length + 1) return null;
        Console.WriteLine($"index {index} target: {targets[index-1].Name}");
        return targets[index-1];
    }

    //TODO: print order de que
    private IEnumerable<string> PrintOrder()
    {
        return [
            _table.ToString(),
            PrintTurns(),
            PrintTeamInOrder(),
        ];
    }

    //TODO: no es especifico
    public void RoundBanner()
    {
        //TODO: encapsular writeline
        PrintIndent();
        _view.WriteLine(
            $"Ronda de {_currentTeam.Samurai.Name}" +
            $" (J{_round})");
    }
        
    //TODO: es turns LEFT, y aqui hay lógica que no deberia estar
    private string PrintTurns() =>
        $"Full Turns: {_currentTeam.TurnsLeft - _turnsPlayed}\n" +
        $"Blinking Turns: 0";

    private string PrintTeamInOrder()
    {
        // var orderStrings = _inOrder
        //     .Select((fighter, i) => $"{i+1}-{fighter.Name}");
        _inOrder = _currentTeam.TurnOrder().ToArray();
        List<string> orderStrings = [];
        //TODO: de nuevo, logica que no deberia ser
        for (int i = 0; i < _inOrder.Length; i++)
        {
            string fighterString = $"{i+1}-{_inOrder[(i + _turnsPlayed) % _inOrder.Length].Name}";
            orderStrings.Add(fighterString);
        }
        //TODO: algunos metodos printean, otros retornan un string
        string orderedTeamInString = string.Join('\n', orderStrings);
        return $"Orden:\n{orderedTeamInString}";
    }

    public void PrintWinner(Team winner)
    {
        PrintIndent();
        //TODO: deberia entregar el player
        int player = _table.GetPlayerFromTeam(winner);
        _view.WriteLine($"Ganador: {winner.Samurai.Name} (J{player})");
    }
    private void PrintIndent() => _view.WriteLine(_indent);
}