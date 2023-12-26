using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameWinMenu : MonoBehaviour
{
    [Header("-------------COMPONENT---------------")]
    [SerializeField] Toggle[] toggleStars;

    [SerializeField] GameObject cointEarned;

    [SerializeField] List<GameObject> items;

    [Header("------------TIMEDELAY----------------")]
    [SerializeField] float timedelay = 0.35f;

    Coroutine gameWinCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(GameWinUI());
    }

    IEnumerator GameWinUI()
    {
        // toggleStar
        yield return new WaitForSeconds(timedelay);
        for (int i =0; i<3; ++i)
        {
            toggleStars[i].isOn = true;
            yield return new WaitForSeconds(timedelay);
        }

        // earn coin
        cointEarned.SetActive(true);
        yield return new WaitForSeconds(timedelay);

        // items
        foreach(GameObject game in items)
        {
            game.SetActive(true);
            yield return new WaitForSeconds(timedelay);
        }
    }

    // event 
    public void OnRestartBtn()
    {

    }

    public void OnExitBtn()
    {

    }
}
