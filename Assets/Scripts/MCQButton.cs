using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MCQButton : MonoBehaviour
{
    public GameObject buttonsPanel;
    public List<CinemaController.EventDescriptor> events;


    public void ToPlayOnClick()
    {
        EventSystem.current.SetSelectedGameObject(null);
        FindObjectOfType<CinemaController>().events = events;
        buttonsPanel.transform.DOScale(0, 0.4f);
        FindObjectOfType<CinemaController>().LaunchSequenceOfEvent();
    }
}
