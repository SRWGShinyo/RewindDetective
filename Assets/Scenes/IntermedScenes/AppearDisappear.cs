using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppearDisappear : MonoBehaviour
{
    public float onScene = 4f;
    public TextMeshProUGUI text;
    public int nextScene;

    private void Start()
    {
        StartCoroutine(AppearDisapear());
    }

    private IEnumerator AppearDisapear()
    {
        while (text.color.a < 1f)
        {
            Color color = text.color;
            color.a += 0.02f;
            text.color = color;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(3f);

        while (text.color.a > 0f)
        {
            Color color = text.color;
            color.a -= 0.02f;
            text.color = color;
            yield return new WaitForSeconds(0.02f);
        }

        SceneManager.LoadScene(nextScene);
    }
}
