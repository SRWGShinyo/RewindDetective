using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileDescriptionSetter : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI characName;
    public TextMeshProUGUI age;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI height;
    public TextMeshProUGUI descriptionT;


    public void SetUp(ProfileElement.ProfileDescription description)
    {
        portrait.sprite = description.portrait;
        characName.text = description.characName;
        age.text = description.age.ToString();
        weight.text = description.weight.ToString();
        height.text = description.size.ToString();
        descriptionT.text = description.description;
    }
}
