using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Common;

public class Affinities
{
    private Dictionary<string, string> AffinityMap = new();

    public static Affinities FromInfo(AffinityInfo affinityInfo)
    {
        Affinities affinities = new Affinities();
        affinities.AffinityMap = new Dictionary<string, string>
        {
            ["Phys"] = affinityInfo.Phys,
            ["Gun"] = affinityInfo.Gun,
            ["Fire"] = affinityInfo.Fire,
            ["Ice"] = affinityInfo.Ice,
            ["Elec"] = affinityInfo.Elec,
            ["Force"] = affinityInfo.Force,
            ["Light"] = affinityInfo.Light,
            ["Dark"] = affinityInfo.Dark
        };
        return affinities;
    }
}