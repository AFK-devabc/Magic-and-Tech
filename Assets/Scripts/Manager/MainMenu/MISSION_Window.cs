using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MISSION_Window : MonoBehaviour
{
    [Header("--------------COMPONENT--------------")]
    [SerializeField] Text nameCurrentMission;
    [SerializeField] Text contentCurrentMission;
    [SerializeField] Transform contentArea;
    [SerializeField] Transform contentMission;


    [Header("------------FREFABS------------")]
    [SerializeField] AreaMissionBtn AreaMissionBtn;
    [SerializeField] MissionPanelBtn MissionPanelBtn;

    [Header("-----------LIST MISSION----------")]
    [SerializeField] List<MissionPanelBtn> lstMissions;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event click
    public void OnClickCloseBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void Load()
    {
        // create load list area mission
        List<AreaMissionConfig> lstAreaMission = MissionManagerConfig.getInstance().GetAreaMissionConfigs();

        if (lstAreaMission != null)
        {
            foreach (AreaMissionConfig area in lstAreaMission)
            {
                AreaMissionBtn areaBtn = Instantiate(AreaMissionBtn, new Vector3(0, 0, 0), Quaternion.identity);
                areaBtn.transform.parent = contentArea;

                areaBtn.transform.localScale = Vector3.one;
                areaBtn.SetAreaMission(area);
                areaBtn.parent = this;
            }
        }

        ONChangeAreaMission(lstAreaMission[0].ID);
    }


    public void ONChangeAreaMission(int IDAreaMission)
    {
        foreach (MissionPanelBtn mission in lstMissions)
        {
            Destroy(mission.gameObject);
        }

        lstMissions.Clear();

        List<MissionConfig> lstMission = MissionManagerConfig.getInstance().GetMissionConfigsByArea(IDAreaMission);

        if (lstMission != null)
        {
            foreach (MissionConfig mission in lstMission)
            {
                MissionPanelBtn missionBtn = Instantiate(MissionPanelBtn, new Vector3(0, 0, 0), Quaternion.identity);

                missionBtn.transform.parent = contentMission;
                missionBtn.setMisson(mission);
                missionBtn.parent = this;
                missionBtn.transform.localScale = Vector3.one;
                missionBtn.transform.localRotation = Quaternion.Euler(0,0,0);

                lstMissions.Add(missionBtn);
            }
        }

        selectMission(lstMission[0].ID);
    }

    public void selectMission(int IDMission)
    {
        MissionConfig mission = MissionManagerConfig.getInstance().GetMissionConfigByID(IDMission);

        nameCurrentMission.text = mission.nameMission.ToString();
        contentCurrentMission.text = mission.descriptionMission.ToString();
    }
}
