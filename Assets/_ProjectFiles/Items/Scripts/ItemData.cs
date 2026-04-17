using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string IetmID;
    public string Name;
    [TextArea] public string Description;
    
}
