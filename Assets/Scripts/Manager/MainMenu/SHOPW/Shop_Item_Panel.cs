using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Item_Panel : MonoBehaviour
{
    [Header("------------COMPONENT---------------")]
    [SerializeField] Text NameItem;
    [SerializeField] Image img;
    [SerializeField] Text priceText;

    [Header("-------------PARENT-------------")]
    [SerializeField] public SHOPITEM_Window Pwindow;

    [Header("-------------WINDOW-------------")]
    [SerializeField] public Item_Buy_Window ItembuyW;

    public int ID;
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
        ItembuyW.gameObject.SetActive(true);
        ItembuyW.setItemData(ID);
    }

    public void setItem(int ID)
    {
        // update data
        Item item = ItemManagerConfig.getInstance().getConfig(ID);
        if (item != null)
        {
            this.ID = ID;
            NameItem.text = item.name.ToUpper();
            img.sprite = item.avatar;
            img.SetNativeSize();
            priceText.text = item.price.ToString();
        }
        else this.gameObject.SetActive(false);
    }
}
