using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class InteractableController : MonoBehaviour
{
    public Material selected;
    Queue<Material> store = new Queue<Material>();
    CinemaController cinema;

    public Interactable interacted = null;
    public bool isInteracting;
    public bool isMoving;

    HintHolderInfo h1;
    HintHolderInfo h2;

    public Interactable.Action defaultUnfused;

    private void Start()
    {
        cinema = FindObjectOfType<CinemaController>();
    }

    void Update()
    {
        if (!isMoving && !isInteracting && !cinema.isEventing && GetOnInteractable() && Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            goBackToProperColor(interacted.transform);
            if (interacted.toPosition == null)
            {
                isMoving = false;
                isInteracting = true;
                interacted.PlayDoor();
            }
            else
                FindObjectOfType<DetectiveMovement>().GoTopoint(interacted.toPosition.transform.position);

            FindObjectOfType<FolderScript>().closeFolder();
        }
    }

    private bool GetOnInteractable()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "Interactable")
            {
                if (interacted == hit.transform.gameObject.GetComponent<Interactable>())
                    return true;

                if (interacted != null)
                {
                    goBackToProperColor(interacted.transform);
                }

                interacted = hit.transform.gameObject.GetComponent<Interactable>();
                changeColorForInteracted(interacted.transform);
                return true;
            }

            else if (interacted != null)
            {
                goBackToProperColor(interacted.transform);
                interacted = null;
                return false;
            }
        }

        else if (interacted != null)
        {
            goBackToProperColor(interacted.transform);
            interacted = null;
            return false;
        }

        return false;
    }

    private void changeColorForInteracted(Transform transform)
    {
        MeshRenderer meshr = transform.gameObject.GetComponent<MeshRenderer>();
        SkinnedMeshRenderer meshskin = transform.gameObject.GetComponent<SkinnedMeshRenderer>();
        if (meshr != null)
        {
            store.Enqueue(meshr.material);
            meshr.material = selected;
        }

        else if (meshskin != null)
        {
            store.Enqueue(meshskin.material);
            meshskin.material = selected;
        }

        foreach (Transform tr in transform)
        {
            if (tr == transform)
                continue;

            changeColorForInteracted(tr);
        }
    }

    private void goBackToProperColor(Transform transform)
    {
        MeshRenderer meshr = transform.gameObject.GetComponent<MeshRenderer>();
        SkinnedMeshRenderer meshskin = transform.gameObject.GetComponent<SkinnedMeshRenderer>();

        if (store.Count == 0)
            return;

        if (meshr != null)
        {
            Material mat = store.Dequeue();
            meshr.material = mat;
        }

        else if (meshskin != null)
        {
            Material mat = store.Dequeue();
            meshskin.material = mat;
        }

        foreach (Transform tr in transform)
        {
            if (tr == transform)
                continue;

            goBackToProperColor(tr);
        }
    }

    public void PingMovement()
    {
        if (!isMoving || isInteracting)
            return;

        isMoving = false;
        isInteracting = true;
        interacted.PlayNext();
    }

    public void PingAction()
    {
        isInteracting = false;
        interacted = null;
    }

    public void AddToSelection(HintHolderInfo h)
    {
        if (h1 != null && h2 != null)
            return;

        if (h1 == null)
            h1 = h;

        else if (h2 == null)
            h2 = h;

        if (h1 != null && h2 != null)
            GoForFuse();
    }

    public void RemoveFromSelection(HintHolderInfo h)
    {
        if (h1 == h)
            h1 = null;
        if (h2 == h)
            h2 = null;
    }

    private void GoForFuse()
    {
        if (h1.hint.combineWith != h2.hint)
        {
            List<CinemaController.EventDescriptor> eventsCopy = new List<CinemaController.EventDescriptor>();
            foreach (CinemaController.EventDescriptor ed in defaultUnfused.events)
                eventsCopy.Add(ed);

            GameObject.FindGameObjectWithTag("HintButton").GetComponent<FolderScript>().openHints();
            h1 = null;
            h2 = null;
            FindObjectOfType<CinemaController>().events = eventsCopy;
            FindObjectOfType<CinemaController>().LaunchSequenceOfEvent();
            return;
        }

        else
        {
            DetectiveHolderBehaviour detective = FindObjectOfType<DetectiveHolderBehaviour>();
            detective.hints.Remove(h1.hint);
            detective.hints.Remove(h2.hint);
            detective.hints.Add(h1.hint.givesBack);

            List<CinemaController.EventDescriptor> eventsCopy = new List<CinemaController.EventDescriptor>();
            foreach (CinemaController.EventDescriptor ed in h1.hint.actionIfFused.events)
                eventsCopy.Add(ed);

            FindObjectOfType<CinemaController>().events = eventsCopy;
            FindObjectOfType<CinemaController>().LaunchSequenceOfEvent();
            GameObject.FindGameObjectWithTag("HintButton").GetComponent<FolderScript>().openHints();
            return;
        }
    }
}
