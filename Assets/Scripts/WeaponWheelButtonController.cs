using UnityEngine;

public class WeaponWheelButtonController : MonoBehaviour
{
    public int ID;
    public Color color;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void HoverEnter(){
        WeaponWheelController.weaponID = ID;
        WeaponWheelController.changed = true;
        anim.SetBool("Hover", true);
    }

    public void HoverExit(){
        WeaponWheelController.weaponID = 0;
        WeaponWheelController.changed = true;
        anim.SetBool("Hover", false);
    }
}