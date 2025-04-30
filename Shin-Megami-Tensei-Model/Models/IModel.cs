namespace Shin_Megami_Tensei_Model;

public interface IModel
{
    public void AddObserver(IModelObserver observer);

    public void RemoveObserver(IModelObserver observer);
}