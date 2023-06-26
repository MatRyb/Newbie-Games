using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private TextData text;
    [SerializeField] private int fontSize = 40;

    private GameObject notesUI;

    private GameObject note;
    private Text noteText;
    private static Text info;

    private string read = "Press E to read";
    private string close = "Press E to close";

    private bool showNote = false;

    private Vector3 startPosition;

    private void Start()
    {
        notesUI = GameObject.Find("NotesUI");

        note = notesUI.transform.GetChild(0).gameObject;
        noteText = note.transform.GetChild(0).GetComponent<Text>();
        info = notesUI.transform.GetChild(1).GetComponent<Text>();

        noteText.fontSize = fontSize;

        info.text = read;

        startPosition = transform.position;

        note.SetActive(false);
        info.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, .1f);
        transform.position = Vector3.Lerp(startPosition, startPosition + new Vector3(0, .2f, 0), (Mathf.Sin(Time.time)+1)/2);
    }

    public bool isShowed()
    {
        return showNote;
    }

    public static void showInfo()
    {
        info.gameObject.SetActive(true);
    }

    public static void hideInfo()
    {
        if(info != null && info.gameObject != null){
        info.gameObject.SetActive(false);

        }

    }

    public void showNoteUI()
    {
        noteText.text = text.Text;
        note.SetActive(true);
        info.text = close;
        showNote = true;
    }

    public void closeNoteUI()
    {
        note.SetActive(false);
        info.text = read;
        showNote = false;
    }

}
