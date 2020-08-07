using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalButtonsController : MonoBehaviour
{
    [Serializable]
    public class ButtonQuizz
    {
        public List<string> sentence;
        public List<Interactable.Action> actionOnClick;
    }

    [Serializable]
    public class ButtonAction
    {
        public List<string> sentences;
        public List<ButtonQuizz> buttonsInteractions;
    }

    public ButtonAction action;
    public List<GameObject> allButtons;
    public GameObject buttonPanel;
    public TextMeshProUGUI question;

    public void setUpPanel(int index)
    {
        FindObjectOfType<DetectiveMovement>().enabled = false;
        question.text = action.sentences[index];
        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = action.buttonsInteractions[index].sentence[i];
            List<CinemaController.EventDescriptor> newEvents = new List<CinemaController.EventDescriptor>();
            foreach (CinemaController.EventDescriptor ed in action.buttonsInteractions[index].actionOnClick[i].events)
                newEvents.Add(ed);

            allButtons[i].GetComponent<MCQButton>().events = newEvents;
        }

        buttonPanel.transform.DOScale(1f, 0.8f);
    }
}
