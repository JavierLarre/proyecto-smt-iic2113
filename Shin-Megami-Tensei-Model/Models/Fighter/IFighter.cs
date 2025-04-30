
namespace Shin_Megami_Tensei_Model;

public interface IFighter: IModel
{
    public UnitData GetUnitData();
    public int GetCurrentHp();
    public void SetHp(int value);
    public int GetCurrentMp();
    public void SetMp(int value);
    public bool IsAlive();
}