using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOPITEM_Window : MonoBehaviour
{
    [Header("------------COMPONENT---------------")]
    [SerializeField] GameObject content;

    [Header("------------FREFABS-----------------")]
    [SerializeField] Shop_Item_Panel ItemPanel;

    [SerializeField] List<GameObject> lstItem;

    private void Start()
    {
        OnItemTypeBtn(1);
    }

    public void OnItemTypeBtn(int typeGun)
    {
        foreach (GameObject weapon in lstItem)
        {
            Destroy(weapon);
        }

        lstItem.Clear();

        List<Item> lstGN = ItemManagerConfig.getInstance().getConfigByType(typeGun);

        if (lstGN != null)
        {
            foreach (Item item in lstGN)
            {
                Shop_Item_Panel itempanel = Instantiate(ItemPanel, new Vector3(0, 0, 0), Quaternion.identity);
                itempanel.setItem(item.ID);

                itempanel.transform.parent = content.transform;
                itempanel.Pwindow = this;

                itempanel.transform.localScale = new Vector3(1f, 1f, 1f);

                lstItem.Add(itempanel.gameObject);
            }
        }
    }

    public void OnCloseBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void Delete(GameObject itemPanel)
    {
        lstItem.Remove(itemPanel);
    }
}
