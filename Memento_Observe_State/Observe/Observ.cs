namespace Memento_Observe_State.Observe;

public abstract class Subject
{
    private List<Observer> observers = new List<Observer>();

    public void Attach(Observer observer)
        => observers.Add(observer);

    public void Detach(Observer observer)
        => observers.Remove(observer);

    public void Notify()
    {
        foreach (Observer o in observers)
            o.Update();
    }
}


public class ConcreteSubject : Subject
{
    private string? subjectState;

    // Gets or sets subject state
    public string? SubjectState
    {
        get { return subjectState; }
        set { subjectState = value; }
    }
}


public abstract class Observer
{
    public abstract void Update();
}


public class ConcreteObserver : Observer
{
    private string Name;
    private string ObserverState;
    private ConcreteSubject _Subject;

    public ConcreteObserver(ConcreteSubject subject, string name)
    {
        _Subject = subject;
        Name = name;
    }

    public override void Update()
    {
        ObserverState = _Subject.SubjectState;
        Console.WriteLine("Observer {0}'s new state is {1}", Name, ObserverState);
    }

    
    public ConcreteSubject Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }
}