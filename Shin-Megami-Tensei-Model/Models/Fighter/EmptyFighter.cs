using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_Model.Fighters;

public class EmptyFighter: AbstractModel, IFighterModel
{
    public void SetHp(int value) { }

    public void SetMp(int value) { }
    
    public void AddToReserve(Team team) { }

    public FighterState GetState() => new()
    {
        CanBeSwapped = true,
        Affinities = new Affinities
        {
            Dark = "-",
            Elec = "-",
            Fire = "-",
            Force = "-",
            Gun = "-",
            Ice = "-",
            Light = "-",
            Phys = "-",
        }
    };
}