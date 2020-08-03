using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HInt : MonoBehaviour
{
    public IEnumerator AppearAndDisappear()
    {
        transform.DOScale(1f, 1f);
        yield return new WaitForSeconds(2f);
        transform.DOScale(0f, 1f);
    }
}
