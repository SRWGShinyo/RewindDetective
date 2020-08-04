using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    public Material selected;
    Queue<Material> store = new Queue<Material>();
    CinemaController cinema;

    public Interactable interacted = null;
    public bool isInteracting;
    public bool isMoving;

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
            FindObjectOfType<DetectiveMovement>().GoTopoint(interacted.toPosition.transform.position);
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
}
