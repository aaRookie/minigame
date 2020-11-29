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

    public GameObject[,] Grid_gameobject = null;
    public GameObject[,] GameObject_element = null;
     

    public GameObject Prefab_player;
    public GameObject Prefab_wall;
    public GameObject Prefab_end;
    public GameObject Prefab_tree;
    public GameObject Prefab_box;

    


    public GameObject m_player=null;
    public GameObject m_end = null;

    public float[] MapData = new float[100];
    public int levelMoveNum = 0;

    public int player_x=0;
    public int player_y=0;

    public int end_x = 0;
    public int end_y = 0;

    public void Start()
    {
        InitMap();
    }

    //重置关卡
    public void ResetMap()
    {
        Destroy(m_player);

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Destroy(Grid_gameobject[i, j]);
                Grid_gameobject[i, j] = null;
                Destroy(GameObject_element[i, j]);
                GameObject_element[i, j] = null;
            }
        }
        m_player = null;
        InitMap();
    }

    public void ChangeNodesData(int x1,int y1,int x2,int y2)
    {
        Node.nodetype type1 = nodes[x1, y1].temptype;
        Node.nodetype type2 = nodes[x2, y2].temptype;

        nodes[x2, y2].temptype = type1;
        nodes[x2, y2].SetType();

        //Debug.Log(MapData[x2 * 10 + y2]);
        //Debug.Log(MapData[x1 * 10 + y1]);

        //MapData[x2*10+y2] = MapData[x1*10+y1];
    }
    
    public void ChangeNodesData(int x1, int y1, bool isext)
    {
            nodes[x1, y1].SetIsWall(isext);
            nodes[x1, y1].temptype = Node.nodetype.ext;
    }

    public void CheckIsWin()
    {
        if(player_x==end_x&&player_y==end_y)
        {
            FlowManager.Instance.ChangeToWin();
            Debug.Log("win");
        }
    }

    //初始化地图
    void InitMap()
    {
        //LoadLevelData(SelectLevel.Instance.CurrentLevel);
        LoadLevelData(4);

        player_x = 0;
        player_y = 0;
        end_x = 0;
        end_y = 0;

        nodes = new Node[Width, Height];
        Grid_gameobject = new GameObject[Width, Height];
        GameObject_element=new GameObject[Width, Height];

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

                    float temp = MapData[i * Width + j];
                    temp *= 10;
                    nodes[i,j].ChangeDir= (int)temp % 10;
                    temp *= 10;
                    nodes[i, j].ChangeX = (int)temp % 10;
                    //temp *= 10;
                    //nodes[i, j].ChangeY = (int)temp % 10;

                    //Debug.Log("ChangeDir: " + nodes[i, j].ChangeDir + " ChangeX: " + nodes[i, j].ChangeX + " ChangeY: " + nodes[i, j].ChangeY);
                }
                //藤蔓
                else if (MapData[i * Width + j] >= 3f && MapData[i * Width + j] < 4)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsTree(true);

                    float temp = MapData[i * Width + j];
                    temp *= 10;
                    nodes[i, j].ChangeDir = (int)temp % 10;
                    temp *= 10;
                    nodes[i, j].ChangeX = (int)temp % 10;
                    //temp *= 10;
                    //nodes[i, j].ChangeY = (int)temp % 10;
                }
                //盒子
                else if (MapData[i * Width + j] == 4f)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsBox(true);
                }                    
                //镜子
                else if (MapData[i * Width + j] == 5f)
                {
                    nodes[i, j].SetIsWall(true);
                    nodes[i, j].SetIsMirror(true);
                }
                //角色
                else if (MapData[i * Width + j] == 10f)
                {
                    //player.SetCurNode(nodes[i, j]);
                    player_x = i;
                    player_y = j;

                }
                //终点
                else if(MapData[i * Width + j] == 9f)
                {
                    end_x = i;
                    end_y = j;
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
                    m_player = GameObject.Instantiate(Prefab_player, Grid_gameobject[i, j].transform.position + new Vector3(0, 0, -1f), Quaternion.identity);
                    player = m_player.GetComponent<Player>();
                }

                if(i== end_x&&j== end_y)
                {
                    m_end = GameObject.Instantiate(Prefab_end, Grid_gameobject[i, j].transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity);
                }

                //墙
                if (MapData[i * Width + j] == 1f)
                {
                    GameObject.Instantiate(Prefab_wall, Grid_gameobject[i, j].transform.position+new Vector3(0,0,-0.1f), Quaternion.identity);               
                }

                //box
                if (MapData[i * Width + j] == 4f)
                {
                    GameObject temp=GameObject.Instantiate(Prefab_box, Grid_gameobject[i, j].transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity);
                    GameObject_element[i, j] = temp;
                    //nodes[i, j].GetNodeItem().OnMouseDown();
                }

                //藤蔓
                if (MapData[i * Width + j] >3f&& MapData[i * Width + j] < 4f)
                {
                    GameObject temp = GameObject.Instantiate(Prefab_tree, Grid_gameobject[i, j].transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity);
                    GameObject_element[i, j] = temp;
                    //nodes[i, j].GetNodeItem().OnMouseDown();
                }
            }
        }

        SetPlayerPosition(player_x, player_y);
        //Debug.Log(levelMoveNum);
        GameUIManager.Instance.ChangeMoveNum(levelMoveNum);
    }

    //新增藤蔓
    public void CreateTree(int i,int j)
    {
        GameObject temp = GameObject.Instantiate(Prefab_tree, Grid_gameobject[i, j].transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity);
        GameObject_element[i, j] = temp;
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
        if(m_player.GetComponent<Player>().path.Count<=4)
        ShowPath(end);
    }

    void ShowPath(Node end)
    {
        //end.ShowPathNode();
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
