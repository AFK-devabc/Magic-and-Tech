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
    //[SerializeField] GameObject 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
