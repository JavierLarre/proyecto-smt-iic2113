using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SummonPositionsMenu: AbstractOptionsMenu
{
    private IEnumerable<IFighterModel> _targets;
    public SummonPositionsMenu(IEnumerable<IFighterModel> targets)
    {
        _targets = targets;
        SetPositions();
        SetHeader("Seleccione una posición para invocar");
    }

    private void SetPositions()
    {
        var positions = _targets.Select(FormatPosition).ToArray();
        for (int i = 0; i < positions.Length; i++)
        {
            AddOption((i + 1).ToString(), positions[i]);
        }
        AddCancelOption();
    }

    private static string FormatPosition(IFighterModel target, int position)
    {
        IFighterView fighterView = FighterViewFactory.FromFighter(target);
        string positionInfo = fighterView.GetInfo();
        if (positionInfo == "")
            positionInfo = "Vacío";
        positionInfo += $" (Puesto {position + 2})";
        // + 1 porque empezamos a contar de 1 y no de 0
        // + 1 porque nos saltamos el samurai (es posible que esto sea más general?)
        // o no me debería preocupar?
        return positionInfo;
    }
    
    protected override string GetSeparator() => "-";
}