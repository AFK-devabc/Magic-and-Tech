using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKILL_Window : MonoBehaviour
{
    [Header("---------COMPONENT---------")]
    [SerializeField] protected GameObject content;

    [Header("--------PREFABS----------")]
    [SerializeField] Item_Panel_PopUp PanelPrefab;

    //[Header("------------WINDOW----------")]
    //[SerializeField] GunUpgradePopup UpgradePopupWindow;
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
        List<Item> lstGN = ItemManagerConfig.getInstance().getConfigsOwn();

        if (lstGN != null)
        {
            foreach (Item item in lstGN)
            {
                Item_Panel_PopUp itempanel = Instantiate(PanelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                itempanel.SetData(item);
                //itempanel.gunUprapeWindow = UpgradePopupWindow;
                itempanel.transform.parent = content.transform;
                itempanel.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }


    public void OnExitBtnClick()
    {
        this.gameObject.SetActive(false);
    }
}
