using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        InteractableController interaC = FindObjectOfType<InteractableController>();
        DetectiveMovement detective = FindObjectOfType<DetectiveMovement>();
        if (interaC.isMoving && interaC.interacted == gameObject.GetComponentInParent<Interactable>())
        {
            detective.transform.LookAt(transform.parent);
            interaC.PingMovement();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        InteractableController interaC = FindObjectOfType<InteractableController>();
        DetectiveMovement detective = FindObjectOfType<DetectiveMovement>();

        if (interaC.isMoving && !interaC.isInteracting && interaC.interacted == gameObject.GetComponentInParent<Interactable>())
        {
            detective.transform.LookAt(transform.parent);
            interaC.PingMovement();
        }
    }
}
