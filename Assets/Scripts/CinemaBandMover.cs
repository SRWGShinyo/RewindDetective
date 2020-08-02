using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaBandMover : MonoBehaviour
{
    public GameObject endPoint;
    Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    public void GoToCinematic()
    {
        transform.DOMove(endPoint.transform.position, 1f);
    }

    public void EndCinematic()
    {
        transform.DOMove(startPos, 1f);
    }
}
