using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
struct UI
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI notes;
}

public class ExitController : MonoBehaviour
{
    private GameObject barrier;

    private float time = 0.0f;
    public static int notesCollected = 0;

    [SerializeField] GameObject statsUI;
    [SerializeField] private UI ui;

    void Start()
    { 
        InteractionSystem.NotesCollected += OpenBarrier;

        statsUI.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    private void Win()
    {
        statsUI.SetActive(true);
        ui.notes.text = string.Format("Collected {0}/4 notes", notesCollected);
        ui.time.text = string.Format("You finished game in {0}m {1}s", Mathf.FloorToInt(time/60), (int)time%60);
    }

    private void OpenBarrier()
    {
        barrier = GameObject.Find("Barrier");
        barrier.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Win();
        GameManager.WinGame();
    }
}
