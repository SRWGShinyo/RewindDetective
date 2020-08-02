using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiscoLightsYipee : MonoBehaviour
{
    public List<DiscoLightsYipee> discos;

    // Start is called before the first frame update
    void Start()
    {
        discos = FindObjectsOfType<DiscoLightsYipee>().ToList();
        StartCoroutine(FindMovePoint());
    }

    private IEnumerator FindMovePoint()
    {
        int movePoint = Random.Range(0, discos.Count);
        while (discos[movePoint] == this)
            movePoint =  Random.Range(0, discos.Count);

        transform.DOMove(discos[movePoint].transform.position, 20f);
        yield return new WaitForSeconds(20f);
        StartCoroutine(FindMovePoint());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
