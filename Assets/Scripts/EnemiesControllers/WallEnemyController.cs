using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallEnemyController : EnemyController
{
    public Transform[] spawnPositions;
    public static int spawnIndex = 0;

    public override void Start()
    {
        health = maxHealth;
    }
    public override void Die() {
        spawnIndex++;
        if(spawnIndex == 4){
            spawnIndex = 0;
        }
        Destroy(gameObject);
        Instantiate(gameObject, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);   
    }
}