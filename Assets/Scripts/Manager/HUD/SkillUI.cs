using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] string ID;

    [Header("-------------COMPONENT------------")]
    [SerializeField] Image imgSkill;
    [SerializeField] CircleSlider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(slider.isCoolDown == false)
        {
            slider.startCoolDown();
        }
    }

    // id
    public void setID(string ID)
    {
        this.ID = ID;
    }

    public string getID()
    {
        return this.ID;
    }
}
