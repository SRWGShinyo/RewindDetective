using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuseHintButton : MonoBehaviour
{
    public bool isSelected;

    public void Select()
    {
        if (isSelected)
            UnSelectTotally();
        else
            SelectTotally();
    }

    private void UnSelectTotally()
    {
        Color color = GetComponent<Image>().color;
        color.a = 0f;
        GetComponent<Image>().color = color;

        FindObjectOfType<InteractableController>().RemoveFromSelection(GetComponentInParent<HintHolderInfo>());

        isSelected = false;
    }

    private void SelectTotally()
    {
        isSelected = true;

        Color color = GetComponent<Image>().color;
        color.a = 0.2f;
        GetComponent<Image>().color = color;

        FindObjectOfType<InteractableController>().AddToSelection(GetComponentInParent<HintHolderInfo>());

    }
}
