using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float health =  50f;
    public float maxHealth = 1000f;
    public ParticleSystem deathParticle;
    public ParticleSystem damageTakenParticle;

    // Start is called before the first frame update
    public virtual void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public virtual void TakeDamage(float amount){
        health -= amount;
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(damageTakenParticle, currentPos, Quaternion.identity);
        if (health <= 0f){
            Die();
        }
    }
    
    public virtual void Die(){
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(deathParticle, currentPos, Quaternion.identity);
        Destroy(gameObject);

    }
}
