using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagV1Controller : MonoBehaviour
{
    public Light light;
    public float autoDeleteDistance;

    void Update(){
        if(IsPlayerTooFar()){
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<DropDeleteFlags>().DecreaseFlagNumber();
        }
    }

    private bool IsPlayerTooFar(){
        if(Vector3.Distance(this.transform.position, GameObject.Find("Player").transform.position) > autoDeleteDistance){
            return true; 
        }
        return false;
    } 

    public void Init(Color color){
        light.color = color;
    }
}
