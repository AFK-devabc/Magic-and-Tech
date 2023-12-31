using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUN_Window : MonoBehaviour
{
    [Header("---------COMPONENT---------")]
    [SerializeField] protected GameObject content;

    [Header("--------PREFABS----------")]
    [SerializeField] Gun_panel_Popup PanelPrefab;

    [Header("------------WINDOW----------")]
    [SerializeField] GunUpgradePopup UpgradePopupWindow;


    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function
    public void Load()
    {
        List<Weapon> lstGN = GunManagerConfig.getInstance().getConfigsOwn();

        if(lstGN != null)
        {
            foreach (Weapon weapon in lstGN)
            {
                Gun_panel_Popup gunpanel = Instantiate(PanelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                gunpanel.SetData(weapon);
                gunpanel.gunUprapeWindow = UpgradePopupWindow;
                gunpanel.transform.parent = content.transform;
                gunpanel.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }


    public void OnExitBtnClick()
    {
        this.gameObject.SetActive(false);  
    }
}
