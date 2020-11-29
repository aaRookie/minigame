using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManger : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public Button level9;
    public Button level10;

    void Start()
    {
        level1.onClick.AddListener(button1);
        level2.onClick.AddListener(button2);
        level3.onClick.AddListener(button3);
        level4.onClick.AddListener(button4);
        level5.onClick.AddListener(button5);
        level6.onClick.AddListener(button6);
        level7.onClick.AddListener(button7);
        level8.onClick.AddListener(button8);
        level9.onClick.AddListener(button9);
        level10.onClick.AddListener(button10);
    }

    void button1()
    {
        SelectLevel.Instance.CurrentLevel = 1;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right1;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left1;
        StartCoroutine(LoadGameScene());
    }

    void button2()
    {
        SelectLevel.Instance.CurrentLevel = 2;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right1;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left1;
        StartCoroutine(LoadGameScene());
    }

    void button3()
    {
        SelectLevel.Instance.CurrentLevel = 3;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right1;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left1;
        StartCoroutine(LoadGameScene());
    }

    void button4()
    {
        SelectLevel.Instance.CurrentLevel = 4;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right2;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left2;
        StartCoroutine(LoadGameScene());
    }

    void button5()
    {
        SelectLevel.Instance.CurrentLevel = 5;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right2;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left2;
        StartCoroutine(LoadGameScene());
    }

    void button6()
    {
        SelectLevel.Instance.CurrentLevel = 6;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right2;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left2;
        StartCoroutine(LoadGameScene());
    }

    void button7()
    {
        SelectLevel.Instance.CurrentLevel = 7;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right3;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left3;
        StartCoroutine(LoadGameScene());
    }

    void button8()
    {
        SelectLevel.Instance.CurrentLevel = 8;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right3;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left3;
        StartCoroutine(LoadGameScene());
    }

    void button9()
    {
        SelectLevel.Instance.CurrentLevel = 9;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right3;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left3;
        StartCoroutine(LoadGameScene());
    }

    void button10()
    {
        SelectLevel.Instance.CurrentLevel = 10;
        SelectUIManager.Instance.m_right.GetComponent<Image>().sprite = SelectUIManager.Instance.right4;
        SelectUIManager.Instance.m_left.GetComponent<Image>().sprite = SelectUIManager.Instance.left4;
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        SelectUIManager.Instance.HideGamePanel();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }


}
