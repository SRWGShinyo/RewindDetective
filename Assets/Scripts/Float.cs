using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    float refy;
    bool isDescending = false;
    // Start is called before the first frame update
    void Start()
    {
        refy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDescending)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            if (transform.position.y >= refy + 2f)
                isDescending = true;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            if (transform.position.y <= refy - 2f)
                isDescending = false;
        }
    }
}
