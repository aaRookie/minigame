using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowManager : MonoBehaviour
{
    public static FlowManager Instance = null;

    private cFlow tempFlow = cFlow.choose;
    public enum cFlow
    {
        pause,
        choose,
        change,
        move,
        dead,
        win
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

    public void ChangeToMove()
    {
        tempFlow = cFlow.move;
    }

    public void ChangeToWin()
    {
        tempFlow = cFlow.win;
    }

    public void ChangeToChoose()
    {
        tempFlow = cFlow.choose;
    }

    public void ChangeToDead()
    {
        tempFlow = cFlow.dead;
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
        tempFlow = cFlow.dead;
        GameUIManager.Instance.HideGamePanel();
        StartCoroutine(LoadCurrentScene());
    }

    public void ResetGame()
    {
        //过场动画后转化为pause
        tempFlow = cFlow.choose;
        //Map.Instance.ResetMap();

        GameUIManager.Instance.HideGamePanel();
        StartCoroutine(LoadCurrentScene());
        //SceneManager.LoadScene(1);
    }

    public void WinFun()
    {
        GameUIManager.Instance.HideGamePanel();
        StartCoroutine(LoadLevelScene());
    }

    IEnumerator LoadCurrentScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    IEnumerator LoadLevelScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

}
