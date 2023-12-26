using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Counting0ToN : MonoBehaviour
{
    [SerializeField] int n = 0;
    [SerializeField] Text textCount;
    int count = 0;
    [SerializeField] float speed = 0.01f;

    private void OnEnable()
    {
        StartCoroutine(Counting());
    }


    IEnumerator Counting()
    {
        count = 0;
        while (count < n)
        {
            ++count;
            textCount.text = count.ToString();
            yield return new WaitForSeconds(speed);
        }

        textCount.text = n.ToString();
    }
}
