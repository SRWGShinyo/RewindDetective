using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hint", menuName = "Hint/Element")]
public class HintDescription : ScriptableObject
{
    public Sprite image;
    public string description;

    public HintDescription combineWith;
    public HintDescription givesBack;

    public Interactable.Action actionIfFused;
}
