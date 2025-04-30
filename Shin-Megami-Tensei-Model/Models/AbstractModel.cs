namespace Shin_Megami_Tensei_Model;

public abstract class AbstractModel: IModel
{
    private readonly List<IModelObserver> _observers = [];
    
    public void AddObserver(IModelObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IModelObserver observer)
    {
        _observers.Remove(observer);
    }

    protected void UpdateObservers()
    {
        foreach (IModelObserver observer in _observers)
        {
            observer.Update();
        }
    }
}