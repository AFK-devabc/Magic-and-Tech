using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
