using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TYPE_ITEM
{
    POTION = 1,
    UPGRADE = 2,
    COIN = 3,
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public int ID;
    public string Name;
    public int type;

    [Header("-----------COMPONENT----------")]
    public Sprite avatar;
    public int price;

    public int quanity;
}
