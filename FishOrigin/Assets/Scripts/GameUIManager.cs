using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public GameObject Prefab_bowen;

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
