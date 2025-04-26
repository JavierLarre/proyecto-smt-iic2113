namespace Shin_Megami_Tensei_Model;

public class Stats
{
    public int MaxHp { get; }
    public int MaxMp { get; }
    public int HpLeft { get; private set; }
    public int MpLeft { get; private set; }

    public int Str { get; }
    public int Skl { get; }
    public int Mag { get; }
    public int Spd { get; }
    public int Lck { get; }

    public Stats()
    {
        
    }

    public Stats(int maxHp, int maxMp, int str, int skl, int mag, int spd, int lck)
    {
        MaxHp = maxHp;
        MaxMp = maxMp;
        HpLeft = MaxHp;
        MpLeft = MaxMp;
        Str = str;
        Skl = skl;
        Mag = mag;
        Spd = spd;
        Lck = lck;
    }

    public void HealDamage(double amount)
    {
        int truncatedHeal = Convert.ToInt32(Math.Floor(amount));
        HpLeft = int.Min(MaxHp, HpLeft + truncatedHeal);
    }
    public void RecieveDamage(double damage)
    {
        int truncatedDamage = Convert.ToInt32(Math.Floor(damage));
        int newHp = HpLeft - truncatedDamage;
        HpLeft = int.Max(0, newHp);
    }

    public void DecreaseMp(int cost)
    {
        MpLeft = int.Max(0, MpLeft - cost);
    }
}