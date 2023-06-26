using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private float interactionDistance;
    [SerializeField] private LayerMask layersToInteract;

    private PlayerMovement playerMovement;

    private List<Note> interactedNotes;

    public static event Action NotesCollected;
    private bool openDoor = false;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        interactedNotes = new List<Note>();
    }


    void Update()
    {
        RaycastHit? hit = DoRaycast();

        if (hit.HasValue)
        {
            var note = hit.Value.transform.gameObject.GetComponent<Note>();
            if (note)
            {
                Note.showInfo();
                if (Input.GetKeyDown(KeyCode.E) && !note.isShowed())
                {
                    playerMovement.blockMovement = true;

                    if (!interactedNotes.Contains(note))
                    {
                        interactedNotes.Add(note);
                    }
                        
                    note.showNoteUI();
                }
                else if (Input.GetKeyDown(KeyCode.E) && note.isShowed())
                {
                    playerMovement.blockMovement = false;
                    note.closeNoteUI();
                }
            }
        }
        else
        {
            Note.hideInfo();
        }

        ExitController.notesCollected = interactedNotes.Count;

        if (interactedNotes.Count >= 4 && !openDoor)
        {
            openDoor = true;
            Debug.Log("Door opened");
            NotesCollected?.Invoke();
        }
    }

    private RaycastHit? DoRaycast()
    {
        Ray ray = new Ray(camera.position, camera.forward);

        RaycastHit hit;

        bool hasHit = Physics.Raycast(ray, out hit, interactionDistance, layersToInteract);

        if (hasHit)
        {
            return hit;
        }
        return null;
    }
}
