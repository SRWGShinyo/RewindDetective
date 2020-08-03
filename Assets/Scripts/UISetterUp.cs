using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISetterUp : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI characName;
    public TextMeshProUGUI characSpeak;

    public AudioSource speaking;

    public void SetUpWith(Sprite portrait_, string characName_)
    {
        portrait.sprite = portrait_;
        characName.text = characName_;
    }

    public void TalkWith(string toTalk)
    {
        StartCoroutine(PrintText(toTalk));
    }

    public void Disappear()
    {
        transform.DOScale(0, 1);
    }

    private IEnumerator PrintText(string textToSpeak)
    {
        speaking.Play();
        transform.DOScale(1, 1);
        FindObjectOfType<CinemaController>().isDialogHappening = true;
        characSpeak.text = "";
        
        for (int i = 0; i < textToSpeak.Length; i++)
        {
            characSpeak.text += textToSpeak[i];
            yield return new WaitForSeconds(0.03f);
        }

        FindObjectOfType<CinemaController>().isDialogHappening = false;
        speaking.Pause();
    }
}
