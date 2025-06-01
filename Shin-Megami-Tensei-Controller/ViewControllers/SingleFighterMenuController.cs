using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;

namespace Shin_Megami_Tensei.TargetTypes;

public class SingleFighterMenuController: IViewController
{
    private IFighterModel _cachedTarget = new EmptyFighter();
    private IViewInput _menu;
    private ICollection<IFighterModel> _fighters = [];

    public SingleFighterMenuController(IViewInput menu)
    {
        _menu = menu;
        _menu.SetInput(this);
    }

    public void SetFighters(ICollection<IFighterModel> fighters)
    {
        _fighters = fighters;
    }

    public IFighterModel GetTarget()
    {
        if (_cachedTarget is EmptyFighter)
            _menu.Display();
        return _cachedTarget;
    }

    
    public void OnInput(string input)
    {
        bool FindByName(IFighterModel fighter)
        {
            return fighter.GetState().Name == input;
        }

        try
        {
            _cachedTarget = _fighters.First(FindByName);

        }
        catch (InvalidOperationException)
        {
            throw new NullReferenceException($"mish {input}");
        }
    }
}