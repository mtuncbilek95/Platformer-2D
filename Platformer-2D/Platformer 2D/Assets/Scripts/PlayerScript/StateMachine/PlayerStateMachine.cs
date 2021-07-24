public class PlayerStateMachine
{
    public PlayerState CurrentState;

    public void Initialize(PlayerState newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }
}
