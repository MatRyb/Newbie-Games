using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMarkDissapear : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    float range = 5f;
    void Update () {
        if (Input.GetMouseButtonDown (1)) {
            Ray ray =  Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit) && (hit.distance < range)) {
                if (hit.transform.gameObject.name == "Cube(Clone)"){
                    Destroy(hit.transform.gameObject);
                }
                else{
                    Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
                }
            }
        }
       
    }
}
