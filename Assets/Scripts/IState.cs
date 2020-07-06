// Interface for the finite state machine states

public interface IState
{
    // takes FSM script so that we can access some variables like animator or agent to move our character and etc...
    void Enter(FSM machine);

    // called when running the state, it keeps calling execute function which is like update() function
    void Execute();

    // called when we exit the state
    void Exit();
}
