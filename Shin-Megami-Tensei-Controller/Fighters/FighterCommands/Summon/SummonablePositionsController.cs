using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class SummonablePositionsController: IViewController
{
    private Table _table = Table.GetInstance();
    private ICollection<IFighter> _positions;
    private int _position = -1;

    public SummonablePositionsController()
    {
        _positions = GetPositions().ToArray();
    }
    
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

    public int GetPosition()
    {
        var positions = GetPositions();
        SummonPositionsMenu summonPositionsMenu = new SummonPositionsMenu(positions);
        summonPositionsMenu.SetInput(this);
        summonPositionsMenu.GetChoice();
        return _position;
    }


    public void OnInput(string input)
    {
        _position =  int.Parse(input);
    }
}