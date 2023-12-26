using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGamePlay : MonoBehaviour
{
    // SINGLETON
    private static UIManagerGamePlay instance;

    public static UIManagerGamePlay getInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<UIManagerGamePlay>();
        }
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    [Header("--------------MENU---------------")]
    [SerializeField] GameObject HUDMenu;
    [SerializeField] GameObject GameWinMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu(GameObject Menu)
    {
        Menu.SetActive(true);
    }

}
