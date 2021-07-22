using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int jumpValue;

    public PlayerJumpState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
        jumpValue = playerData.jumpCount;
    }

    public override void Enter()
    {
        base.Enter();
        jumpValue--;
        isAbilityDone = true;
        player.SetVelocityY(playerData.jumpVelocity);
        player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if(jumpValue > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    public void ResetJump() => jumpValue = playerData.jumpCount;

}
