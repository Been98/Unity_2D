using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string name;
    public Sprite img;
    public int atk;
    public Color32 nameColor;
}
