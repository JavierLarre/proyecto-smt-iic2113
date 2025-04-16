using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class OptionMenu: IOptionMenu
{
    private string _header = "";
    private ICollection<IOptionMenu> _options = [];
    private string _separator = "";
    private readonly BattleView _view;

    public OptionMenu(BattleView view)
    {
        _view = view;
    }

    public void SetMenuView(string header, string separator)
    {
        _header = header;
        _separator = separator;
    }

    public void SetOptions(IEnumerable<IOptionMenu> options)
    {
        _options = options.ToArray();
    }

    public override string ToString()
    {
        return _header;
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

    public int GetOptionIndex(IOptionMenu option)
    {
        return _options.ToList().IndexOf(option);
    }

    private string GetFormattedOptions()
    {
        var formattedOptions = _options.Select(GetFormattedOption);
        return string.Join('\n', formattedOptions);
    }

    private string GetFormattedOption(IOptionMenu option, int optionIndex)
    {
        return $"{optionIndex + 1}{_separator}{option.ToString()}";
    }
}