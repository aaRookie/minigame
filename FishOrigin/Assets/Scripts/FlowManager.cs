using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public static FlowManager Instance = null;

    private cFlow tempFlow = cFlow.choose;
    public enum cFlow
    {
        pause,
        choose,
        move,
        dead
    }

    public cFlow getTempFlow()
    {
        return tempFlow;
    }

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void ResetFlow()
    {
        tempFlow = cFlow.pause;
    }

    public void chooseFun()
    {

    }

    public void moveFun()
    {

    }

    public void DeadFun()
    {
        tempFlow = cFlow.pause;
    }

    public void ResetGame()
    {
        //过场动画后转化为pause
        tempFlow = cFlow.choose;
        Map.Instance.ResetMap();
    }

}
