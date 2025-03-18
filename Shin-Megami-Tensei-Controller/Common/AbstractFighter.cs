using Shin_Megami_Tensei.Skills;
using Shin_Megami_Tensei.DataClassesFromJson;

namespace Shin_Megami_Tensei.Common;

public abstract class AbstractFighter
{
    public string Name;
    public Stats Stats;
    public Affinities Affinities;
    public Skill[] Skills = [];
    
}