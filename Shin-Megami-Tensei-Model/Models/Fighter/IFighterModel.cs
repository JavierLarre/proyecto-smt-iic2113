
using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_Model;

public interface IFighterModel: IModel
{
    public FighterState GetState();
    public void SetHp(int value);
    public void SetMp(int value);
    public void AddToReserve(Team team);
}