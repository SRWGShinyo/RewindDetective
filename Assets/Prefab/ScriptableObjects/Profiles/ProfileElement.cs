using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Profile", menuName = "Profile/Element")]
public class ProfileElement : ScriptableObject
{
    [Serializable]
    public class ProfileDescription
    {
        public Sprite portrait;
        public string characName;
        public int size;
        public int weight;
        public int age;

        public string description;
    }

    public Sprite portrait;
    public string characName;
    public ProfileDescription profile;
}
