using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    private EnemyBaseScript[] enemyBase;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyBase[i] = enemies[i].GetComponent<EnemyBaseScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyBase[i] = enemies[i].GetComponent<EnemyBaseScript>();

            if (enemyBase[i].EnemyisDead)
            {
                Debug.Log(enemyBase[i] + " is Dead");
            }
        }
    }
}
