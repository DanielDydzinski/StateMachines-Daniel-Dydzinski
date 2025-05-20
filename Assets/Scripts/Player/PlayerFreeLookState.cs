using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    /*
     * Constructor that passes the PlayerStateMachine reference to the base class.
     */
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

//animation variables 
    private const float AnimatorDampTime = 0.1f;
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private readonly int freeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.MovementVector = CalculateMovement();

        stateMachine.Controller.Move(stateMachine.MovementVector * stateMachine.playerSpeed*deltaTime);

        FaceMovementDirection(deltaTime);
    }

    Vector3 CalculateMovement()
    {
        //Get forward dir of camera
        Vector3 forward = stateMachine.MainCameraTransform.forward;

        //Zero out the Y coordinate to keep the movement on horizontal palne
        forward.y = 0f;

        //normalize the forward vector to ensure it has magnitued of 1
        forward.Normalize();

        Vector3 right = stateMachine.MainCameraTransform.right;
        right.y = 0f;
        right.Normalize();

        //calculate the vactor movement based on camera orientation and input values

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;

        /* Vector3 movement = new Vector3();
                          movement.x = stateMachine.InputReader.MovementValue.x;
                          movement.y = 0;
                          movement.z = stateMachine.InputReader.MovementValue.y;
                          return movement; */
    }

    private void FaceMovementDirection(float deltaTime)
    {
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0f);
            return;
        }

        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);


       // Smoothly rotate the character towards the movement direction
        // The rotation is interpolated using Quaternion.Lerp with rotation damping
        stateMachine.transform.rotation = Quaternion.Lerp(stateMachine.transform.rotation,
            Quaternion.LookRotation(stateMachine.MovementVector), deltaTime * stateMachine.RotationDamping);
    }
}