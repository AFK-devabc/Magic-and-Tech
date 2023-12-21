using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunManagerConfig", menuName = "Config/GunManager")]
public class GunManagerConfig : ScriptableObject
{
    private static GunManagerConfig instance;
    public static GunManagerConfig getInstance()
    {
        if (instance == null)
        {
            instance = Resources.Load<GunManagerConfig>("ScriptableObject/Manager/GunManagerConfig");
        }
        return instance;
    }

    [SerializeField] private List<Weapon> configs = new List<Weapon>();

    public Weapon getConfig(int ID)
    {
        return configs.Find(c => c.ID == ID);
    }

    public List<Weapon> getListConfigs()
    {
        return configs;
    }

    public List <Weapon> getConfigsNotOwn()
    {
        return configs.FindAll(c => c.owned == false);
    }

    public List <Weapon> getConfigsOwn()
    {
        return configs.FindAll(c=>c.owned == true);
    }

    public List<Weapon> getConfigByType(int type)
    {
        return configs.FindAll(c=>c.type == type);
    }
}
