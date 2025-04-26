namespace Shin_Megami_Tensei.Fighters;

public class AffinityFactory
{
    private string _affinity;

    public AffinityFactory(string affinity)
    {
        _affinity = affinity;
    }

    public IAffinityController GetAffinity()
    {
        return _affinity switch
        {
            "Dr" => new DrainAffinity(),
            "-" => new NeutralAffinity(),
            "Nu" => new NullAffinity(),
            "Rp" => new RepelAffinity(),
            "Rs" => new ResistAffinity(),
            "Wk" => new WeakAffinity(),
            _ => throw new ArgumentException($"Affinity Not Found:{_affinity}")
        };
    }
}