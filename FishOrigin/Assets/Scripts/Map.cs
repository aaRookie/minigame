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

    public int[] MapData = new int[100];

    public int player_x=0;
    public int player_y=0;
   
    
    void Start()
    {     
        InitMap();
    }

    //初始化地图
    void InitMap()
    {
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
                    //Debug.Log(player_x);
                    //Debug.Log(player_y);
                    player.SetCurNode(nodes[player_x, player_y]);
                }
                else if(MapData[i * Width + j] == 3)
                {

                }
            }
        }

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Grid_gameobject[i, j] = GameObject.Find("Node(" + i + "," + j + ")").gameObject;
                Debug.Log(Grid_gameobject[i, j].name);
            }
        }

        //设置玩家坐标
        player.SetCurNode(nodes[player_x, player_y]);
        //设置图片位置
        player.transform.position = Grid_gameobject[player_x, player_y].transform.position+new Vector3(0,0,-0.1f);
    }

    //加载关卡数据
    void LoadLevelData(int level)
    {
        switch (level)
        {
            case 1:
                MapData = LevelData.Instance.Getlevel1_map();
                break;

            case 2:
                MapData = LevelData.Instance.level2_map;
                break;

            case 3:
                MapData = LevelData.Instance.level3_map;
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
