using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public interface IFighterCommand
{
    //todo: todas las acciones necesitan printear su mensaje, pero se puede hacer mejor con una vista
    public void Execute();
}