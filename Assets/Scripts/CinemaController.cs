using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaController : MonoBehaviour
{
    public List<CharacterDefinition> charactersToInteract;
    public List<EventDescriptor> events;

    public bool playOnAwake;

    public CinemaBandMover band1;
    public CinemaBandMover band2;

    [Serializable]
    public class EventDescriptor
    {
        public enum eventType
        {
            THINKING,
            TALKING,
            WALKING,
            ANGRY,
            IDLE,
            CRYING,
            LEAVE
        }

        public int characterIndex;
        public eventType eventType_;
        public string whatToSay;
        public Vector3 finalpos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCinematic()
    {
        band1.GoToCinematic();
        band2.GoToCinematic();
    }

    public void EndCinematic()
    {
        band1.EndCinematic();
        band2.EndCinematic();
    }
}
