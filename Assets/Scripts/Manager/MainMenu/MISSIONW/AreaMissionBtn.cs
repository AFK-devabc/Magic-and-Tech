using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaMissionBtn : MonoBehaviour
{
    [SerializeField] Text NameAreaMission;

    [Header("------------PARENT--------------")]
    [SerializeField] public MISSION_Window parent;

    public int IDArea;

    public void SetAreaMission(AreaMissionConfig config)
    {
        IDArea = config.ID;
        NameAreaMission.text = config.NameArea;
    }

    public void OnClick()
    {
        parent.ONChangeAreaMission(IDArea);
    }
}
