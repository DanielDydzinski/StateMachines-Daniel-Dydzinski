using JetBrains.Annotations;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }
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

    public void Attack()
    {
        Debug.Log("Attack!");
    }
}
