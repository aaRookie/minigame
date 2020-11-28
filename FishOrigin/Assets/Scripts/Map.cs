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

    public int[] MapData = new int[100];

    public int player_x=0;
    public int player_y=0;

    public void Start()
    {
        InitMap();
    }

    //初始化地图
    void InitMap()
    {
        //LoadLevelData(SelectLevel.Instance.CurrentLevel);
        LoadLevelData(1);

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
                if(MapData[i*Width+j]==0)
                {
                    nodes[i, j].SetIsWall(false);
                }
                //障碍
                else if (MapData[i * Width + j] == 1)
                {
                    nodes[i, j].SetIsWall(true);
                }
                //角色
                else if(MapData[i * Width + j] == 2)
                {
                    //player.SetCurNode(nodes[i, j]);
                    player_x = i;
                    player_y = j;
                    
                }
                //
                else if(MapData[i * Width + j] == 3)
                {

                }
                //
                
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
    }

    public void SetPlayerPosition(int x,int y)
    {
        //Debug.Log(player_x);
        //Debug.Log(player_y);
        player_x = x;
        player_y = y;
        //设置玩家坐标
        player.SetCurNode(nodes[player_x, player_y]);
        //设置图片位置
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
                //Debug.Log(level);
                break;
            case 2:
                MapData = LevelData.Instance.Getlevel2_map();
                break;
            case 3:
                MapData = LevelData.Instance.Getlevel3_map();
                break;
            case 4:
                MapData = LevelData.Instance.Getlevel4_map();
                break;
            case 5:
                MapData = LevelData.Instance.Getlevel5_map();
                break;
            case 6:
                MapData = LevelData.Instance.Getlevel6_map();
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

    //重新随机一下Map
    public void ReSetMap()
    {
        foreach (Node item in nodes)
        {
            item.ReSetNode();
            if (item.X == player.GetCurNode().X && item.Y == player.GetCurNode().Y)
                continue;
            bool wall = Random.Range(0,10) > 7f;
            item.SetIsWall(wall);
        }  
    }

    public void ReFind()
    {
        foreach (Node item in nodes)
        {
            item.ReSetNormalNode();
        }
    }
}
