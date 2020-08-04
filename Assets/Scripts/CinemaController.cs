using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaController : MonoBehaviour
{
    public List<CharacterDefinition> charactersToInteract;
    public List<EventDescriptor> events;

    public UISetterUp uiSetter;

    public bool playOnAwake;
    public bool isDialogHappening;
    public bool isEventing;

    public Image toFadeIn;

    public GameObject newHintPanel;

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
            LEAVE,
            FADE,
            HINT,
            PROFILE
        }

        public int characterIndex;
        public eventType eventType_;
        public string whatToSay;
        public Vector3 finalpos;
        public bool isSpeaking;
        public HintDescription hintToGive;
        public ProfileElement profileToGive;
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

    public void LaunchSequenceOfEvent()
    {
        isEventing = true;
        GoToCinematic();
        LaunchNextEvent();
    }

    private void LaunchNextEvent()
    {
        if (events.Count == 0)
            return;

        EventDescriptor toPlay = events[0];
        events.RemoveAt(0);

        switch(toPlay.eventType_)
        {
            case EventDescriptor.eventType.END:
                CharacterDefinition def12 = charactersToInteract[toPlay.characterIndex];
                def12.GoIdleState();
                EndCinematic();
                uiSetter.Disappear();
                if (FindObjectOfType<InteractableController>().isInteracting)
                    FindObjectOfType<InteractableController>().PingAction();
                isEventing = false;
                break;
            case EventDescriptor.eventType.HINT:
                FindObjectOfType<DetectiveHolderBehaviour>().hints.Add(toPlay.hintToGive);
                StartCoroutine(newHintPanel.GetComponent<HInt>().AppearAndDisappear());
                uiSetter.Disappear();
                LaunchNextEvent();
                break;
            case EventDescriptor.eventType.PROFILE:
                FindObjectOfType<DetectiveHolderBehaviour>().profiles.Add(toPlay.profileToGive);
                LaunchNextEvent();
                break;
            case EventDescriptor.eventType.LEAVE:
                uiSetter.Disappear();
                LaunchNextEvent();
                charactersToInteract[toPlay.characterIndex].gameObject.SetActive(false);
                break;
            case EventDescriptor.eventType.ANGRY:
                CharacterDefinition def = charactersToInteract[toPlay.characterIndex];
                def.GoAngryState();
                uiSetter.SetUpWith(def.portrait, def.characterName);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.THINKING:
                CharacterDefinition def1 = charactersToInteract[toPlay.characterIndex];
                def1.GoThinkingState();
                uiSetter.SetUpWith(def1.portrait, def1.characterName);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.CRYING:
                CharacterDefinition def2 = charactersToInteract[toPlay.characterIndex];
                def2.GoCryingState();
                uiSetter.SetUpWith(def2.portrait, def2.characterName);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.TALKING:
                CharacterDefinition def3 = charactersToInteract[toPlay.characterIndex];
                def3.GoTalkingState();
                uiSetter.SetUpWith(def3.portrait, def3.characterName);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.IDLE:
                CharacterDefinition def4 = charactersToInteract[toPlay.characterIndex];
                def4.GoIdleState();
                if (!toPlay.isSpeaking)
                {
                    uiSetter.Disappear();
                    LaunchNextEvent();
                    break;
                }
                uiSetter.SetUpWith(def4.portrait, def4.characterName);
                uiSetter.TalkWith(toPlay.whatToSay);
                break;
            case EventDescriptor.eventType.WALKING:
                CharacterDefinition def5 = charactersToInteract[toPlay.characterIndex];
                def5.GoWalk(toPlay.finalpos);
                LaunchNextEvent();
                uiSetter.Disappear();
                break;
            case EventDescriptor.eventType.FADE:
                uiSetter.Disappear();
                StartCoroutine(Fade(toFadeIn));
                if (FindObjectOfType<InteractableController>() && FindObjectOfType<InteractableController>().isInteracting)
                    FindObjectOfType<InteractableController>().PingAction();
                isEventing = false;
                break;
        }
    }

    private IEnumerator Fade(Image image)
    {
        while (image.color.a < 1f)
        {
            Color color = image.color;
            color.a += 0.1f;
            yield return new WaitForSeconds(0.1f);
            image.color = color;
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
