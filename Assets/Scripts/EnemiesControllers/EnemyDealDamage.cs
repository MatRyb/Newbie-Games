using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDealDamage : MonoBehaviour
{
    private int damage = 7;

    public float damageRange = 1000f;
    private float damageDelay = 1f;
    private float damageTimer = 0f;

    public PlayerHealth playerHealth;
    public Transform target;
    
    void Start()
    {

    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        damageTimer += Time.deltaTime;

        if(IsInDamageRange(distance) && damageTimer > damageDelay){
            DealDamage(damage);    
        }
    }

    public void DealDamage(int damage){
        playerHealth.TakeDamage(damage);
        damageTimer = 0f;
        if (!DamageIndicator_System.CheckIfObjectInSight(this.transform))
        {
            DamageIndicator_System.CreateIndicator(this.transform);
        }
    }
    
    public bool IsInDamageRange(float distance){
        if(distance <= damageRange){
            return true;    
        }
        return false;
    }

}
