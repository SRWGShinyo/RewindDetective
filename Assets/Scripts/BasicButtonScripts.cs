using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BasicButtonScripts : MonoBehaviour
{

    public GameObject panel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

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

    public void Quit()
    {
        Application.Quit();
    }
}
