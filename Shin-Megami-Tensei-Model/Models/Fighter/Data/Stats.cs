namespace Shin_Megami_Tensei_Model;

public struct Stats
{
    public int Hp { get; }
    public int Mp { get; }
    public int Str { get; }
    public int Skl { get; }
    public int Mag { get; }
    public int Spd { get; }
    public int Lck { get; }

    public Stats()
    {
        
    }

    public Stats(int hp, int mp, int str, int skl, int mag, int spd, int lck)
    {
        Hp = hp;
        Mp = mp;
        Str = str;
        Skl = skl;
        Mag = mag;
        Spd = spd;
        Lck = lck;
    }
}