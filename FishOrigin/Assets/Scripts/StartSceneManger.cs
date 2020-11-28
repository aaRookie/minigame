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

    void Start()
    {
        level1.onClick.AddListener(button1);
        level2.onClick.AddListener(button2);
        level3.onClick.AddListener(button3);
    }

    void button1()
    {
        SelectLevel.Instance.CurrentLevel = 1;
        SceneManager.LoadScene("GameScene");
    }

    void button2()
    {
        SelectLevel.Instance.CurrentLevel = 2;
        SceneManager.LoadScene("GameScene");
    }

    void button3()
    {
        SelectLevel.Instance.CurrentLevel = 3;
        SceneManager.LoadScene("GameScene");
    }
}
