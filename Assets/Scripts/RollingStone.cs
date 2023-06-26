using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour
{
    public Transform target;
    Rigidbody ownRigidbody;
    bool isForceAdded;
    public float forceValue = 200;


    public float maxDistance = 50f;
    // Start is called before the first frame update
    void Start()
    {
        ownRigidbody = GetComponent<Rigidbody>();
        isForceAdded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, target.position);
        Vector3 currentDirection = Vector3.Normalize(target.position - transform.position);
        if(currentDistance < maxDistance && !isForceAdded){
            ownRigidbody.AddForce(forceValue*currentDirection);
            isForceAdded = true;
        }
        
    }
}
