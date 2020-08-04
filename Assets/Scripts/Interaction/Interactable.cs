using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject toPosition;

    [Serializable]
    public class Action
    {
        public List<CinemaController.EventDescriptor> events;
    }

    public List<Action> actions;
    public Action deflt;

    public void PlayNext()
    {
        CinemaController cinemator = FindObjectOfType<CinemaController>();
        List<CinemaController.EventDescriptor> events = new List<CinemaController.EventDescriptor>();
        if (actions.Count == 0)
        {
            foreach (CinemaController.EventDescriptor evt in deflt.events)
                events.Add(evt);

            cinemator.events = events;
        }

        else
        {
            foreach (CinemaController.EventDescriptor evt in actions[0].events)
                events.Add(evt);

            cinemator.events = events;
            actions.RemoveAt(0);
        }

        cinemator.LaunchSequenceOfEvent();
    }

    public virtual void PlayDoor()
    {
        Debug.LogError("Not a door");
    }
}
