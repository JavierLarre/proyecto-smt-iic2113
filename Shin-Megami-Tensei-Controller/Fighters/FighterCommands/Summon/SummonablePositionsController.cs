using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class SummonablePositionsController
{
    private Table _table = Table.GetInstance();
    
    public IEnumerable<IFighter> GetPositions()
    {
        Player currentPlayer = _table.GetCurrentPlayer();
        Team currentTeam = currentPlayer.GetTeam();
        IEnumerable<IFighter> frontRow = currentTeam.GetFrontRow();
        IEnumerable<IFighter> swapablePositions = frontRow.Where(fighter => fighter.CanBeSwapped());
        return swapablePositions;
        // Rompo la ley de demeter,
        // pero prefiero hacer las consultas en los controladores
        // en vez de escribir un método por cada consulta en los modelos.
        // Así los modelos solo se enfocan en tener los datos correctos.
        // Aún así pienso que pude haber hecho los modelos como estructuras de datos,
        // pero sería responsabilidad de los controladores que los datos estuvieran correctos
    }
    
    
}