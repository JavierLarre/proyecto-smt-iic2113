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
        return null;
    }
}