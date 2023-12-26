using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemManagerConfig", menuName = "Config/ItemManager")]
public class ItemManagerConfig : ScriptableObject
{
    private static ItemManagerConfig instance;
    public static ItemManagerConfig getInstance()
    {
        if (instance == null)
        {
            instance = Resources.Load<ItemManagerConfig>("ScriptableObject/Manager/ItemManagerConfig");
        }
        return instance;
    }

    [SerializeField] private List<Item> configs = new List<Item>();

    public Item getConfig(int ID)
    {
        return configs.Find(c => c.ID == ID);
    }

    public List<Item> getListConfigs()
    {
        return configs;
    }

    public List<Item> getConfigsOwn()
    {
        return configs.FindAll(c => c.quanity > 0);
    }

    public List<Item> getConfigByType(int type)
    {
        return configs.FindAll(c => c.type == type);
    }
}
