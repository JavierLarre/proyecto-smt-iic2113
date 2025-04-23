namespace Shin_Megami_Tensei_Model;

public struct Skill
{
    public string Name;
    public string Type;
    public int Cost;
    public int Power;
    public string Target;
    public string Hits;
    public string Effect;

    public override string ToString() => $"{Name} MP:{Cost}";
}