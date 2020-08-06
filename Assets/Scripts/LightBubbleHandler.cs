using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBubbleHandler : MonoBehaviour
{
    Light light;
    float toadd = 0.01f;
    private void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    private void Update()
    {

        if (light.intensity <= 0f)
            toadd = -toadd;
        if (light.intensity >= 2f)
            toadd = -toadd;

        light.intensity += toadd * 2;
    }
}
