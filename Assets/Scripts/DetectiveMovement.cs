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
        Debug.Log(agent.velocity);
        if (Mathf.Abs(agent.velocity.x) <= 1f && Mathf.Abs(agent.velocity.z) <= 1f)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    private void GroundHasBeenChecked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Ground")
                    agent.SetDestination(hit.point);
            }
        }
    }
}
