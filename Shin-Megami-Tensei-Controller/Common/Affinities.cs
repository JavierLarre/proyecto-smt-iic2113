using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Common;

public class Affinities
{
    private Dictionary<string, string> AffinityMap;

    public static Affinities FromInfo(AffinityDataFromJson data)
    {
        return new Affinities(data);
    }

    private Affinities(AffinityDataFromJson data)
    {
        AffinityMap = new Dictionary<string, string>
        {
            ["Phys"] = data.Phys,
            ["Gun"] = data.Gun,
            ["Fire"] = data.Fire,
            ["Ice"] = data.Ice,
            ["Elec"] = data.Elec,
            ["Force"] = data.Force,
            ["Light"] = data.Light,
            ["Dark"] = data.Dark
        };
    }
}