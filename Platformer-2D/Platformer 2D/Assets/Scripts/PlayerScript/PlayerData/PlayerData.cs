using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/BaseData/PlayerBaseData")]
public class PlayerData : ScriptableObject
{
    [Header("Character Movement Values")]
    [Range(0,20)]
    public int maxSpeed;
    [Range(0, 2)]
    public float dragLerpValue;

    [Range(0,10)]
    public float groundLayerLength;

    [Header("Character Jump Values")]
    public float jumpVelocity = 15f;
    public int jumpCount = 1;
    public float jumpHeightMultiplier = 0.5f;

    [Header("Character Attack Values")]
    [Range(0, 20)]
    public float attackVelocity, hitForceY;
    [Range(0,10)]
    public float weaponRaycastRadius;

    [Header("Character In-Game Status")]
    public int health = 3;
}
