using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorInState : PlayerAbilityState
{
    public bool enterTheDoor;

    public PlayerDoorInState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        SoundManagerScript.PlaySound("winTheGame");
        enterTheDoor = true;
        player.SetVelocityX(0);
        player.SetVelocityY(0);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
