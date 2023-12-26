using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitWindow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // event 
    public void OnCloseBtn()
    {
        this.gameObject.SetActive(false);   
    }

    public void OnCancelBtn()
    {
        OnCloseBtn();
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}
