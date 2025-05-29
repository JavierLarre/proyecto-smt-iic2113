
using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_Model;

public interface IFighterModel: IModel
{
    public UnitData GetUnitData();
    public int GetCurrentHp();
    public void SetHp(int value);
    public int GetCurrentMp();
    public void SetMp(int value);
    public void AddToReserve(Team team);
    public bool IsAlive();
    public bool CanBeSwapped();
    public FighterState GetState();
}