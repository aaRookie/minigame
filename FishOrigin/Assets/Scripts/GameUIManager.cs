using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public Sprite left1;
    public Sprite left2;
    public Sprite left3;
    public Sprite left4;
    public Sprite right1;
    public Sprite right2;
    public Sprite right3;
    public Sprite right4;

    public GameObject m_left;
    public GameObject m_right;

    public GameObject Prefab_bowen;

    public void Awake()
    {
        Instance = this;
        ShowGamePanel();
        //DontDestroyOnLoad(gameObject);
    }

    public Text m_movenum;

    void Start()
    {

    }

    //退出动画
    public void HideGamePanel()
    {
        //Debug.Log("隐藏屏幕");
        m_left.GetComponent<Animator>().SetTrigger("close");
        m_right.GetComponent<Animator>().SetTrigger("close");
    }

    //进入动画
    public void ShowGamePanel()
    {
        //Debug.Log("显示屏幕");
        m_left.GetComponent<Animator>().SetTrigger("open");
        m_right.GetComponent<Animator>().SetTrigger("open");
    }

    public void ChangeMoveNum(int i)
    {
        m_movenum.text = i.ToString();
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0,0,30)+new Vector3(Random.Range(-0.1f,0.1f), Random.Range(-0.1f, 0.1f), 0);
                GameObject bowen = GameObject.Instantiate(Prefab_bowen, mousePositionInWorld, transform.rotation);
                float tempscale = Random.Range(0.8f, 1.3f);
                bowen.transform.localScale = new Vector3(tempscale, tempscale, tempscale);
                bowen.GetComponent<Animator>().speed = Random.Range(0.7f, 0.9f);
                Destroy(bowen, 1f);
            }
        }
    }
}
