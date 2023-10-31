using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchTranform : MonoBehaviour
{
    [SerializeField] Transform targetTranform;

    private Transform _tranform;
    private void Start()
    {
        _tranform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        _tranform.position = targetTranform.position;
        _tranform.rotation = targetTranform.rotation;
    }
}
