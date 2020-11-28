using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;

    public void Awake()
    {
        Instance = this;    
    }

    public Player player;
    public AStar Astarpath;

    public int Height = 10;
    public int Width = 10;
    public Node[,] nodes;

    public GameObject[,] Grid_gameobject=null;

    public GameObject Prefab_player;
    public GameObject m_player=null;

    public float[] MapData = new float[100];
    public int levelMoveNum = 0;

    public int player_x=0;
    public int player_y=0;

    public void Start()
    {
        InitMap();
    }

    public void ResetMap()
    {
        Destroy(m_player);

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Destroy(Grid_gameobject[i, j]);
                Grid_gameobject[i, j] = null;
            }
        }
        m_player = null;
        InitMap();
    }

    //初始化地图
    void InitMap()
    {
        //LoadLevelData(SelectLevel.Instance.CurrentLevel);
        LoadLevelData(1);

        player_x = 0;
        player_y = 0;

        nodes = new Node[Width, Height];
        Grid_gameobject = new GameObject[Width, Height];

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {              
                nodes[i, j] = new Node(i, j);               
                nodes[i, j].SetMap(this);
                if (i == 0 && j == 0)
                    continue;
                //bool wall = Random.Range(0, 10) > 7f;
                //nodes[i, j].SetIsWall(wall);

                //if()
                //空闲
                if(MapData[i*Width+j]==0f)
                {
                    nodes[i, j].SetIsWall(false);
                }
                //石头
                else if (MapData[i * Width + j] ==1f)
                {
                    nodes[i, j].SetIsWall(true);
                }               
                //荷花
                else if(MapData[i * Width + j] >=2f&& MapData[i * Width + j] <3)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsFlower(true);
                }
                //藤蔓
                else if (MapData[i * Width + j] >= 3f && MapData[i * Width + j] < 4)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsTree(true);
                }
                //敌人
                else if (MapData[i * Width + j] == 4)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsTree(true);
                }
                //敌人
                else if (MapData[i * Width + j] == 5)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsTree(true);
                }
                //角色
                else if (MapData[i * Width + j] == 10)
                {
                    //player.SetCurNode(nodes[i, j]);
                    player_x = i;
                    player_y = j;

                }
            }
        }

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Grid_gameobject[i, j] = GameObject.Find("Node(" + i + "," + j + ")").gameObject;

                if (i == player_x && j == player_y)
                {
                    m_player = GameObject.Instantiate(Prefab_player, Grid_gameobject[i, j].transform.position, Quaternion.identity);
                    player = m_player.GetComponent<Player>();
                }
                    
            }
        }

        SetPlayerPosition(player_x, player_y);
        //Debug.Log(levelMoveNum);
        GameUIManager.Instance.ChangeMoveNum(levelMoveNum);
    }

    //设置玩家位置
    public void SetPlayerPosition(int x,int y)
    {
        //Debug.Log(player_x);
        //Debug.Log(player_y);
        player_x = x;
        player_y = y;
        //设置玩家坐标
        player.SetCurNode(nodes[player_x, player_y]);
        //设置图片位置
        if(Grid_gameobject[player_x, player_y])
        player.transform.position = Grid_gameobject[player_x, player_y].transform.position + new Vector3(0, 0, -0.1f);
    }

    //加载关卡数据
    void LoadLevelData(int level)
    {
        //Debug.Log(level);
        switch (level)
        {
            case 1:
                MapData = LevelData.Instance.Getlevel1_map();
                levelMoveNum = LevelData.Instance.GetLevelMoveNum(1);
                //Debug.Log(LevelData.Instance.Level1MoveNum);
                break;
            case 2:
                MapData = LevelData.Instance.Getlevel2_map();
                levelMoveNum = LevelData.Instance.GetLevelMoveNum(2);
                break;
            case 3:
                MapData = LevelData.Instance.Getlevel3_map();
                levelMoveNum = LevelData.Instance.GetLevelMoveNum(3);
                break;
            case 4:
                MapData = LevelData.Instance.Getlevel4_map();
                levelMoveNum = LevelData.Instance.GetLevelMoveNum(4);
                break;
            case 5:
                MapData = LevelData.Instance.Getlevel5_map();
                levelMoveNum = LevelData.Instance.GetLevelMoveNum(5);
                break;
            case 6:
                MapData = LevelData.Instance.Getlevel6_map();
                levelMoveNum = LevelData.Instance.GetLevelMoveNum(6);
                break;
        }

    }

    public void StartFindPath(Node start, Node end)
    {
        Astarpath.AStarPath(start, end);
        ShowPath(end);
    }

    void ShowPath(Node end)
    {
        end.ShowPathNode();
        player.MoveToEnd(end);
    }

    ////重新随机一下Map
    //public void ReSetMap()
    //{
    //    foreach (Node item in nodes)
    //    {
    //        item.ReSetNode();
    //        if (item.X == player.GetCurNode().X && item.Y == player.GetCurNode().Y)
    //            continue;
    //        bool wall = Random.Range(0,10) > 7f;
    //        item.SetIsWall(wall);
    //    }  
    //}

    public void ReFind()
    {
        foreach (Node item in nodes)
        {
            item.ReSetNormalNode();
        }
    }
}
