using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfileInfoButton : MonoBehaviour
{
    public ProfileElement.ProfileDescription profileDescription;

    public void openPanel() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        ProfileDescriptionSetter pds = FindObjectOfType<ProfileDescriptionSetter>();
        pds.SetUp(profileDescription);
        pds.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void closePanel() {
        ProfileDescriptionSetter pds = FindObjectOfType<ProfileDescriptionSetter>();
        pds.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

}
