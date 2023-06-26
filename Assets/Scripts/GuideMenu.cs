using UnityEngine;

public class GuideMenu : MonoBehaviour
{

    [SerializeField] GameObject about;
    [SerializeField] GameObject controlls;

    void Start()
    {
        ShowAbout();
    }

    private void OnEnable()
    {
        ShowAbout();
    }

    public void ShowAbout()
    {
        about.SetActive(true);
        controlls.SetActive(false);
    }

    public void ShowControlls()
    {
        about.SetActive(false);
        controlls.SetActive(true);
    }
}
