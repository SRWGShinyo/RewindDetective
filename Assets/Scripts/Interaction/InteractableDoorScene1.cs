using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorScene1 : Interactable
{
    [Serializable]
    public class interactionSummary
    {
        public GameObject interactable;
        public Action actionToDisplay;
        public int countRef;
    }

    public Action ifNotFused;
    public Action letsLeave;
    public List<HintDescription> toHaveToLeave;
    public List<interactionSummary> toInteractProperly;

    public override void PlayDoor()
    {
        Action awaited = checkForEnd();
        List<CinemaController.EventDescriptor> events = new List<CinemaController.EventDescriptor>();
        foreach (CinemaController.EventDescriptor evt in awaited.events)
            events.Add(evt);

        FindObjectOfType<CinemaController>().events = events;
        FindObjectOfType<CinemaController>().LaunchSequenceOfEvent();
    }

    private Action checkForEnd()
    {
        DetectiveHolderBehaviour dect = FindObjectOfType<DetectiveHolderBehaviour>();
        foreach (interactionSummary ins in toInteractProperly)
        {
            if (ins.interactable.GetComponent<Interactable>().actions.Count >= ins.countRef)
                return ins.actionToDisplay;
        }

        foreach (HintDescription hint in toHaveToLeave)
        {
            if (!dect.hints.Contains(hint))
                return ifNotFused;
        }

        return letsLeave;
    }
}
