using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    bool gameHasEnded = false;

    static bool win = false;

    [SerializeField] private int delayTime = 1;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        { 
            playerMovement.blockMovement = true;
            playerHealth.healthBar.ShowGameOver(true);
            EndGame();
        }

        if (win)
        {
            playerMovement.blockMovement = true;
            EndGame();
        }
    }


    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }
    }

    public static void WinGame()
    {
        win = true;
    }

    void Restart()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }
}
