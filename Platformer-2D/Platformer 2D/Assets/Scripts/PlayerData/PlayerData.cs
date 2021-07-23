using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/BaseData/PlayerBaseData")]
public class PlayerData : ScriptableObject
{
    [Header("Character Movement Values")]
    [Range(0,20)]
    public int maxSpeed;
    [Range(0,100)]
    public int accelerateValue, dragValue;

    [Range(0,10)]
    public float groundLayerLength;

    [Header("Character Jump Values")]
    public float jumpVelocity = 15f;
    public int jumpCount = 1;
    public float jumpHeightMultiplier = 0.5f;

    [Header("Character Attack Values")]
    [Range(0,20)]
    public float attackVelocity;

    [Header("Character In-Game Status")]
    public int health;
}
