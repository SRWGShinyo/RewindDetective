using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleButtonScript : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        panel.SetActive(false);
    }
}
