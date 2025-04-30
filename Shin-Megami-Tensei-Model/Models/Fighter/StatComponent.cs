namespace Shin_Megami_Tensei_Model.Models.Fighter.Fighters;

public class StatComponent
{
    private readonly int _statMax;
    private int _stat;

    public StatComponent(int statMax)
    {
        _statMax = statMax;
        _stat = statMax;
    }

    public int Get()
    {
        return _stat;
    }

    public void Set(int value)
    {
        _stat = int.Min(_statMax, value);
        _stat = int.Max(_stat, 0);
    }
}