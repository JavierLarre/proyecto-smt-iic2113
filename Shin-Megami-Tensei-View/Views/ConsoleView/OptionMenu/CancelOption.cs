namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class CancelOption: IOptionMenu
{
    public override string ToString() => "Cancelar";
    public IOptionMenu GetOption() => this;
    public void SetOptions(
        IEnumerable<IOptionMenu> options, string header, string separator)
    {
    }
}