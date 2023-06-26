 using UnityEngine;
 using System.Collections;
 
 public class ClimbScript : MonoBehaviour {
 
 
 Transform chController;
 bool  inside = false;
 float heightFactor = 3.2f;

 
 void  Start (){
    
 }
 
 void  OnTriggerEnter ( Collider Col  ){
     if(Col.gameObject.tag == "Ladder")
     {
         inside = !inside;
     }
 }
 
 void  OnTriggerExit ( Collider Col  ){
     if(Col.gameObject.tag == "Ladder")
     {
         inside = !inside;
     }
 }
         
 void  Update (){
     if(inside == true && Input.GetKey("w"))
     {
             chController.transform.position += Vector3.up / heightFactor;
     }
 }
 void  Test (){}
 }