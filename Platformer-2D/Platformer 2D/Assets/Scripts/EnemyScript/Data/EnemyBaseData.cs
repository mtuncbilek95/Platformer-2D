using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="newEnemyData" ,menuName="Data/EnemyData/EnemyBaseData")]
public class EnemyBaseData : ScriptableObject
{
    public int health;
    
    public int maxSpeed;

    public float weaponRadius;

    public bool canTakeDamage;

    public float ledgeCheckLength;
    public float playerCheckRadius;
}
