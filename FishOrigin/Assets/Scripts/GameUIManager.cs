using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public Text m_movenum;

    void Start()
    {
        
    }

    public void ChangeMoveNum(int i)
    {
        m_movenum.text = i.ToString();
    }
    
    void Update()
    {
        
    }
}
