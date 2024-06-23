using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float baseCountdownTime = 10f;
    [SerializeField] private float waitToRestart = 2f;

    [Header("UI Manager")]
    [SerializeField] UIManager uiManager;

    public int temp = 0;

    public bool gameplayStar;
    void Start()
    {
        gameplayStar = false;
    }
    
    public void OnClick() {
        temp++;
        Debug.Log(temp);
        //if(!gameplayStar)
        //{
        //    gameplayStar =true;
        //}

        if (!gameplayStar)
        {
            uiManager.ShowInstructions(false);
            gameplayStar = true;
            Debug.Log("here");
        }
    }

}