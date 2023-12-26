using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGun_panel_Popup : MonoBehaviour
{
    [Header("------------COMPONENT---------------")]
    [SerializeField] Text NameGun;
    [SerializeField] Image img;
    [SerializeField] Text coinText;

    [Header("-------------PARENT-------------")]
    [SerializeField] public SHOPGUN_Window Pwindow;

    public int ID;

    //[Header("------------PARAMS------------------")]
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBuyBtn()
    {
        Pwindow.Delete(this.gameObject);

        UIMainMenuManager.getInstance().OpenMessageBox("Notification", "Buy gun successful", new Vector3(0f, 0f, 0f));

        Destroy(gameObject);
    }

    public void setGun(int ID)
    {
        // update data
        Weapon gun = GunManagerConfig.getInstance().getConfig(ID);
        if (gun != null)
        {
            this.ID = ID;
            NameGun.text = gun.name.ToUpper();
            img.sprite = gun.avatar;
            img.SetNativeSize();
        }
        else this.gameObject.SetActive(false);
    }
}
