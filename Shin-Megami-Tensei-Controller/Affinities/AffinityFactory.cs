namespace Shin_Megami_Tensei.Fighters;

public static class AffinityFactory
{

    public static IAffinityController FromString(string affinity)
    {
        return affinity switch
        {
            "Dr" => new DrainAffinity(),
            "-" => new NeutralAffinity(),
            "Nu" => new NullAffinity(),
            "Rp" => new RepelAffinity(),
            "Rs" => new ResistAffinity(),
            "Wk" => new WeakAffinity(),
            _ => throw new ArgumentException($"Affinity Not Found:{affinity}")
        };
    }
}