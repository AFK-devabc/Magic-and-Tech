using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    [SerializeField] string ID;
    [Header("-------------COMPONENT------------")]
    [SerializeField] Image imgGun;
    [SerializeField] Text numberBullet;
    [SerializeField] Text TotalNumberBullet;
    [SerializeField] Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        // dựa vào ID khởi tạo imgGun
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(HUDManager.getInstance().getCurrentGun() != ID)
        {
            Debug.Log("Run");
            HUDManager.getInstance().SwapGun();
        }
    }

    public void upGUN()
    {
        ani.Play("UPGUN");
    }

    public void downGUN()
    {
        ani.Play("DOWNGUN");
    }

    // ID
    public void setIDGun(string ID)
    {
        this.ID = ID;
        // update UI
    }
    public string getIDGun()
    {
        return this.ID;
    }
}
