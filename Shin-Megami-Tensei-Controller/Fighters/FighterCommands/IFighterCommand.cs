using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public interface IFighterCommand
{
    public void Execute(Table table, BattleView view);
}