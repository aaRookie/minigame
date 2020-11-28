using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeItem : MonoBehaviour
{
    public Node self;

    public List<Vector2> influ = new List<Vector2>();
    public void SetNode(Node node)
    {
        self = node;
    }

    public void OnMouseDown()
    {             
        //点击荷花
        if(self.isFlower==true)
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                if (Map.Instance.levelMoveNum > 0)
                {
                    //改变数值
                    Map.Instance.levelMoveNum--;
                    GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                    self.FlowerSwitch = !self.FlowerSwitch;

                    //Debug.Log(self.ChangeDir);
                    //Debug.Log(self.ChangeX);

                    //获取变化范围
                    if (influ.Count==0)
                    {
                        if (self.ChangeDir == 1)
                        {
                            for (int i = 1; i <= self.ChangeX; i++)
                            {
                                influ.Add(new Vector2(self.X - i, self.Y));
                            }
                        }
                        if (self.ChangeDir == 2)
                        {
                            for (int i = 1; i <= self.ChangeX; i++)
                            {
                                influ.Add(new Vector2(self.X + i, self.Y));
                            }
                        }
                        if (self.ChangeDir == 3)
                        {
                            for (int i = 1; i <= self.ChangeX; i++)
                            {
                                influ.Add(new Vector2(self.X, self.Y - i));
                            }
                        }
                        if (self.ChangeDir == 4)
                        {
                            for (int i = 1; i <= self.ChangeX; i++)
                            {
                                influ.Add(new Vector2(self.X, self.Y + i));
                            }
                        }
                        if (self.ChangeDir == 5)
                        {
                            for (int i = 0; i <= self.ChangeX; i++)
                            {
                                for (int j = 0; j <= self.ChangeX; j++)
                                {
                                    if ((self.X - i) != self.X || (self.Y - j) != self.Y)
                                        influ.Add(new Vector2(self.X - i, self.Y - j));
                                }
                            }
                        }
                        if (self.ChangeDir == 6)
                        {
                            for (int i = 0; i <= self.ChangeX; i++)
                            {
                                for (int j = 0; j <= self.ChangeX; j++)
                                {
                                    if ((self.X - i) != self.X || (self.Y + j) != self.Y)
                                        influ.Add(new Vector2(self.X - i, self.Y + j));
                                }
                            }
                        }
                        if (self.ChangeDir == 7)
                        {
                            for (int i = 0; i <= self.ChangeX; i++)
                            {
                                for (int j = 0; j <= self.ChangeX; j++)
                                {
                                    if ((self.X + i) != self.X || (self.Y - j) != self.Y)
                                        influ.Add(new Vector2(self.X + i, self.Y - j));
                                }
                            }
                        }
                        if (self.ChangeDir == 8)
                        {
                            for (int i = 0; i <= self.ChangeX; i++)
                            {
                                for (int j = 0; j <= self.ChangeX; j++)
                                {
                                    if ((self.X + i) != self.X || (self.Y + j) != self.Y)
                                        influ.Add(new Vector2(self.X + i, self.Y + j));
                                }
                            }
                        }
                    }

                    //Debug.Log(influ.Count);
                    //for (int i = 0; i < influ.Count; i++)
                    //{
                    //    Debug.Log(influ[i].x+" "+influ[i].y);
                    //}

                    //数据和图片变化
                    if (self.FlowerSwitch)
                    {
                        for (int i = 0; i < influ.Count; i++)
                        {
                            Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(true);
                        }
                    }

                    else if(!self.FlowerSwitch)
                    {
                        for(int i = 0; i < influ.Count; i++)
                        {
                            Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(false);
                            Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].ReSetNode();
                        }
                    }
                }
            }
        }

        //点击藤蔓
        else if (self.isTree == true)
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                if (Map.Instance.levelMoveNum > 0)
                {
                    //改变数值
                    Map.Instance.levelMoveNum--;
                    GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                    self.isTree = !self.isTree;

                    //Debug.Log(self.ChangeDir);
                    //Debug.Log(self.ChangeX);

                    //获取变化范围
                    if (influ.Count == 0)
                    {
                        if(self.isTree==false)
                        {
                            if (self.ChangeDir == 1)
                            {
                                for (int i = 1; i <= self.ChangeX; i++)
                                {
                                    influ.Add(new Vector2(self.X - i, self.Y));

                                    float temp1 = Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y];
                                    float temp2 = Map.Instance.MapData[(self.X - 1) * 10 + self.Y];

                                    Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y] = temp2;
                                    Map.Instance.MapData[(self.X - 1) * 10 + self.Y] = temp1;
                                    Map.Instance.GameObject_element[self.X - 1, self.Y].transform.position = Map.Instance.Grid_gameobject[self.X - i - 1, self.Y].transform.position;
                                    //交换两个网格的node
                                    //Map.Instance.nodes[self.X - i - 1, self.Y]

                                    //Map.Instance.GameObject_element[self.X - i - 1, self.Y] = Map.Instance.GameObject_element[self.X - 1, self.Y];
                                    //Map.Instance.GameObject_element[self.X - 1, self.Y]= null;
                                    //Debug.Log(Map.Instance.MapData[(self.X - 1) * 10 + self.Y]);
                                    //Debug.Log(Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y]);
                                }
                            }
                            if (self.ChangeDir == 2)
                            {
                                for (int i = 1; i <= self.ChangeX; i++)
                                {
                                    influ.Add(new Vector2(self.X + i, self.Y));

                                    float temp1 = Map.Instance.MapData[(self.X + i + 1) * 10 + self.Y];
                                    float temp2 = Map.Instance.MapData[(self.X + 1) * 10 + self.Y];

                                    Map.Instance.MapData[(self.X + i + 1) * 10 + self.Y] = temp2;
                                    Map.Instance.MapData[(self.X + 1) * 10 + self.Y] = temp1;
                                    Map.Instance.GameObject_element[self.X + 1, self.Y].transform.position = Map.Instance.Grid_gameobject[self.X + i + 1, self.Y].transform.position;
                                }
                            }
                            if (self.ChangeDir == 3)
                            {
                                for (int i = 1; i <= self.ChangeX; i++)
                                {
                                    influ.Add(new Vector2(self.X, self.Y - i));

                                    float temp1 = Map.Instance.MapData[self.X * 10 + (self.Y - i - 1)];
                                    float temp2 = Map.Instance.MapData[self.X * 10 + self.Y - i];

                                    Map.Instance.MapData[self.X * 10 + (self.Y - i - 1)] = temp2;
                                    Map.Instance.MapData[self.X * 10 + self.Y - i] = temp1;
                                    Map.Instance.GameObject_element[self.X, self.Y - 1].transform.position = Map.Instance.Grid_gameobject[self.X, self.Y - i - 1].transform.position;
                                }
                            }
                            if (self.ChangeDir == 4)
                            {
                                for (int i = 1; i <= self.ChangeX; i++)
                                {
                                    influ.Add(new Vector2(self.X, self.Y + i));

                                    float temp1 = Map.Instance.MapData[self.X * 10 + (self.Y + i + 1)];
                                    float temp2 = Map.Instance.MapData[self.X * 10 + self.Y + i];

                                    Map.Instance.MapData[self.X * 10 + (self.Y + i + 1)] = temp2;
                                    Map.Instance.MapData[self.X * 10 + self.Y + i] = temp1;
                                    Map.Instance.GameObject_element[self.X, self.Y + 1].transform.position = Map.Instance.Grid_gameobject[self.X, self.Y + i + 1].transform.position;
                                }
                            }
                        }
                                             
                    }

                    //数据和图片变化
                    if (self.TreeSwitch)
                    {
                        for (int i = 0; i < influ.Count; i++)
                        {
                            Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(true);
                        }
                    }

                    else if (!self.TreeSwitch)
                    {
                        for (int i = 0; i < influ.Count; i++)
                        {
                            Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(false);
                            Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].ReSetNode();
                        }
                    }
                }
            }
        }

        //点击开关
        else if (self.isBox==true)
        {
            if (Map.Instance.levelMoveNum > 0)
            {
                //改变数值
                Map.Instance.levelMoveNum--;
                GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                self.BoxSwitch = !self.BoxSwitch;

                if (!self.BoxSwitch)
                {
                    Map.Instance.nodes[self.X, self.Y].SetIsWall(true);
                    //Map.Instance.GameObject_element[self.X, self.Y].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    Map.Instance.GameObject_element[self.X, self.Y].GetComponent<Animator>().SetBool("guan", false);
                }
                    
                else if (self.BoxSwitch)
                {
                    Map.Instance.nodes[self.X, self.Y].SetIsWall(false);
                    Map.Instance.nodes[self.X, self.Y].ReSetNode();
                    //Map.Instance.GameObject_element[self.X, self.Y].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                    Map.Instance.GameObject_element[self.X, self.Y].GetComponent<Animator>().SetBool("guan", true);
                }
            }
        }

        //空位角色移动
        else if (self.isWall == false)
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                if (Map.Instance.levelMoveNum > 0)
                {
                    int max_x = Map.Instance.player_x + 2;
                    int min_x = Map.Instance.player_x - 2;
                    int max_y = Map.Instance.player_y + 2;
                    int min_y = Map.Instance.player_y - 2;
                    if (max_x > 9)
                        max_x = 9;
                    if (min_x < 0)
                        min_x = 0;
                    if (max_y > 9)
                        max_y = 9;
                    if (min_y < 0)
                        min_y = 0;

                    //Debug.Log("player_x: " + Map.Instance.player_x + " player_y: " + Map.Instance.player_y);
                    //Debug.Log("x from "+min_x+" to "+max_x);
                    //Debug.Log("y from " + min_y + " to " + max_y);

                    if (self.X >= min_x && self.X <= max_x && self.Y >= min_y && self.Y <= max_y)
                    {
                            self.SetEndNode();
                            Map.Instance.levelMoveNum--;
                            GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);                    
                    }
                }
            }

        }
    }

    //光标变化
    private void OnMouseEnter()
    {
        if (self.isWall == false)
        {
            if (Mathf.Abs(self.X - Map.Instance.player_x) <= 1 && Mathf.Abs(self.Y - Map.Instance.player_y) <= 1)
            {
                
            }

        }

    }
}
