﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance = null;


    private int Level1MoveNum = 8;
    private int Level2MoveNum = 8;
    private int Level3MoveNum = 6;
    private int Level4MoveNum = 8;
    private int Level5MoveNum = 8;
    private int Level6MoveNum = 8;

    private void Awake()
    {
        Instance = this;
    }

    public int GetLevelMoveNum(int i)
    {
        if (i == 1)
            return Level1MoveNum;
        else if (i == 2)
            return Level2MoveNum;
        else if (i == 3)
            return Level3MoveNum;
        else if (i == 4)
            return Level4MoveNum;
        else if (i == 5)
            return Level5MoveNum;
        else if (i == 6)
            return Level6MoveNum;
        else return 1;
    }

    public float[] Getlevel1_map()
    {
        return level1_map;
    }

    public float[] Getlevel2_map()
    {
        return level2_map;
    }

    public float[] Getlevel3_map()
    {
        return level3_map;
    }

    public float[] Getlevel4_map()
    {
        return level4_map;
    }

    public float[] Getlevel5_map()
    {
        return level5_map;
    }

    public float[] Getlevel6_map()
    {
        return level6_map;
    }

    //bug,第一格必须为0

    [HideInInspector]
    private float[] level1_map = new float[100] {0.000f, 0.000f, 0.000f, 0.000f, 10.00f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 10.00f, 0.000f, 1.000f, 0.000f, 9.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

    [HideInInspector]
    private float[] level2_map = new float[100] {0.000f, 0.000f, 0.000f, 0.000f, 10.00f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 1.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 1.000f, 10.00f, 4.000f, 0.000f, 0.000f, 9.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 1.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

    [HideInInspector]
    private float[] level3_map = new float[100] {0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 1.000f, 1.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 4.000f, 4.000f, 4.000f, 9.000f, 1.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 10.00f, 1.000f, 0.000f, 0.000f, 1.000f, 0.000f, 0.000f,
                                                 1.000f, 1.000f, 1.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

    [HideInInspector]
    private float[] level4_map = new float[100] {0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 1.000f, 1.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 4.000f, 4.000f, 4.000f, 9.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 10.00f, 3.111f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 1.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

    [HideInInspector]
    private float[] level5_map = new float[100] {1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

    [HideInInspector]
    private float[] level6_map = new float[100] {1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f,
                                                 1.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };
}
