using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public static SelectLevel Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    public int CurrentLevel = 1;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeCurrentLevel(int x)
    {
        CurrentLevel = x;
    }

    
    void Update()
    {
        
    }


}
