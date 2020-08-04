using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectiveMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GroundHasBeenChecked();
        if (Mathf.Abs(agent.velocity.x) <= 1f && Mathf.Abs(agent.velocity.z) <= 1f)
        {
            anim.SetBool("isWalking", false);
        }
        else
            anim.SetBool("isWalking", true);
    }

    private void GroundHasBeenChecked()
    {
        if (Input.GetMouseButtonDown(0) &&
            !FindObjectOfType<InteractableController>().isInteracting &&
            !FindObjectOfType<InteractableController>().isMoving)
        {
            if (FindObjectOfType<FolderScript>().folderPanel.activeSelf)
                return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Ground")
                    agent.SetDestination(hit.point);
            }
        }
    }

    public void GoTopoint(Vector3 vector)
    {
        agent.SetDestination(vector);
    }
}
