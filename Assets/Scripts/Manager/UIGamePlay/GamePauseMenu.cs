using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseMenu : MonoBehaviour
{
    [Header("-------------COMPONENT--------------")]
    [SerializeField] GameObject SettingWindow;
    
    public void OnReStartBtn()
    {

    }

    public void OnExitBtn()
    {

    }

    public void OnResumeBtn()
    {

    }

    public void OnSettingBtn()
    {
        if(SettingWindow != null)
        {
            SettingWindow.SetActive(true);
        }

        this.gameObject.SetActive(false);
    }
}
