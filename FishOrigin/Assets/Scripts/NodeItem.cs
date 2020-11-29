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
        //Debug.Log(self.temptype+" "+self.X+" "+self.Y);

        if (self.temptype == Node.nodetype.ext)
            return;

        //点击荷花,1*1 to 2*2
        if(self.temptype==Node.nodetype.flower)
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                if (Map.Instance.levelMoveNum > 0)
                {
                    //改变数值
                    Map.Instance.levelMoveNum--;
                    GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                    self.FlowerSwitch = !self.FlowerSwitch;


                    //获取变化范围
                    if (influ.Count==0)
                    {
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

                    ////数据和图片变化
                    //if (self.FlowerSwitch)
                    //{
                    //    for (int i = 0; i < influ.Count; i++)
                    //    {
                    //        Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(true);
                    //    }
                    //}

                    //else if(!self.FlowerSwitch)
                    //{
                    //    for(int i = 0; i < influ.Count; i++)
                    //    {
                    //        Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(false);
                    //        Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].ReSetNode();
                    //    }
                    //}
                }
            }
        }

        //点击藤蔓 1*1 to X*1
        else if (self.temptype == Node.nodetype.tree)
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                if (Map.Instance.levelMoveNum > 0)
                {
                    //改变数值
                    Map.Instance.levelMoveNum--;
                    GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                    self.isTree = !self.isTree;

                    float temp = Map.Instance.MapData[self.X * 10 + self.Y];
                    //Debug.Log(temp);
                    temp *= 1000;
                    temp /= 100;
                    //Debug.Log((int)temp % 10);
                    self.ChangeDir=((int)temp%10);
                    //self.ChangeDir = (int)temp % 10;
                    //Debug.Log(self.ChangeX);

                    //Debug.Log(self.isTree);

                    //生长
                    if (influ.Count == 0)
                    {                       
                        if (self.isTree==false)
                        {
                            //改变1的触发器开关
                            self.isTree = true;
                            //self.TreeSwitch = true;
                            //Debug.Log(self.ChangeDir);
                            if (self.ChangeDir == 1)
                            {
                                for (int i = 1; i <= 1; i++)
                                {
                                    //Debug.Log("fun");
                                    //添加ext坐标
                                    influ.Add(new Vector2(self.X - i, self.Y));                              

                                    //播放生长动画
                                    Map.Instance.GameObject_element[self.X, self.Y].transform.GetChild(0).GetComponent<Animator>().SetTrigger("zhang");

                                    //移动gameoject
                                    if(Map.Instance.GameObject_element[self.X - i, self.Y])
                                    Map.Instance.GameObject_element[self.X - i, self.Y].transform.position = Map.Instance.Grid_gameobject[self.X - i - 1, self.Y].transform.position;
                                    //更新列表gameobject
                                    Map.Instance.GameObject_element[self.X - i - 1, self.Y] = Map.Instance.GameObject_element[self.X - i, self.Y];
                                    Map.Instance.GameObject_element[self.X - i, self.Y] = null;
                                    //更新node
                                    //Debug.Log(Map.Instance.nodes[self.X - i, self.Y].isWall);

                                    //Debug.Log(Map.Instance.nodes[self.X - i - 1, self.Y].temptype);
                                    Map.Instance.ChangeNodesData(self.X - i, self.Y, self.X - i - 1, self.Y);
                                    
                                    //为box时修复
                                    if (Map.Instance.nodes[self.X - i, self.Y].temptype == Node.nodetype.box)
                                    {
                                        //Debug.Log("tuibox");
                                        Map.Instance.nodes[self.X - i - 1, self.Y].isWall = Map.Instance.nodes[self.X - i, self.Y].isWall;
                                    }
                                    else if(Map.Instance.nodes[self.X - i, self.Y].temptype == Node.nodetype.danger)
                                    {
                                        for (int k = 0; k < Map.Instance.deadPos.Count; k++)
                                        {
                                            if(Map.Instance.deadPos[k].x== self.X - i&& Map.Instance.deadPos[k].y == self.Y)
                                            {
                                                Map.Instance.deadPos.RemoveAt(k);
                                                Map.Instance.deadPos.Add(new Vector2(self.X - i - 1, self.Y));
                                            }
                                        }
                                        //Debug.Log("tuitree");
                                        //Map.Instance.CreateNewNode(self.X - i - 1, self.Y, Map.Instance.nodes[self.X - i, self.Y].temptype);
                                        //Map.Instance.CreateNewNode(self.X - i, self.Y, Node.nodetype.zero);
                                    }

                                    //Debug.Log(Map.Instance.nodes[self.X - i - 1, self.Y].temptype);

                                    Map.Instance.ChangeNodesData(self.X - i, self.Y,false);
                                    Map.Instance.nodes[self.X - i, self.Y].temptype = Node.nodetype.zero;

                                    
                                    ////更新mapdata
                                    float temp2 = Map.Instance.MapData[(self.X - i) * 10 + self.Y];
                                    Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y] = temp2;
                                    Map.Instance.MapData[(self.X - i) * 10 + self.Y] = 0;

                                    

                                    //Debug.Log(Map.Instance.nodes[self.X - i - 1, self.Y].temptype);
                                    //Debug.Log(Map.Instance.nodes[self.X - 1, self.Y].temptype);
                                    //Map.Instance.nodes[self.X - i - 1, self.Y]

                                    //Map.Instance.GameObject_element[self.X - i - 1, self.Y] = Map.Instance.GameObject_element[self.X - 1, self.Y];
                                    //Map.Instance.GameObject_element[self.X - 1, self.Y]= null;
                                    //Debug.Log(Map.Instance.MapData[(self.X - 1) * 10 + self.Y]);
                                    //Debug.Log(Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y]);
                                }
                            }
                            if (self.ChangeDir == 2)
                            {
                                //Map.Instance.GameObject_element[self.X, self.Y].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                               
                                for (int i = 1; i <= 1; i++)
                                {
                                    //添加ext坐标
                                    influ.Add(new Vector2(self.X + i, self.Y));

                                    //播放生长动画
                                    Map.Instance.GameObject_element[self.X, self.Y].transform.GetChild(0).GetComponent<Animator>().SetTrigger("zhang");
                                    

                                    //移动gameoject
                                    if (Map.Instance.GameObject_element[self.X + i, self.Y])
                                        Map.Instance.GameObject_element[self.X + i, self.Y].transform.position = Map.Instance.Grid_gameobject[self.X + i + 1, self.Y].transform.position;
                                    //更新列表gameobject
                                    Map.Instance.GameObject_element[self.X + i + 1, self.Y] = Map.Instance.GameObject_element[self.X + i, self.Y];
                                    Map.Instance.GameObject_element[self.X + i, self.Y] = null;
                                    //更新node
                                    Map.Instance.ChangeNodesData(self.X + i, self.Y, self.X + i + 1, self.Y);

                                    //为box时修复
                                    if (Map.Instance.nodes[self.X + i, self.Y].temptype == Node.nodetype.box)
                                    {
                                        Map.Instance.nodes[self.X + i + 1, self.Y].isWall = Map.Instance.nodes[self.X + i, self.Y].isWall;
                                    }
                                    else if (Map.Instance.nodes[self.X + i, self.Y].temptype == Node.nodetype.danger)
                                    {
                                        for (int k = 0; k < Map.Instance.deadPos.Count; k++)
                                        {
                                            if (Map.Instance.deadPos[k].x == self.X + i && Map.Instance.deadPos[k].y == self.Y)
                                            {
                                                Map.Instance.deadPos.RemoveAt(k);
                                                Map.Instance.deadPos.Add(new Vector2(self.X + i + 1, self.Y));
                                            }
                                        }
                                        //Debug.Log("tuitree");
                                        //Map.Instance.CreateNewNode(self.X - i - 1, self.Y, Map.Instance.nodes[self.X - i, self.Y].temptype);
                                        //Map.Instance.CreateNewNode(self.X - i, self.Y, Node.nodetype.zero);
                                    }

                                    Map.Instance.ChangeNodesData(self.X + i, self.Y, false);
                                    Map.Instance.nodes[self.X + i, self.Y].temptype = Node.nodetype.zero;
                                    //更新mapdata
                                    float temp2 = Map.Instance.MapData[(self.X + i) * 10 + self.Y];
                                    Map.Instance.MapData[(self.X + i + 1) * 10 + self.Y] = temp2;
                                    Map.Instance.MapData[(self.X + i) * 10 + self.Y] = 0;

                                    //Debug.Log(Map.Instance.nodes[self.X - i - 1, self.Y].temptype);
                                    //Debug.Log(Map.Instance.nodes[self.X - 1, self.Y].temptype);
                                    //Map.Instance.nodes[self.X - i - 1, self.Y]

                                    //Map.Instance.GameObject_element[self.X - i - 1, self.Y] = Map.Instance.GameObject_element[self.X - 1, self.Y];
                                    //Map.Instance.GameObject_element[self.X - 1, self.Y]= null;
                                    //Debug.Log(Map.Instance.MapData[(self.X - 1) * 10 + self.Y]);
                                    //Debug.Log(Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y]);
                                }
                            }
                            else if (self.ChangeDir == 3)
                            {
                                for (int i = 1; i <= 1; i++)
                                {
                                    //添加ext坐标
                                    influ.Add(new Vector2(self.X, self.Y - i));

                                    //播放生长动画
                                    Map.Instance.GameObject_element[self.X, self.Y].transform.GetChild(0).GetComponent<Animator>().SetTrigger("zhang");


                                    //移动gameoject
                                    if (Map.Instance.GameObject_element[self.X, self.Y-i])
                                        Map.Instance.GameObject_element[self.X , self.Y - i].transform.position = Map.Instance.Grid_gameobject[self.X, self.Y - i - 1].transform.position;
                                    //更新列表gameobject
                                    Map.Instance.GameObject_element[self.X , self.Y-i-i] = Map.Instance.GameObject_element[self.X, self.Y-i];
                                    Map.Instance.GameObject_element[self.X , self.Y-i] = null;
                                    //更新node
                                    Map.Instance.ChangeNodesData(self.X, self.Y-i, self.X, self.Y-i-i);

                                    //为box时修复
                                    if (Map.Instance.nodes[self.X, self.Y-i].temptype == Node.nodetype.box)
                                    {
                                        Map.Instance.nodes[self.X, self.Y - i - 1].isWall = Map.Instance.nodes[self.X , self.Y - i].isWall;
                                    }
                                    else if (Map.Instance.nodes[self.X , self.Y - i].temptype == Node.nodetype.danger)
                                    {
                                        for (int k = 0; k < Map.Instance.deadPos.Count; k++)
                                        {
                                            if (Map.Instance.deadPos[k].x == self.X  && Map.Instance.deadPos[k].y == self.Y - i)
                                            {
                                                Map.Instance.deadPos.RemoveAt(k);
                                                Map.Instance.deadPos.Add(new Vector2(self.X , self.Y - i - 1));
                                            }
                                        }
                                        //Debug.Log("tuitree");
                                        //Map.Instance.CreateNewNode(self.X - i - 1, self.Y, Map.Instance.nodes[self.X - i, self.Y].temptype);
                                        //Map.Instance.CreateNewNode(self.X - i, self.Y, Node.nodetype.zero);
                                    }

                                    Map.Instance.ChangeNodesData(self.X, self.Y - i, false);
                                    Map.Instance.nodes[self.X , self.Y-i].temptype = Node.nodetype.zero;
                                    //更新mapdata
                                    float temp2 = Map.Instance.MapData[(self.X ) * 10 + self.Y-i];
                                    Map.Instance.MapData[(self.X ) * 10 + self.Y-i-1] = temp2;
                                    Map.Instance.MapData[(self.X ) * 10 + self.Y-i] = 0;

                                    //Debug.Log(Map.Instance.nodes[self.X - i - 1, self.Y].temptype);
                                    //Debug.Log(Map.Instance.nodes[self.X - 1, self.Y].temptype);
                                    //Map.Instance.nodes[self.X - i - 1, self.Y]

                                    //Map.Instance.GameObject_element[self.X - i - 1, self.Y] = Map.Instance.GameObject_element[self.X - 1, self.Y];
                                    //Map.Instance.GameObject_element[self.X - 1, self.Y]= null;
                                    //Debug.Log(Map.Instance.MapData[(self.X - 1) * 10 + self.Y]);
                                    //Debug.Log(Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y]);
                                }
                            }
                            else if (self.ChangeDir == 4)
                            {
                                for (int i = 1; i <= 1; i++)
                                {
                                    //添加ext坐标
                                    influ.Add(new Vector2(self.X, self.Y + i));

                                    //播放生长动画
                                    Map.Instance.GameObject_element[self.X, self.Y].transform.GetChild(0).GetComponent<Animator>().SetTrigger("zhang");


                                    //移动gameoject
                                    if (Map.Instance.GameObject_element[self.X, self.Y + i])
                                        Map.Instance.GameObject_element[self.X, self.Y + i].transform.position = Map.Instance.Grid_gameobject[self.X, self.Y + i + 1].transform.position;
                                    //更新列表gameobject
                                    Map.Instance.GameObject_element[self.X, self.Y + i + i] = Map.Instance.GameObject_element[self.X, self.Y + i];
                                    Map.Instance.GameObject_element[self.X, self.Y + i] = null;
                                    //更新node
                                    Map.Instance.ChangeNodesData(self.X, self.Y + i, self.X, self.Y + i + i);

                                    //为box时修复
                                    if (Map.Instance.nodes[self.X, self.Y + i].temptype == Node.nodetype.box)
                                    {
                                        Map.Instance.nodes[self.X, self.Y + i + 1].isWall = Map.Instance.nodes[self.X, self.Y + i].isWall;
                                    }
                                    else if (Map.Instance.nodes[self.X, self.Y + i].temptype == Node.nodetype.danger)
                                    {
                                        for (int k = 0; k < Map.Instance.deadPos.Count; k++)
                                        {
                                            if (Map.Instance.deadPos[k].x == self.X && Map.Instance.deadPos[k].y == self.Y + i)
                                            {
                                                Map.Instance.deadPos.RemoveAt(k);
                                                Map.Instance.deadPos.Add(new Vector2(self.X, self.Y + i + 1));
                                            }
                                        }
                                    }

                                        Map.Instance.ChangeNodesData(self.X, self.Y + i, false);
                                    Map.Instance.nodes[self.X, self.Y + i].temptype = Node.nodetype.zero;
                                    //更新mapdata
                                    float temp2 = Map.Instance.MapData[(self.X) * 10 + self.Y + i];
                                    Map.Instance.MapData[(self.X) * 10 + self.Y + i + 1] = temp2;
                                    Map.Instance.MapData[(self.X) * 10 + self.Y + i] = 0;

                                    //Debug.Log(Map.Instance.nodes[self.X - i - 1, self.Y].temptype);
                                    //Debug.Log(Map.Instance.nodes[self.X - 1, self.Y].temptype);
                                    //Map.Instance.nodes[self.X - i - 1, self.Y]

                                    //Map.Instance.GameObject_element[self.X - i - 1, self.Y] = Map.Instance.GameObject_element[self.X - 1, self.Y];
                                    //Map.Instance.GameObject_element[self.X - 1, self.Y]= null;
                                    //Debug.Log(Map.Instance.MapData[(self.X - 1) * 10 + self.Y]);
                                    //Debug.Log(Map.Instance.MapData[(self.X - i - 1) * 10 + self.Y]);
                                }
                            }

                            
                        }
                        //Debug.Log(Map.Instance.GameObject_element[self.X, self.Y]);
                        Map.Instance.GameObject_element[self.X, self.Y].transform.GetChild(0).GetComponent<Animator>().SetTrigger("zhang");
                        self.isTree = false;
                        influ.Clear();
                        return;                      
                    }

                    ////数据和图片变化
                    //if (self.TreeSwitch)
                    //{
                    //    for (int i = 0; i < influ.Count; i++)
                    //    {
                    //        Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(true);
                    //    }
                    //}

                    //else if (!self.TreeSwitch)
                    //{
                    //    for (int i = 0; i < influ.Count; i++)
                    //    {
                    //        Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].SetIsWall(false);
                    //        Map.Instance.nodes[(int)influ[i].x, (int)influ[i].y].ReSetNode();
                    //    }
                    //}
                }
            }
        }

        //点击开关
        else if (self.temptype == Node.nodetype.box)
        {
            if (Map.Instance.levelMoveNum > 0)
            {
                //改变数值
                Map.Instance.levelMoveNum--;
                GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);

                self.BoxSwitch = !self.BoxSwitch;
                //Debug.Log(self.BoxSwitch);

                if (!self.BoxSwitch)
                {
                    Map.Instance.nodes[self.X, self.Y].ChangeToWall(true);
                    //Map.Instance.GameObject_element[self.X, self.Y].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    Map.Instance.GameObject_element[self.X, self.Y].GetComponent<Animator>().SetBool("guan", false);
                }
                    
                else if (self.BoxSwitch)
                {
                    Map.Instance.nodes[self.X, self.Y].ChangeToWall(false);
                    Map.Instance.nodes[self.X, self.Y].ReSetNode();
                    //Map.Instance.GameObject_element[self.X, self.Y].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                    Map.Instance.GameObject_element[self.X, self.Y].GetComponent<Animator>().SetBool("guan", true);
                }
            }
        }

        //空位角色移动
        else if (self.temptype == Node.nodetype.zero|| self.temptype == Node.nodetype.danger)
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
        if(self.temptype==Node.nodetype.zero)
        {
            if(Mathf.Abs(self.X-Map.Instance.player_x)<=2&& Mathf.Abs(self.Y - Map.Instance.player_y) <= 2)
            {
                GameUIManager.Instance.ChangeMousetToInFish();
            }
            else
            GameUIManager.Instance.ChangeMousetToOutFish();
        }

        if (self.temptype == Node.nodetype.box|| self.temptype == Node.nodetype.flower|| self.temptype == Node.nodetype.tree)
        {
            GameUIManager.Instance.ChangeMousetToOpera();
        }
    }

    private void OnMouseExit()
    {
        GameUIManager.Instance.ChangeMouseToDefault();
    }
}
