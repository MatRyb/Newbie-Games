using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    public Animator anim;
    public FlashlightControler flashlight;
    public Button[] buttons;
    public PlayerMovement playerMovement;
    public static bool changed = false;
    public static int weaponID;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            OpeningWeaponWheel();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ClosingWeaponWheel();
        }

        if (changed)
        {
            switch (weaponID)
            {
                case 1:
                    flashlight.SetLightColor(new Color(1, 0.98f, 0.79f));
                    break;
                case 2:
                    flashlight.SetLightColor(Color.blue);
                    break;
                case 3:
                    flashlight.SetLightColor(Color.red);
                    break;
                case 4:
                    flashlight.SetLightColor(Color.green);
                    break;
                default:
                    break;

            }
            changed = false;
        }
    }

    void OpeningWeaponWheel(){
        anim.SetBool("OpenWeaponWheel", true);
        foreach(Button button in buttons){
            button.interactable = true;
        }
        playerMovement.blockMovement = true;
    }

    void ClosingWeaponWheel(){
        anim.SetBool("OpenWeaponWheel", false);
        foreach(Button button in buttons){
            button.interactable  = false;
        }
        playerMovement.blockMovement = false;
    }

}
