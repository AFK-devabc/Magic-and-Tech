using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Buy_Window : MonoBehaviour
{
    [Header("------------COMPONENT-----------------")]
    [SerializeField] Text NameitemText;
    [SerializeField] Text QuanityBuyText;
    [SerializeField] Text QuanityOwnedText;
    [SerializeField] Image img;
    [SerializeField] Text UnitCostText;
    [SerializeField] Text TotalCostText;

    [Header("------------PARENT-------------------")]
    [SerializeField] public Item_Panel_PopUp parentW;

    public int ID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // function

    public void setItemData(int ID)
    {
        // update data
        Item item = ItemManagerConfig.getInstance().getConfig(ID);
        if (item != null)
        {
            this.ID = ID;
            NameitemText.text = item.name.ToUpper();
            img.sprite = item.avatar;
            img.SetNativeSize();
            QuanityOwnedText.text = item.quanity.ToString();
            QuanityBuyText.text = "1";
            UnitCostText.text = item.price.ToString();
            TotalCostText.text = item.price.ToString();
        }
        else this.gameObject.SetActive(false);
    }

    // event click
    public void OnCancelBtn()
    {
        OnCloseBtn();
    }

    public void OnbuyBtn()
    {
        // check coin

        ItemManagerConfig.getInstance().getConfig(ID).quanity += int.Parse(QuanityBuyText.text);

        UIMainMenuManager.getInstance().OpenMessageBox("Notification", "Buy item successfull!", transform.position);
        OnCloseBtn();

        if(parentW!=null)
            parentW.UpdateQuanity();
    }

    public void OnCloseBtn()
    {
        this.gameObject.SetActive(false);
    }

    void updateTotalCost()
    {
        TotalCostText.text = (int.Parse(QuanityBuyText.text) * int.Parse(UnitCostText.text)).ToString();
    }

    public void OnAddQuanity()
    {
        QuanityBuyText.text = (int.Parse(QuanityBuyText.text) + 1).ToString();
        updateTotalCost();
    }

    public void OnSubQuanity()
    {
        int quanity = int.Parse(QuanityBuyText.text);
        if (--quanity <= 0)
        {
            quanity = 1;
        }
        QuanityBuyText.text = quanity.ToString();
        updateTotalCost();
    }
}
