using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class UIMainMenuManager : MonoBehaviour
{
    // SINGLETON
    private static UIMainMenuManager instance;

    public static UIMainMenuManager getInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<UIMainMenuManager>();
        }
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    // PROPERTY


    // WINDOW
    [SerializeField] GameObject GUNW;
    [SerializeField] GameObject SKILLW;
    [SerializeField] GameObject BOOMW;
    [SerializeField] GameObject SHOPW;
    [SerializeField] GameObject ShopGunW;
    [SerializeField] GameObject ShopItemW;
    [SerializeField] GameObject InventoryW;
    [SerializeField] GameObject MissionW;

    GameObject currentWindow = null;

    // current Equip
    [Header("---------CURRENT EQUIP-----------")]
    [SerializeField] public int IDGun;
    [SerializeField] Text levelGuntext;
    [SerializeField] Image imgGun;

    [SerializeField] public int IDItem;
    [SerializeField] Text nameItemtext;
    [SerializeField] Text quanityItemtext;
    [SerializeField] Image imgItem;

    [SerializeField] public int IDWeaponSupport;
    [SerializeField] Text levelWeaponSupporttext;
    [SerializeField] Image imgWeaponSupport;

    [Header("---------MESSAGE BOX-------------")]
    [SerializeField] MessageBox messageBoxFrefabs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOpenWindow(GameObject window)
    {
        if(currentWindow != null)
        {
            currentWindow.SetActive(false);
        }
        
        window.SetActive(true);
        currentWindow = window;
    }

    // load
    public void Load()
    {

    }

    // Equipment
    public void updateSelectGun(int IDGun)
    {
        Weapon gun = GunManagerConfig.getInstance().getConfig(IDGun);
        if(gun != null)
        {
            this.IDGun = IDGun;
            levelGuntext.text = "Level " + gun.level.ToString();
            imgGun.sprite = gun.avatar;
        }
    }

    public void updateSelectItem(int IDItem)
    {
        Item item = ItemManagerConfig.getInstance().getConfig(IDItem);
        if(item != null)
        {
            this.IDItem = IDItem;
            nameItemtext.text = item.name;
            quanityItemtext.text = "Quanity: "+ item.quanity.ToString();
        }
    }

    public void updateSelectWeaponSupport(int IDWeaponSupport)
    {
        this.IDWeaponSupport = IDWeaponSupport;
    }

    // Message Box
    public void OpenMessageBox(string title, string content, Vector3 pos)
    {
        MessageBox message = Instantiate(messageBoxFrefabs, pos, this.transform.rotation);

        message.title.text = title;
        message.message.text = content;

        message.transform.parent = this.transform;
        message.transform.localScale = new Vector3(1f, 1f, 1f);

        Destroy(message.gameObject, 1f);
    }
}
