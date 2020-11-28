using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance = null;


    private int Level1MoveNum = 3;
    private int Level2MoveNum = 3;
    private int Level3MoveNum = 3;
    private int Level4MoveNum = 3;
    private int Level5MoveNum = 3;
    private int Level6MoveNum = 3;

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

    public int[] Getlevel1_map()
    {
        return level1_map;
    }

    public int[] Getlevel2_map()
    {
        return level2_map;
    }

    public int[] Getlevel3_map()
    {
        return level3_map;
    }

    public int[] Getlevel4_map()
    {
        return level4_map;
    }

    public int[] Getlevel5_map()
    {
        return level5_map;
    }

    public int[] Getlevel6_map()
    {
        return level6_map;
    }

    //bug,第一格必须为0

    [HideInInspector]
    private int[] level1_map = new int[100] {1, 0, 0, 0, 10, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                             1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    [HideInInspector]
    private int[] level2_map = new int[100] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
    [HideInInspector]
    private int[] level3_map = new int[100] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
    [HideInInspector]
    private int[] level4_map = new int[100] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
    [HideInInspector]
    private int[] level5_map = new int[100] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
    [HideInInspector]
    private int[] level6_map = new int[100] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                               1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
}
