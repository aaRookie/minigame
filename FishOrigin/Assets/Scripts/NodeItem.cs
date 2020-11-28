﻿using System.Collections;
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

    private void OnMouseDown()
    {
        //空位角色移动
        if(self.isWall==false)
        {
            if(FlowManager.Instance.getTempFlow()==FlowManager.cFlow.choose)
            {
                if(Map.Instance.levelMoveNum>0)
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

                    if (self.X>=min_x&& self.X <= max_x&& self.Y >= min_y&& self.Y <= max_y)
                    {
                        self.SetEndNode();
                        Map.Instance.levelMoveNum--;
                        GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);
                    }
                }                
            }            
        }      

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
        if (self.isTree == true)
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
        if (self.isBox==true)
        {
            if (Map.Instance.levelMoveNum > 0)
            {
                //改变数值
                Map.Instance.levelMoveNum--;
                GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                self.BoxSwitch = !self.BoxSwitch;

                if (self.BoxSwitch)
                    Map.Instance.nodes[self.X, self.Y].SetIsWall(true);
                else if (!self.BoxSwitch)
                {
                    Map.Instance.nodes[self.X, self.Y].SetIsWall(false);
                    Map.Instance.nodes[self.X, self.Y].ReSetNode();
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
