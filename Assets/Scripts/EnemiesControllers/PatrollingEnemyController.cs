using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemyController : EnemyController
{
    public Transform target;
    public Transform[] waypoint;
    public float lookRadius = 10f;
    public float patrolSpeed = 3f; 
    public float dampingLook= 6.0f;
    public float pauseDuration = 0;
    private float curTime;
    int moveSpeed = 4;
    private int currentWaypoint = 0;
    public bool  loop = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        
        if(distance <= lookRadius){
            transform.LookAt(target);
            transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        }else{
            if(currentWaypoint < waypoint.Length){
                Patrol();
            }else{
                if(loop){
                    currentWaypoint=0;
                }
            }
        }        
    }
    
    void  Patrol (){

        Vector3 targetWaypoint = waypoint[currentWaypoint].position;
        targetWaypoint.y = transform.position.y;
        Vector3 moveDirection = targetWaypoint - transform.position;

        if(moveDirection.magnitude < 0.5f){
            if (curTime == 0)
                curTime = Time.time; 
            if ((Time.time - curTime) >= pauseDuration){
                currentWaypoint++;
                curTime = 0;
            }
        }else{        
            var rotation= Quaternion.LookRotation(targetWaypoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
            transform.position += moveDirection.normalized * patrolSpeed * Time.deltaTime;
        }  
    }
    
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
