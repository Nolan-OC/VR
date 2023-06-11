using HurricaneVR.Framework.Core.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Item Info")]
    public string name;
    public float weight;

    [Header("Socketable Tags")]
    public HVRSocketableTag Tags;
}
