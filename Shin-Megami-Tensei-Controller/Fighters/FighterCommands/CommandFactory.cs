using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class CommandFactory
{
    private Table _table;
    private BattleView _view;

    public CommandFactory(Table table, BattleView view)
    {
        _table = table;
        _view = view;
    }
    
    public IFighterCommand GetAction(string action)
    {
        return action switch
        {
            "Atacar" => new Attack(_table, _view),
            "Disparar" => new Shoot(_table, _view),
            "Usar Habilidad" => new UseSkill(_table, _view),
            "Invocar" => new Invoke(),
            "Pasar Turno" => new Pass(),
            "Rendirse" => new GiveUp(_table, _view),
            _ => throw new ArgumentException("Action Not Found")
        };
    } 
}