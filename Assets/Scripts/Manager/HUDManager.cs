using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;

    public static HUDManager getInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<HUDManager>();
        }
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    // PORPERTY
    // STATUS
    [Header("----------Health----------")]
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] protected Slider healthBar;

    [Header("----------Defense----------")]
    [SerializeField] protected int maxDefense;
    [SerializeField] protected int defense;
    [SerializeField] protected Slider defenseBar;

    [Header("----------Player----------")]
    [SerializeField] Player player;

    [Header("----------Coin----------")]
    [SerializeField] public int coin;
    [SerializeField] public Text coinText;

    [Header("----------Diamond----------")]
    [SerializeField] public int diamond;
    [SerializeField] public Text diamondText;

    // SKILL
    [Header("----------Health----------")]
    [SerializeField] protected Dictionary<string, SkillUI> lstSkill;
    [SerializeField] protected Grid gridSkill;
    [SerializeField] protected GameObject skill_UIFrefab;

    // GUN
    [Header("----------GUN----------")]
    [SerializeField] protected GunUI[] lstGUN;
    [SerializeField] protected int currentGUNIndex;


    // Start is called before the first frame update
    void Start()
    {
        updateSTATUS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // STATUS FUNCTION
    public void updateSTATUS()
    {
        updateHealthBar();
        updateDefenseBar();
        updateCoinUI();
        updateDiamondUI();
    }

    // HEALTH
    public void setHP(int hp)
    {
        if(hp>0) this.health = hp;
        else this.health = 0;
    }
    public int getHP()
    {
        return health;
    }
    public void setMaxHP(int Maxhp)
    {
        if(Maxhp > 0) this.maxHealth = Maxhp;
        else this.maxHealth = 0;    
    }
    public int getMaxHP()
    {
        return maxHealth;
    }
    public void updateHealthBar()
    {
        healthBar.value = health * 1.0f / maxHealth;
    }

    // DEFENSE
    public void setDefense(int defense)
    {
        if (defense > 0) this.defense = defense;
        else this.defense = 0;
    }
    public int getDefense()
    {
        return defense;
    }
    public void setMaxDefense(int Maxdefense)
    {
        if (Maxdefense > 0) this.maxDefense = Maxdefense;
        else this.maxDefense = 0;
    }
    public int getMaxDefense()
    {
        return maxDefense;
    }
    public void updateDefenseBar()
    {
        defenseBar.value = defense * 1.0f / maxDefense;
    }

    // COIN
    public void setCoin(int coin)
    {
        if (coin > 0) this.coin = coin;
        else this.coin = 0;
    }
    public int getCoin()
    {
        return coin;
    }
    public void updateCoinUI()
    {
        coinText.text = coin.ToString();
    }

    // DIAMOND
    public void setDiamond(int diamond)
    {
        if (diamond > 0) this.diamond = diamond;
        else this.diamond = 0;
    }
    public int getDiamond()
    {
        return diamond;
    }
    public void updateDiamondUI()
    {
        diamondText.text = diamond.ToString();
    }


    // LIST SKILL FUNCTION
    public void AddSkill(string ID)
    {
        // create GameObject game UI

        // update UI and time of skill UI

        // add into grid

    }
    public void RemoveSkill(string ID)
    {
        // find 
        SkillUI skill = lstSkill[ID];
        lstSkill.Remove(ID);
        Destroy(skill); 
    }

    // LIST GUN FUNCTION
    public void SwapGun()
    {
        for(int i =0; i <2; ++i)
        {
            if(i == currentGUNIndex)
                lstGUN[i].downGUN();
            else lstGUN[i].upGUN();
        }

        currentGUNIndex = currentGUNIndex == 0 ? 1 : 0;
    }
    public void ChangeGun(string ID)
    {
        lstGUN[currentGUNIndex].setIDGun(ID);
    }
    public string getCurrentGun()
    {
        return lstGUN[currentGUNIndex].getIDGun();
    }
}