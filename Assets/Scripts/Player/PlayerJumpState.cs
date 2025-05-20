using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering the state");
    }

    public override void Exit()
    {
        Debug.Log("Exiting the state.");
    }

    public override void Tick(float deltaTime)
    {

    }
}
