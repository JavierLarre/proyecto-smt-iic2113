using Shin_Megami_Tensei.Fighters.DataClassesForJson;

namespace Shin_Megami_Tensei.Fighters;

public class Affinities
{
    private Dictionary<string, string> AffinityMap;

    public static Affinities FromData(AffinityDataFromJson data) =>
        new (data);

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