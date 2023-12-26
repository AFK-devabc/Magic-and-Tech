using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SETTING_Window : MonoBehaviour
{
    [Header("----------COMPONENT------------")]
    [SerializeField] Dropdown dropdownResolution;

    [SerializeField] GameObject parentW;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // EVENT
    public void ChangeResolution()
    {
        //Debug.Log(dropdownResolution.options[dropdownResolution.value].text);
        string[] reso = dropdownResolution.options[dropdownResolution.value].text.Split('x');
        Screen.SetResolution(int.Parse(reso[0]), int.Parse(reso[1]), false);
    }

    public void ChangeMusicVolume()
    {

    }

    public void ChangeEffectVolumne()
    {

    }

    public void OnExitBtnClick()
    {
        if(parentW != null)
        {
            parentW.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
