using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUpgradePopup : MonoBehaviour
{
    [Header("----------COMPONENT------------")]
    [SerializeField] Text NameGun;
    [SerializeField] Image img;

    [Header("----------EFFECT------------")]
    [SerializeField] GameObject effect;

    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void OnUpgradeBtn()
    {
        Vector3 pos = transform.position;
        pos.z = -1f;
        GameObject effectPlayer = (GameObject)Instantiate(effect, pos, Quaternion.Euler(-90f, 0f, 0f));
        effectPlayer.transform.localScale = new Vector3(13f, 13f, 13f);

        UIMainMenuManager.getInstance().OpenMessageBox("Notification", "Successful upgrade!", transform.position);

        Destroy(effectPlayer, 1f);
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
        else this.gameObject.SetActive(false) ;
    }
}
