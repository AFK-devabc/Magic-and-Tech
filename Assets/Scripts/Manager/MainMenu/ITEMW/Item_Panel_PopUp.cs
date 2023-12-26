using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Panel_PopUp : MonoBehaviour
{
    [Header("----------COMPONENT------------")]
    [SerializeField] Text Name;
    [SerializeField] Image img;
    [SerializeField] Text Decription;
    [SerializeField] Text Quanity;

    public int ID;


    [Header("--------WINDOW-----------")]
    [SerializeField] public Item_Buy_Window itemBuyWindow;

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

    public void SetData(Item item)
    {
        this.ID = item.ID;
        Name.text = item.Name;
        img.sprite = item.avatar;
        Decription.text = "";
        Quanity.text = item.quanity.ToString();
    }

    public void UpdateQuanity()
    {
        Item item = ItemManagerConfig.getInstance().getConfig(ID);
        if (item != null)
        {
            Quanity.text = item.quanity.ToString();
        }
    }

    public void OnSelect()
    {
        UIMainMenuManager.getInstance().updateSelectItem(ID);
    }

    public void OnAddBtn()
    {
        itemBuyWindow.gameObject.SetActive(true);   
        itemBuyWindow.setItemData(ID);
        itemBuyWindow.parentW = this;
    }
}
