public class EnemyStateMachine
{
    public IEnemyState Current { get; private set; }

    public IEnemyState LastState { get; private set; }

    private bool _locked;

    public void ChangeState(IEnemyState next) 
    {
        if (_locked) 
            return;

        if (Current == next)
            return;

        Current?.Exit();

        LastState = Current;
        Current = next;
        
        Current.Enter();
    }

    public void Update()
    {
        Current?.Update();
    }

    public void Lock() => _locked = true;
}
