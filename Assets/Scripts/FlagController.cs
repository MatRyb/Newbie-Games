using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class FlagController : MonoBehaviour{
    [SerializeField] private Light light;
    [SerializeField] private VisualEffect particles;
    [SerializeField] private Color particleColor;
    [SerializeField] private float autoDeleteDistance;

    private void Update(){
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
        particleColor = color;
        particles.SetVector4("Color", particleColor);
    } 
}
