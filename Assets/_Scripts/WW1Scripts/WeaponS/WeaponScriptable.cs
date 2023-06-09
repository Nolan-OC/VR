using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObjects/New Gun", order = 1)]
public class GunScriptableObject : ScriptableObject
{
    public string weaponName;
    public float weaponDmg;

    //reload stats
    public int magSize;

    public float weaponRange;
}
