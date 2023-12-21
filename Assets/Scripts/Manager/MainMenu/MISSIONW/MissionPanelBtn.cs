using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanelBtn : MonoBehaviour
{
    [SerializeField] Text nameMission;
    //[SerializeField] string contentMission;

    [SerializeField] public MISSION_Window parent;

    public int IDMission;

    public void setMisson(MissionConfig config)
    {
        IDMission = config.ID;
        nameMission.text = config.nameMission;
        //contentMission = config.descriptionMission;
    }

    public void OnClick()
    {
        parent.selectMission(IDMission);
    }
}
