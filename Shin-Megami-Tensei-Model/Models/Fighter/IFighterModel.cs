
using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_Model;

public interface IFighterModel: IModel
{
    public UnitData GetUnitData(); //tambien
    public int GetCurrentHp(); //todo: eliminar esto
    public void SetHp(int value);
    public int GetCurrentMp(); // esto tmb
    public void SetMp(int value);
    public void AddToReserve(Team team);
    public bool IsAlive(); //tambien
    public bool CanBeSwapped();
    public FighterState GetState();
}