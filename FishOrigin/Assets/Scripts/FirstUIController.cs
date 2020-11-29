using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FirstUIController : MonoBehaviour
{

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
    public GameObject m_logo;

    public float TempTime = 0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        TempTime += Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {
            if(TempTime>6f)
            {
                SceneManager.LoadScene(1);
            }

            if(m_white.transform.localScale==Vector3.one)
            {
                m_white.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
                StartCoroutine(ShowImage());
            }
        }
    }

    IEnumerator ShowImage()
    {
        yield return new WaitForSeconds(1f);
        m_yellowback.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.8f);
        m_grass4.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.8f);
        m_grass2.GetComponent<Image>().DOFade(1, 0.5f);      
        yield return new WaitForSeconds(0.8f);
        m_grass1.GetComponent<Image>().DOFade(1, 0.5f);
        m_grass3.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.8f);
        m_tree3.GetComponent<Image>().DOFade(1, 0.5f);
        m_tree5.GetComponent<Image>().DOFade(1, 0.5f);
        m_tree1.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.8f);
        m_tree2.GetComponent<Image>().DOFade(1, 0.5f);
        m_tree4.GetComponent<Image>().DOFade(1, 0.5f);
        m_grass5.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        m_logo.SetActive(true);

        //yield return new WaitForSeconds(0.8f);
        //m_grass5.GetComponent<Image>().DOFade(1, 0.5f);

    }
}
