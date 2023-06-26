using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject chooseLevelUI;
    [SerializeField] private CanvasGroup mainMenu;
    [SerializeField] private CanvasGroup guide;
    [SerializeField] private CanvasGroup donate;


    void Start(){
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

        mainMenu.gameObject.SetActive(true);
        guide.gameObject.SetActive(false);
        donate.gameObject.SetActive(false);
	}

    public void PlayGame(){

        chooseLevelUI.SetActive(true);
    }

    public void SelectLevel1()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ShowGuide()
    {
        mainMenu.gameObject.SetActive(false);
        guide.gameObject.SetActive(true);
    }

    public void MakeDonate(){
        Debug.Log("DONATE!");
    }

    public void ReturnToMenu()
    {
        mainMenu.gameObject.SetActive(true);
        guide.gameObject.SetActive(false);
        donate.gameObject.SetActive(false);
    }
}
