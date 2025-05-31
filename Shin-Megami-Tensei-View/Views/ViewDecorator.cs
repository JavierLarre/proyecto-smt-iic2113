namespace Shin_Megami_Tensei_View.Views;

public class ViewDecorator: IView
{
    private IView _previous;
    private IView _new;

    public ViewDecorator(IView newView, IView previousView)
    {
        _previous = previousView;
        _new = newView;
    }

    public void Display()
    {
        _previous.Display();
        _new.Display();
    }
}