using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float BaseCountdownTime = 10f;
    [SerializeField] private float waitToRestart = 2f;

    public int temp = 0;
    void Start()
    {
        
    }
    
    public void OnClick() {
        temp++;
        Debug.Log(temp);
    }
}
