using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Window : MonoBehaviour
{
    //[Header("------------WINDOW------------")]
    //[SerializeField] GameObject ShopGunWindow;
    //[SerializeField] GameObject ShopItemWindow;
    //[SerializeField] GameObject ShopSupportWeaponWindow;

    [SerializeField] GameObject currentWindow;

    // Start is called before the first frame update
    void Start()
    {
        currentWindow = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // event click
    public void OnClickExitBtn()
    {
        this.gameObject.SetActive(false);
    }

    // event Open window
    public void OnClickOpentBtn(GameObject window)
    {
        this.gameObject.SetActive(false);
        if(currentWindow != null)
            currentWindow.SetActive(false );

        window.SetActive(true);
        currentWindow  = window;
    }
}
