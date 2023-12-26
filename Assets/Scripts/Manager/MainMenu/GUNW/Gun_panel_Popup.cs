using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_panel_Popup : MonoBehaviour
{
    [Header("----------COMPONENT------------")]
    [SerializeField] Text NameGun;
    [SerializeField] Image img;
    [SerializeField] Text Decription;
    [SerializeField] Text Level;
    [SerializeField] SliderRunTo1 slider;

    [Header("--------WINDOW-----------")]
    [SerializeField] public GunUpgradePopup gunUprapeWindow;

    public int ID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {

    }

    public void SetData(Weapon weapon)
    {
        this.ID = weapon.ID;
        NameGun.text = weapon.Name;
        img.sprite = weapon.avatar;
        Decription.text = "";
        Level.text = weapon.level.ToString();
        slider.percent = weapon.level *1.0f/80;
    }

    public void OnSelect()
    {
        UIMainMenuManager.getInstance().updateSelectGun(ID);
    }

    public void ONUpgrade()
    {
        gunUprapeWindow.gameObject.SetActive(true);
        gunUprapeWindow.setGun(ID);
    }
}
