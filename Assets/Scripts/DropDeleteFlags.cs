using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDeleteFlags : MonoBehaviour
{
    public Transform objectPos;
    public GameObject item;
    public Light flashlight;
    private const float pickUpRange = 5;
    private int flagsNum = 0;
    private const int flagsMaxNum = 8;

    void Update(){
        DestroyFlag();
        DropFlag();
    }

    void DestroyFlag(){
        if (Input.GetMouseButtonDown(1)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast (ray, out hit, pickUpRange) && hit.transform.gameObject.name == "Flag_v2(Clone)"){
                Destroy(hit.transform.gameObject);
                flagsNum--;
            } 
        }
    }

    void DropFlag(){
        if(Input.GetKeyDown(KeyCode.Q) && flagsNum != flagsMaxNum){
            GameObject flag = Instantiate(item, objectPos.position, objectPos.rotation);
            flag.GetComponent<FlagController>().Init(flashlight.color);
            flagsNum++;
        }
    }

    public void DecreaseFlagNumber(){
        flagsNum--;
    }
}
