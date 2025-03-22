using Shin_Megami_Tensei.Fighters.DataClassesForJson;

namespace Shin_Megami_Tensei.Fighters;

public class Stats(StatsDataFromJson data)
{
    public int Hp = data.HP;
    public int HpLeft = data.HP;
    public int Mp = data.MP;
    public int MpLeft = data.MP;
    public int Str = data.Str;
    public int Skl = data.Skl;
    public int Mag = data.Mag;
    public int Spd = data.Spd;
    public int Lck = data.Lck;

    public override string ToString() =>
        $"{PrintHp()} MP:{MpLeft}/{Mp}";
    
    public string PrintHp() =>
        $"HP:{HpLeft}/{Hp}";
}