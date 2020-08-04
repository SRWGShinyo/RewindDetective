using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FolderScript : MonoBehaviour
{
    public GameObject folderPanel;
    public GameObject profilePanel;
    public GameObject hintPanel;

    public GameObject contentProfile;
    public GameObject contentHint;
    public GameObject profileEntry;
    public GameObject hintEntry;

    public void openFolder()
    {
        if (FindObjectOfType<CinemaController>().isEventing || FindObjectOfType<InteractableController>().isInteracting ||
            FindObjectOfType<InteractableController>().isInteracting)
            return;
        EventSystem.current.SetSelectedGameObject(null);
        folderPanel.SetActive(true);
        openProfiles();
    }

    public void closeFolder()
    {
        EventSystem.current.SetSelectedGameObject(null);

        folderPanel.SetActive(false);
    }

    public void openProfiles()
    {
        EventSystem.current.SetSelectedGameObject(null);
        profilePanel.SetActive(true);
        hintPanel.SetActive(false);

        foreach (Transform tr in contentProfile.transform)
        {
            if (tr == contentProfile.transform)
                continue;

            Destroy(tr.gameObject);
        }

        DetectiveHolderBehaviour detective = FindObjectOfType<DetectiveHolderBehaviour>();
        foreach (ProfileElement element in detective.profiles)
        {
            GameObject profile = Instantiate(profileEntry, contentProfile.transform);
            profile.GetComponentInChildren<ProfileInfoButton>().profileDescription = element.profile;
            profile.GetComponentInChildren<Image>().sprite = element.portrait;
            profile.GetComponentInChildren<TextMeshProUGUI>().text = element.characName;
        }
    }

    public void openHints()
    {
        EventSystem.current.SetSelectedGameObject(null);
        profilePanel.SetActive(false);
        hintPanel.SetActive(true);


        foreach (Transform tr in contentHint.transform)
        {
            if (tr == contentHint.transform)
                continue;

            Destroy(tr.gameObject);
        }

        DetectiveHolderBehaviour detective = FindObjectOfType<DetectiveHolderBehaviour>();
        foreach (HintDescription hint in detective.hints)
        {
            GameObject hintGO = Instantiate(hintEntry, contentHint.transform);
            hintGO.GetComponentInChildren<Image>().sprite = hint.image;
            hintGO.GetComponentInChildren<TextMeshProUGUI>().text = hint.description;
            hintGO.GetComponentInChildren<HintHolderInfo>().hint = hint;
        }
    }
}
