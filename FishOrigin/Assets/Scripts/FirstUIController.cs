using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstUIController : MonoBehaviour
{

    public GameObject m_back;
    public GameObject m_white;
    public GameObject m_yellowback;
    public GameObject m_grass1;
    public GameObject m_grass2;
    public GameObject m_grass3;
    public GameObject m_grass4;
    public GameObject m_grass5;
    public GameObject m_tree1;
    public GameObject m_tree2;
    public GameObject m_tree3;
    public GameObject m_tree4;
    public GameObject m_tree5;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(m_back.transform.localScale==Vector3.one)
            {
                m_back.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
                StartCoroutine(ShowWhite());
            }
        }
    }

    IEnumerator ShowWhite()
    {
        yield return new WaitForSeconds(1f);
        m_white.SetActive(true);
        m_grass1.SetActive(true);
        m_grass2.SetActive(true);
        m_grass3.SetActive(true);
        m_grass4.SetActive(true);
        m_grass5.SetActive(true);
        m_tree1.SetActive(true);
        m_tree2.SetActive(true);
        m_tree3.SetActive(true);
        m_tree4.SetActive(true);
        m_tree5.SetActive(true);
        m_yellowback.SetActive(true);
    }
}
