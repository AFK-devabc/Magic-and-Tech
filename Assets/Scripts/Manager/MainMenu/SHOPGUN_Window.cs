using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOPGUN_Window : MonoBehaviour
{
    [Header("------------COMPONENT---------------")]
    [SerializeField] GameObject content;

    [Header("------------FREFABS-----------------")]
    [SerializeField] ShopGun_panel_Popup gunPanel;

    [SerializeField] List<GameObject> lstWeapon;

    // Start is called before the first frame update
    void Start()
    {
        OnGunTypeBtn(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGunTypeBtn(int typeGun)
    {
        foreach(GameObject weapon in lstWeapon)
        {
            Destroy(weapon);    
        }

        lstWeapon.Clear();

        List<Weapon> lstGN = GunManagerConfig.getInstance().getConfigByType(typeGun);

        if (lstGN != null)
        {
            foreach (Weapon weapon in lstGN)
            {
                ShopGun_panel_Popup gunpanel = Instantiate(gunPanel, new Vector3(0, 0, 0), Quaternion.identity);
                gunpanel.setGun(weapon.ID);

                gunpanel.transform.parent = content.transform;
                gunPanel.Pwindow = this;

                gunpanel.transform.localScale = new Vector3(1f, 1f, 1f);

                lstWeapon.Add(gunpanel.gameObject);
            }
        }   
    }

    public void OnCloseBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void Delete(GameObject gunPanel)
    {
        lstWeapon.Remove(gunPanel);
    }
}
