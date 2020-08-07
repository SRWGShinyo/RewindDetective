using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class MCQButton : MonoBehaviour
{
    public GameObject buttonsPanel;
    public List<CinemaController.EventDescriptor> events;


    public void ToPlayOnClick()
    {
        FindObjectOfType<CinemaController>().events = events;
        buttonsPanel.transform.DOScale(0, 0.4f);
        FindObjectOfType<CinemaController>().LaunchSequenceOfEvent();
    }
}
