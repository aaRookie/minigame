using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstUIController : MonoBehaviour
{

    public GameObject m_back;
    public GameObject m_white;
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
    }
}
