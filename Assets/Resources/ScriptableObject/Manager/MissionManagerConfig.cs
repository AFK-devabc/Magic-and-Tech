using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionManagerConfig", menuName = "Config/MissionManager")]
public class MissionManagerConfig : ScriptableObject
{
    private static MissionManagerConfig instance;
    public static MissionManagerConfig getInstance()
    {
        if (instance == null)
        {
            instance = Resources.Load<MissionManagerConfig>("ScriptableObject/Manager/MissionManagerConfig");
        }
        return instance;
    }

    [SerializeField] private List<AreaMissionConfig> AreaConfigs = new List<AreaMissionConfig>();
    [SerializeField] private List<MissionConfig> MissionConfigs = new List<MissionConfig>();

    // AREA MISSION
    public List<AreaMissionConfig> GetAreaMissionConfigs()
    {
        return AreaConfigs;
    }

    // MISSION
    public List<MissionConfig> GetMissionConfigsByArea(int IDArea)
    {
        return MissionConfigs.FindAll(c=>c.AreaID == IDArea);
    }

    public MissionConfig GetMissionConfigByID(int IDMission)
    {
        return MissionConfigs.Find(c=>c.ID == IDMission);
    }
}

[System.Serializable]
public class AreaMissionConfig
{
    public int ID;
    public string NameArea;
}

[System.Serializable]
public class MissionConfig
{
    public int ID;
    public string nameMission;
    public string descriptionMission;

    public int AreaID;
}


