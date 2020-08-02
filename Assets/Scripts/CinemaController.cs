using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaController : MonoBehaviour
{
    public List<CharacterDefinition> charactersToInteract;
    public List<EventDescriptor> events;

    public UISetterUp uiSetter;

    public bool playOnAwake;
    public bool isDialogHappening;
    public bool isEventing;

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
            END,
            IDLE,
            CRYING,
            LEAVE
        }

        public int characterIndex;
        public eventType eventType_;
        public string whatToSay;
        public Vector3 finalpos;
    }

    void Start()
    {
        if (playOnAwake)
            LaunchSequenceOfEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEventing && Input.GetKeyDown(KeyCode.Return) && !isDialogHappening)
            LaunchNextEvent();
    }

    private void LaunchSequenceOfEvent()
    {
        GoToCinematic();
        LaunchNextEvent();
    }

    private void LaunchNextEvent()
    {
        EventDescriptor toPlay = events[0];
        events.RemoveAt(0);

        switch(toPlay.eventType_)
        {
            case EventDescriptor.eventType.END:
                EndCinematic();
                isEventing = false;
                break;
            case EventDescriptor.eventType.LEAVE:
                charactersToInteract[toPlay.characterIndex].gameObject.SetActive(false);
                break;
            case EventDescriptor.eventType.ANGRY:
                CharacterDefinition def = charactersToInteract[toPlay.characterIndex];
                def.GoAngryState();
                uiSetter.SetUpWith(def.portrait, def.name);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.THINKING:
                CharacterDefinition def1 = charactersToInteract[toPlay.characterIndex];
                def1.GoAngryState();
                uiSetter.SetUpWith(def1.portrait, def1.name);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.CRYING:
                CharacterDefinition def2 = charactersToInteract[toPlay.characterIndex];
                def2.GoAngryState();
                uiSetter.SetUpWith(def2.portrait, def2.name);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.TALKING:
                CharacterDefinition def3 = charactersToInteract[toPlay.characterIndex];
                def3.GoAngryState();
                uiSetter.SetUpWith(def3.portrait, def3.name);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.IDLE:
                CharacterDefinition def4 = charactersToInteract[toPlay.characterIndex];
                def4.GoAngryState();
                uiSetter.SetUpWith(def4.portrait, def4.name);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.WALKING:
                CharacterDefinition def5 = charactersToInteract[toPlay.characterIndex];
                def5.GoWalk(toPlay.finalpos);
                break;
        }
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
