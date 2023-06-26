using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    Transform target;
    public PlayerHealth playerHealth;
    public float lookRadius = 15f;
    public float moveSpeed = 2;
    public float damageRange = 4f;

    private void Start()
    {
        target = playerHealth.gameObject.transform;
    }

    void Update()
    {
        transform.LookAt(target);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= lookRadius)
        {
            transform.LookAt(target);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (distance <= damageRange)
        {
            DealDamage(2);
        }
    }

    public void DealDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
