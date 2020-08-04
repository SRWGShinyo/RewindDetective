using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveHolderBehaviour : MonoBehaviour
{
    public static DetectiveHolderBehaviour detect;

    private void Awake()
    {
        if (detect != null && detect != this)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            detect = this;
        }
    }

    public List<HintDescription> hints;
    public List<ProfileElement> profiles;
}
