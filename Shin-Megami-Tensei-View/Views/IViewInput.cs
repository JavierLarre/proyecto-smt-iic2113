namespace Shin_Megami_Tensei_View.Views;

public interface IViewInput: IView, IViewController
{
    public void SetInput(IViewController viewController);
}