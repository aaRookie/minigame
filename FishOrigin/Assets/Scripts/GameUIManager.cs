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

    public Sprite[] numImage = new Sprite[12];

    public GameObject m_left;
    public GameObject m_right;

    public Button replayButton;
    public Button returnButton;

    public GameObject Prefab_bowen;

    public Texture2D mouseDefault;
    public Texture2D mouseInFish;
    public Texture2D mouseOutFish;

    public void Awake()
    {
        Instance = this;
        ChangeSprite();
        ShowGamePanel();
        //DontDestroyOnLoad(gameObject);
    }

    public void ChangeSprite()
    {
        if(SelectLevel.Instance.CurrentLevel>=1&& SelectLevel.Instance.CurrentLevel <= 3)
        {
            m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right1;
            m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left1;
        }
        if (SelectLevel.Instance.CurrentLevel >= 4 && SelectLevel.Instance.CurrentLevel <= 6)
        {
            m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right2;
            m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left2;
        }
        if (SelectLevel.Instance.CurrentLevel >= 7 && SelectLevel.Instance.CurrentLevel <= 9)
        {
            m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right3;
            m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left3;
        }
        if (SelectLevel.Instance.CurrentLevel ==10 )
        {
            m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right4;
            m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left4;
        }
    }

    public Text m_movenum;
    public GameObject m_numImage;

    public void ChangeMouseToDefault()
    {
        Cursor.SetCursor(mouseDefault, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeMousetToInFish()
    {
        Cursor.SetCursor(mouseInFish, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeMousetToOutFish()
    {
        Cursor.SetCursor(mouseOutFish, Vector2.zero, CursorMode.Auto);
    }

    void Start()
    {
        replayButton.onClick.AddListener(FlowManager.Instance.ResetGame);
        returnButton.onClick.AddListener(FlowManager.Instance.WinFun);
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
        switch(i)
        {
            case 1:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 2:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 3:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 4:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 5:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 6:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 7:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 8:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 9:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 10:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
            case 11:
                m_numImage.GetComponent<Image>().sprite = numImage[0];
                break;
        }
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
