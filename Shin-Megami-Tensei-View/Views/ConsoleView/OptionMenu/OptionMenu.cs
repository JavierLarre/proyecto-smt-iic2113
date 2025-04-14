using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class OptionMenu: IOptionMenu
{
    private readonly string _name;
    private string _header = "";
    private ICollection<IOptionMenu> _options = [];
    private string _separator = "";
    private readonly BattleView _view;

    public OptionMenu(string name, BattleView view)
    {
        _name = name;
        _view = view;
    }

    public void SetOptions(IEnumerable<IOptionMenu> options,
        string header, string separator)
    {
        _options = options.ToArray();
        _header = header;
        _separator = separator;
    }

    public override string ToString()
    {
        return _name;
    }

    public IOptionMenu GetOption()
    {
        ShowOptionsToUser();
        IOptionMenu choosenOption = GetOptionFromUser();
        return choosenOption.GetOption();
    }

    private void ShowOptionsToUser()
    {
        _view.WriteLine(_header + '\n' + GetFormattedOptions());
    }


    private IOptionMenu GetOptionFromUser()
    {
        string userInput = _view.ReadLine();
        int choice = int.Parse(userInput);
        try
        {
            return _options.ToArray()[choice - 1];
        }
        catch (IndexOutOfRangeException e)
        {
            throw new OptionException("Option Not Valid");
        }
    }

    private string GetFormattedOptions()
    {
        var formattedOptions = _options
            .Select((option, i) => $"{i+1}{_separator}{option.ToString()}");
        return string.Join('\n', formattedOptions);
    }
}