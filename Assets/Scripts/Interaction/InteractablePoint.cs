using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        InteractableController interaC = FindObjectOfType<InteractableController>();
        if (interaC.isInteracting)
            interaC.PingMovement();
    }
}
