using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUIManager : MonoBehaviour
{
    public static SelectUIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

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

    void Start()
    {
        ShowGamePanel();
    }

    void Update()
    {
        
    }

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
}
